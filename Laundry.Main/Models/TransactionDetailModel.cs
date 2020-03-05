using Laundry.Entity;
using Laundry.Entity.Models;

namespace Laundry.Main.Models
{
    public class TransactionDetailModel : ObjectBase
    {
        private TransactionDetail _transactionDetail;

        public TransactionDetailModel()
        {
            _transactionDetail = new TransactionDetail();
        }

        public TransactionDetailModel(TransactionDetail transactionDetail)
        {
            _transactionDetail = transactionDetail;
        }

        public int RatesId
        {
            get
            {
                return _transactionDetail.RatesId;
            }
            set
            {
                if(_transactionDetail.RatesId != value)
                {
                    _transactionDetail.RatesId = value;
                    OnPropertyChanged();
                }
            }
        }

        public int TransactionId
        {
            get
            {
                return _transactionDetail.TransactionId;
            }
            set
            {
                if(_transactionDetail.TransactionId != value)
                {
                    _transactionDetail.TransactionId = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Quantity
        {
            get
            {
                return _transactionDetail.Quantity;
            }
            set
            {
                if(_transactionDetail.Quantity != value)
                {
                    _transactionDetail.Quantity = value;
                    OnPropertyChanged();
                }
            }
        }

        public TransactionDetail GetObject()
        {
            return _transactionDetail;
        }

        public RatesModel RatesModel
        {
            get
            {
                if(_transactionDetail.Rates == null)
                {
                    _transactionDetail.Rates = new Rates();
                }
                return new RatesModel(_transactionDetail.Rates);
            }
            set
            {
                _transactionDetail.Rates = value.GetObject();
                OnPropertyChanged();
            }
        }
    }
}
