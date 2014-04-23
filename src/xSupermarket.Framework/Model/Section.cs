using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xSupermarket.Framework.Model
{
    public class Section : IModel
    {
        public const string ID = "Section.Id";
        public const string NAME = "Section.Name";

        public string Id { get; set; }
        public string Name { get; set; }

        public object GetValue(string fieldName)
        {
            switch (fieldName)
            {
                case NAME:
                    return this.Name;
                case ID:
                    return this.Id;
                default:
                    return null;
            }
        }
    }
}
