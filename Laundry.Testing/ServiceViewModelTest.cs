using Laundry.Main.Models;
using Laundry.Main.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Laundry.Testing
{
    [TestClass]
    public class ServiceViewModelTest : BaseViewModelTest
    {
        private ServiceViewModel _serviceViewModel;

        public ServiceViewModelTest()
        {
            _serviceViewModel = new ServiceViewModel(_unitOfWork);
        }

        [TestMethod]
        public void FindService_WithId1()
        {
            ServiceModel service = _serviceViewModel.ServiceCollection.FirstOrDefault(e => e.Id.Equals(1));
            Assert.AreEqual(service.Id, 1);
            Assert.AreEqual(service.Name, "Wash");
        }

        [TestMethod]
        public void AddService_Success()
        {
            _serviceViewModel.Id = 4;
            _serviceViewModel.Name = "Clean";
            _serviceViewModel.AddService.Execute(new object());
            ServiceModel service = _serviceViewModel.ServiceCollection.Where(e => e.Id == 4).FirstOrDefault();
            Assert.AreEqual(service.Id, 4);
            Assert.AreEqual(service.Name, "Clean");
        }

        [TestMethod]
        public void UpdateService_Success()
        {
      
            ServiceModel service = _serviceViewModel.ServiceCollection.Where(e => e.Id == 3).FirstOrDefault();
            service.Id = 3;
            service.Name = "Rinse and Wash";
            Assert.AreEqual(service.Id, 3);
            Assert.AreEqual(service.Name, "Rinse and Wash");
        }

        [TestMethod]
        public void RemoveService_Success()
        {
            _serviceViewModel.SelectedService = _serviceViewModel.ServiceCollection.FirstOrDefault(e => e.Id.Equals(2));
            _serviceViewModel.RemoveService.Execute(new object());
            ServiceModel service = _serviceViewModel.ServiceCollection.FirstOrDefault(e => e.Id.Equals(2));
            Assert.AreEqual(null, service);
        }
    }
}
