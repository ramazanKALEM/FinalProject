using Business.Abstract;
using DateAccess.Abstract;
using Entities.Concrete;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public void Add(Order order)
        {
            throw new NotImplementedException();
        }

        public void Delete(Order order)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAll()
        {
           return _orderDal.GetAll();
        }

        public Order GetById(int orderId)
        {
            return _orderDal.Get(p => p.OrderId == orderId);
        }

        public void Update(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
