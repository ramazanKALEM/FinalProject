using Business.Concrete;
using Business.Constants;
using Core.DateAccess;
using DateAccess.Concrete.EntityFramework;
using DateAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main()
        {
            ProducktTest();
            CategoryTest();
            OrderTest();
            Console.WriteLine("Deneme");
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }


        }

        private static void OrderTest()
        {
            OrderManager orderManager = new OrderManager(new EfOrderDal());
            foreach (var order in orderManager.GetAll() )
            {
                Console.WriteLine(order.OrderId);
            }
        }

        private static void ProducktTest()
        {
            Console.WriteLine("Hello World!");

            //  Product_Manager   new lendiğinded değiştirilmesi beklenen kısım InmemoryProductDal --- EfProductDal
            ProductManager productManager = new ProductManager(new EfProductDal());

            var result = productManager.GetProductDetailDtos();
            if (result.Success ==true )
            {
                foreach (var product in productManager.GetProductDetailDtos().Data)
                {
                    Console.WriteLine(product.ProductId + "/" + product.CategoryName);
                }
            }
           else
            {
                Console.WriteLine(result.Message);
            }
           
        }
    }
}