using Laundry.Entity;
using Laundry.Main.Models;
using Laundry.Main.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Laundry.Main.ViewModels
{
    public class RatesViewModel : ViewModelBase
    {
        #region variable

        #region private or protected
        private ServiceModel _service;
        private ShirtModel _shirt;
        private RatesModel _rates;
        private RatesModel _selectedRates;
        private ObservableCollection<ServiceModel> _serviceCollection;
        private ObservableCollection<ShirtModel> _shirtCollection;
        private ObservableCollection<RatesModel> _ratesCollection;
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

        public ObservableCollection<ShirtModel> ShirtCollection
        {
            get
            {
                return _shirtCollection;
            }
            set
            {
                _shirtCollection = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<RatesModel> RatesCollection
        {
            get
            {
                return _ratesCollection;
            }
            set
            {
                _ratesCollection = value;
                OnPropertyChanged();
            }
        }

        public ServiceModel Service
        {
            get
            {
                return _service;
            }
            set
            {
                if(_service != value)
                {
                    _service = value;
                    _rates.ServiceId = value.Id;
                    OnPropertyChanged();
                }
            }
        }

        public ShirtModel Shirt
        {
            get
            {
                return _shirt;
            }
            set
            {
                if(_shirt != value)
                {
                    _shirt = value;
                    _rates.ShirtId = value.Id;
                    OnPropertyChanged();
                }
            }
        }

        public RatesModel SelectedRates
        {
            get
            {
                return _selectedRates;
            }
            set
            {
                if(_selectedRates != value)
                {
                    _selectedRates = value;
                    OnPropertyChanged();
                }
            }
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
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region command
        public ICommand AddRates
        {
            get;
            private set;
        }

        public ICommand RemoveRates
        {
            get;
            private set;
        }
        #endregion

        #endregion

        #region method
        public RatesViewModel(IUnitOfWork unitOfWork)
        {
            RatesModel.unitOfWork = unitOfWork;
            ServiceModel.unitOfWork = unitOfWork;
            ShirtModel.unitOfWork = unitOfWork;

            _rates = new RatesModel();
            _rates.IsNewObject = true;
            _service = new ServiceModel();
            _shirt = new ShirtModel();
            _selectedRates = new RatesModel();
            _ratesCollection = RatesModel.GetAllData();
            _serviceCollection = ServiceModel.GetAllData();
            _shirtCollection = ShirtModel.GetAllData();
            
            #region Initialize Commands
            AddRates = new DelegatingCommand((o) => {
                RatesModel.AddItem(_rates);
                _rates = new RatesModel();
                _rates.IsNewObject = true;
            });
            RemoveRates = new DelegatingCommand((o) => RatesModel.RemoveItem(_selectedRates));
            #endregion
        }
        #endregion

     
    }
}
