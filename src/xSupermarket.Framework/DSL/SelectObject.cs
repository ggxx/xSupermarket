using System.Collections.Generic;
using xSupermarket.Framework.DSL;
using xSupermarket.Framework.Model;
using xSupermarket.Framework.Repo;
using System.Linq;

namespace xSupermarket.Framework.DSL
{
    public class SelectObject
    {
        private bool isAsc = true;

        public SelectObject()
        {
            this.Criterions = new List<ICriterion>();
            this.GroupFields = new List<string>();
            this.AscFields = new List<string>();
            this.DescFields = new List<string>();
            this.Table = string.Empty;
        }

        public IList<ICriterion> Criterions { get; set; }
        public IList<string> GroupFields { get; set; }
        public IList<string> AscFields { get; set; }
        public IList<string> DescFields { get; set; }
        public IList<string> OrderFields { get { return isAsc ? AscFields : DescFields; } }
        public string Table { get; set; }
        public void SetAsc(bool asc)
        {
            this.isAsc = asc;
        }

        public IResult<T> GetResult<T>() where T : IModel
        {
            IRepository<T> repo = RepositoryFactory.CreateRepository<T>();
            IResult<T> result = null;
            if (this.Criterions.Count == 1)
            {
                ICriterion criterions = this.Criterions[0];
                result = repo.Find(criterions);
            }
            else if (this.Criterions.Count > 1)
            {
                ICriterion criterions = new CriterionPair(this.Criterions[0], this.Criterions[1], Relationship.And);
                for (int i = 2; i < this.Criterions.Count; i++)
                {
                    criterions.And(this.Criterions[i]);
                }
                result = repo.Find(criterions);
            }
            else
            {
                result = repo.Find();
            }
            if (this.GroupFields.Count > 0)
            {
                result = result.GroupBy(this.GroupFields.Select(x => string.Format("{0}.{1}", this.Table, x)).ToArray());
            }
            if (this.isAsc && this.AscFields.Count > 0)
            {
                result = result.AscOrderBy(this.AscFields.Select(x => string.Format("{0}.{1}", this.Table, x)).ToArray());
            }
            if (!this.isAsc && this.DescFields.Count > 0)
            {
                result = result.DescOrderBy(this.DescFields.Select(x => string.Format("{0}.{1}", this.Table, x)).ToArray());
            }
            return result;
        }
    }
}
