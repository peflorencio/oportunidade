using System.Threading.Tasks.Dataflow;

namespace MinutoSegurosBlogParser.Steps
{
    internal interface IStep<in TInput, out TOutput>
    {
        IPropagatorBlock<TInput, TOutput> Step { get; }
    }
}
