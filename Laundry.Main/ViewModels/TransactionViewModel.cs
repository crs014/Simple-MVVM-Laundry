using Laundry.Entity;
using Laundry.Main.Models;
using Laundry.Main.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Laundry.Main.ViewModels
{
    public class TransactionViewModel : ViewModelBase
    {
        #region variable

        #region private or protected
        private TransactionModel _transaction;
        private ObservableCollection<TransactionModel> _transactionCollection;
        private ObservableCollection<TransactionDetailModel> _transactionDetailCollection;
        private float _total;
        #endregion

        #region public
        public ObservableCollection<TransactionModel> TransactionCollection
        {
            get
            {
                return _transactionCollection;
            }
            set
            {
                _transactionCollection = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<TransactionDetailModel> TransactionDetailCollection
        {
            get
            {
                return _transactionDetailCollection;
            }
            set
            {
                _transactionDetailCollection = value;
                OnPropertyChanged();
            }
        }

        public TransactionModel Transaction
        {
            get
            {
                return _transaction;
            }
            set
            {
                if(_transaction != value)
                {
                    _transaction = value;
                    _previewItemTrasaction();
                    OnPropertyChanged();
                }
            }
        }

        public float Total
        {
            get
            {
                return _total;
            }
            set
            {
                if(_total != value)
                {
                    _total = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region command
        public ICommand RemoveTransaction
        {
            get;
            private set;
        }
        #endregion

        #endregion

        #region method
        public TransactionViewModel(IUnitOfWork unitOfWork)
        {
            TransactionModel.unitOfWork = unitOfWork;
            _transaction = new TransactionModel();
            _transactionCollection = TransactionModel.GetAllData();
            _transactionDetailCollection = new ObservableCollection<TransactionDetailModel>();

            #region Initialize Commands
            RemoveTransaction = new DelegatingCommand((o) => {
                TransactionModel.RemoveItem(_transaction);
                TransactionDetailCollection = new ObservableCollection<TransactionDetailModel>();
                Transaction = new TransactionModel();
            });
            #endregion
        }

        private void _previewItemTrasaction()
        {
            if (_transaction == null)
            {
                Transaction = new TransactionModel();
                Transaction.TransactionDetails = new ObservableCollection<TransactionDetailModel>();
                Total = 0;
            }
            TransactionDetailCollection = _transaction.TransactionDetails;
            Total = TransactionDetailCollection.Sum(e => e.Quantity * (float)e.RatesModel.Price);
        }
        #endregion
    }
}
