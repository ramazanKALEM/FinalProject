using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DateAccess.Abstract;
using DateAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {

        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

       public IResult Add(Product product)
        {
            if (product.ProductName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInValid);
            }
            _productDal.Add(product);

            return new SuccessRsult(Messages.ProductAdded);
        }

      public IResult Delete(Product product)
        { 
            //if ( //Olumsuz buraya gelmesi lazim)
            //{

            //}
            _productDal.Delete(product);
            return new  SuccessRsult(Messages.ProductDelete);
        }

       public IDataResult<List<Product>> GetAll() 
        {  
             if (DateTime.Now.Hour < 24)
            {
                 return new ErrorDataResult<List<Product>>(Messages.MainTenanceTime);
            }
          return new SuccessDataResult<List<Product>>(Messages.ProductListed);
        }


        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p =>p.CategoryId == id));
        }

        public IDataResult<Product>GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitsPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetailDtos()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetailDtos());
        }
        public IResult Update(Product product)
        {  
           if (product.ProductName.Length < 2 && product.ProductName == product.ProductName)
            {
                return new ErrorResult(Messages.CouldNotBeAdded);
            }
            _productDal.Update(product);
          return new SuccessRsult(Messages.productUpdata);

        }

    }
}
