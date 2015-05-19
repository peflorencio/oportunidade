namespace MinutoSegurosBlogParser
{
    internal class ExtendedInput<TAccumulator, TInput>
    {
        public TInput Input { get; set; }

        public TAccumulator Accumulator { get; set; }
    }

    internal static class ExtendedInput
    {
        public static ExtendedInput<TAccumulator, TInput> Create<TAccumulator, TInput>(TAccumulator accumulator, TInput input)
        {
            return new ExtendedInput<TAccumulator, TInput>
            {
                Accumulator = accumulator,
                Input = input
            };
        }
    }
}
