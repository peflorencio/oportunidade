using System;
using System.Threading.Tasks.Dataflow;
using MinutoSegurosBlogParser.Steps;

namespace MinutoSegurosBlogParser.Extensions
{
    public static class TransformBlock
    {
        internal static IPropagatorBlock<TInput, ExtendedInput<TAccumulatorOutput, TOutput>> Create<TInput, TOutput, TAccumulatorOutput>(
            Func<TInput, TOutput> execute,
            Func<TInput, TOutput, TAccumulatorOutput> createAccumulator,
            ExecutionDataflowBlockOptions options = null)
        {
            return new TransformBlock<TInput, ExtendedInput<TAccumulatorOutput, TOutput>>(input =>
            {
                var output = execute(input);

                var accumulatorOutput = default(TAccumulatorOutput);

                if (createAccumulator != null)
                {
                    accumulatorOutput = createAccumulator(input, output);
                }

                return ExtendedInput.Create(accumulatorOutput, output);
            },
            options ?? new ExecutionDataflowBlockOptions());
        }

        internal static IPropagatorBlock<ExtendedInput<TAccumulatorInput, TInput>, ExtendedInput<TAccumulatorOutput, TOutput>> Create<TInput, TOutput, TAccumulatorInput, TAccumulatorOutput>(
            Func<TInput, TOutput> execute,
            Func<TAccumulatorInput, TInput, TOutput, TAccumulatorOutput> updateAccumulator,
            ExecutionDataflowBlockOptions options = null)
        {
            return new TransformBlock<ExtendedInput<TAccumulatorInput, TInput>, ExtendedInput<TAccumulatorOutput, TOutput>>(stepData =>
            {
                var output = execute(stepData.Input);

                var accumulatorOutput = default(TAccumulatorOutput);

                if (updateAccumulator != null)
                {
                    accumulatorOutput = updateAccumulator(stepData.Accumulator, stepData.Input, output);
                }

                return ExtendedInput.Create(accumulatorOutput, output);
            },
            options ?? new ExecutionDataflowBlockOptions());
        }

        internal static IPropagatorBlock<ExtendedInput<TAccumulator, TInput>, ExtendedInput<TAccumulator, TOutput>> Create<TInput, TOutput, TAccumulator>(
            Func<TInput, TOutput> execute,
            Func<TAccumulator, TInput, TOutput, TAccumulator> updateAccumulator,
            ExecutionDataflowBlockOptions options = null)
        {
            return new TransformBlock<ExtendedInput<TAccumulator, TInput>, ExtendedInput<TAccumulator, TOutput>>(stepData =>
            {
                var output = execute(stepData.Input);

                var accumulatorOutput = stepData.Accumulator;

                if (updateAccumulator != null)
                {
                    accumulatorOutput = updateAccumulator(stepData.Accumulator, stepData.Input, output);
                }

                return ExtendedInput.Create(accumulatorOutput, output);
            },
            options ?? new ExecutionDataflowBlockOptions());
        }

        internal static IPropagatorBlock<ExtendedInput<TAccumulator, TInput>, ExtendedInput<TAccumulator, TOutput>> Create<TInput, TOutput, TAccumulator>(
            Func<TInput, TOutput> execute,
            ExecutionDataflowBlockOptions options = null)
        {
            return Create<TInput, TOutput, TAccumulator>(execute, (Func<TAccumulator, TInput, TOutput, TAccumulator>)null, options);
        }
    }
}
