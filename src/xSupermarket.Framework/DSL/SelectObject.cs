using System.Collections.Generic;
using xSupermarket.Framework.DSL;
using xSupermarket.Framework.Model;
using xSupermarket.Framework.Repo;
using System.Linq;
using System.Text;

namespace xSupermarket.Framework.DSL
{
    public class SelectObject : DslObject
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

        public string GetOutput()
        {
            StringBuilder sb = new StringBuilder(string.Empty);
            switch (this.Table)
            {
                case Category.TABLE:
                    {
                        IResult<Category> result = GetResult<Category>();
                        if (result is IGroupResult<Category>)
                        {
                            IGroupResult<Category> gResult = (IGroupResult<Category>)result;
                            foreach (GroupRecord<Category> gr in gResult.ListGroupingResult())
                            {
                                foreach (object key in gr.GroupKey.Keys)
                                {
                                    sb.Append(key);
                                    sb.Append(", ");
                                }
                                sb.AppendLine();
                                sb.AppendLine("-------------------------------------------------");

                                foreach (Category c in gr.GruopValue.List())
                                {
                                    sb.Append(c.Id);
                                    sb.Append(", ");
                                    sb.AppendLine(c.Name);
                                }
                            }
                        }
                        else
                        {
                            foreach (Category c in result.List())
                            {
                                sb.Append(c.Id);
                                sb.Append(", ");
                                sb.AppendLine(c.Name);
                            }
                        }
                        break;
                    }
                case Employee.TABLE:
                    {
                        IResult<Employee> result = GetResult<Employee>();
                        if (result is IGroupResult<Employee>)
                        {
                            IGroupResult<Employee> gResult = (IGroupResult<Employee>)result;
                            foreach (GroupRecord<Employee> gr in gResult.ListGroupingResult())
                            {
                                foreach (object key in gr.GroupKey.Keys)
                                {
                                    sb.Append(key);
                                    sb.Append(", ");
                                }
                                sb.AppendLine();
                                sb.AppendLine("-------------------------------------------------");

                                foreach (Employee c in gr.GruopValue.List())
                                {
                                    sb.Append(c.Name);
                                    sb.Append(", ");
                                    sb.Append(c.Section.Name);
                                    sb.Append(", ");
                                    sb.AppendLine(c.Sex.ToString());
                                }
                            }
                        }
                        else
                        {
                            foreach (Employee c in result.List())
                            {
                                sb.Append(c.Name);
                                sb.Append(", ");
                                sb.Append(c.Section.Name);
                                sb.Append(", ");
                                sb.AppendLine(c.Sex.ToString());
                            }
                        }
                        break;
                    }
                case Marketbasket.TABLE:
                    {
                        IResult<Marketbasket> result = GetResult<Marketbasket>();
                        if (result is IGroupResult<Marketbasket>)
                        {
                            IGroupResult<Marketbasket> gResult = (IGroupResult<Marketbasket>)result;
                            foreach (GroupRecord<Marketbasket> gr in gResult.ListGroupingResult())
                            {
                                foreach (object key in gr.GroupKey.Keys)
                                {
                                    sb.Append(key);
                                    sb.Append(", ");
                                }
                                sb.AppendLine();
                                sb.AppendLine("-------------------------------------------------");

                                foreach (Marketbasket c in gr.GruopValue.List())
                                {
                                    sb.Append(c.Id);
                                    sb.Append(", ");
                                    sb.AppendLine(c.Product.Name);
                                }
                            }
                        }
                        else
                        {
                            foreach (Marketbasket c in result.List())
                            {
                                sb.Append(c.Id);
                                sb.Append(", ");
                                sb.AppendLine(c.Product.Name);
                            }
                        }
                        break;
                    }
                case Product.TABLE:
                    {
                        IResult<Product> result = GetResult<Product>();
                        if (result is IGroupResult<Product>)
                        {
                            IGroupResult<Product> gResult = (IGroupResult<Product>)result;
                            foreach (GroupRecord<Product> gr in gResult.ListGroupingResult())
                            {
                                foreach (object key in gr.GroupKey.Keys)
                                {
                                    sb.Append(key);
                                    sb.Append(", ");
                                }
                                sb.AppendLine();
                                sb.AppendLine("-------------------------------------------------");

                                foreach (Product c in gr.GruopValue.List())
                                {
                                    sb.Append(c.Name);
                                    sb.Append(", ");
                                    sb.Append(c.Category.Name);
                                    sb.Append(", ");
                                    sb.Append(c.ProductArea.Name);
                                    sb.Append(", ");
                                    sb.Append(c.Section.Name);
                                    sb.Append(", ");
                                    sb.Append(c.Cost);
                                    sb.Append(", ");
                                    sb.Append(c.Price);
                                    sb.Append(", ");
                                    sb.AppendLine(c.Sales.HasValue ? c.Sales.Value.ToString() : "");
                                }
                            }
                        }
                        else
                        {
                            foreach (Product c in result.List())
                            {
                                sb.Append(c.Name);
                                sb.Append(", ");
                                sb.Append(c.Category.Name);
                                sb.Append(", ");
                                sb.Append(c.ProductArea.Name);
                                sb.Append(", ");
                                sb.Append(c.Section.Name);
                                sb.Append(", ");
                                sb.Append(c.Cost);
                                sb.Append(", ");
                                sb.Append(c.Price);
                                sb.Append(", ");
                                sb.AppendLine(c.Sales.HasValue ? c.Sales.Value.ToString() : "");
                            }
                        }
                        break;
                    }
                case ProductArea.TABLE:
                    {
                        IResult<ProductArea> result = GetResult<ProductArea>();
                        if (result is IGroupResult<ProductArea>)
                        {
                            IGroupResult<ProductArea> gResult = (IGroupResult<ProductArea>)result;
                            foreach (GroupRecord<ProductArea> gr in gResult.ListGroupingResult())
                            {
                                foreach (object key in gr.GroupKey.Keys)
                                {
                                    sb.Append(key);
                                    sb.Append(", ");
                                }
                                sb.AppendLine();
                                sb.AppendLine("-------------------------------------------------");

                                foreach (ProductArea c in gr.GruopValue.List())
                                {
                                    sb.Append(c.Id);
                                    sb.Append(", ");
                                    sb.AppendLine(c.Name);
                                }
                            }
                        }
                        else
                        {
                            foreach (ProductArea c in result.List())
                            {
                                sb.Append(c.Id);
                                sb.Append(", ");
                                sb.AppendLine(c.Name);
                            }
                        }
                        break;
                    }
                case Section.TABLE:
                    {
                        IResult<Section> result = GetResult<Section>();
                        if (result is IGroupResult<Section>)
                        {
                            IGroupResult<Section> gResult = (IGroupResult<Section>)result;
                            foreach (GroupRecord<Section> gr in gResult.ListGroupingResult())
                            {
                                foreach (object key in gr.GroupKey.Keys)
                                {
                                    sb.Append(key);
                                    sb.Append(", ");
                                }
                                sb.AppendLine();
                                sb.AppendLine("-------------------------------------------------");

                                foreach (Section c in gr.GruopValue.List())
                                {
                                    sb.Append(c.Id);
                                    sb.Append(", ");
                                    sb.AppendLine(c.Name);
                                }
                            }
                        }
                        else
                        {
                            foreach (Section c in result.List())
                            {
                                sb.Append(c.Id);
                                sb.Append(", ");
                                sb.AppendLine(c.Name);
                            }
                        }
                        break;
                    }
            }
            return sb.ToString();
        }
    }
}
