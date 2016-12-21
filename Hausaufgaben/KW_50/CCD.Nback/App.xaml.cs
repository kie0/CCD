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
        private Test test;
        private MainDialog dialog;
        private ParameterViewModel parameterViewModel;
        private TestViewModel testViewModel;
        private ErgebnisViewModel ergebnisViewModel;

        protected override void OnStartup(StartupEventArgs e)
        {
            dialog = new MainDialog();
            parameterViewModel = new ParameterViewModel();
            testViewModel = new TestViewModel();
            ergebnisViewModel = new ErgebnisViewModel();

            //nachdem schließen wieder zurück zur Parameter-Eingabe
            ergebnisViewModel.OnClose += ParameterAnzeigen;

            parameterViewModel.OnStarted += parameter =>
            {
                var reiz = TestStarten(parameter);
                testViewModel.ReizSetzen(reiz);
                dialog.SetDataContext(testViewModel);
            };

            testViewModel.OnNext += reaktion =>
            {
                var innerReiz = ReaktionBehandeln(reaktion);
                testViewModel.ReizSetzen(innerReiz);
            };

            testViewModel.OnCancel += () =>
            {               
                ergebnisViewModel.ErgebnisWert = TestAuswerten().Prozent;
                ErgebnisAnzeigen();
            };

            testViewModel.Finished += (s,args) =>
            {
                ergebnisViewModel.ErgebnisWert = TestAuswerten().Prozent;
                ErgebnisAnzeigen();
            };

            

            ParameterAnzeigen();
            dialog.Show();
        }

        void ParameterAnzeigen()
        {
            dialog.SetDataContext(parameterViewModel);
        }

        private Reiz TestStarten(Parameter parameter)
        {
            testViewModel.Initialisieren(parameter);

            //todo: Ausgefuxte Technik für die Erstellung einer Reizfolge
            string reizend = "AAAAAAAAAATLHCHSCCQLCKLHTLHCHSCCQLCKLHTLHCHSCCQLCKLHTLHCHSCCQLCKLH";
            var reizTeil = reizend.Substring(0, parameter.ReizeAnzahl);

            test = new Test(reizTeil.ToCharArray());
            return test.Next();
        }

        
        private Reiz ReaktionBehandeln(Reaktion reaktion)
        {
            test.Add(reaktion);

            return test.Next();
        }

        private Ergebnis TestAuswerten()
        {
            var back = 3;
            //TODO: 2016-12-20 KIE Logik auswerten oder einfach in schön

            var expected = new Reaktion[test.ReizFolge.Length];
            for (int i = 0; i < back
                ; i++)
            {
                expected[i]=Reaktion.KeineWiederholung;
            }

            for (int i = 0; i < test.ReizFolge.Length-back; i++)
            {
                var precessor = test.ReizFolge[i];
                var successor = test.ReizFolge[i + back];
                expected[i + back] = successor == precessor ? Reaktion.WiederholungErkannt : Reaktion.KeineWiederholung;

            }


            double identiticalCounter = 0;
            for (int i = 0; i < expected.Length; i++)
            {
                var reaktion = test.ReaktionsFolge[i];
                if (reaktion == expected[i])
                    identiticalCounter++;
            }
            

            return new Ergebnis
            {
                Prozent = identiticalCounter/expected.Length
            };
        }

        private void ErgebnisAnzeigen()
        {
            dialog.SetDataContext(ergebnisViewModel);
        }

    }
}
