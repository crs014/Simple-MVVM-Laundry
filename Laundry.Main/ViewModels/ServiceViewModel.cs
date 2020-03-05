using Laundry.Entity;
using Laundry.Entity.Context;
using Laundry.Entity.Models;
using Laundry.Main.Models;
using Laundry.Main.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Laundry.Main.ViewModels
{
    public class ServiceViewModel : ViewModelBase
    {
        #region variable
        
        #region private and protected
        private ServiceModel _service;
        private ServiceModel _selectedService;
        private ObservableCollection<ServiceModel> _serviceCollection;
        #endregion

        #region public 
        public ObservableCollection<ServiceModel> ServiceCollection
        {
            get
            {
                return _serviceCollection;
            }
            set
            {
                _serviceCollection = value;
                OnPropertyChanged();
            }
        }

        public ServiceModel SelectedService
        {
            get
            {
                return _selectedService;
            }
            set
            {
                if(_selectedService != value)
                {
                    _selectedService = value;
                    OnPropertyChanged();
                }
            }
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
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region command
        public ICommand AddService
        {
            get;
            private set;
        }

        public ICommand RemoveService
        {
            get;
            private set;
        }
        #endregion

        #endregion

        #region method
        public ServiceViewModel(IUnitOfWork unitOfWork)
        {
            ServiceModel.unitOfWork = unitOfWork;
            _service = new ServiceModel();
            _service.IsNewObject = true;
            _selectedService = new ServiceModel();
            _serviceCollection = ServiceModel.GetAllData();

            #region Initialize Commands
            AddService = new DelegatingCommand((o) => {
                ServiceModel.AddItem(_service);
                _service = new ServiceModel();
                _service.IsNewObject = true;
            });
            RemoveService = new DelegatingCommand((o) => ServiceModel.RemoveItem(_selectedService));
            #endregion
        }
        #endregion
    }
}
