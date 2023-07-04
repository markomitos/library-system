using LibrarySystem.MainUI.Commands;
using LibrarySystem.Users.GUI.Commands;
using LibrarySystem.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibrarySystem.MainUI.ViewModels
{
    public class LibrarianViewModel : ViewModelBase
    {
        private readonly LibrarianWindow _librarianWindow;

        private string? _loggedUser;

        public string? LoggedUser
        {
            get => _loggedUser;
            set
            {
                _loggedUser = value;
                OnPropertyChanged(nameof(LoggedUser));
            }
        }


        private ICommand _showBookBorrowingViewCommand;
        public ICommand ShowBookBorrowingViewCommand
        {
            get { return _showBookBorrowingViewCommand ??= new ShowBookBorrowingViewCommand(); }
        }

        private ICommand _showBookReturnWindowCommand;
        public ICommand ShowBookReturnWindowCommand
        {
            get { return _showBookReturnWindowCommand ??= new ShowBookReturnWindowCommand(); }
        }

        private ICommand _showMembersHandlingWindowCommand;
        public ICommand ShowMembersHandlingWindowCommand
        {
            get { return _showMembersHandlingWindowCommand ??= new ShowMembersHandlingWindowCommand(); }
        }

        private ICommand _logoutCommand;
        public ICommand LogoutCommand
        {
            get { return _logoutCommand ??= new LogoutCommand(_librarianWindow); }
        }

        private ICommand _showPaymentReportsCommand;
        public ICommand ShowPaymentReportsCommand
        {
            get { return _showPaymentReportsCommand ??= new ShowPaymentReportsCommand(); }
        }

        public LibrarianViewModel(LibrarianWindow librarianWindow)
        {
            _librarianWindow = librarianWindow;
            LoggedUser = Globals.LoggedUser!.Username;
        }


    }
}
