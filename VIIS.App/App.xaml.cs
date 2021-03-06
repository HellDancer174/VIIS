using ElegantLib.Authorize.Tokenize;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Threading.Tasks;
using System.Windows;
using VIIS.Domain.Global;

namespace VIIS.App
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static RefreshViewModel Token { get; set; }
        public static User CurrentUser { get; set; }
        static App()
        {
            Token = new RefreshViewModel();
            CurrentUser = new User();
        }
        public App()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) =>
            {
                return errors == SslPolicyErrors.RemoteCertificateChainErrors;
            };
        }
    }
}
