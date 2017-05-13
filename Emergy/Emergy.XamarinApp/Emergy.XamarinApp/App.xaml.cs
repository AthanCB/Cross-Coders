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
        public IMobileServiceTable<User> SyncUsers { get; set; }

        public App()
        {
            InitializeComponent();
            MainPage = new MasterDetailPageView();
        }

        protected async override void OnStart()
        {
            Client = new MobileServiceClient("http://localhost:51800/");
           
            SyncSignals = Client.GetTable<Signal>();
            SyncServices = Client.GetTable<Service>();
            SyncUsers = Client.GetTable<User>();
            Signal s = new Signal
            {
                Id = Guid.NewGuid().ToString("N"),
                Latitude = 23.33323,
                Longitude = 32.32323,
                Own = ServiceOwn.FireDep
            };
            await SyncSignals.InsertAsync(s);
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