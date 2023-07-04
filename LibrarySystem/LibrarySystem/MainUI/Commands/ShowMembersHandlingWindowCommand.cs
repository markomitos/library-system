using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Users.GUI.Views;
using System.Windows;
using LibrarySystem.Utils;
using LibrarySystem.BookBorrowings.BookReturn;

namespace LibrarySystem.MainUI.Commands
{
    public class ShowMembersHandlingWindowCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            var librarianWindow = parameter as LibrarianWindow;

            MembersHandlingWindow membersHandlingWindow = new();
            membersHandlingWindow.Owner = librarianWindow;
            membersHandlingWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            membersHandlingWindow.ShowDialog();
        }
    }
}
