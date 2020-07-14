using System;

namespace SalesWebMVC.Models.Services.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string ex) : base(ex)
        {

        }
    }
}
