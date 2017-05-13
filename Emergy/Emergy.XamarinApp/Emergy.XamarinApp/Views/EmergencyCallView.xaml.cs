using Plugin.Geolocator;
using System;
using Emergy.XamarinApp.Models;
using Xamarin.Forms;

namespace Emergy.XamarinApp.Views
{
    public partial class EmergencyCallView : ContentPage
    {
        private double lat;
        private double lng;

        public EmergencyCallView()
        {
            InitializeComponent();
        }

        private async void Button_OnClick(object sender, EventArgs e)
        {
            Indicator.IsRunning = true;
            Indicator.IsVisible = true;

            try
            {
                var locator = CrossGeolocator.Current;

                locator.DesiredAccuracy = 50;

                var position = await locator.GetPositionAsync(100000);

                lat = position.Latitude;
                lng = position.Longitude;

                CoordsLabel.Text = "Position Latitude: " + lat + "\nPosition Longitude: " +lng;

                Signal signal = new Signal();
                signal.Id = Guid.NewGuid().ToString("N");
                signal.Latitude = lat;
                signal.Longitude = lng;
                if ((Button)sender == FireDepButton)
                    signal.Own = ServiceOwn.FireDep;
                else if((Button)sender == HospButton)
                    signal.Own = ServiceOwn.Hospital;
                else if((Button)sender == PoliceButton)
                signal.Own = ServiceOwn.Police;
                /*else
                    signal.Own = ServiceOwn.RoadAssist;*/

                await (Application.Current as App).SyncSignals.InsertAsync(signal);
            }
            catch (Exception ex)
            {
                CoordsLabel.Text = "Unable to get address!";
            }

            Indicator.IsRunning = false;
            Indicator.IsVisible = false;
        }
    }
}
