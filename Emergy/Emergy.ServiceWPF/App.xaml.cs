using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Emergy.ServiceWPF.Models;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;

namespace Emergy.ServiceWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    { 
        private IMobileServiceClient Client { get; set; }
        private IMobileServiceTable<Service> Services { get; set; }
        private IMobileServiceTable<Signal> SyncSignals { get; set; }

        protected void OnStartUp(StartupEventArgs e)
        {

        }
    }

    
}
