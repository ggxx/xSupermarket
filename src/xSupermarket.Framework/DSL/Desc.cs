using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace xSupermarket.Framework.DSL
{
    public class Desc<T> : Asc<T>
    {
        public override int Compare(T x, T y)
        {
            return -base.Compare(x, y);
        }
    }
}
