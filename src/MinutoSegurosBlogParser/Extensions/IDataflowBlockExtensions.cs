using System.Threading.Tasks.Dataflow;

namespace MinutoSegurosBlogParser.Extensions
{
    public static class IDataflowBlockExtensions
    {
        public static void ContinueWithOnCompletion(this IDataflowBlock source, IDataflowBlock target)
        {
            source.Completion.ContinueWith(t =>
            {
                if (t.IsFaulted)
                {
                    target.Fault(t.Exception);
                }
                else target.Complete();
            });
        }
    }
}
