using System.Threading.Tasks.Dataflow;
using FluentAssertions;
using MinutoSegurosBlogParser.Configuration;
using Moq;
using NUnit.Framework;

namespace MinutoSegurosBlogParser.Tests
{
    [TestFixture]
    public class MinutoSegurosBlogParserTests
    {
        [Test]
        public async void When_Asked_To_Read_A_Blog_Should_Return_Blog_Data()
        {
            var fakeConfiguration = new Mock<MinutoSegurosParserConfiguration>();
            var fakePipeline = new Mock<IParserPipeline<string, BlogData>>();
            var fakeBlock = new Mock<ITargetBlock<string>>();

            fakePipeline.Setup(p => p.GetOutput()).ReturnsAsync(new BlogData());
            fakePipeline.Setup(p => p.FirstStep).Returns(fakeBlock.Object);

            var minutoSegurosBlogParser = new MinutoSegurosBlogParser(fakeConfiguration.Object, fakePipeline.Object);

            var blogData = await minutoSegurosBlogParser.ReadAsync();

            blogData.Should().NotBeNull();
        }
    }
}
