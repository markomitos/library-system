using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Users.GUI.Views;
using System.Windows;
using LibrarySystem.Utils;

namespace LibrarySystem.MainUI.Commands
{
    public class ShowBookBorrowingViewCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            var librarianWindow = parameter as LibrarianWindow;

            BookBorrowingView bookBorrowingView = new();
            bookBorrowingView.Owner = librarianWindow;
            bookBorrowingView.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            bookBorrowingView.ShowDialog();
        }
    }
}
