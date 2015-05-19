using System;
using System.Threading.Tasks.Dataflow;

namespace MinutoSegurosBlogParser.Extensions
{
    public static class ISourceBlockExtensions
    {
        public static IDisposable ContinueWith<TOutput>(this ISourceBlock<TOutput> source, ITargetBlock<TOutput> target)
        {
            source.ContinueWithOnCompletion(target);
            return source.LinkTo(target);
        }
    }
}
