using System;
using System.Collections.Generic;
using System.Reflection;

namespace xSupermarket.Framework.DSL
{
    public class Asc<T> : IComparer<T>
    {
        private PropertyInfo[] properties;

        public static Asc<T> By(params string[] properties)
        {
            return new Asc<T>(properties);
        }

        public Asc(params string[] orderBy)
        {
            if (orderBy == null)
                throw new ArgumentNullException();
            if (orderBy.Length < 1)
                throw new ArgumentException();
            Type t = typeof(T);
            PropertyInfo[] ps = t.GetProperties();
            List<PropertyInfo> list = new List<PropertyInfo>();
            foreach (string name in orderBy)
            {
                foreach (PropertyInfo p in ps)
                {
                    if (p.Name != name)
                        continue;
                    list.Add(p);
                    break;
                }
            }
            properties = list.ToArray();
        }
        public int Compare(T x, T y)
        {
            return Compare(x, y, 0);
        }
        private int Compare(object x, object y, int p)
        {
            if (p >= properties.Length) return 0;
            PropertyInfo pi = properties[p];
            IComparable xx = pi.GetValue(x, null) as IComparable;
            IComparable yy = pi.GetValue(y, null) as IComparable;
            if (xx != null && yy != null)
            {
                int r = xx.CompareTo(yy);
                if (r != 0) return r;
            }
            if (p + 1 < properties.Length)
                return Compare(x, y, p + 1);
            string s1 = x.ToString();
            string s2 = x.ToString();
            return s1.CompareTo(s2);
        }
    }
}
