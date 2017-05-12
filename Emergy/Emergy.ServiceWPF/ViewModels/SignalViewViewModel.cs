using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Emergy.ServiceWPF.Annotations;
using Emergy.ServiceWPF.Models;
using Microsoft.WindowsAzure.MobileServices;

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
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));  
        }
    }
}
