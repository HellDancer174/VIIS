using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Services;
using VIMVVM.Detail;

namespace VIIS.App.Services.ViewModels
{
    public class ViewServiceValue : ServiceValue, IEquatable<ViewServiceValue>, IDetailedViewModel
    {

        public ViewServiceValue(ServiceValue other) : base(other)
        {
        }
        public ViewServiceValue(): this(new ServiceValue())
        {
        }

        public string Name
        {
            get => name;
            set
            {
                if (name == value) return;
                name = value;
                ChangeProperty();
            }
        }
        public decimal Price
        {
            get => Sale;
            set
            {
                if (value == sale) return;
                sale = value;
                ChangeProperty();
            }
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ViewServiceValue);
        }

        public bool Equals(ViewServiceValue other)
        {
            return other != null &&
                   base.Equals(other);
        }

        public override int GetHashCode()
        {
            var hashCode = -44027456;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Price.GetHashCode();
            return hashCode;
        }

        public void NotifySelector()
        {
            throw new NotImplementedException();
        }
    }
}
