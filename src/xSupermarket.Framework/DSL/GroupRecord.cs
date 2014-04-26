using System;
using xSupermarket.Framework.Model;

namespace xSupermarket.Framework.DSL
{
    public class GroupRecord<T> : IComparable where T : IModel
    {
        public GroupKey GroupKey { get; set; }

        public IResult<T> GruopValue { get; set; }

        public int CompareTo(object obj)
        {
            GroupRecord<T> gr = obj as GroupRecord<T>;
            return this.GroupKey.CompareTo(gr.GroupKey);
        }
    }
}
