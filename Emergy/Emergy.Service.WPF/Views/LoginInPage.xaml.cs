using System.Windows;
using Emergy.Service.WPF.Views;

namespace Emergy.ServiceWPF.Views
{
	/// <summary>
    /// Interaction logic for LoginInPage.xaml
    /// </summary>
    public partial class LoginInPage : Window
    {
        public LoginInPage()
        {
            InitializeComponent();
        }

	    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
	    {		    
			SignalView signalView = new SignalView();
			signalView.Show();
		    this.Hide();
		}
    }
}
