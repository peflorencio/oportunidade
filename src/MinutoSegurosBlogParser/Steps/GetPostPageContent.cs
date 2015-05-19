using System;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks.Dataflow;
using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using MinutoSegurosBlogParser.Extensions;

namespace MinutoSegurosBlogParser.Steps
{
    internal sealed class GetPostPageContent : IStep<SyndicationItem, ExtendedInput<PostData, string>>
    {
        public IPropagatorBlock<SyndicationItem, ExtendedInput<PostData, string>> Step { get; private set; }

        public Func<string, string> GetPostPageHtml = url =>
        {
            using (var client = new WebClient {Encoding = Encoding.UTF8})
            {
                return client.DownloadStringTaskAsync(url).Result;
            }
        };

        public GetPostPageContent()
        {
            Step = TransformBlock.Create<SyndicationItem, string, PostData>(Execute, CreatePipelineSession, new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 8 });
        }

        public static PostData CreatePipelineSession(SyndicationItem syndicationItem, string postContent)
        {
            return new PostData
            {
                Title = syndicationItem.Title.Text,
                Content = postContent,
            };
        }

        public string Execute(SyndicationItem syndicationItem)
        {
            var postUrl = syndicationItem.Id;

            var postPage = GetPostPageHtml(postUrl);

            var html = new HtmlDocument();
            html.LoadHtml(postPage);

            var paragraphs = html.DocumentNode.QuerySelectorAll("#wrapper-info ._entry_ > p").Select(p => p.InnerText);

            var postContent = string.Join(" ", paragraphs);

            return postContent;
        }
    }
}
