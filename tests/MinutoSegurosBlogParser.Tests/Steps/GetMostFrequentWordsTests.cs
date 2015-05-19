using System.Collections.Generic;
using FluentAssertions;
using MinutoSegurosBlogParser.Steps;
using NUnit.Framework;

namespace MinutoSegurosBlogParser.Tests.Steps
{
    [TestFixture]
    public class GetMostFrequentWordsTests
    {
        private Dictionary<string, int> _wordTallies;

        [SetUp]
        public void SetUp()
        {
            _wordTallies = new Dictionary<string, int>
            {
                {"cat", 4}, {"dog", 17}, {"bear", 3}, {"frog", 46}, {"wolf", 1}, {"shark", 7}, {"rattlesnake", 3}, {"beetle", 8},
                {"bull", 12}, {"pig", 41}, {"bat", 30}, {"crow", 10}, {"dolphin", 6}, {"barracuda", 32}, {"rabbit", 11}, {"oyster", 2},
                {"fox", 3}, {"goat", 46}, {"falcon", 22}, {"duck", 7}, {"hyena", 10}, {"rhinoceros", 27}, {"snail", 13}, {"sheep", 15}
            };
        }

        [Test]
        public void Given_A_List_Of_Word_Tallies_Should_Return_A_List_Of_The_Most_Frequent_Words_Respecting_The_Limit_()
        {
            var expectedMostFrequentWords = new List<KeyValuePair<string, int>>
            {
                new KeyValuePair<string, int>("goat", 46),
                new KeyValuePair<string, int>("frog", 46),
            };

            const int numberOfMostFrequentWords = 2;

            var getMostFrequentWordsResult = new GetMostFrequentWords(numberOfMostFrequentWords).Execute(_wordTallies);

            getMostFrequentWordsResult.ShouldBeEquivalentTo(expectedMostFrequentWords);
        }
    }
}