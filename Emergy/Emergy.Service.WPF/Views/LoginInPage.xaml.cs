using System.Windows;

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
		    this.Hide();
	    }
    }
}
