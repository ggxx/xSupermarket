using System.Collections.Generic;
using xSupermarket.Framework.DSL;
using xSupermarket.Framework.Model;

namespace xSupermarket.Framework.ExDSL
{
    public class SelectObject
    {
        public static IModel model;
        public static IList<ICriterion> criterions;
        public static IList<string> groupFields;
        public static IList<string> ascFields;
        public static IList<string> descFields;
    }
}
