using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks.Dataflow;
using MinutoSegurosBlogParser.Extensions;

namespace MinutoSegurosBlogParser.Steps
{
    internal sealed class GetMostFrequentWords : IStep<ExtendedInput<BlogData, Dictionary<string, int>>, ExtendedInput<BlogData, List<KeyValuePair<string, int>>>>
    {
        private readonly int _numberOfMostFrequentWords;

        public IPropagatorBlock<ExtendedInput<BlogData, Dictionary<string, int>>, ExtendedInput<BlogData, List<KeyValuePair<string, int>>>> Step { get; private set; }

        public GetMostFrequentWords(int numberOfMostFrequentWords = 10)
        {
            _numberOfMostFrequentWords = numberOfMostFrequentWords;
            Step = TransformBlock.Create<Dictionary<string, int>, List<KeyValuePair<string, int>>, BlogData>(Execute, UpdatePipelineSession);
        }

        private static BlogData UpdatePipelineSession(BlogData blogData, Dictionary<string, int> wordTallies, List<KeyValuePair<string, int>> mostFrequentWords)
        {
            blogData.MostFrequentWords = mostFrequentWords;

            return blogData;
        }

        public List<KeyValuePair<string, int>> Execute(Dictionary<string, int> wordTallies)
        {
            var mostFrequentWords = wordTallies
                .OrderByDescending(tally => tally.Value)
                .Take(_numberOfMostFrequentWords).ToList();

            return mostFrequentWords;
        }
    }
}