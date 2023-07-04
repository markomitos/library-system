using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using LibrarySystem.Utils;

namespace LibrarySystem.Payments.Reports
{
    public class PaymentReportsViewModel:ViewModelBase
    {
        private ObservableCollection<Payment> _payments;

        public ObservableCollection<Payment> Payments
        {
            get {  return _payments; }
            set
            {
                _payments = value;
                OnPropertyChanged(nameof(Payments));
            }
        }

        private DateTime _selectedDate;

        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                _selectedDate = value;
                OnPropertyChanged(nameof(SelectedDate));
            }
        }

        private PaymentService _paymentService;

        private int _totalAmount;

        public int TotalAmount
        {
            get { return _totalAmount; }
            set
            {
                _totalAmount = value;
                OnPropertyChanged(nameof(TotalAmount));
            }
        }

        private ICommand _selectedDateChangedCommand;

        public ICommand SelectedDateChangedCommand
        {
            get { return _selectedDateChangedCommand ??= new SelectedDateChangedCommand(this); }
        }

        public PaymentReportsViewModel(PaymentService paymentService)
        {
            _paymentService = paymentService;
            LoadData();
        }

        private void LoadData()
        {
            SelectedDate = DateTime.Now;
            Payments = _paymentService.Get(SelectedDate);
            TotalAmount = _paymentService.GetTotalAmount(SelectedDate);
        }
    }
}
