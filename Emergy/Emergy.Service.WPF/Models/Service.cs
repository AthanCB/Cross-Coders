using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Emergy.ServiceWPF.Models
{
    public class Service : INotifyPropertyChanged
    {
        private string _id;
        private string _serviceName;
        private string _username;
        private string _password;
        private double _latitude;
        private double _longitude;

        


        public string Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string SericeName
        {
            get { return _serviceName; }
            set
            {
                _serviceName = value;
                OnPropertyChanged(nameof(SericeName));
            }
        }

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public double Latitude
        {
            get { return _latitude; }
            set
            {
                _latitude = value;
                OnPropertyChanged(nameof(Latitude));
            }
        }

        public double Lognitude
        {
            get { return _longitude; }
            set
            {
                _longitude = value;
                OnPropertyChanged(nameof(Lognitude));
            }
        }


	    public event PropertyChangedEventHandler PropertyChanged;

	    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
	    {
		    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	    }
    }
}
