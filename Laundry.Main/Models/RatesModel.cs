using Laundry.Entity;
using Laundry.Entity.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Laundry.Main.Models
{
    public class RatesModel : ObjectBase
    {
        private Rates _rates;
        private bool _isNewObject;
        private static ObservableCollection<RatesModel> _ratesModelCollection;
        public static IUnitOfWork unitOfWork;

        public RatesModel()
        {
            _rates = new Rates();
        }

        public RatesModel(Rates rates)
        {
            _rates = rates;
        }

        public int Id
        {
            get
            {
                return _rates.Id;
            }
            set
            {
                if(_rates.Id != value)
                {
                    _rates.Id = value;
                    OnPropertyChanged();
                }
            }
        }

        public int ShirtId
        {
            get
            {
                return _rates.ShirtId;
            }
            set
            {
                if (_rates.ShirtId != value)
                {
                    _rates.ShirtId = value;
                    OnPropertyChanged();
                }
            }
        }

        public int ServiceId
        {
            get
            {
                return _rates.ServiceId;
            }
            set
            {
                if (_rates.ServiceId != value)
                {
                    _rates.ServiceId = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal Price
        {
            get
            {
                return _rates.Price;
            }
            set
            {
                if (_rates.Price != value)
                {
                    _rates.Price = value;
                    if (!_isNewObject)
                    {
                        UpdateItem(_rates);
                    }
                    OnPropertyChanged();
                }
            }
        }

        public string Unit
        {
            get
            {
                return _rates.Unit;
            }
            set
            {
                if (_rates.Unit != value)
                {
                    _rates.Unit = value;
                    if (!_isNewObject)
                    {
                        UpdateItem(_rates);
                    }
                    OnPropertyChanged();
                }
            }
        }

        public ServiceModel ServiceModel
        {
            get
            {
                return new ServiceModel(_rates.Service);
            }
        }

        public ShirtModel ShirtModel
        {
            get
            {
                return new ShirtModel(_rates.Shirt);
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
                if (_isNewObject != value)
                {
                    _isNewObject = value;
                    OnPropertyChanged();
                }
            }
        }

        public Rates GetObject()
        {
            return _rates;
        }

        public static ObservableCollection<RatesModel> GetAllData()
        {
            _ratesModelCollection = new ObservableCollection<RatesModel>(
                unitOfWork.RatesRepository.GetAll().Select(e => new RatesModel(e)));
            return _ratesModelCollection;
        }

        public static void AddItem(RatesModel ratesModel)
        {
            try
            {
                unitOfWork.RatesRepository.Add(ratesModel.GetObject());
                unitOfWork.Complete();
                _ratesModelCollection.Add(ratesModel);
            }
            catch
            {

            }
        }

        public static void RemoveItem(RatesModel ratesModel)
        {
            try
            {
                unitOfWork.RatesRepository.Remove(ratesModel.GetObject());
                unitOfWork.Complete();
                _ratesModelCollection.Remove(ratesModel);
            }
            catch
            {

            }
        }

        public static void UpdateItem(Rates rates)
        {
            try
            {
                Rates ratesObject = unitOfWork.RatesRepository
                      .Find(e => e.Id == rates.Id).FirstOrDefault();
                ratesObject.Unit = rates.Unit;
                ratesObject.Price = rates.Price;
                ratesObject.UpdatedAt = DateTime.Now;
                unitOfWork.Complete();
            }
            catch
            {

            }
        }
    }
}