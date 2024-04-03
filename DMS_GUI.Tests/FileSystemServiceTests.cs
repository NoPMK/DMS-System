using DMS_BLL.Services.FileSystemServices;
using DMS_Domain.Interfaces.HelperInterfaces;
using DMS_Domain.Interfaces.ProviderInterfaces;
using DMS_Domain.Interfaces.WrapperInterfaces.FileSystem;
using Moq;

namespace DMS_GUI.Tests
{
    [TestFixture]
    public class FileSystemServiceTests
    {
        private FileSystemService _fileSystemService;
        private Mock<IFileSystemValidator> _fileSystemValidator;
        private Mock<IFileSystemWrapperProvider> _fileSystemWrapperProvider;

        [SetUp]
        public void Setup()
        {
            _fileSystemValidator = new Mock<IFileSystemValidator>();
            _fileSystemWrapperProvider = new Mock<IFileSystemWrapperProvider>();
            _fileSystemService = new FileSystemService(_fileSystemValidator.Object, _fileSystemWrapperProvider.Object);
        }

        [Test]
        public void GetFiles_WhenCalled_ReturnsFiles()
        {
            // Arrange
            var folderPath = "C:\\";
            var includeHidden = false;

            var mockDirInfoWrapper = new Mock<IDirectoryInfoWrapper>();
            var fakeFiles = new List<IFileInfoWrapper>();

            _fileSystemWrapperProvider.Setup(x => x.CreateDirectoryInfo(folderPath)).Returns(mockDirInfoWrapper.Object);
            mockDirInfoWrapper.Setup(x => x.GetFiles()).Returns(fakeFiles);

            // Act
            var result = _fileSystemService.GetFiles(folderPath, includeHidden);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Count(), Is.EqualTo(fakeFiles.Count));
            });
        }

        [Test]
        public void GetFiles_WhenDirectoryNotFound_ThrowsDirectoryNotFoundException()
        {
            // Arrange
            var folderPath = "Z:\\NonExistentDirectory";
            _fileSystemWrapperProvider.Setup(p => p.CreateDirectoryInfo(It.IsAny<string>()))
                .Throws(new DirectoryNotFoundException());

            // Act & Assert
            Assert.Throws<DirectoryNotFoundException>(() => _fileSystemService.GetFiles(folderPath, false));
        }

        [Test]
        public void GetDirectories_WhenCalledWithIncludeHidden_IncludesHiddenDirectories()
        {
            // Arrange
            var folderPath = "C:\\Test";
            var mockDirInfoWrapper = new Mock<IDirectoryInfoWrapper>();
            var hiddenDirectoryMock = new Mock<IDirectoryInfoWrapper>();
            hiddenDirectoryMock.Setup(d => d.Attributes).Returns(FileAttributes.Directory | FileAttributes.Hidden);
            var visibleDirectoryMock = new Mock<IDirectoryInfoWrapper>();
            visibleDirectoryMock.Setup(d => d.Attributes).Returns(FileAttributes.Directory);

            var directories = new List<IDirectoryInfoWrapper> { hiddenDirectoryMock.Object, visibleDirectoryMock.Object };

            _fileSystemWrapperProvider.Setup(p => p.CreateDirectoryInfo(It.IsAny<string>())).Returns(mockDirInfoWrapper.Object);
            mockDirInfoWrapper.Setup(d => d.GetDirectories()).Returns(directories);

            // Act
            var result = _fileSystemService.GetDirectories(folderPath, true);

            // Assert
            Assert.That(result.Count(), Is.EqualTo(2));
        }

        [Test]
        public void GetSubDirectories_IdentifiesRestrictedDirectoriesCorrectly()
        {
            // Arrange
            var path = "C:\\Test";
            var showHiddenItems = false;
            var mockDirInfoWrapper = new Mock<IDirectoryInfoWrapper>();
            var accessibleDirMock = new Mock<IDirectoryInfoWrapper>();
            accessibleDirMock.Setup(d => d.Name).Returns("Accessible");
            accessibleDirMock.Setup(d => d.FullName).Returns("C:\\Test\\Accessible");
            var restrictedDirMock = new Mock<IDirectoryInfoWrapper>();
            restrictedDirMock.Setup(d => d.Name).Returns("Restricted");
            restrictedDirMock.Setup(d => d.FullName).Returns("C:\\Test\\Restricted");

            var directories = new List<IDirectoryInfoWrapper> { accessibleDirMock.Object, restrictedDirMock.Object };

            _fileSystemWrapperProvider.Setup(p => p.CreateDirectoryInfo(It.IsAny<string>())).Returns(mockDirInfoWrapper.Object);
            mockDirInfoWrapper.Setup(d => d.GetDirectories()).Returns(directories);
            _fileSystemValidator.Setup(v => v.CanAccessDirectory("C:\\Test\\Accessible")).Returns(true);
            _fileSystemValidator.Setup(v => v.CanAccessDirectory("C:\\Test\\Restricted")).Returns(false);

            // Act
            var (subDirectories, restrictedDirectories) = _fileSystemService.GetSubDirectories(path, showHiddenItems);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(subDirectories.Count(), Is.EqualTo(1));
                Assert.That(restrictedDirectories.Count(), Is.EqualTo(1));
                Assert.That(restrictedDirectories.ToList(), Does.Contain("Restricted"));
            });
        }

        [Test]
        public void GetSubDirectories_WhenAccessDenied_ContinuesWithNextDirectory()
        {
            // TODO: Add verify that the method is called twice
            // Arrange
            var path = "C:\\Test";
            var showHiddenItems = false;
            var mockDirInfoWrapper = new Mock<IDirectoryInfoWrapper>();
            var accessibleDirMock = new Mock<IDirectoryInfoWrapper>();
            accessibleDirMock.Setup(d => d.Name).Returns("Accessible");
            accessibleDirMock.Setup(d => d.FullName).Returns("C:\\Test\\Accessible");
            var inaccessibleDirMock = new Mock<IDirectoryInfoWrapper>();
            inaccessibleDirMock.Setup(d => d.Name).Returns("Inaccessible");
            inaccessibleDirMock.Setup(d => d.FullName).Returns("C:\\Test\\Inaccessible");

            var directories = new List<IDirectoryInfoWrapper> { accessibleDirMock.Object, inaccessibleDirMock.Object };

            _fileSystemWrapperProvider.Setup(p => p.CreateDirectoryInfo(It.IsAny<string>())).Returns(mockDirInfoWrapper.Object);
            mockDirInfoWrapper.Setup(d => d.GetDirectories()).Returns(directories);
            _fileSystemValidator.Setup(v => v.CanAccessDirectory(It.IsAny<string>()))
                .Returns<string>(path => !path.EndsWith("Inaccessible"));

            // Act
            var (subDirectories, restrictedDirectories) = _fileSystemService.GetSubDirectories(path, showHiddenItems);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(subDirectories.Count(), Is.EqualTo(1));
                Assert.That(restrictedDirectories.Count(), Is.EqualTo(1));
            });
        }
    }
}