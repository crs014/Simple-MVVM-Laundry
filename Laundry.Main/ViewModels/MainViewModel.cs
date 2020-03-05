using Laundry.Entity;
using Laundry.Entity.Context;
using Laundry.Main.Database;
using Laundry.Main.Services;
using Laundry.Main.Views;
using System.Windows.Input;

namespace Laundry.Main.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        #region variable
        private IUnitOfWork _unitOfWork;

        private IDbLaundry _dbLaundry;

        public ICommand CreateTransactionCommand
        {
            get;
            private set;
        }

        public ICommand TransactionHistoryCommand
        {
            get;
            private set;
        }

        public ICommand ServiceCommand
        {
            get;
            private set;
        }

        public ICommand ShirtCommand
        {
            get;
            private set;
        }

        public ICommand RatesCommand
        {
            get;
            private set;
        }
        #endregion

        #region method
        public MainViewModel()
        {
            _dbLaundry = new DbLaundry();
            _unitOfWork = new UnitOfWork(_dbLaundry);

            #region Initialize Commands
            CreateTransactionCommand = new DelegatingCommand((o) => ToolbarButtonMethod(new CreateTransactionAction(this)));
            TransactionHistoryCommand = new DelegatingCommand((o) => ToolbarButtonMethod(new TransactionHistoryAction(this)));
            ServiceCommand = new DelegatingCommand((o) => ToolbarButtonMethod(new ServiceAction(this)));
            ShirtCommand = new DelegatingCommand((o) => ToolbarButtonMethod(new ShirtAction(this)));
            RatesCommand = new DelegatingCommand((o) => ToolbarButtonMethod(new RatesAction(this)));
            #endregion
        }
        #endregion

        #region command implementation
        protected class CreateTransactionAction : IToolBarMethod
        {
            private MainViewModel _viewModel;

            public CreateTransactionAction(MainViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public void DoAction()
            {
                AddTransactionView addTransactionView = new AddTransactionView();
                addTransactionView.DataContext = new AddTransactionViewModel(_viewModel._unitOfWork);
                addTransactionView.ShowDialog();
            }
        }

        protected class TransactionHistoryAction : IToolBarMethod
        {
            private MainViewModel _viewModel;

            public TransactionHistoryAction(MainViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public void DoAction()
            {
                TransactionView transactionView = new TransactionView();
                transactionView.DataContext = new TransactionViewModel(_viewModel._unitOfWork);
                transactionView.ShowDialog();
            }
        }

        protected class ServiceAction : IToolBarMethod
        {
            private MainViewModel _viewModel;

            public ServiceAction(MainViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public void DoAction()
            {
                ServiceView serviceView = new ServiceView();
                serviceView.DataContext = new ServiceViewModel(_viewModel._unitOfWork);
                serviceView.ShowDialog();
            }
        }

        protected class ShirtAction : IToolBarMethod
        {
            private MainViewModel _viewModel;

            public ShirtAction(MainViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public void DoAction()
            {
                ShirtView shirtView = new ShirtView();
                shirtView.DataContext = new ShirtViewModel(_viewModel._unitOfWork);
                shirtView.ShowDialog();
            }
        }

        protected class RatesAction : IToolBarMethod
        {
            private MainViewModel _viewModel;

            public RatesAction(MainViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public void DoAction()
            {
                RatesView ratesView = new RatesView();
                ratesView.DataContext = new RatesViewModel(_viewModel._unitOfWork);
                ratesView.ShowDialog();
            }
        }
        #endregion
    }
}
