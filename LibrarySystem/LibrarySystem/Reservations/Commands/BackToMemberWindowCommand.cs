using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.MainUI;
using LibrarySystem.Utils;

namespace LibrarySystem.Reservations.Commands
{
    internal class BackToMemberWindowCommand : CommandBase
    {
        private readonly CancelReservationView _cancelReservationView;
        public BackToMemberWindowCommand(CancelReservationView cancelReservationView)
        {
            _cancelReservationView = cancelReservationView;
        }

        public override void Execute(object? parameter)
        {
            MemberWindow memberWindow = new MemberWindow();
            memberWindow.Show();

            _cancelReservationView.Close();
        }
    }
}
