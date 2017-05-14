using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivityTracker.Models;
using Plugin.Geolocator;
using Xamarin.Forms;
using Java.Util;
using System.Threading;
using Java.Lang;
using Exception = System.Exception;

namespace ActivityTracker
{
    public partial class MainPage : ContentPage
    {
        private int Heartrate;
        Timer timer = new Timer();
        public MainPage()
        {
            InitializeComponent();
            timer = new Timer();
            Heartrate = 60;
            HeartrateLabel.Text = Heartrate.ToString();
        }

        private void Plus_OnClicked(object sender, EventArgs e)
        {
            Heartrate += 10;
            HeartrateLabel.Text = Heartrate.ToString();
        }

        private void Minus_OnClicked(object sender, EventArgs e)
        {
            Heartrate -= 10;
            HeartrateLabel.Text = Heartrate.ToString();
            if (Heartrate < 20)
                SendSignal();
        }
            
        private async void SendSignal()
        {
            stacklayout.IsVisible = false;
            LoadingLabel.Text = "Εύρεση τοποθεσίας...";
            LoadingStackLayout.IsVisible = true;
            Indicator.IsRunning = true;
            Indicator.IsVisible = true;

            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;
                var position = await locator.GetPositionAsync(100000);

                LoadingLabel.Text = "Αποστολή σήματος κινδύνου...";

                Signal signal = new Signal();
                signal.Id = Guid.NewGuid().ToString("N");
                signal.Latitude = position.Latitude;
                signal.Longitude = position.Longitude;
                signal.Own = ServiceOwn.FireDep;

                await (Application.Current as App).SyncSignals.InsertAsync(signal);

                LoadingStackLayout.IsVisible = false;
                Indicator.IsRunning = false;
                Indicator.IsVisible = false;

                await DisplayAlert("Επιτυχία!", "Το σήμα κινδύνου στάλθηκε επιτυχώς!", "ΟΚ");
                stacklayout.IsVisible = true;
            }
            catch (Exception ex)
            {
                LoadingStackLayout.IsVisible = false;
                Indicator.IsRunning = false;
                Indicator.IsVisible = false;

                if (!await DisplayAlert("Αποτυχία!", "Η αποστολή σήματος κινδύνου απέτυχε! Ελέγξτε αν είναι ενεργοποιημένη η τοποθεσίας σας.", "ΟΚ", "Προσπαθήστε ξανά!"))
                    SendSignal();
                stacklayout.IsVisible = true;
            }
            Heartrate = 60;
            HeartrateLabel.Text = Heartrate.ToString();
        }
    }
}
