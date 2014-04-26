using System.Collections.Generic;
using System.Linq;
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

        public IList<T> List()
        {
            return list;
        }

        public IResult<T> AscOrderBy(params string[] fields)
        {
            string[] orderBy = fields.Select<string, string>(x => x.Split('.')[1]).ToArray();
            ((List<T>)list).Sort(Asc<T>.By(orderBy));
            return this;
        }

        public IResult<T> DescOrderBy(params string[] fields)
        {
            string[] orderBy = fields.Select<string, string>(x => x.Split('.')[1]).ToArray();
            ((List<T>)list).Sort(Desc<T>.By(orderBy));
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
                IList<GroupRecord<T>> records = new List<GroupRecord<T>>();
                foreach (T t in this.list)
                {
                    GroupKey groupKey = new GroupKey(t.GetValue(cKey));
                    GroupRecord<T> groupingRecord = records.Count > 0 ? records.SingleOrDefault(x => x.GroupKey.Equals(groupKey)) : null;

                    if (groupingRecord != null)
                    {
                        groupingRecord.GruopValue.List().Add(t);
                    }
                    else
                    {
                        IResult<T> val = new Result<T>(new List<T>());
                        val.List().Add(t);
                        records.Add(new GroupRecord<T>() { GroupKey = groupKey, GruopValue = val });
                    }
                }
                return new GroupResult<T>(records);
            }
            else
            {
                return null;
            }
        }
    }
}
