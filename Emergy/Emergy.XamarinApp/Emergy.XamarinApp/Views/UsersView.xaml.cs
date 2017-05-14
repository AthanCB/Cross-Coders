using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emergy.XamarinApp.Models;
using Emergy.XamarinApp.ViewModels;
using Xamarin.Forms;

namespace Emergy.XamarinApp.Views
{
    public partial class UsersView : ContentPage
    {
        public UsersView()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            await ((UserViewViewModel) BindingContext).FetchData();
            UsersListView.ItemsSource = ((UserViewViewModel)BindingContext).Users;
        }

        private async void Search_OnClicked(object sender, EventArgs e)
        {
            foreach (User user in UsersListView.ItemsSource)
            {
                if (user.Username.Equals(UserEntry.Text))
                {
                    if (await DisplayAlert("Προσθήκη Χρήστη", "Προσθήκη χρήστη με Username: " + user.Username + " στα αγαπημένα;", "Ναι", "Άκυρο"))
                    {
                        await ((UserViewViewModel)BindingContext).FetchData();
                    }
                }
            }
        }

        private void Add_OnClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
    } 

