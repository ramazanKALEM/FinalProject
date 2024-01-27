using Core.DateAccess.EntityFramework;
using DateAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfEntityRepositorybase<Order, NorthWindContext>,IOrderDal
    {
    }
}
