using System.Threading.Tasks;
using MinutoSegurosBlogParser.Configuration;

namespace MinutoSegurosBlogParser.Console.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintBlogData().Wait();
            System.Console.Read();
        }

        public static async Task PrintBlogData()
        {
            var minutoSegurosBlogParser = new MinutoSegurosBlogParser(
                new MinutoSegurosParserConfiguration
                {
                    LimitOfParsedPosts = 10,
                    NumberOfMostFrequentWords = 10,
                    Input = "http://www.minutoseguros.com.br/blog/feed/"
                });

            System.Console.WriteLine(await minutoSegurosBlogParser.ReadAsync());
        }
    }
}
