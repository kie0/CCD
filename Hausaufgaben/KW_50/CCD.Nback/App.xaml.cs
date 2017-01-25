using System;
using System.Linq;
using System.Windows;
using CCD.Nback.ViewModels;
using CCD.Nback.Views;

namespace CCD.Nback
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var dialog = new MainDialog();
            var protokollAdapter = new ProtokollAdapter();
            var reizAdapter = new ReizAdapter();
            var app = new IntegrationApp(dialog, protokollAdapter, reizAdapter);
            app.Run();
            dialog.Show();
        }
    }
}
