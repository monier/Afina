using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Afina.DataAccess.AdoNet.Instrumentations
{
    public class QuerySelector : IQuerySelector
    {
        private readonly Dictionary<string, string> _queries;

        public QuerySelector()
        {
            _queries = new Dictionary<string, string>();
        }
        public void AddQueries(string filename)
        {
            using (FileStream file = new FileStream(filename, FileMode.Open))
            {
                AddQueries(file);
            }
        }
        public void AddQueries(Stream stream)
        {
            using (XmlReader reader = XmlReader.Create(stream))
            {
                while (reader.Read())
                {
                    if (reader.Name == "Query" && reader.NodeType == XmlNodeType.Element)
                    {
                        var name = reader.GetAttribute("name");
                        var query = reader.ReadElementContentAsString()?.Trim();
                        _queries[name] = query;
                    }
                }
            }
        }
        public string GetQuery(string name)
        {
            if (_queries.TryGetValue(name, out string query))
                return query;
            return null;
        }
    }
}
