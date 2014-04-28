using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xSupermarket.Framework.DSL;

namespace xSupermarket.Framework.ExDSL
{
    public class ExObject
    {
        public static SelectObject SelectObject { get; set; }
        public static InsertObject InsertObject { get; set; }
        public static UpdateObject UpdateObject { get; set; }
        public static DeleteObject DeleteObject { get; set; }
        public static TopObject TopObject { get; set; }
        public static SuppObject SuppObject { get; set; }
        public static ConfObject ConfObject { get; set; }

        public static void Reset()
        {
            SelectObject = null;
            SelectObject = new SelectObject();
            InsertObject = null;
            InsertObject = new InsertObject();
            UpdateObject = null;
            UpdateObject = new UpdateObject();
            DeleteObject = null;
            DeleteObject = new DeleteObject();

            TopObject = null;
            TopObject = new TopObject();
            SuppObject = null;
            SuppObject = new SuppObject();
            ConfObject = null;
            ConfObject = new ConfObject();
        }
    }
}
