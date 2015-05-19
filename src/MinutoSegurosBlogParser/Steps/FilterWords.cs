using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks.Dataflow;
using MinutoSegurosBlogParser.Extensions;

namespace MinutoSegurosBlogParser.Steps
{
    internal sealed class FilterWords : IStep<ExtendedInput<PostData, IEnumerable<string>>, ExtendedInput<PostData, IEnumerable<string>>>
    {
        public IPropagatorBlock<ExtendedInput<PostData, IEnumerable<string>>, ExtendedInput<PostData, IEnumerable<string>>> Step { get; private set; }

        public FilterWords()
        {
            Step = TransformBlock.Create<IEnumerable<string>, IEnumerable<string>, PostData>(Execute, new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 8 });
        }

        public static IEnumerable<string> Execute(IEnumerable<string> words)
        {
            var filteredWords = words.Where(word => !IsPreposition(word) && !IsArticle(word));

            return filteredWords;
        }

        private static bool IsPreposition(string word)
        {
            string[] prepositions =
            {
                "a", "ante", "perante", "após", "até", "com", "contra", "de", "desde", "em", "entre",
                "para", "por", "sem", "sob", "sobre", "trás", "atrás de", "dentro de", "para com"
            };

            return prepositions.Contains(word.ToLowerInvariant());
        }

        private static bool IsArticle(string word)
        {
            string[] articles = { "a", "as", "o", "os", "um", "uns", "uma", "umas" };

            return articles.Contains(word.ToLowerInvariant());
        }
    }
}
