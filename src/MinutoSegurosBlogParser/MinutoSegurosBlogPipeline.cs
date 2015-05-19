using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using MinutoSegurosBlogParser.Extensions;
using MinutoSegurosBlogParser.Steps;

namespace MinutoSegurosBlogParser
{
    public class MinutoSegurosBlogPipeline : IParserPipeline<string, BlogData>
    {
        private BlogData _output;

        private readonly IDataflowBlock _lastStep;

        public ITargetBlock<string> FirstStep { get; private set; }

        public async Task<BlogData> GetOutput()
        {
            await _lastStep.Completion;

            return _output;
        }

        public MinutoSegurosBlogPipeline(int limitOfParsedPosts, int numberOfMostFrequentWords)
        {
            var parseRss = new ParseRss(limitOfParsedPosts).Step;
            var getPostPageContent = new GetPostPageContent().Step;
            var splitIntoWords = new SplitIntoWords().Step;
            var filterWords = new FilterWords().Step;
            var tallyWords = new TallyWords().Step;
            var aggregate = new BatchBlock<ExtendedInput<PostData, Dictionary<string, int>>>(limitOfParsedPosts);
            var addUpWordTallies = new AddUpWordTallies().Step;
            var getMostFrequentWords = new GetMostFrequentWords(numberOfMostFrequentWords).Step;
            var output = new ActionBlock<ExtendedInput<BlogData, List<KeyValuePair<string, int>>>>(input => { _output = input.Accumulator; });

            parseRss.ContinueWith(getPostPageContent);
            getPostPageContent.ContinueWith(splitIntoWords);
            splitIntoWords.ContinueWith(filterWords);
            filterWords.ContinueWith(tallyWords);
            tallyWords.ContinueWith(aggregate);
            aggregate.ContinueWith(addUpWordTallies);
            addUpWordTallies.ContinueWith(getMostFrequentWords);
            getMostFrequentWords.ContinueWith(output);

            FirstStep = parseRss;
            _lastStep = output;
        }
    }
}
