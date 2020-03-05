using Laundry.Entity;
using Laundry.Main.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using Laundry.Main.Models;

namespace Laundry.Main.ViewModels
{
    public class AddTransactionViewModel : ViewModelBase
    {
        #region variable

        #region private or protected
        private TransactionModel _transaction;
        private TransactionDetailModel _transactionDetail;
        private RatesModel _rates;
        private ObservableCollection<RatesModel> _ratesCollection;
        #endregion

        #region public
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
                    OnPropertyChanged();
                }
            }
        }

        public TransactionDetailModel TransactionDetail
        {
            get
            {
                return _transactionDetail;
            }
            set
            {
                
                _transactionDetail = value;
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

        public RatesModel Rates
        {
            get
            {
                return _rates;
            }
            set
            {
                if(_rates != value)
                {
                    _rates = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region command
        public ICommand AddTransaction
        {
            get;
            private set;
        }

        public ICommand AddItemTransaction
        {
            get;
            private set;
        }

        public ICommand RemoveItemTransaction
        {
            get;
            private set;
        }
        #endregion

        #endregion

        #region method
        public AddTransactionViewModel(IUnitOfWork unitOfWork)
        {
            TransactionModel.unitOfWork = unitOfWork;
            RatesModel.unitOfWork = unitOfWork;
            _transaction = new TransactionModel();
            _transaction.IsNewObject = true;
            _transactionDetail = new TransactionDetailModel();
            _rates = new RatesModel();
            _ratesCollection = RatesModel.GetAllData();

            #region Initialize Commands
            AddTransaction = new DelegatingCommand((o) => {
                TransactionModel.AddItem(_transaction);
                Transaction = new TransactionModel();
                Transaction.TransactionDetails = new ObservableCollection<TransactionDetailModel>();
                Transaction.IsNewObject = true;
            });
            AddItemTransaction = new DelegatingCommand((o) => ToolbarButtonMethod(new AddItemTransactionAction(this)));
            RemoveItemTransaction = new DelegatingCommand((o) => ToolbarButtonMethod(new RemoveItemTransactionAction(this)));
            #endregion
        }
        #endregion

        #region command implementation
        protected class AddItemTransactionAction : IToolBarMethod
        {
            private AddTransactionViewModel _viewModel;

            public AddItemTransactionAction(AddTransactionViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public void DoAction()
            {
                _viewModel._transactionDetail = new TransactionDetailModel();
                _viewModel._transactionDetail.RatesId = _viewModel._rates.Id;
                _viewModel._transactionDetail.RatesModel = _viewModel._rates;
                if (_viewModel.Transaction.TransactionDetails
                    .FirstOrDefault(e => e.RatesId.Equals(_viewModel._rates.Id)) == null)
                {
                    _viewModel.Transaction.TransactionDetails.Add(_viewModel._transactionDetail);
                    _viewModel._transactionDetail = new TransactionDetailModel();
                }
            }
        }

        protected class RemoveItemTransactionAction : IToolBarMethod
        {
            private AddTransactionViewModel _viewModel;

            public RemoveItemTransactionAction(AddTransactionViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public void DoAction()
            {
                _viewModel.Transaction.TransactionDetails.Remove(_viewModel._transactionDetail);
                _viewModel._transactionDetail = new TransactionDetailModel();
            }
        }
        #endregion
    }
}
