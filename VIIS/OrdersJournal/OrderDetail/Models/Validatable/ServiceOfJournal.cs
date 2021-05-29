using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Services;
using VIIS.Domain.Services.Decorators;

namespace VIIS.App.OrdersJournal.OrderDetail.Models.Validatable
{
    public class ServiceOfJournal : ServiceDecorator
    {

        public ServiceOfJournal(Service other) : base(other)
        {

        }
    }
}
