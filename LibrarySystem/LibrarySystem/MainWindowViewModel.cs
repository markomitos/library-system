using LibrarySystem.MainUI;
using LibrarySystem.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LibrarySystem.Users.Account;
using System.Windows.Input;
using System.Windows;
using LibrarySystem.Utils;
using ZdravoCorp.MainUI.NotificationDialogs;

namespace LibrarySystem
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly AccountService _accountService;
        private readonly MainWindow _mainWindow;

        private string? _username;

        public string? Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private ICommand? _logIn { get; set; }

        private string? _password;
        public string? Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public MainWindowViewModel(MainWindow mainWindow)
        {
            _accountService = new(new AccountRepository());
            _mainWindow = mainWindow;
        }

        private void openRoleWindow(Account account)
        {
            switch (account.Type)
            {
                case UserType.Administrator:
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                    break;
                case UserType.Librarian:
                    LibrarianWindow librarianWindow = new LibrarianWindow();
                    librarianWindow.Show();
                    break;
                case UserType.SpecializedLibrarian:
                    SpecializedLibrarianWindow specializedLibrarianWindow = new SpecializedLibrarianWindow();
                    specializedLibrarianWindow.Show();
                    break;
                case UserType.Member:
                    MemberWindow memberWindow = new MemberWindow();
                    memberWindow.Show();
                    break;
            }
        }
    }
}
