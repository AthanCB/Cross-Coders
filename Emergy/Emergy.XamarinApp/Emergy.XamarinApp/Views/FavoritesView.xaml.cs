using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Emergy.XamarinApp.Views
{
    public partial class FavoritesView : ContentPage
    {
        public FavoritesView()
        {
            InitializeComponent();
        }

       

        private void UsernameEntry_OnUnfocused(object sender, FocusEventArgs e)
        {
            if (!UsernameEntry.Text.Contains("@"))
            {
                UsernameEntry.Text = "";
                UsernameEntry.Placeholder = "Μη έγκυρο e-mail";
                UsernameEntry.PlaceholderColor = Color.Red;
            }
        }

        private void UsernameEntry_OnFocused(object sender, FocusEventArgs e)
        {
            UsernameEntry.BackgroundColor = Color.Transparent;
            UsernameEntry.Placeholder = "";
            UsernameEntry.Text = "";
        }
    }
}
