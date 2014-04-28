using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xSupermarket.Framework.Model;
using xSupermarket.Framework.Repo;

namespace xSupermarket.Framework.DSL
{
    public class TopObject : DslObject
    {
        public TopObject()
        {
            this.MinSupport = 55;
            this.Table = string.Empty;
        }

        public string Table { get; set; }
        public int MinSupport { get; set; }

        public Dictionary<List<string>, int> GetResult()
        {
            IRepository<Marketbasket> mRepo = new MarketbasketRepository();
            IList<Marketbasket> marketbaskets = mRepo.Find().List();
            Dictionary<string, List<string>> data = new Dictionary<string, List<string>>();
            foreach (Marketbasket ma in marketbaskets)
            {
                if (data.ContainsKey(ma.Id))
                {
                    List<string> l;
                    if (data.TryGetValue(ma.Id, out l))
                    {
                        l.Add(ma.Product.Name);
                    }
                }
                else
                {
                    List<string> l = new List<string>();
                    l.Add(ma.Product.Name);
                    data.Add(ma.Id, l);
                }
            }

            DataMining.Apriori ap = new DataMining.Apriori(data, MinSupport);
            return ap.GetResults();
        }

        public string GetOutput()
        {
            StringBuilder sb = new StringBuilder(string.Empty);
            List<int> values = new List<int>();
            List<List<string>> keys = new List<List<string>>();
            Dictionary<List<string>, int> result = GetResult();
            foreach (KeyValuePair<List<string>, int> kvp in result)
            {
                keys.Add(kvp.Key);
                values.Add(kvp.Value);
            }

            while (keys.Count > 0)
            {
                int index = 0;
                int max = 0;
                for (int i = 0; i < keys.Count; i++)
                {
                    if (values[i] > max)
                    {
                        index = i;
                        max = values[i];
                    }
                }

                foreach (string key in keys[index])
                {
                    sb.Append(key);
                    sb.Append(", ");
                }
                sb.Append(values[index]);
                sb.AppendLine();


                keys.RemoveAt(index);
                values.RemoveAt(index);
            }

            return sb.ToString();
        }
    }
}
