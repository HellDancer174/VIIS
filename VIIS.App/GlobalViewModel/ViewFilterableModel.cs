using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIMVVM;

namespace VIIS.App.GlobalViewModel
{
    public abstract class ViewFilterableModel<T>: Notifier
    {
        private T selected;

        public T Selected
        {
            get { return selected; }
            set
            {
                if (value.Equals(selected)) return;
                selected = value;
                Refresh();
            }
        }

        protected abstract void Refresh();

    }
}
