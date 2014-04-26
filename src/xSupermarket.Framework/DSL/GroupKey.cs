using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xSupermarket.Framework.DSL
{
    public class GroupKey : IComparable
    {
        public object[] Keys { get; private set; }

        public object this[int index]
        {
            get
            {
                if (index < Keys.Length)
                {
                    return Keys[index];
                }
                return 0;
            }
        }

        public GroupKey(params object[] objects)
        {
            List<object> list = new List<object>();
            foreach (object obj in objects)
            {
                if (obj is object[])
                {
                    list.AddRange(obj as object[]);
                }
                else
                {
                    list.Add(obj);
                }
            }
            this.Keys = list.ToArray();
        }

        public override bool Equals(object obj)
        {
            if (obj is GroupKey)
            {
                GroupKey k = obj as GroupKey;
                if (k.Keys.Length == this.Keys.Length)
                {
                    return this.GetHashCode() == k.GetHashCode();
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hashCode = 0;
            foreach (object key in Keys)
            {
                hashCode += key.GetHashCode();
            }
            return hashCode;
        }

        public int CompareTo(object obj)
        {
            GroupKey gk = obj as GroupKey;
            for (int i = 0; i < Keys.Length; i++)
            {
                int result = Keys[i].ToString().CompareTo(gk.Keys[i].ToString());
                if (result != 0)
                {
                    return result;
                }
            }
            return 0;
        }
    }
}
