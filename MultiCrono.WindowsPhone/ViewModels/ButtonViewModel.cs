using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using MultiCrono.Commands;


namespace MultiCrono.ViewModels
{
    public class ButtonViewModel : INotifyPropertyChanged
    {

        public DelegateCommand buttonCommand  { get; set; }

        private bool _isEnabled;
        private string _description;

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
               
                _isEnabled = value;
                NotifyPropertyChanged("IsEnabled");
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                NotifyPropertyChanged("Description");
            }
        }
        
        public ButtonViewModel()
        {
            IsEnabled = true;
        }

        public ButtonViewModel(Action exec)
        {
            IsEnabled = true;
            buttonCommand = new DelegateCommand(exec);
        }

        public ButtonViewModel(Action exec, Func<bool> canExec)
        {
            IsEnabled = true;
            buttonCommand = new DelegateCommand(exec, canExec);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }


    }
}
