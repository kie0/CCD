using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CCD.Nback.Annotations;
using CCD.Nback.Helper;

namespace CCD.Nback.ViewModels
{
    public class ErgebnisViewModel : INotifyPropertyChanged
    {
        private double ergebnisWert;

        public ErgebnisViewModel()
        {
            CloseCommand = new RelayCommand(() => { OnClose(); });
        }

        public ICommand CloseCommand { get; set; }

        public double ErgebnisWert
        {
            get { return ergebnisWert; }
            set
            {
                ergebnisWert = value;
                OnPropertyChanged();
            }
        }

        public Action OnClose { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}