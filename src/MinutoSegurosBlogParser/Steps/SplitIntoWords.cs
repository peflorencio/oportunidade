using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks.Dataflow;
using MinutoSegurosBlogParser.Extensions;

namespace MinutoSegurosBlogParser.Steps
{
    internal sealed class SplitIntoWords : IStep<ExtendedInput<PostData, string>, ExtendedInput<PostData, IEnumerable<string>>>
    {
        public IPropagatorBlock<ExtendedInput<PostData, string>, ExtendedInput<PostData, IEnumerable<string>>> Step { get; private set; }

        public SplitIntoWords()
        {
            Step = TransformBlock.Create<string, IEnumerable<string>, PostData>(Execute, new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 8 });
        }

        public static IEnumerable<string> Execute(string postContent)
        {
            var matches = Regex.Matches(postContent, @"\b[\w-]+\b");

            var words = matches.Cast<Match>().Select(m => m.Value);

            return words;
        }
    }
}
