using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xSupermarket.Framework.Repo;

namespace xSupermarket.Framework.Model
{
    public interface IModel
    {
        object GetValue(string fieldName);
    }
}
