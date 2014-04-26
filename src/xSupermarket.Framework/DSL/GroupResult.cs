using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xSupermarket.Framework.Model;

namespace xSupermarket.Framework.DSL
{
    public class GroupResult<T> : IGroupResult<T> where T : IModel
    {
        private IList<GroupRecord<T>> groupingResult;
        private IList<T> list = new List<T>();

        public GroupResult(IList<GroupRecord<T>> records)
        {
            this.groupingResult = records;
            foreach (GroupRecord<T> gr in this.groupingResult)
            {
                foreach (T t in gr.GruopValue.List())
                {
                    list.Add(t);
                }
            }
        }

        public IList<GroupRecord<T>> ListGroupingResult()
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
                IList<GroupRecord<T>> newRecords = new List<GroupRecord<T>>();
                foreach (GroupRecord<T> record in this.groupingResult)
                {
                    IGroupResult<T> tmp = record.GruopValue.GroupBy(cKey);
                    foreach (GroupRecord<T> gr in tmp.ListGroupingResult())
                    {
                        GroupRecord<T> newRecord = new GroupRecord<T>();
                        newRecord.GroupKey = new GroupKey(record.GroupKey.Keys, gr.GroupKey.Keys);
                        newRecord.GruopValue = gr.GruopValue;
                        newRecords.Add(newRecord);
                    }
                }
                return new GroupResult<T>(newRecords);
            }
            else
            {
                return null;
            }
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
    }
}
