using System;

namespace MinutoSegurosBlogParser.Proxies
{
    public class XmlReader
    {
        public static Func<string, System.Xml.XmlReader> Create = s => System.Xml.XmlReader.Create(s);
    }
}
