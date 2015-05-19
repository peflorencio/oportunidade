using MinutoSegurosBlogParser.Configuration;

namespace MinutoSegurosBlogParser
{
    public class MinutoSegurosBlogParser : ParserBase<string, BlogData>
    {
        public MinutoSegurosBlogParser(MinutoSegurosParserConfiguration configuration, IParserPipeline<string, BlogData> pipeline) 
            : base(configuration, pipeline)
        {
        }

        public MinutoSegurosBlogParser(MinutoSegurosParserConfiguration configuration)
            : this(configuration, new MinutoSegurosBlogPipeline(configuration.LimitOfParsedPosts, configuration.NumberOfMostFrequentWords))
        {
        }
    }
}