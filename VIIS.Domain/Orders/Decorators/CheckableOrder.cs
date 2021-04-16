using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Orders.Decorators
{
    public class CheckableOrder<T> : OrderDecorator
    {
        protected readonly CheckableOrder<T> checkableOther;
        protected readonly T checker;

        public CheckableOrder(Order other, T checker) : base(other)
        {
            this.checker = checker;
        }
        public CheckableOrder(CheckableOrder<T> checkableOther): this((Order)checkableOther, checkableOther.checker)
        {
            this.checkableOther = checkableOther;
        }

        public virtual bool Check() => true;

    }
}
