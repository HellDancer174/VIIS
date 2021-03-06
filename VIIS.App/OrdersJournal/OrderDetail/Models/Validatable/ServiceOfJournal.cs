using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VIIS.Domain.Global;
using VIIS.Domain.Services;
using VIIS.Domain.Services.Decorators;

namespace VIIS.App.OrdersJournal.OrderDetail.Models.Validatable
{
    public class ServiceOfJournal : ServiceDecorator
    {
        private ValidProperty<TimeSpan> validTimespan;
        private ValidProperty<int> validID;

        public ServiceOfJournal(Service other) : base(other)
        {
            validTimespan = new ValidProperty<TimeSpan>(String.Format("Продолжительность сервиса {0}", ToString()), timeSpan, timeSpan != new TimeSpan());
            validID = new ValidProperty<int>(String.Format("Идентификатор сервиса {0}", ToString()), id, id > 0);
        }

        public Service Safe()
        {
            try
            {
                return UnSafe();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        public Service UnSafe()
        {
            validTimespan.Validate();
            validID.Validate();
            return this;
        }
    }
}
