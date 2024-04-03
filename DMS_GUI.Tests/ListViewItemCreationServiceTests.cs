using DMS_BLL.Services.ListViewServices;
using DMS_Domain.Interfaces.WrapperInterfaces.FileSystem;
using Moq;

namespace DMS_GUI.Tests
{
    [TestFixture]
    public class ListViewItemCreationServiceTests
    {
        private ListViewItemCreationService listItemCreationService;

        [SetUp]
        public void Setup()
        {
            listItemCreationService = new ListViewItemCreationService();
        }

        [Test]
        public void CreateDirectoryItem_WhenCalled_ReturnsCorrectListItemDTO()
        {
            // Arrange
            var mockDirInfo = new Mock<IDirectoryInfoWrapper>();
            mockDirInfo.SetupGet(x => x.Name).Returns("TestDirectory");
            mockDirInfo.SetupGet(x => x.FullName).Returns(@"C:\Path\To\TestDirectory");
            mockDirInfo.SetupGet(x => x.LastWriteTime).Returns(new DateTime(2022, 1, 1));

            // Act
            var result = listItemCreationService.CreateDirectoryItem(mockDirInfo.Object);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result.PrimaryText, Is.EqualTo("TestDirectory"));
                Assert.That(result.SubItems, Does.Contain(""));
                Assert.That(result.SubItems, Does.Contain("<DIR>"));
                Assert.That(result.SubItems[2], Is.EqualTo(new DateTime(2022, 1, 1).ToString()));
                Assert.That(result.Tag, Is.EqualTo(@"C:\Path\To\TestDirectory"));
                Assert.That(result.LastWriteTime, Is.EqualTo(new DateTime(2022, 1, 1).ToString()));
            });
        }

        [Test]
        public void CreateFileItem_WhenCalled_ReturnsCorrectListItemDTO()
        {
            // Arrange
            var mockFileInfo = new Mock<IFileInfoWrapper>();
            mockFileInfo.SetupGet(x => x.Name).Returns("TestFile.txt");
            mockFileInfo.SetupGet(x => x.Extension).Returns(".txt");
            mockFileInfo.SetupGet(x => x.Length).Returns(1024);
            mockFileInfo.SetupGet(x => x.FullName).Returns(@"C:\Path\To\TestFile.txt");
            mockFileInfo.SetupGet(x => x.LastWriteTime).Returns(new DateTime(2022, 2, 2));

            // Act
            var result = listItemCreationService.CreateFileItem(mockFileInfo.Object);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result.PrimaryText, Is.EqualTo("TestFile.txt"));
                Assert.That(result.SubItems[0], Is.EqualTo(".txt"));
                Assert.That(result.SubItems[1], Is.EqualTo("1024"));
                Assert.That(result.SubItems[2], Is.EqualTo(new DateTime(2022, 2, 2).ToString()));
                Assert.That(result.Tag, Is.EqualTo(@"C:\Path\To\TestFile.txt"));
                Assert.That(result.LastWriteTime, Is.EqualTo(new DateTime(2022, 2, 2).ToString()));
            });
        }

        [Test]
        public void CreateFileItem_WhenLargeFile_ReturnsCorrectListItemDTOWithReadableFileSize()
        {
            // Arrange
            var mockFileInfo = new Mock<IFileInfoWrapper>();
            mockFileInfo.SetupGet(x => x.Name).Returns("LargeTestFile.txt");
            mockFileInfo.SetupGet(x => x.Extension).Returns(".txt");
            mockFileInfo.SetupGet(x => x.Length).Returns(1_024_000_000);
            mockFileInfo.SetupGet(x => x.FullName).Returns(@"C:\Path\To\LargeTestFile.txt");
            mockFileInfo.SetupGet(x => x.LastWriteTime).Returns(new DateTime(2024, 2, 7));

            // Act
            var result = listItemCreationService.CreateFileItem(mockFileInfo.Object);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result.PrimaryText, Is.EqualTo("LargeTestFile.txt"));
                Assert.That(result.SubItems[0], Is.EqualTo(".txt"));
                Assert.That(result.SubItems[1], Is.EqualTo("1024000000"));
                Assert.That(result.SubItems[2], Is.EqualTo(new DateTime(2024, 2, 7).ToString()));
                Assert.That(result.Tag, Is.EqualTo(@"C:\Path\To\LargeTestFile.txt"));
                Assert.That(result.LastWriteTime, Is.EqualTo(new DateTime(2024, 2, 7).ToString()));
            });
        }

        [Test]
        public void CreateFileItem_WhenZeroLengthFile_ReturnsCorrectListItemDTO()
        {
            // Arrange
            var mockFileInfo = new Mock<IFileInfoWrapper>();
            mockFileInfo.SetupGet(x => x.Name).Returns("EmptyTestFile.txt");
            mockFileInfo.SetupGet(x => x.Extension).Returns(".txt");
            mockFileInfo.SetupGet(x => x.Length).Returns(0); // Empty file
            mockFileInfo.SetupGet(x => x.FullName).Returns(@"C:\Path\To\EmptyTestFile.txt");
            mockFileInfo.SetupGet(x => x.LastWriteTime).Returns(new DateTime(2022, 5, 5));

            // Act
            var result = listItemCreationService.CreateFileItem(mockFileInfo.Object);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result.PrimaryText, Is.EqualTo("EmptyTestFile.txt"));
                Assert.That(result.SubItems[0], Is.EqualTo(".txt"));
                Assert.That(result.SubItems[1], Is.EqualTo("0"));
                Assert.That(result.SubItems[2], Is.EqualTo(new DateTime(2022, 5, 5).ToString()));
                Assert.That(result.Tag, Is.EqualTo(@"C:\Path\To\EmptyTestFile.txt"));
                Assert.That(result.LastWriteTime, Is.EqualTo(new DateTime(2022, 5, 5).ToString()));
            });
        }
    }
}