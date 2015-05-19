using System.Collections.Generic;
using FluentAssertions;
using MinutoSegurosBlogParser.Steps;
using NUnit.Framework;

namespace MinutoSegurosBlogParser.Tests.Steps
{
    [TestFixture]
    public class AddUpWordTalliesTests
    {
        private IEnumerable<ExtendedInput<PostData, Dictionary<string, int>>> _stepData;

        [SetUp]
        public void SetUp()
        {
            _stepData = new List<ExtendedInput<PostData, Dictionary<string, int>>>
            {
                new ExtendedInput<PostData, Dictionary<string, int>>
                {
                    Accumulator = new PostData
                    {
                        Title = "First List of Animals",
                        Content = "This is the first list of animals",
                        WordTally = 7
                    },
                    Input = new Dictionary<string, int>
                    {
                        {"cat", 2},
                        {"dog", 4},
                        {"mouse", 1},
                        {"wolf", 1},
                    }
                },
                new ExtendedInput<PostData, Dictionary<string, int>>
                {
                    Accumulator = new PostData
                    {
                        Title = "A new list of animals",
                        Content = "More animals",
                        WordTally = 2
                    },
                    Input = new Dictionary<string, int>
                    {
                        {"elephant", 6},
                        {"bee", 2},
                        {"cat", 1},
                        {"gorilla", 2},
                        {"dog", 3},
                    }
                },
                new ExtendedInput<PostData, Dictionary<string, int>>
                {
                    Accumulator = new PostData
                    {
                        Title = "The last list of animals",
                        Content = "This is the last one",
                        WordTally = 5
                    },
                    Input = new Dictionary<string, int>
                    {
                        {"ostrich", 1},
                        {"wolf", 5},
                        {"fly", 2},
                        {"ant", 1},
                        {"cat", 3},
                    }
                }
            };
        }

        [Test]
        public void Given_Some_Word_Tallies_Should_Add_Them_Up_As_Expected()
        {
            var addUpWordTalliesResult = AddUpWordTallies.Execute(_stepData);
            var wordTallies = addUpWordTalliesResult;

            wordTallies["cat"].Should().Be(6);
            wordTallies["dog"].Should().Be(7);
            wordTallies["mouse"].Should().Be(1);
            wordTallies["wolf"].Should().Be(6);
            wordTallies["elephant"].Should().Be(6);
            wordTallies["bee"].Should().Be(2);
            wordTallies["gorilla"].Should().Be(2);
            wordTallies["ostrich"].Should().Be(1);
            wordTallies["fly"].Should().Be(2);
            wordTallies["ant"].Should().Be(1);
        }
    }
}
