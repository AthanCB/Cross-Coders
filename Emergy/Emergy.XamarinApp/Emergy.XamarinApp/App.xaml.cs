using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emergy.XamarinApp.Models;
using Emergy.XamarinApp.Views;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

namespace Emergy.XamarinApp
{
    public partial class App : Application
    {
        public MobileServiceClient Client { get; set; }
        public IMobileServiceTable<Service> SyncServices { get; set; }
        public IMobileServiceTable<Signal> SyncSignals { get; set; }

        public App()
        {
            InitializeComponent();
            MainPage = new TabbedPageView();
        }

        protected override void OnStart()
        {
//            Client = new MobileServiceClient("http://emergy.azurewebsites.net/");
//           
//            SyncSignals = Client.GetTable<Signal>();
//            SyncServices = Client.GetTable<Service>();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}