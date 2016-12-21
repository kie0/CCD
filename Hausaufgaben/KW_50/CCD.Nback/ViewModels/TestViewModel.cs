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
using System.Timers;
using System.Windows.Input;
using CCD.Nback.Annotations;
using CCD.Nback.Helper;

namespace CCD.Nback.ViewModels
{
    public class TestViewModel: INotifyPropertyChanged
    {
        private Timer timer;
        private char buchstabe;
        private int reizdauer = 3000;
        private int restdauer = 3000;
        private int progress = 100;
        private string testProgress;

        public TestViewModel()
        {
            NextCommand = new RelayCommand(NextCommandExecute);
            CancelCommand = new RelayCommand(CancelExecute);
            DetectCommand = new RelayCommand(DetectCommandExecute);
        }


        /// <summary>
        /// Der <see cref="ICommand"/> für den Aufruf des nächsten Reiz.
        /// </summary>
        public ICommand NextCommand { get; set; }

        private void NextCommandExecute()
        {
            OnNext(Reaktion.KeineWiederholung);
            restdauer = reizdauer;
        }

        public ICommand DetectCommand { get; set; }

        private void DetectCommandExecute()
        {
            OnNext(Reaktion.WiederholungErkannt);
            restdauer = reizdauer;
        }



        /// <summary>
        /// zugehörige <see cref="Action"/> für Abschluss eines Testschrittes
        /// </summary>
        public Action<Reaktion> OnNext { get; set; }

        /// <summary>
        /// Der <see cref="ICommand"/> für den Abbruch des laufenden Tests.
        /// </summary>
        public ICommand CancelCommand { get; set; }

        private void CancelExecute()
        {
            timer.Stop();
            OnCancel();
        }

        /// <summary>
        /// Die zum <see cref="CancelCommand"/> zugehörige <see cref="Action"/>
        /// </summary>
        public Action OnCancel { get; set; }
        

        public event EventHandler Finished;

        protected virtual void OnFinished()
        {
            Finished?.Invoke(this, EventArgs.Empty);
        }
        

        public void Initialisieren(Parameter parameter)
        {
            reizdauer = parameter.Reizdauer;
            restdauer = parameter.Reizdauer;

            timer = new Timer(200);
            timer.Elapsed += (s, e) =>
            {
                restdauer -= 200;
                Progress = restdauer * 100 / reizdauer;

                if (restdauer <= 0)
                {
                    NextCommandExecute();
                }
                
            };
            timer.Start();
        }

        public void ReizSetzen(Reiz neuerReiz)
        {
            if (neuerReiz != null)
            {
                Buchstabe = neuerReiz.Buchstabe;
                TestProgress = $"{neuerReiz.Index+1}/{neuerReiz.Total}";
            }
            else
            {
                timer.Stop();
                Buchstabe = '-';
                OnFinished();
            }
        }


        public string TestProgress
        {
            get { return testProgress; }
            set { testProgress = value; OnPropertyChanged(nameof(TestProgress));}
        }

        public char Buchstabe
        {
            get { return buchstabe; }
            set
            {
                buchstabe = value;
                OnPropertyChanged(nameof(Buchstabe));
            }
        }

        public int Progress
        {
            get { return progress; }
            set
            {
                progress = value; 
                OnPropertyChanged(nameof(Progress));
            }
        }

        

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
    }
}