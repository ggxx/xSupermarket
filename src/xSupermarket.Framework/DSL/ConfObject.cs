using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xSupermarket.Framework.Model;
using xSupermarket.Framework.Repo;

namespace xSupermarket.Framework.DSL
{
    public class ConfObject
    {
        public ConfObject()
        {
            this.Name1 = string.Empty;
            this.Name2 = string.Empty;
            this.Table = string.Empty;
        }

        public string Table { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }

        public float GetResult()
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

            Framework.DataMining.Apriori ap = new Framework.DataMining.Apriori(data, 50);
            List<string> l1 = new List<string>();
            List<string> l2 = new List<string>();
            l1.Add(Name1);
            l2.Add(Name2);

            return ap.GetConfidence(l1, l2);
        }
    }
}
