using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace MinutoSegurosBlogParser
{
    public interface IParserPipeline<in TInput, TOutput>
    {
        Task<TOutput> GetOutput();

        ITargetBlock<TInput> FirstStep { get; }
    }
}