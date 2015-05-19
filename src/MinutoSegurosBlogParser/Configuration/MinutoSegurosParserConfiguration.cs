using System;

namespace MinutoSegurosBlogParser.Configuration
{
    public class MinutoSegurosParserConfiguration : IParserConfiguration<string>
    {
        private int _limitOfParsedPosts;
        private int _numberOfMostFrequentWords;

        public int LimitOfParsedPosts
        {
            get { return _limitOfParsedPosts; }
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("value", "The limit of parsed posts should be greather than zero.");

                _limitOfParsedPosts = value;
            }
        }

        public int NumberOfMostFrequentWords
        {
            get { return _numberOfMostFrequentWords; }
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("value", "The number of most frequent words to show should be greather than zero.");

                _numberOfMostFrequentWords = value;
            }
        }

        public string Input { get; set; }
    }
}