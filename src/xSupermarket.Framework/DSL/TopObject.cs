using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xSupermarket.Framework.Model;
using xSupermarket.Framework.Repo;

namespace xSupermarket.Framework.DSL
{
    public class TopObject
    {
        public TopObject()
        {
            this.Number = 5;
            this.Table = string.Empty;
        }

        public string Table { get; set; }
        public int Number { get; set; }

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

            DataMining.Apriori ap = new DataMining.Apriori(data, 55);
            return ap.GetResults();
        }
    }
}
