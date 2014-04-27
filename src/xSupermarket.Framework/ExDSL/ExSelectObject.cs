using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xSupermarket.Framework.DSL;

namespace xSupermarket.Framework.ExDSL
{
    public class ExSelectObject 
    {
        public static SelectObject SelectObject { get; set; }
        //public static InsertObject InsertObject { get; set; }
        //public static UpdateObject InsertObject { get; set; }
        //public static DeleteObject InsertObject { get; set; }
        //public static TopObject InsertObject { get; set; }
        //public static SuppObject InsertObject { get; set; }
        //public static ConfObject InsertObject { get; set; }

        public static void Reset()
        {
            SelectObject = null;
            SelectObject = new SelectObject();
        }
    }
}
