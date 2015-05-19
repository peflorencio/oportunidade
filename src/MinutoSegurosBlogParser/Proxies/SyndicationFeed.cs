using System;

namespace MinutoSegurosBlogParser.Proxies
{
    public class SyndicationFeed
    {
        public static Func<System.Xml.XmlReader, System.ServiceModel.Syndication.SyndicationFeed> Load = r => System.ServiceModel.Syndication.SyndicationFeed.Load(r);
    }
}
