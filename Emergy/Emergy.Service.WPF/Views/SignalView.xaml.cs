using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Emergy.ServiceWPF.Views;
using System.ComponentModel;
using Emergy.Service.WPF.ViewModels;
using Microsoft.WindowsAzure.MobileServices;

namespace Emergy.Service.WPF.Views
{
	/// <summary>
	/// Interaction logic for SignalView.xaml
	/// </summary>
	public partial class SignalView : Window, INotifyPropertyChanged
	{
		
		public SignalView()
		{
			InitializeComponent();			
		}

		public async override void EndInit()
		{
			base.EndInit();
			var list = await  (Application.Current as App).SyncSignals.ToCollectionAsync();
		}

		private void Back_OnClickack_Click(object sender, RoutedEventArgs e)
		{			
			LoginInPage lpInPage = new LoginInPage();
			lpInPage.Show();
			this.Close();
		}

		private void Accidents_OnClick(object sender, RoutedEventArgs e)
		{
			AccidentsList.Visibility = Visibility.Visible;
			StatisticsList.Visibility = Visibility.Hidden;
			Map.Visibility = Visibility.Hidden;
		}

		private void Statistics_OnClick(object sender, RoutedEventArgs e)
		{
			AccidentsList.Visibility = Visibility.Hidden;
			Map.Visibility = Visibility.Hidden;
			StatisticsList.Visibility = Visibility.Visible;
		}

		private void Maps_OnClick(object sender, RoutedEventArgs e)
		{
			AccidentsList.Visibility = Visibility.Hidden;
			Map.Visibility = Visibility.Visible;
			StatisticsList.Visibility = Visibility.Hidden;
		}

		private void EditDepartment_OnClick(object sender, RoutedEventArgs e)
		{
			//this.Close();
			EditDepartment ed= new EditDepartment();
			ed.Show();				
		}

		event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
		{
			add
			{
				
			}
			remove
			{
				
			}
		}
		
	}
}
