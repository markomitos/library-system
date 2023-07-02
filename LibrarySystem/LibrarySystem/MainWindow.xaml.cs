using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LibrarySystem.MainUI;
using LibrarySystem.Users;
using ZdravoCorp.MainUI.NotificationDialogs;
using static LibrarySystem.Users.Account;

namespace LibrarySystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AccountService _accountService;
        public MainWindow()
        {
            InitializeComponent();
            _accountService = new(new AccountRepository());
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            Account account = _accountService.GetAccount(this.usernameTextbox.Text, this.passwordTextbox.Password);
            if (account == null)
            {
                errorLabel.Visibility = Visibility.Visible;
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
            this.Close();
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

        private void LoginWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
        }


        private void loginWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                loginBtn_Click(sender, e);
        }
    }
}
