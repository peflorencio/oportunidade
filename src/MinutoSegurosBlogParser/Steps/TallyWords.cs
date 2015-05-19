using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks.Dataflow;
using MinutoSegurosBlogParser.Extensions;

namespace MinutoSegurosBlogParser.Steps
{
    internal sealed class TallyWords : IStep<ExtendedInput<PostData, IEnumerable<string>>, ExtendedInput<PostData, Dictionary<string, int>>>
    {
        public IPropagatorBlock<ExtendedInput<PostData, IEnumerable<string>>, ExtendedInput<PostData, Dictionary<string, int>>> Step { get; private set; }

        public TallyWords()
        {
            Step = TransformBlock.Create<IEnumerable<string>, Dictionary<string, int>, PostData>(Execute, UpdatePipelineSession, new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 8 });
        }

        public static PostData UpdatePipelineSession(PostData postData, IEnumerable<string> words, Dictionary<string, int> wordTallies)
        {
            postData.WordTally = wordTallies.Sum(pair => pair.Value);

            return postData;
        }

        public static Dictionary<string, int> Execute(IEnumerable<string> words)
        {
            var wordTallies = words.GroupBy(w => w).ToDictionary(g => g.Key, g => g.Count());

            return wordTallies;
        }
    }
}
