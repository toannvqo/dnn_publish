using DotNetNuke.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Christoc.Modules.DNNModule1.Components
{
    public class ProductController
    {
        public Product GetProduct(int productId)
        {
            Product p;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Product>();
                p = rep.GetById(productId);
            }
            return p;
        }
        public IEnumerable<Product> getAll()
        {
            IEnumerable<Product> p;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Product>();
                p = rep.Get();
            }
            return p;
        }

        public void CreateProduct(Product p)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Product>();
                rep.Insert(p);
            }
        }

        public void DeleteProduct(int productId)
        {
            var p = GetProduct(productId);
            DeleteProduct(p);
        }

        public void DeleteProduct(Product p)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Product>();
                rep.Delete(p);
            }
        }

        public void UpdateProduct(Product p)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Product>();
                rep.Update(p);
            }
        }

    }
}