using System;
using System.Threading;
using CCD.Nback;
using CCD.Nback.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CCD.Nback.Tests
{
    [TestClass]
    public class ViewModelTests
    {
        [TestMethod]
        public void ParameterViewModelTest()
        {
            var pvm = new ParameterViewModel();
            Parameter parameterResult = null;
            pvm.OnStarted = parameter => parameterResult = parameter;

            pvm.Nummer = 5;
            pvm.Proband = "Carl";
            pvm.Reizdauer = 15;
            pvm.ReizeAnzahl = 25;
            pvm.StartCommand.Execute(this);

            Assert.IsNotNull(parameterResult);
            Assert.AreEqual(pvm.Nummer, parameterResult.Nummer);
            Assert.AreEqual(pvm.Proband, parameterResult.Proband);
            Assert.AreEqual(pvm.Reizdauer, parameterResult.Reizdauer);
            Assert.AreEqual(pvm.ReizeAnzahl, parameterResult.ReizeAnzahl);
        }

        [TestMethod]
        public void ErgebnisViewModelTest()
        {
            var evm = new ErgebnisViewModel();
            bool closed = false;
            evm.OnClose = () => closed = true;
            evm.CloseCommand.Execute(this);
            Assert.AreEqual(true, closed);
        }

        [TestMethod]
        public void TestViewModelCancelTest()
        {
            var tvm = new TestViewModel();
            var parameter = new Parameter("Carl", 2000, 3, 10);
            tvm.Initialisieren(parameter);
            bool cancelPressed = false;
            tvm.OnCancel = () => cancelPressed = true;
            tvm.CancelCommand.Execute(this);

            Assert.AreEqual(true, cancelPressed);


        }
        [TestMethod]
        public void TestViewModelNextTest()
        {
            var tvm = new TestViewModel();
            var parameter = new Parameter("Carl", 300, 3, 10);
            tvm.Initialisieren(parameter);

            Reaktion reaktionResult = Reaktion.KeineAntwort;
            tvm.OnNext = reaktion => reaktionResult = reaktion;
            tvm.NextCommand.Execute(this);
            Assert.AreEqual(Reaktion.KeineWiederholung, reaktionResult);

            reaktionResult = Reaktion.KeineAntwort;
            tvm.DetectCommand.Execute(this);
            Assert.AreEqual(Reaktion.WiederholungErkannt, reaktionResult);

            reaktionResult = Reaktion.KeineAntwort;
            Thread.Sleep(550);
            Assert.AreEqual(Reaktion.KeineWiederholung, reaktionResult);

        }

    }
}
