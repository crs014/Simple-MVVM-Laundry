using Laundry.Entity;
using Laundry.Entity.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Laundry.Main.Models
{
    public class ServiceModel : ObjectBase
    {
        private Service _service;
        private static ObservableCollection<ServiceModel> _serviceModelCollection;
        private bool _isNewObject;
        public static IUnitOfWork unitOfWork;

        public ServiceModel(Service service)
        {
            _service = service;
        }

        public ServiceModel()
        {
            _service = new Service();
        }

        public int Id 
        {
            get
            {
                return _service.Id;
            }
            set
            {
                if(_service.Id != value)
                {
                    _service.Id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Name
        {
            get
            {
                return _service.Name;
            }
            set
            {
                if(_service.Name != value)
                {
                    _service.Name = value;
                    if (!_isNewObject)
                    {
                        UpdateItem(_service);
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

        public Service GetObject()
        {
            return _service;
        }

        public static ObservableCollection<ServiceModel> GetAllData()
        {
            _serviceModelCollection = new ObservableCollection<ServiceModel>(
                unitOfWork.ServiceRepository.GetAll().Select(e => new ServiceModel(e)));
            return _serviceModelCollection;
        }

        public static void AddItem(ServiceModel serviceModel)
        {
            try
            {
                unitOfWork.ServiceRepository.Add(serviceModel.GetObject());
                unitOfWork.Complete();
                _serviceModelCollection.Add(serviceModel);
            }
            catch
            {

            }
        }

        public static void RemoveItem(ServiceModel serviceModel)
        {
            try
            {
                unitOfWork.ServiceRepository.Remove(serviceModel.GetObject());
                unitOfWork.Complete();
                _serviceModelCollection.Remove(serviceModel);
            }
            catch
            {

            }
        }

        public static void UpdateItem(Service service)
        {
            try
            {
                Service serviceObject = unitOfWork.ServiceRepository
                     .Find(e => e.Id == service.Id).FirstOrDefault();
                serviceObject.Name = service.Name;
                serviceObject.UpdatedAt = DateTime.Now;
                unitOfWork.Complete();
            }
            catch
            {

            }
        }
    }
}
