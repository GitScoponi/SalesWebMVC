﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Models
{
    public enum SaleStatus : int
    {
        Pending = 0,
        Billed = 1,
        Calceled = 2
    }
}