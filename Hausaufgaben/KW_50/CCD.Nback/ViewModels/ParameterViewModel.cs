#region Header
// ============================================================================================
//   Projekt:   CCD5-2016/12/13
//  
//   (C) Copyright 2008-2016 CP Corporate Planning AG
//   http://www.corporate-planning.com
//  
//   Alle Rechte vorbehalten. All rights reserved.
// ============================================================================================
#endregion

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CCD.Nback.Annotations;
using CCD.Nback.Helper;

namespace CCD.Nback.ViewModels
{
    public class ParameterViewModel : INotifyPropertyChanged
    {
        private int reizdauer = 3000;
        private int nummer = 3;
        private int reizeAnzahl = 10;
        private string proband = "test";

        public RelayCommand StartCommand { get; set; }

        public Action<Parameter> OnStarted { get; set; }

        public ParameterViewModel()
        {
            StartCommand = new RelayCommand(() =>
            {
                OnStarted(new Parameter(proband, reizdauer, nummer, reizeAnzahl));
            }, GetIsModelValid);
        }

        public string Proband
        {
            get { return proband; }
            set
            {
                proband = value;
                OnPropertyChanged(nameof(Proband));
            }
        }

        public int Reizdauer
        {
            get { return reizdauer; }
            set
            {
                reizdauer = value; 
                OnPropertyChanged(nameof(Reizdauer));
            }
        }

        public int Nummer
        {
            get { return nummer; }
            set
            {
                nummer = value;
                OnPropertyChanged(nameof(Nummer));
            }
        }

        public int ReizeAnzahl
        {
            get { return reizeAnzahl; }
            set
            {
                reizeAnzahl = value;
                OnPropertyChanged(nameof(ReizeAnzahl));
            }
        }

        private bool GetIsModelValid(object parameter)
        {
            return Nummer > 0 && Nummer < 10 && Reizdauer > 0 && ReizeAnzahl > 9 && reizeAnzahl < 101 && !string.IsNullOrEmpty(Proband);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            StartCommand.RaiseCanExecuteChanged();
        }
    }
}