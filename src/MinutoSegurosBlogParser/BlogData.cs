using System.Collections.Generic;
using Newtonsoft.Json;

namespace MinutoSegurosBlogParser
{
    public class BlogData
    {
        public BlogData()
        {
            MostFrequentWords = new List<KeyValuePair<string, int>>();
            Posts = new List<PostData>();
        }

        public List<KeyValuePair<string, int>> MostFrequentWords { get; set; }

        public List<PostData> Posts { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}