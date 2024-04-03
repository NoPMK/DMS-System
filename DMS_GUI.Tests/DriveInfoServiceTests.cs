using DMS_BLL.Services.DrivePanelServices;
using DMS_Domain.Interfaces.HelperInterfaces;
using DMS_Domain.Interfaces.ProviderInterfaces;
using DMS_Domain.Interfaces.WrapperInterfaces.FileSystem;
using Moq;

namespace DMS_GUI.Tests
{
    [TestFixture]
    public class DriveInfoServiceTests
    {
        private DriveInfoService _driveInfoService;
        private Mock<IFormatter> _formatter;
        private Mock<IFileSystemWrapperProvider> _fileSystemFactory;

        [SetUp]
        public void Setup()
        {
            _formatter = new Mock<IFormatter>();
            _fileSystemFactory = new Mock<IFileSystemWrapperProvider>();
            _driveInfoService = new DriveInfoService(_formatter.Object, _fileSystemFactory.Object);
        }

        [Test]
        public void GetDriveDetails_WhenDriveIsReady_ReturnsFormattedDetails()
        {
            // Arrange
            var driveName = "C:\\";
            var mockDriveInfo = new Mock<IDriveInfoWrapper>();
            mockDriveInfo.SetupGet(x => x.IsReady).Returns(true);
            mockDriveInfo.SetupGet(x => x.TotalFreeSpace).Returns(50000000000); // 50 GB
            mockDriveInfo.SetupGet(x => x.TotalSize).Returns(100000000000); // 100 GB

            _fileSystemFactory.Setup(x => x.CreateDriveInfo(driveName)).Returns(mockDriveInfo.Object);
            _formatter.Setup(x => x.FormatBytes(50000000000)).Returns("50 GB");
            _formatter.Setup(x => x.FormatBytes(100000000000)).Returns("100 GB");

            // Act
            var result = _driveInfoService.GetDriveDetails(driveName);

            // Assert
            var expectedOutput = "50 GB free of 100 GB\r\n";
            Assert.That(result, Is.EqualTo(expectedOutput));
        }

        [Test]
        public void GetDriveDetails_WhenDriveIsNotReady_ReturnsDriveNotReadyMessage()
        {
            // Arrange
            var driveName = "D:\\";
            var mockDriveInfo = new Mock<IDriveInfoWrapper>();
            mockDriveInfo.SetupGet(x => x.IsReady).Returns(false);

            _fileSystemFactory.Setup(x => x.CreateDriveInfo(driveName)).Returns(mockDriveInfo.Object);

            // Act
            var result = _driveInfoService.GetDriveDetails(driveName);

            // Assert
            var expectedOutput = "Drive not ready.\r\n";
            Assert.That(result, Is.EqualTo(expectedOutput));
        }

        [Test]
        public void GetDriveDetails_WhenDriveHasZeroFreeSpace_ReturnsCorrectDetails()
        {
            var formatterMock = new Mock<IFormatter>();
            var fileSystemFactoryMock = new Mock<IFileSystemWrapperProvider>();
            var driveInfoMock = new Mock<IDriveInfoWrapper>();

            var driveName = "D:\\";
            formatterMock.Setup(f => f.FormatBytes(It.Is<long>(bytes => bytes == 0))).Returns("0 Bytes");
            formatterMock.Setup(f => f.FormatBytes(It.Is<long>(bytes => bytes > 0))).Returns("1 TB");
            driveInfoMock.SetupGet(x => x.IsReady).Returns(true);
            driveInfoMock.SetupGet(x => x.TotalFreeSpace).Returns(0);
            driveInfoMock.SetupGet(x => x.TotalSize).Returns(1000000000000); // 1 TB

            fileSystemFactoryMock.Setup(f => f.CreateDriveInfo(driveName)).Returns(driveInfoMock.Object);

            var service = new DriveInfoService(formatterMock.Object, fileSystemFactoryMock.Object);

            var result = service.GetDriveDetails(driveName);

            Assert.That(result, Is.EqualTo("0 Bytes free of 1 TB\r\n"));

        }
        [Test]
        public void GetDriveDetails_WhenDriveHasLargeFreeSpace_FormatsNumbersCorrectly()
        {
            var formatterMock = new Mock<IFormatter>();
            var fileSystemFactoryMock = new Mock<IFileSystemWrapperProvider>();
            var driveInfoMock = new Mock<IDriveInfoWrapper>();

            var driveName = "E:\\";
            formatterMock.Setup(f => f.FormatBytes(It.IsAny<long>())).Returns((long bytes) => $"{bytes / 1_000_000_000_000.0:0.00} TB");
            driveInfoMock.SetupGet(x => x.IsReady).Returns(true);
            driveInfoMock.SetupGet(x => x.TotalFreeSpace).Returns(2000000000000); // 2 TB
            driveInfoMock.SetupGet(x => x.TotalSize).Returns(4000000000000); // 4 TB

            fileSystemFactoryMock.Setup(f => f.CreateDriveInfo(driveName)).Returns(driveInfoMock.Object);

            var service = new DriveInfoService(formatterMock.Object, fileSystemFactoryMock.Object);

            var result = service.GetDriveDetails(driveName);

            Assert.That(result, Is.EqualTo("2.00 TB free of 4.00 TB\r\n"));
        }
    }
}