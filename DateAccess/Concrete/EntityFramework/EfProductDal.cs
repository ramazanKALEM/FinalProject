    using Core.DateAccess.EntityFramework;
using DateAccess.Abstract;
using DateAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace   Core.DateAccess
{
    public class EfProductDal : EfEntityRepositorybase<Product, NorthWindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetailDtos()
        {
            using (NorthWindContext context  = new NorthWindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.ProductId equals c.CategoryId
                             select new ProductDetailDto
                             {
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 UnitsInStcok = p.UnitsInStock
                             };
                return result.ToList();
            }
        }
    }
}
