using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Reservations.Views;
using LibrarySystem.Utils;

namespace LibrarySystem.Reservations.Commands
{
    public class ShowReserveDialogCommand:CommandBase
    {
        public ShowReserveDialogCommand()
        {
            
        }
        public override void Execute(object? parameter)
        {
            ReserveTitleDialog titleDialog = new ReserveTitleDialog();
            titleDialog.ShowDialog();
        }
    }
}
