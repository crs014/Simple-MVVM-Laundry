using Laundry.Entity;
using Laundry.Entity.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Laundry.Main.Models
{
    public class TransactionModel : ObjectBase
    {
        private Transaction _transaction;
        private bool _isNewObject;
        private ObservableCollection<TransactionDetailModel> _transactionDetailModelCollection;
        private static ObservableCollection<TransactionModel> _transactionModelCollection;
        public static IUnitOfWork unitOfWork;

        public TransactionModel()
        {
            _transaction = new Transaction();
            _transactionDetailModelCollection = new ObservableCollection<TransactionDetailModel>();
        }

        public TransactionModel(Transaction transaction)
        {
            _transaction = transaction;
            _transactionDetailModelCollection = new ObservableCollection<TransactionDetailModel>();
            if (transaction.TransactionDetails != null){
                _transactionDetailModelCollection = new ObservableCollection<TransactionDetailModel>(_transaction.TransactionDetails
                .Select(e => new TransactionDetailModel(e)));
            }
            
        }

        public int Id
        {
            get
            {
                return _transaction.Id;
            }
            set
            {
                if(_transaction.Id != value)
                {
                    _transaction.Id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Name
        {
            get
            {
                return _transaction.Name;
            }
            set
            {
                if (_transaction.Name != value)
                {
                    _transaction.Name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Address
        {
            get
            {
                return _transaction.Address;
            }
            set
            {
                if (_transaction.Address != value)
                {
                    _transaction.Address = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Phone
        {
            get
            {
                return _transaction.Phone;
            }
            set
            {
                if (_transaction.Phone != value)
                {
                    _transaction.Phone = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime DateTime
        {
            get
            {
                return _transaction.CreatedAt;
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

        public ObservableCollection<TransactionDetailModel> TransactionDetails
        {
            get
            {
                return _transactionDetailModelCollection;
            }
            set
            {
                _transactionDetailModelCollection = value;
                OnPropertyChanged();
            }
        }

        public Transaction GetObject()
        {
            return _transaction;
        }

        public static ObservableCollection<TransactionModel> GetAllData()
        {
            _transactionModelCollection = new ObservableCollection<TransactionModel>(
                unitOfWork.TransactionRepository.GetAll().Select(e => new TransactionModel(e)));
            return _transactionModelCollection;
        }

        public static void AddItem(TransactionModel transactionModel)
        {
            try
            {
                Transaction transaction = unitOfWork.TransactionRepository.AddReturnObject(transactionModel.GetObject());
                unitOfWork.Complete();
                unitOfWork.TransactionDetailRepository.AddRange(
                    transactionModel.TransactionDetails.Select(e =>
                    {
                        e.TransactionId = transaction.Id;
                        return e.GetObject();
                    }));
                unitOfWork.Complete();
                //MessageBox.Show("Input Success", "Success");
            }
            catch
            {
                MessageBox.Show("Input Failed", "Error");
            }
          
        }

        public static void RemoveItem(TransactionModel transactionModel)
        {
            unitOfWork.TransactionDetailRepository.RemoveRange(transactionModel.TransactionDetails.Select(e => e.GetObject()));
            unitOfWork.TransactionRepository.Remove(transactionModel.GetObject());
            unitOfWork.Complete();
            _transactionModelCollection.Remove(transactionModel);
        }
    }
}
