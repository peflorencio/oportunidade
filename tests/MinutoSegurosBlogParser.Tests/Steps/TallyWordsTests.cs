using System.Collections.Generic;
using FluentAssertions;
using MinutoSegurosBlogParser.Steps;
using NUnit.Framework;

namespace MinutoSegurosBlogParser.Tests.Steps
{
    [TestFixture]
    public class TallyWordsTests
    {
        [Test]
        public void Given_A_List_Of_Words_Should_Tally_Them_As_Expected()
        {
            var words = new[]
            {
                "cat", "crab", "dog", "Dog", "Scorpion", "bee", "alligator", "bear", "eagle", "cat", "whale", "Ant", "parrot",
                "crab", "fly", "bee", "Dog", "elephant", "Tiger", "whale", "mouse", "mouse", "mouse", "catfish", "lion", "cat",
                "swordfish", "vulture", "Baboon", "eagle", "mouse", "fly", "cougar", "crab", "crab", "horse", "gorilla", "scorpion"
            };

            var expectedWordTallies = new Dictionary<string, int>
            {
                { "cat", 3}, { "crab", 4}, { "dog", 1}, { "Dog", 2}, { "Scorpion", 1 }, { "scorpion", 1 }, { "bee", 2 },
                { "alligator", 1 }, { "bear", 1 }, { "eagle", 2 }, { "whale", 2 }, { "Ant", 1 }, { "parrot", 1 },
                { "fly", 2 }, { "elephant", 1 }, { "Tiger", 1 }, { "mouse", 4 }, { "catfish", 1 }, { "lion", 1 },
                { "swordfish", 1 }, { "vulture", 1 }, { "Baboon", 1 },  { "cougar", 1 }, { "horse", 1 }, { "gorilla", 1 },
            };

            var stepData = TallyWords.Execute(words);

            stepData.ShouldBeEquivalentTo(expectedWordTallies);
        }
    }
}