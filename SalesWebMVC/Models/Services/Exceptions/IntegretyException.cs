using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Models.Services.Exceptions
{
    public class IntegretyException : ApplicationException
    {
        public IntegretyException(string mensage) : base(mensage)
        {
        }

    }
}
