using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService
    {
        List<Order> GetAll();

        Order GetById(int orderId);
        public void Add(Order order);
        public void Update(Order order);
        public void Delete(Order order);


    }
}
