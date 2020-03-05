using Laundry.Main.Models;
using Laundry.Main.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Laundry.Testing
{
    [TestClass]
    public class TransactionViewModelTest : BaseViewModelTest
    {
        private TransactionViewModel _transactionViewModel;
        private AddTransactionViewModel _addTransactionViewModel;

        public TransactionViewModelTest()
        {
            _transactionViewModel = new TransactionViewModel(_unitOfWork);
            _addTransactionViewModel = new AddTransactionViewModel(_unitOfWork);
        }

        [TestMethod] 
        public void FindTransaction_WithId1()
        {
            TransactionModel transaction = _transactionViewModel.TransactionCollection.FirstOrDefault(e => e.Id.Equals(1));
            Assert.AreEqual(transaction.Id, 1);
            Assert.AreEqual(transaction.Name, "Ucok");
            Assert.AreEqual(transaction.Address, "Jalan Bakpau");
            Assert.AreEqual(transaction.Phone, "012345678");
            Assert.AreEqual(transaction.TransactionDetails.Count, 2);
        }

        [TestMethod]
        public void AddTransaction_Success()
        {
            _addTransactionViewModel.Transaction.Id = 4;
            _addTransactionViewModel.Transaction.Name = "Rasputin";
            _addTransactionViewModel.Transaction.Address = "Rusia Bear";
            _addTransactionViewModel.Transaction.Phone = "000111222";
            _addTransactionViewModel.Rates = _addTransactionViewModel.RatesCollection.FirstOrDefault(e => e.Id.Equals(3));
            _addTransactionViewModel.AddItemTransaction.Execute(new object());
            _addTransactionViewModel.AddTransaction.Execute(new object());
            _transactionViewModel = new TransactionViewModel(_unitOfWork);
            TransactionModel transaction = _transactionViewModel.TransactionCollection.FirstOrDefault(e => e.Id.Equals(4));

            Assert.AreEqual(transaction.Id, 4);
            Assert.AreEqual(transaction.Name, "Rasputin");
            Assert.AreEqual(transaction.Address, "Rusia Bear");
            Assert.AreEqual(transaction.Phone, "000111222");
            Assert.AreEqual(_unitOfWork.TransactionDetailRepository.GetAll().Count(), 1);
        }

        [TestMethod]
        public void RemoveTransaction_Success()
        {
            _transactionViewModel.Transaction = _transactionViewModel.TransactionCollection.FirstOrDefault(e => e.Id.Equals(2));
            _transactionViewModel.RemoveTransaction.Execute(new object());
            TransactionModel transaction = _transactionViewModel.TransactionCollection.FirstOrDefault(e => e.Id.Equals(2));
            Assert.AreEqual(null, transaction);
        }

        [TestMethod]
        public void RemoveTransactionItem_Success()
        {
            _addTransactionViewModel.Rates = _addTransactionViewModel.RatesCollection.FirstOrDefault(e => e.Id.Equals(3));
            _addTransactionViewModel.AddItemTransaction.Execute(new object());
            Assert.AreEqual(_addTransactionViewModel.Transaction.TransactionDetails.Count, 1);

            _addTransactionViewModel.TransactionDetail = _addTransactionViewModel.Transaction.TransactionDetails
                .FirstOrDefault(e => e.RatesId.Equals(3));
            _addTransactionViewModel.RemoveItemTransaction.Execute(new object());
            Assert.AreEqual(_addTransactionViewModel.Transaction.TransactionDetails.Count, 0);
        }
    }
}
