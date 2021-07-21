using ElegantLib.Authorize.Tokenize;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace VIIS.App
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static RefreshViewModel Token;
        static App()
        {
            Token = new RefreshViewModel();
        }
    }
}
