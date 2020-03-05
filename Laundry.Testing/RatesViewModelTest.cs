using Laundry.Main.Models;
using Laundry.Main.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Laundry.Testing
{
    [TestClass]
    public class RatesViewModelTest : BaseViewModelTest
    {
        private RatesViewModel _ratesViewModel;

        public RatesViewModelTest()
        {
            _ratesViewModel = new RatesViewModel(_unitOfWork);
        }

        [TestMethod]
        public void FindRates_WithId1()
        {
            RatesModel rates = _ratesViewModel.RatesCollection.FirstOrDefault(e => e.Id.Equals(1));
            Assert.AreEqual(rates.Id, 1);
            Assert.AreEqual(rates.ShirtId, 1);
            Assert.AreEqual(rates.ServiceId, 1);
            Assert.AreEqual(rates.Price, 2000);
            Assert.AreEqual(rates.Unit, "Kg");
        }

        [TestMethod]
        public void AddRates_Success()
        {
            _ratesViewModel.Id = 4;
            _ratesViewModel.Shirt = _ratesViewModel.ShirtCollection.FirstOrDefault(e => e.Id.Equals(2));
            _ratesViewModel.Service = _ratesViewModel.ServiceCollection.FirstOrDefault(e => e.Id.Equals(1));
            _ratesViewModel.Price = 4500;
            _ratesViewModel.Unit = "Gram";
            _ratesViewModel.AddRates.Execute(new object());
            RatesModel rates = _ratesViewModel.RatesCollection.FirstOrDefault(e => e.Id.Equals(4));
            Assert.AreEqual(rates.Id, 4);
            Assert.AreEqual(rates.ShirtId, 2);
            Assert.AreEqual(rates.ServiceId, 1);
            Assert.AreEqual(rates.Price, 4500);
            Assert.AreEqual(rates.Unit, "Gram");
        }

        [TestMethod]
        public void UpdateRates_Success()
        {
           
            RatesModel rates = _ratesViewModel.RatesCollection.FirstOrDefault(e => e.Id.Equals(3));
            rates.Id = 3;
            rates.Price = 5500;
            rates.Unit = "Gram";
            Assert.AreEqual(rates.Id, 3);
            Assert.AreEqual(rates.Price, 5500);
            Assert.AreEqual(rates.Unit, "Gram");
        }

        [TestMethod]
        public void RemoveRates_Success()
        {
            _ratesViewModel.SelectedRates = _ratesViewModel.RatesCollection.FirstOrDefault(e => e.Id.Equals(2));
            _ratesViewModel.RemoveRates.Execute(new object());
            RatesModel rates = _ratesViewModel.RatesCollection.FirstOrDefault(e => e.Id.Equals(2));
            Assert.AreEqual(null, rates);
        }
    }
}
