using Laundry.Entity;
using Laundry.Entity.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Laundry.Main.Models
{
    public class ShirtModel : ObjectBase
    {
        private Shirt _shirt;
        private static ObservableCollection<ShirtModel> _shirtModelCollection;
        private bool _isNewObject;
        public static IUnitOfWork unitOfWork;

        public ShirtModel()
        {
            _shirt = new Shirt();
        }

        public ShirtModel(Shirt shirt)
        {
            _shirt = shirt;
        }

        public int Id
        {
            get
            {
                return _shirt.Id;
            }
            set
            {
                if(_shirt.Id != value)
                {
                    _shirt.Id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Name
        {
            get
            {
                return _shirt.Name;
            }
            set
            {
                if(_shirt.Name != value)
                {
                    _shirt.Name = value;
                    if (!_isNewObject)
                    {
                        UpdateItem(_shirt);
                    }
                    OnPropertyChanged();
                }
            }
        }

        public bool IsNewObject
        {
            get
            {
                return _isNewObject;
            }
            set
            {
                if(_isNewObject != value)
                {
                    _isNewObject = value;
                    OnPropertyChanged();
                }
            }
        }

        public Shirt GetObject()
        {
            return _shirt;
        }

        public static ObservableCollection<ShirtModel> GetAllData()
        {
            _shirtModelCollection = new ObservableCollection<ShirtModel>(
                unitOfWork.ShirtRepository.GetAll().Select(e => new ShirtModel(e)));
            return _shirtModelCollection;
        }

        public static void AddItem(ShirtModel shirtModel)
        {
            try
            {
                unitOfWork.ShirtRepository.Add(shirtModel.GetObject());
                unitOfWork.Complete();
                _shirtModelCollection.Add(shirtModel);
            }
            catch
            {

            }
        }

        public static void RemoveItem(ShirtModel shirtModel)
        {
            try
            {
                unitOfWork.ShirtRepository.Remove(shirtModel.GetObject());
                unitOfWork.Complete();
                _shirtModelCollection.Remove(shirtModel);
            }
            catch
            {

            }
        }

        public static void UpdateItem(Shirt shirt)
        {
            try
            {
                Shirt shirtObject = unitOfWork.ShirtRepository
                      .Find(e => e.Id == shirt.Id).FirstOrDefault();
                shirtObject.Name = shirt.Name;
                shirtObject.UpdatedAt = DateTime.Now;
                unitOfWork.Complete();
            }
            catch
            {

            }
        }
    }
}
