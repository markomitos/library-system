using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using LibrarySystem.BookBorrowings.BookReturn;
using LibrarySystem.BookBorrowings.Borrowing;
using LibrarySystem.NotificationDialogs.Presentation;
using LibrarySystem.Utils;

namespace LibrarySystem.Payments.Reports
{
    public class SelectedDateChangedCommand:CommandBase
    {
        private PaymentReportsViewModel _viewModel;
        private PaymentService _paymentService=new(new PaymentRepository());
        public SelectedDateChangedCommand(PaymentReportsViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            _viewModel.Payments.Clear();
            foreach (var payment in _paymentService.Get((DateTime)parameter))
            {
                _viewModel.Payments.Add(payment);
            }

            _viewModel.TotalAmount = _paymentService.GetTotalAmount((DateTime)parameter);
        }
    }
}
