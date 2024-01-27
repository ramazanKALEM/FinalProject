using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessRsult : Result
    {
        public  SuccessRsult (string message):base(true, message) 
        {
              
        }
        public SuccessRsult():base(true)
        {

        }
    }
}
