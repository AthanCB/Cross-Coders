﻿using System;
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

namespace Emergy.Service.WPF.Views
{
	/// <summary>
	/// Interaction logic for EditDepartment.xaml
	/// </summary>
	public partial class EditDepartment : Window
	{
		public EditDepartment()
		{
			InitializeComponent();
		}

		private void BackButton_OnClick(object sender, RoutedEventArgs e)
		{
			this.Close();			
		}

		private void Submit_OnClick(object sender, RoutedEventArgs e)
		{
			//if()
				this.Close();
		}
	}
}