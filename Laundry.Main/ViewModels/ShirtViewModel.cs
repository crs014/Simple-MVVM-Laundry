using Laundry.Entity;
using Laundry.Main.Models;
using Laundry.Main.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Laundry.Main.ViewModels
{
    public class ShirtViewModel : ViewModelBase
    {

        #region variable

        #region private and protected
        private ShirtModel _shirt;
        private ShirtModel _selectedShirt;
        private ObservableCollection<ShirtModel> _shirtCollection;
        private int _selectedShirtIndex;
        #endregion

        #region public
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

        public ShirtModel SelectedShirt
        {
            get
            {
                return _selectedShirt;
            }
            set
            {
                if(_selectedShirt != value)
                {
                    _selectedShirt = value;
                    OnPropertyChanged();
                }
            }
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
                    OnPropertyChanged();
                }
            }
        }

        public int SelectedShirtIndex
        {
            get
            {
                return _selectedShirtIndex;
            }
            set
            {
                if(_selectedShirtIndex != value)
                {
                    _selectedShirtIndex = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region command 
        public ICommand AddShirt
        {
            get;
            private set;
        }

        public ICommand RemoveShirt
        {
            get;
            private set;
        }
        #endregion

        #endregion

        #region method
        public ShirtViewModel(IUnitOfWork unitOfWork)
        {
            ShirtModel.unitOfWork = unitOfWork;
            
            _shirt = new ShirtModel();
            _shirt.IsNewObject = true;
            _selectedShirt = new ShirtModel();
            _shirtCollection = ShirtModel.GetAllData();
            
            #region Initialize Commands
            AddShirt = new DelegatingCommand((o) => {
                ShirtModel.AddItem(_shirt);
                _shirt = new ShirtModel();
                _shirt.IsNewObject = true;
            });
            RemoveShirt = new DelegatingCommand((o) => ShirtModel.RemoveItem(_selectedShirt));
            #endregion
        }
        #endregion
    }
}
