using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCD.Nback.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CCD.Nback.Tests
{
    [TestClass]
    public class AppTests
    {
        [TestMethod]
        public void FullTest()
        {
            var uiAdapter = new UiAdapterMock();
            var protokollAdapter = new ProtokollAdapterMock();
            var reizAdapterMock = new ReizAdapterMock() {Reiz = "DAFAG"};
            var app = new IntegrationApp(uiAdapter,protokollAdapter,reizAdapterMock  );

            var startDate = DateTime.Now;
            app.Run();

            var pvm = uiAdapter.Get<ParameterViewModel>();
            Assert.IsNotNull(pvm);

            pvm.Nummer = 2;
            pvm.Proband = "carl";
            pvm.ReizeAnzahl = 5;
            pvm.Reizdauer = 2000;
            pvm.StartCommand.Execute(this);

            var tvm = uiAdapter.Get<TestViewModel>();
            Assert.IsNotNull(tvm);
            Assert.AreEqual('D',tvm.Buchstabe);
            tvm.NextCommand.Execute(this);
            Assert.AreEqual('A', tvm.Buchstabe);
            tvm.NextCommand.Execute(this);
            Assert.AreEqual('F', tvm.Buchstabe);
            tvm.NextCommand.Execute(this);
            Assert.AreEqual('A', tvm.Buchstabe);
            tvm.DetectCommand.Execute(this);
            Assert.AreEqual('G', tvm.Buchstabe);
            tvm.NextCommand.Execute(this);

            var endDate = DateTime.Now;

            var evm = uiAdapter.Get<ErgebnisViewModel>();
            Assert.IsNotNull(evm);

            Assert.AreEqual(1.0,evm.ErgebnisWert,0.001);

            Assert.AreEqual(5,protokollAdapter.Result.Index);

            Assert.IsTrue(startDate<protokollAdapter.Result.StartDate);
            Assert.IsTrue(protokollAdapter.Result.StartDate<endDate);

            CollectionAssert.AreEqual(
                new []{
                    Reaktion.KeineWiederholung, 
                    Reaktion.KeineWiederholung, 
                    Reaktion.KeineWiederholung, 
                    Reaktion.WiederholungErkannt, 
                    Reaktion.KeineWiederholung, 
                },
                protokollAdapter.Result.ReaktionsFolge);
        }
    }
}
