using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Payments
{
    public class PaymentService
    {
        private PaymentRepository _paymentRepository;

        public PaymentService(PaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public void Add(Payment payment)
        {
            _paymentRepository.Add(payment);
        }
    }
}
