using DateAccess.Abstract;
using DateAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DateAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        readonly List<Product> _products;

        public InMemoryProductDal()
        {
            _products =
            [
                new () { ProductId = 1, CategoryId = 1, ProductName = "Bardak", UnitPrice = 15},
                new () { ProductId = 2, CategoryId = 1, ProductName = "Kamera", UnitPrice = 500  },
                new () { ProductId = 3, CategoryId = 2, ProductName = "Telefon", UnitPrice = 1500 },
                new () { ProductId = 4, CategoryId = 2, ProductName = "Klavye", UnitPrice = 150},
                new () { ProductId = 5, CategoryId = 2, ProductName = "Fare", UnitPrice = 85}
                    

            ];
        }
        public void Add(Product product)
        {
          _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product? productToDelete = null;
            productToDelete = _products.SingleOrDefault(p=> p.ProductId == product.ProductId);
            if (productToDelete != null)
            { 
                _products.Remove(productToDelete); 
            }
        }

        public Product Get(Expression<Func<Product, bool>>? filter)
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                if (filter != null)
                {
                    return context.Set<Product>().SingleOrDefault(filter) ?? throw new ArgumentNullException(nameof(filter));
                }
                else
                {
                    throw new ArgumentNullException(nameof(filter));
                }
            }
        }

        public List<Product> GetAll()
        {
           return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>>? filter = null)
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                return filter == null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList();
            }
        }

        public List<ProductDetailDto> GetProductDetailDtos()
        {
            throw new NotImplementedException();
        }

        public List<Product> GettAllByCategory(int categoryId)
        {
            return _products.Where(p=> p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            
            Product? productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            if (productToUpdate != null)
            {
                productToUpdate.ProductName = product.ProductName;
                productToUpdate.CategoryId = product.CategoryId;
                productToUpdate.UnitPrice = product.UnitPrice;
                //productToUpdate.UnitsInsStock = product.UnitsInsStock;
            }
        }
    }
}
