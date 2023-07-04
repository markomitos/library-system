using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Payments.Reports;
using LibrarySystem.Utils;

namespace LibrarySystem.MainUI.Commands
{
    public class ShowPaymentReportsCommand:CommandBase
    {
        public ShowPaymentReportsCommand() { }
        public override void Execute(object? parameter)
        {
            PaymentReportWindow window = new PaymentReportWindow();
            window.Show();
        }
    }
}
