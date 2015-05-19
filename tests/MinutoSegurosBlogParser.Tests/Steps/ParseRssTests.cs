using System.Linq;
using System.ServiceModel.Syndication;
using FluentAssertions;
using MinutoSegurosBlogParser.Proxies;
using MinutoSegurosBlogParser.Steps;
using NUnit.Framework;
using SyndicationFeed = MinutoSegurosBlogParser.Proxies.SyndicationFeed;

namespace MinutoSegurosBlogParser.Tests.Steps
{
    [TestFixture]
    public class ParseRssTests
    {
        [SetUp]
        public void SetUp()
        {
            XmlReader.Create = (s => null);
        }

        [Test]
        public void Given_An_Rss_Feed_Url_With_More_Posts_Than_The_Limit_Should_Return_A_Limited_Number_Of_Posts()
        {
            const int limit = 5;
            const int numberOfPosts = 10;

            SyndicationFeed.Load = (r => new System.ServiceModel.Syndication.SyndicationFeed(Enumerable.Repeat(new SyndicationItem(), numberOfPosts).ToList()));

            var posts = new ParseRss(limit).Execute("teste");

            posts.Should().HaveCount(limit);
        }

        [Test]
        public void Given_An_Rss_Feed_Url_With_Fewer_Posts_Than_The_Limit_Should_Return_All_Posts()
        {
            const int limit = 5;
            const int numberOfPosts = 3;

            SyndicationFeed.Load = (r => new System.ServiceModel.Syndication.SyndicationFeed(Enumerable.Repeat(new SyndicationItem(), numberOfPosts).ToList()));

            var posts = new ParseRss(limit).Execute("teste");

            posts.Should().HaveCount(numberOfPosts);
        }
    }
}
