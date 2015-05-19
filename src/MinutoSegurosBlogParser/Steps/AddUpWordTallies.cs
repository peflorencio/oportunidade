using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using MinutoSegurosBlogParser.Extensions;

namespace MinutoSegurosBlogParser.Steps
{
    internal sealed class AddUpWordTallies : IStep<IEnumerable<ExtendedInput<PostData, Dictionary<string, int>>>, ExtendedInput<BlogData, Dictionary<string, int>>>
    {
        public IPropagatorBlock<IEnumerable<ExtendedInput<PostData, Dictionary<string, int>>>, ExtendedInput<BlogData, Dictionary<string, int>>> Step { get; private set; }

        public AddUpWordTallies()
        {
            Step = TransformBlock.Create<IEnumerable<ExtendedInput<PostData, Dictionary<string, int>>>, Dictionary<string, int>, BlogData>(
                Execute, UpdatePipelineSession, new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 8 });
        }

        public static BlogData UpdatePipelineSession(IEnumerable<ExtendedInput<PostData, Dictionary<string, int>>> stepData, Dictionary<string, int> blogWordTallies)
        {
            var blogData = new BlogData();

            foreach (var dataItem in stepData)
            {
                blogData.Posts.Add(dataItem.Accumulator);
            }

            return blogData;
        }

        public static Dictionary<string, int> Execute(IEnumerable<ExtendedInput<PostData, Dictionary<string, int>>> stepData)
        {
            var blogWordTallies = new Dictionary<string, int>();

            Parallel.ForEach(stepData, dataItem =>
            {
                foreach (var tally in dataItem.Input)
                {
                    if (blogWordTallies.ContainsKey(tally.Key))
                    {
                        blogWordTallies[tally.Key] += tally.Value;
                    }
                    else
                    {
                        blogWordTallies[tally.Key] = tally.Value;
                    }
                }
            });

            return blogWordTallies;
        }
    }
}
