using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.MainUI;
using LibrarySystem.Users;
using LibrarySystem.Users.Accounts;
using LibrarySystem.Users.GUI.Views;
using LibrarySystem.Utils;
using ZdravoCorp.MainUI.NotificationDialogs;

namespace LibrarySystem.MainCommands
{
    internal class LogInCommand : CommandBase
    {
        private readonly AccountService _accountService;
        private MainWindowViewModel _mainWindowViewModel;
        private MainWindow _mainWindow;
        public LogInCommand(MainWindowViewModel mainWindowViewModel, MainWindow mainWindow)
        {
            _mainWindowViewModel = mainWindowViewModel;
            _accountService = new(new AccountRepository());
            _mainWindow = mainWindow;
        }

        public override void Execute(object? parameter)
        {
            Account account = _accountService.Get(_mainWindowViewModel.Username, _mainWindowViewModel.Password);
            if (account == null)
            {
                Notification.ShowErrorDialog("incorrect username or password");
                return;
            }

            //Globals.LoggedUser = user;
            try
            {
                openRoleWindow(account);
            }
            catch (Exception error)
            {
                Notification.ShowErrorDialog(error.Message);
                return;
            }
            _mainWindow.Close();
        }

        private void openRoleWindow(Account account)
        {
            switch (account.Type)
            {
                case Account.UserType.Administrator:
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                    break;
                case Account.UserType.Librarian:
                    LibrarianWindow librarianWindow = new LibrarianWindow();
                    librarianWindow.Show();
                    break;
                case Account.UserType.SpecializedLibrarian:
                    SpecializedLibrarianWindow specializedLibrarianWindow = new SpecializedLibrarianWindow();
                    specializedLibrarianWindow.Show();
                    break;
                case Account.UserType.Member:
                    MemberWindow memberWindow = new MemberWindow();
                    memberWindow.Show();
                    break;
            }
        }
    }
}
