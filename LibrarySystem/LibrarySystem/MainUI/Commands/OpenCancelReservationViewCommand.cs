using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Utils;

namespace LibrarySystem.MainUI.Commands
{
    internal class OpenCancelReservationViewCommand : CommandBase
    {
        private readonly MemberWindow _memberWindow;
        public OpenCancelReservationViewCommand(MemberWindow memberWindow)
        {
            _memberWindow = memberWindow;
        }


        public override void Execute(object? parameter)
        {
            CancelReservationView cancelReservationView = new CancelReservationView();
            cancelReservationView.Show();

            _memberWindow.Close();
        }
    }
}
