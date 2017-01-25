using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CCD.Nback.ViewModels;
using CCD.Nback.Views;

namespace CCD.Nback
{
    public class IntegrationApp
    {
        private readonly IReizAdapter reizAdapter;
        private Test test;
        private readonly IUiAdapter uiAdapter;
        private readonly IProtokollAdapter protokollAdapter;

        private ParameterViewModel parameterViewModel;
        private TestViewModel testViewModel;
        private ErgebnisViewModel ergebnisViewModel;
        public IntegrationApp(IUiAdapter uiAdapter, IProtokollAdapter protokollAdapter, IReizAdapter reizAdapter)
        {
            this.reizAdapter = reizAdapter;
            this.uiAdapter = uiAdapter;
            this.protokollAdapter = protokollAdapter;
        }

        public void Run()
        {

            parameterViewModel = new ParameterViewModel();
            testViewModel = new TestViewModel();
            ergebnisViewModel = new ErgebnisViewModel();

            //nachdem schließen wieder zurück zur Parameter-Eingabe
            ergebnisViewModel.OnClose += ParameterAnzeigen;

            parameterViewModel.OnStarted += parameter =>
            {
                var reiz = TestStarten(parameter);
                testViewModel.ReizSetzen(reiz);
                uiAdapter.SetDataContext(testViewModel);
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

            testViewModel.Finished += (s, args) =>
            {
                ergebnisViewModel.ErgebnisWert = TestAuswerten().Prozent;
                ErgebnisAnzeigen();
            };



            ParameterAnzeigen();
        }

        void ParameterAnzeigen()
        {
            uiAdapter.SetDataContext(parameterViewModel);
        }

        private Reiz TestStarten(Parameter parameter)
        {
            testViewModel.Initialisieren(parameter);

            var reizTeil = reizAdapter.ReizErstellen(parameter);

            test = new Test(reizTeil.ToCharArray(), parameter);
            return test.Next();
        }


        private Reiz ReaktionBehandeln(Reaktion reaktion)
        {
            test.Add(reaktion);

            return test.Next();
        }

        private Ergebnis TestAuswerten()
        {
            var ergebnis = ErgebnisBerechnen();
            // Protokoll schreiben

            ProtokollSchreiben(test);

            return ergebnis;
        }

        private void ProtokollSchreiben(Test test)
        {
            protokollAdapter.Write(test);
        }

        private Ergebnis ErgebnisBerechnen()
        {
            var back = test.Parameter.Nummer;
            //TODO: 2016-12-20 KIE Logik auswerten oder einfach in schön

            var expected = new Reaktion[test.ReizFolge.Length];
            for (int i = 0; i < back; i++)
            {
                expected[i] = Reaktion.KeineWiederholung;
            }

            for (int i = 0; i < test.ReizFolge.Length - back; i++)
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
                Prozent = identiticalCounter / expected.Length
            };
        }

        private void ErgebnisAnzeigen()
        {
            uiAdapter.SetDataContext(ergebnisViewModel);
        }

    }
}
