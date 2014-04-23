using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xSupermarket.Framework.Model;

namespace xSupermarket.Framework.DSL
{
    public class GroupResult<T> : IGroupResult<T> where T : IModel
    {
        private IDictionary<GroupKey, IResult<T>> groupingResult;

        public GroupResult(IDictionary<GroupKey, IResult<T>> r)
        {
            this.groupingResult = r;
        }

        public IList<T> GetResultList()
        {
            List<T> result = new List<T>();
            foreach (KeyValuePair<GroupKey, IResult<T>> kvp in this.groupingResult)
            {
                result.AddRange(kvp.Value.GetResultList());
            }
            return result;
        }

        public IDictionary<GroupKey, IResult<T>> GetGroupingResult()
        {
            return this.groupingResult;
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
                foreach (KeyValuePair<GroupKey, IResult<T>> kvp in this.groupingResult)
                {
                    foreach (T t in kvp.Value.GetResultList())
                    {
                        if (r.ContainsKey(new GroupKey(kvp.Key.Keys, t.GetValue(cKey))))
                        {
                            IResult<T> val;
                            if (r.TryGetValue(new GroupKey(kvp.Key.Keys, t.GetValue(cKey)), out val))
                            {
                                val.GetResultList().Add(t);
                            }
                        }
                        else
                        {
                            IResult<T> val = new Result<T>(new List<T>());
                            val.GetResultList().Add(t);
                            r.Add(new GroupKey(kvp.Key.Keys, t.GetValue(cKey)), val);
                        }
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
