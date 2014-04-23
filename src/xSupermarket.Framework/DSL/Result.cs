using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xSupermarket.Framework.Model;

namespace xSupermarket.Framework.DSL
{
    public class Result<T> : IResult<T> where T : IModel
    {
        private IList<T> list;

        public Result(IList<T> list)
        {
            this.list = list;
        }

        public IList<T> GetResultList()
        {
            return list;
        }

        public IResult<T> AscOrderBy(params string[] fields)
        {
            for (int i = fields.Length - 1; i >= 0; i--)
            {
                ((List<T>)list).Sort((x, y) => x.GetValue(fields[i]).ToString().CompareTo(y.GetValue(fields[i]).ToString()));
            }
            return this;
        }

        public IResult<T> DescOrderBy(params string[] fields)
        {
            for (int i = fields.Length - 1; i >= 0; i--)
            {
                ((List<T>)list).Sort((x, y) => y.GetValue(fields[i]).ToString().CompareTo(x.GetValue(fields[i]).ToString()));
            }
            return this;
        }

        public IGroupResult<T> GroupBy(params string[] fields)
        {
            if (fields != null && fields.Length > 1)
            {
                IGroupResult<T> r = GroupBy(fields[0]);
                for (int i = 1; i < fields.Length; i++)
                {
                    r = r.GroupBy(fields[i]);
                }
                return r;
            }
            else if (fields != null && fields.Length == 1)
            {
                string cKey = fields[0];
                IDictionary<GroupKey, IResult<T>> r = new Dictionary<GroupKey, IResult<T>>();
                foreach (T t in this.list)
                {
                    if (r.ContainsKey(new GroupKey(t.GetValue(cKey))))
                    {
                        IResult<T> val;
                        if (r.TryGetValue(new GroupKey(t.GetValue(cKey)), out val))
                        {
                            val.GetResultList().Add(t);
                        }
                    }
                    else
                    {
                        IResult<T> val = new Result<T>(new List<T>());
                        val.GetResultList().Add(t);
                        r.Add(new GroupKey(t.GetValue(cKey)), val);
                    }
                }
                return new GroupResult<T>(r);
            }
            else
            {
                return null;
            }
        }
    }
}
