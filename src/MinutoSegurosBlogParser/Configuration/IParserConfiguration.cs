namespace MinutoSegurosBlogParser.Configuration
{
    public interface IParserConfiguration<TInput>
    {
        TInput Input { get; set; }
    }
}