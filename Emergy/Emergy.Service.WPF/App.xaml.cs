using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Emergy.ServiceWPF.Models;
using Microsoft.WindowsAzure.MobileServices;

namespace Emergy.Service.WPF
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
        public IMobileServiceClient Client { get; set; }
        public IMobileServiceTable<ServiceWPF.Models.Service> SyncServices { get; set; }
        public IMobileServiceTable<Signal> SyncSignals { get; set; }

        protected void OnStartUp(StartupEventArgs e)
        {
            Client = new MobileServiceClient("http://localhost:51800/");
            SyncServices = Client.GetTable<ServiceWPF.Models.Service>();
            SyncSignals = Client.GetTable<Signal>();



        }
    }
}
