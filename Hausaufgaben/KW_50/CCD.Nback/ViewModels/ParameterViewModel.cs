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
        private int nummer = 3;
        private string proband = "test";
        private int reizdauer = 3000;
        private int reizeAnzahl = 10;

        public ParameterViewModel()
        {
            StartCommand = new RelayCommand(
                () => { OnStarted(new Parameter(proband, reizdauer, nummer, reizeAnzahl)); }, GetIsModelValid);
        }

        public RelayCommand StartCommand { get; set; }

        public Action<Parameter> OnStarted { get; set; }

        public string Proband
        {
            get { return proband; }
            set
            {
                proband = value;
                OnPropertyChanged();
            }
        }

        public int Reizdauer
        {
            get { return reizdauer; }
            set
            {
                reizdauer = value;
                OnPropertyChanged();
            }
        }

        public int Nummer
        {
            get { return nummer; }
            set
            {
                nummer = value;
                OnPropertyChanged();
            }
        }

        public int ReizeAnzahl
        {
            get { return reizeAnzahl; }
            set
            {
                reizeAnzahl = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private bool GetIsModelValid(object parameter)
        {
            return Nummer > 0 && Nummer < 10 && Reizdauer > 0 && ReizeAnzahl > 9 && reizeAnzahl < 101 &&
                   !string.IsNullOrEmpty(Proband);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            StartCommand.RaiseCanExecuteChanged();
        }
    }
}