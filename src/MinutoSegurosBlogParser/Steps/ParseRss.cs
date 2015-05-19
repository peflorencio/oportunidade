using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using MinutoSegurosBlogParser.Proxies;
using SyndicationFeed = MinutoSegurosBlogParser.Proxies.SyndicationFeed;

namespace MinutoSegurosBlogParser.Steps
{
    internal sealed class ParseRss : IStep<string, SyndicationItem>
    {
        private readonly int _limitOfParsedPosts;
        public IPropagatorBlock<string, SyndicationItem> Step { get; private set; }

        public ParseRss(int limitOfParsedPosts = 10)
        {
            _limitOfParsedPosts = limitOfParsedPosts;

            Step = new TransformManyBlock<string, SyndicationItem>(input => Execute(input));
        }

        public IEnumerable<SyndicationItem> Execute(string uri)
        {
            var feed = Task.Factory.StartNew(() =>
            {
                using (var reader = XmlReader.Create(uri))
                {
                    return SyndicationFeed.Load(reader);
                }
            }).Result;

            return feed.Items.Take(_limitOfParsedPosts);
        }
    }
}
