using DMS_BLL.Services.FileSystemServices;
using DMS_Domain.Interfaces.HelperInterfaces;
using DMS_Domain.Interfaces.ProviderInterfaces;
using DMS_Domain.Interfaces.WrapperInterfaces.FileSystem;
using Moq;

namespace DMS_GUI.Tests
{
    [TestFixture]
    public class TreeNodeServiceTests
    {

        // TODO: Add Setup method
        [Test]
        public void GetSubDirectories_WithAccessAndHiddenConditions_ReturnsCorrectSubDirectories()
        {
            // Arrange
            var fileSystemValidatorMock = new Mock<IFileSystemValidator>();
            var fileSystemWrapperProviderMock = new Mock<IFileSystemWrapperProvider>();
            var dirInfoMock = new Mock<IDirectoryInfoWrapper>();
            var subDir1Mock = new Mock<IDirectoryInfoWrapper>();
            var subDir2Mock = new Mock<IDirectoryInfoWrapper>();

            var path = "C:\\Test";
            var showHiddenItems = true;
            var subDirs = new List<IDirectoryInfoWrapper> { subDir1Mock.Object, subDir2Mock.Object };

            fileSystemWrapperProviderMock.Setup(p => p.CreateDirectoryInfo(path)).Returns(dirInfoMock.Object);
            dirInfoMock.Setup(d => d.GetDirectories()).Returns(subDirs);
            subDir1Mock.Setup(d => d.Attributes).Returns(FileAttributes.Directory);
            subDir2Mock.Setup(d => d.Attributes).Returns(FileAttributes.Directory | FileAttributes.Hidden);
            fileSystemValidatorMock.Setup(v => v.CanAccessDirectory(It.IsAny<string>())).Returns(true);

            var fileSystemService = new FileSystemService(fileSystemValidatorMock.Object, fileSystemWrapperProviderMock.Object);

            // Act
            var (accessibleDirs, restrictedDirs) = fileSystemService.GetSubDirectories(path, showHiddenItems);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(accessibleDirs.Count(), Is.EqualTo(2));
                Assert.That(restrictedDirs.Count(), Is.EqualTo(0));
            });
        }

        [Test]
        public void GetSubDirectories_OnlyHiddenDirectoriesAndShowHiddenFalse_ReturnsNoSubDirectories()
        {
            // Arrange
            var fileSystemValidatorMock = new Mock<IFileSystemValidator>();
            var fileSystemWrapperProviderMock = new Mock<IFileSystemWrapperProvider>();
            var dirInfoMock = new Mock<IDirectoryInfoWrapper>();
            var hiddenDirMock = new Mock<IDirectoryInfoWrapper>();

            var path = "C:\\Test";
            var showHiddenItems = false;
            var subDirs = new List<IDirectoryInfoWrapper> { hiddenDirMock.Object };

            fileSystemWrapperProviderMock.Setup(p => p.CreateDirectoryInfo(path)).Returns(dirInfoMock.Object);
            dirInfoMock.Setup(d => d.GetDirectories()).Returns(subDirs);
            hiddenDirMock.Setup(d => d.Attributes).Returns(FileAttributes.Directory | FileAttributes.Hidden);
            fileSystemValidatorMock.Setup(v => v.CanAccessDirectory(It.IsAny<string>())).Returns(true);

            var fileSystemService = new FileSystemService(fileSystemValidatorMock.Object, fileSystemWrapperProviderMock.Object);

            // Act
            var (accessibleDirs, restrictedDirs) = fileSystemService.GetSubDirectories(path, showHiddenItems);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(accessibleDirs.Count(), Is.EqualTo(0), "Expected no accessible directories when hidden directories are not shown.");
                Assert.That(restrictedDirs.Count(), Is.EqualTo(0), "Expected no restricted directories.");
            });
        }

        [Test]
        public void GetSubDirectories_WithRestrictedDirectories_ReturnsCorrectRestrictedDirectories()
        {
            // Arrange
            var fileSystemValidatorMock = new Mock<IFileSystemValidator>();
            var fileSystemWrapperProviderMock = new Mock<IFileSystemWrapperProvider>();
            var dirInfoMock = new Mock<IDirectoryInfoWrapper>();
            var restrictedDirMock = new Mock<IDirectoryInfoWrapper>();

            var path = "C:\\Test";
            var showHiddenItems = true;
            var subDirs = new List<IDirectoryInfoWrapper> { restrictedDirMock.Object };

            fileSystemWrapperProviderMock.Setup(p => p.CreateDirectoryInfo(path)).Returns(dirInfoMock.Object);
            dirInfoMock.Setup(d => d.GetDirectories()).Returns(subDirs);
            restrictedDirMock.Setup(d => d.Attributes).Returns(FileAttributes.Directory);
            fileSystemValidatorMock.Setup(v => v.CanAccessDirectory(It.IsAny<string>())).Returns(false); // Simulate access denied

            var fileSystemService = new FileSystemService(fileSystemValidatorMock.Object, fileSystemWrapperProviderMock.Object);

            // Act
            var (accessibleDirs, restrictedDirs) = fileSystemService.GetSubDirectories(path, showHiddenItems);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(accessibleDirs.Count(), Is.EqualTo(0), "Expected no accessible directories due to access restrictions.");
                Assert.That(restrictedDirs.Count(), Is.EqualTo(1), "Expected one restricted directory.");
            });
        }

        [Test]
        public void GetSubDirectories_WhenNoSubDirectories_ReturnsEmptyAccessibleAndRestrictedLists()
        {
            // Arrange
            var fileSystemWrapperProviderMock = new Mock<IFileSystemWrapperProvider>();
            var dirInfoMock = new Mock<IDirectoryInfoWrapper>();
            var path = "C:\\EmptyTest";

            fileSystemWrapperProviderMock.Setup(p => p.CreateDirectoryInfo(path)).Returns(dirInfoMock.Object);
            dirInfoMock.Setup(d => d.GetDirectories()).Returns(new List<IDirectoryInfoWrapper>());

            var fileSystemService = new FileSystemService(null, fileSystemWrapperProviderMock.Object);

            // Act
            var (accessibleDirs, restrictedDirs) = fileSystemService.GetSubDirectories(path, true);

            // Assert
            Assert.Multiple(() =>
            {

                Assert.That(accessibleDirs, Is.Empty);
                Assert.That(restrictedDirs, Is.Empty);
            });
        }

        [Test]
        public void GetSubDirectories_WhenAllSubDirectoriesAreRestricted_ReturnsEmptyAccessibleAndAllRestricted()
        {
            // Arrange
            var fileSystemValidatorMock = new Mock<IFileSystemValidator>();
            var fileSystemWrapperProviderMock = new Mock<IFileSystemWrapperProvider>();
            var dirInfoMock = new Mock<IDirectoryInfoWrapper>();
            var subDirMock = new Mock<IDirectoryInfoWrapper>();
            var path = "C:\\Test";
            var subDirs = new List<IDirectoryInfoWrapper> { subDirMock.Object };

            fileSystemWrapperProviderMock.Setup(p => p.CreateDirectoryInfo(path)).Returns(dirInfoMock.Object);
            dirInfoMock.Setup(d => d.GetDirectories()).Returns(subDirs);
            subDirMock.Setup(d => d.Name).Returns("RestrictedDir");
            fileSystemValidatorMock.Setup(v => v.CanAccessDirectory(It.IsAny<string>())).Returns(false);

            var fileSystemService = new FileSystemService(fileSystemValidatorMock.Object, fileSystemWrapperProviderMock.Object);

            // Act
            var (accessibleDirs, restrictedDirs) = fileSystemService.GetSubDirectories(path, true);

            // Assert
            Assert.Multiple(() =>
            {

                Assert.That(accessibleDirs, Is.Empty);
                Assert.That(restrictedDirs, Has.Member("RestrictedDir"));
            });
        }
    }
}