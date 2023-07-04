using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Users.GUI.Views;
using System.Windows;
using LibrarySystem.BookBorrowings.BookReturn;
using LibrarySystem.Utils;

namespace LibrarySystem.MainUI.Commands
{
    public class ShowBookReturnWindowCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            var librarianWindow = parameter as LibrarianWindow;

            BookReturnWindow bookReturnWindow = new();
            bookReturnWindow.Owner = librarianWindow;
            bookReturnWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            bookReturnWindow.ShowDialog();
        }
    }
}
