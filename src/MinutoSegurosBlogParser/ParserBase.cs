using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using MinutoSegurosBlogParser.Configuration;

namespace MinutoSegurosBlogParser
{
    public class ParserBase<TInput, TOutput>
    {
        protected readonly IParserConfiguration<TInput> Configuration;
        protected readonly IParserPipeline<TInput, TOutput> Pipeline;

        public ParserBase(IParserConfiguration<TInput> configuration, IParserPipeline<TInput, TOutput> pipeline)
        {
            Pipeline = pipeline;
            Configuration = configuration;
        }

        public virtual async Task<TOutput> ReadAsync()
        {
            await Pipeline.FirstStep.SendAsync(Configuration.Input);
            Pipeline.FirstStep.Complete();
            return await Pipeline.GetOutput();
        }
    }
}