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

        private async void Signup_OnClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AccountView());
        }

        private async void Button_OnClick(object sender, EventArgs e)
        {
            ButtonStackLayout.IsVisible = false;
            LoadingLabel.Text = "Παρακαλώ περιμένετε...";
            LoadingStackLayout.IsVisible = true;
            Indicator.IsRunning = true;
            Indicator.IsVisible = true;

            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;
                var position = await locator.GetPositionAsync(100000);

                lat = position.Latitude;
                lng = position.Longitude;

                LoadingLabel.Text = "Αποστολή σήματος κινδύνου...";

                Signal signal = new Signal();
                signal.Id = Guid.NewGuid().ToString("N");
                signal.Latitude = lat;
                signal.Longitude = lng;
                if ((Button)sender == FireDepButton)
                    signal.Own = ServiceOwn.FireDep;
                else if ((Button)sender == HospButton)
                    signal.Own = ServiceOwn.Hospital;
                else if ((Button)sender == PoliceButton)
                    signal.Own = ServiceOwn.Police;
                /*else
                    signal.Own = ServiceOwn.RoadAssist;*/

                await (Application.Current as App).SyncSignals.InsertAsync(signal);

                LoadingStackLayout.IsVisible = false;
                LoadingLabel.Text = "Παρακαλώ περιμένετε...";
                Indicator.IsRunning = false;
                Indicator.IsVisible = false;

                await DisplayAlert("Επιτυχία!", "Το σήμα κινδύνου στάλθηκε επιτυχώς!", "ΟΚ");
                ButtonStackLayout.IsVisible = true;
            }
            catch (Exception ex)
            {
                LoadingStackLayout.IsVisible = false;
                LoadingLabel.Text = "Παρακαλώ περιμένετε...";
                Indicator.IsRunning = false;
                Indicator.IsVisible = false;

                if (!await DisplayAlert("Αποτυχία!", "Η αποστολή σήματος κινδύνου απέτυχε! Ελέγξτε αν είναι ενεργοποιημένη η τοποθεσίας σας.", "ΟΚ", "Προσπαθήστε ξανά!"))
                    Button_OnClick(sender, e);
                ButtonStackLayout.IsVisible = true;
            }
        }
    }
}