using DMS_BLL.Strategies.PopulationStrategies;
using DMS_Domain.DTOs;
using Moq;
using System.IO.Abstractions;

namespace DMS_GUI.Tests
{
    [TestFixture]
    public class TreeNodePopulationStrategyTests
    {
        private TreeNodePopulationStrategy _strategy;
        private Mock<IDirectoryInfo> _rootDirectoryMock;
        private Mock<IFileSystem> _fileSystemMock;

        [SetUp]
        public void Setup()
        {
            _strategy = new TreeNodePopulationStrategy();
            _fileSystemMock = new Mock<IFileSystem>();
            _rootDirectoryMock = new Mock<IDirectoryInfo>();
        }

        [Test]
        public void Populate_AddsNonHiddenDirectoriesToNodes()
        {
            // Arrange
            var subDirectory1Mock = new Mock<IDirectoryInfo>();
            subDirectory1Mock.Setup(d => d.Name).Returns("SubDirectory1");
            subDirectory1Mock.Setup(d => d.FullName).Returns(@"C:\Root\SubDirectory1");
            subDirectory1Mock.Setup(d => d.Attributes).Returns(FileAttributes.Directory);
            subDirectory1Mock.Setup(d => d.GetDirectories()).Returns(Array.Empty<IDirectoryInfo>());

            var subDirectory2Mock = new Mock<IDirectoryInfo>();
            subDirectory2Mock.Setup(d => d.Name).Returns("HiddenSubDirectory");
            subDirectory2Mock.Setup(d => d.FullName).Returns(@"C:\Root\HiddenSubDirectory");
            subDirectory2Mock.Setup(d => d.Attributes).Returns(FileAttributes.Directory | FileAttributes.Hidden);
            subDirectory2Mock.Setup(d => d.GetDirectories()).Returns(Array.Empty<IDirectoryInfo>());

            _rootDirectoryMock.Setup(d => d.GetDirectories()).Returns(new[] { subDirectory1Mock.Object, subDirectory2Mock.Object });

            var nodes = new List<TreeNodeDTO>();

            // Act
            _strategy.Populate(nodes, _rootDirectoryMock.Object);

            // Assert
            Assert.That(nodes, Has.Count.EqualTo(1));
            Assert.That(nodes[0].Text, Is.EqualTo("SubDirectory1"));
        }

        [Test]
        public void Populate_AddsDummyNodeForDirectoriesWithChildren()
        {
            // Arrange
            var subDirectoryWithChildrenMock = new Mock<IDirectoryInfo>();
            subDirectoryWithChildrenMock.Setup(d => d.Name).Returns("SubDirectoryWithChildren");
            subDirectoryWithChildrenMock.Setup(d => d.FullName).Returns(@"C:\Root\SubDirectoryWithChildren");
            subDirectoryWithChildrenMock.Setup(d => d.Attributes).Returns(FileAttributes.Directory);
            subDirectoryWithChildrenMock.Setup(d => d.GetDirectories()).Returns(new IDirectoryInfo[] { new Mock<IDirectoryInfo>().Object }); // Simulate subdirectories

            _rootDirectoryMock.Setup(d => d.GetDirectories()).Returns(new[] { subDirectoryWithChildrenMock.Object });

            var nodes = new List<TreeNodeDTO>();

            // Act
            _strategy.Populate(nodes, _rootDirectoryMock.Object);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(nodes.Count, Is.EqualTo(1));
                Assert.That(nodes[0].Children.Any(n => n.Text == "dummy"), Is.True, "Expected dummy node was not added.");
            });
        }
    }
}