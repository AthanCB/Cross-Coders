using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Emergy.XamarinApp.Views
{
    public partial class UsersView : ContentPage
    {
        public UsersView()
        {
            InitializeComponent();
        }
private void UserEntry_OnUnfocused(object sender, FocusEventArgs e)
        {
            if (!UserEntry.Text.Contains("@"))
            {
                UserEntry.Text = "";
                UserEntry.Placeholder = "Μη έγκυρο e-mail";
                UserEntry.PlaceholderColor = Color.Red;
            }
        }

        private void UserEntry_OnFocused(object sender, FocusEventArgs e)
        {
            UserEntry.BackgroundColor = Color.Transparent;
            UserEntry.Placeholder = "";
            UserEntry.Text = "";
        }
      }
    } 

