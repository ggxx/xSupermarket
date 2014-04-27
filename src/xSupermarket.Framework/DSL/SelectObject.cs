using System.Collections.Generic;
using xSupermarket.Framework.DSL;
using xSupermarket.Framework.Model;

namespace xSupermarket.Framework.DSL
{
    public class SelectObject
    {
        public SelectObject()
        {
            this.Criterions = new List<ICriterion>();
            this.GroupFields = new List<string>();
            this.AscFields = new List<string>();
            this.DescFields = new List<string>();
            this.Table = string.Empty;
        }

        public IList<ICriterion> Criterions { get; set; }
        public IList<string> GroupFields { get; set; }
        public IList<string> AscFields { get; set; }
        public IList<string> DescFields { get; set; }
        public string Table { get; set; }
    }
}
