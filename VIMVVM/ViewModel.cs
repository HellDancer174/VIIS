using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace VIMVVM
{
    public class Notifier<T>: Notifier, IViewModel<T>
    {
        /// <summary>
        /// Строит сущность в соответствии с предаставлением. ВАЖНО: этот метод должет быть обязательно переопределен.
        /// </summary>
        /// <returns></returns>
        public virtual T Model()
        {
            throw new NotImplementedException(String.Format("Метод {0} в классе {1} должен быть переопределен!", nameof(Model), GetType().Name));
        }
    }
    public class Notifier: INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void ChangeProperty([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void ChangeProperties(params string[] propertyNames)
        {
            foreach (var propertyName in propertyNames)
                ChangeProperty(propertyName);
        }
    }

}
