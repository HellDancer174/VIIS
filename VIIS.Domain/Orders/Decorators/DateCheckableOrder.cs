﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Orders.Decorators
{
    public class DateCheckableOrder : OrderDecorator
    {
        public DateCheckableOrder(Order other) : base(other)
        {
        }


    }
}
