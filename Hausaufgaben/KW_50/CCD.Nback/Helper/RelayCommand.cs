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
using System.Windows.Input;

namespace CCD.Nback.Helper
{
    public class RelayCommand : ICommand
    {
        private readonly Action _onExecute;
        private readonly Func<object, bool> _onCanExecute;

        public RelayCommand(Action onExecute)
        {
            _onExecute = onExecute;
        }

        public RelayCommand(Action onExecute, Func<object, bool> onCanExecute) : this(onExecute)
        {
            _onCanExecute = onCanExecute;
            RaiseCanExecuteChanged();
        }

        public bool CanExecute(object parameter)
        {
            return _onCanExecute == null || _onCanExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _onExecute();
        }

        /// <summary>
		/// RaiseCanExecuteChanged
		/// </summary>
		public void RaiseCanExecuteChanged()
        {
            OnCanExecuteChanged(EventArgs.Empty);
        }

        /// <summary>
        /// Raise CanExecuteChanged Event
        /// </summary>
        public void OnCanExecuteChanged(EventArgs args)
        {
            EventHandler handler = CanExecuteChanged;
            handler?.Invoke(this, args);

            //var dispatcher = (Dispatcher)null;
            //if (Application.Current != null)
            //    dispatcher = Application.Current.Dispatcher;
            //EventHandler eventHandler = this.CanExecuteChanged;
            //if (eventHandler == null)
            //    return;
            //if (dispatcher != null && !dispatcher.CheckAccess())
            //    dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => OnCanExecuteChanged(args)));
            //else
            //    eventHandler(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged;
    }
}