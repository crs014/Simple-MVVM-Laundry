using Laundry.Main.Models;
using Laundry.Main.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Laundry.Testing
{
    [TestClass]
    public class ShirtViewModelTest : BaseViewModelTest
    {
      
        private ShirtViewModel _shirtViewModel;

        public ShirtViewModelTest()
        {
            _shirtViewModel = new ShirtViewModel(_unitOfWork);
        }

        [TestMethod]
        public void FindShirt_WithId1()
        {
            ShirtModel shirt = _shirtViewModel.ShirtCollection.FirstOrDefault(e => e.Id.Equals(1));
            Assert.AreEqual(shirt.Id, 1);
            Assert.AreEqual(shirt.Name, "T-Shirt");
        }

        [TestMethod]
        public void AddShirt_Success()
        {
            _shirtViewModel.Id = 4;
            _shirtViewModel.Name = "Pants";
            _shirtViewModel.AddShirt.Execute(new object());
            ShirtModel shirt = _shirtViewModel.ShirtCollection.Where(e => e.Id == 4).FirstOrDefault();
            Assert.AreEqual(shirt.Id, 4);
            Assert.AreEqual(shirt.Name, "Pants");
        }

        [TestMethod]
        public void UpdateShirt_Success()
        {
            
            ShirtModel shirt = _shirtViewModel.ShirtCollection.Where(e => e.Id == 3).FirstOrDefault();
            shirt.Name = "Armor";
            Assert.AreEqual(shirt.Id, 3);
            Assert.AreEqual(shirt.Name, "Armor");
        }

        [TestMethod]
        public void RemoveShirt_Success()
        {
            _shirtViewModel.SelectedShirt = _shirtViewModel.ShirtCollection.FirstOrDefault(e => e.Id.Equals(2));
            _shirtViewModel.RemoveShirt.Execute(new object());
            ShirtModel shirt = _shirtViewModel.ShirtCollection.FirstOrDefault(e => e.Id.Equals(2));
            Assert.AreEqual(null, shirt);
        }
    }
}
