using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xSupermarket.Framework.Repo;

namespace xSupermarket.Framework.Model
{
    public class Employee : IModel
    {
        public const string NAME = "Employee.Name";
        public const string SEX = "Employee.Sex";
        public const string SECTION = "Employee.Section";

        public string Name { get; set; }
        public Sex Sex { get; set; }
        public Section Section { get; set; }

        public object GetValue(string fieldName)
        {
            switch (fieldName)
            {
                case NAME:
                    return this.Name;
                case SEX:
                    return this.Sex;
                case SECTION:
                    return this.Section;
                default:
                    return null;
            }
        }
    }

    public enum Sex
    {
        M,
        F
    }
}
