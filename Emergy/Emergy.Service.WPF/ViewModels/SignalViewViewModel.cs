using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Emergy.Service.WPF;
using Emergy.ServiceWPF.Models;
using Microsoft.WindowsAzure.MobileServices;
using System.Windows;

namespace Emergy.ServiceWPF.ViewModels
{
    class SignalViewViewModel : INotifyPropertyChanged
    {
        private MobileServiceCollection<Signal, Signal> _signals;

        public MobileServiceCollection<Signal, Signal> Signals
        {
            get
            {
                return _signals;
            }
            set
            {
                _signals = value;
                OnPropertyChanged(nameof(Signals));
            }
        }

        public async Task FetchData()
        {
            Signals = await (Application.Current as App).SyncSignals.ToCollectionAsync();
        }


	    public event PropertyChangedEventHandler PropertyChanged;

	    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
	    {
		    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	    }
    }
}
