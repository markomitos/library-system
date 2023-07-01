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

namespace LibrarySystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            //User user = UserService.GetLoginUser(this.usernameTextbox.Text, this.passwordTextbox.Password);
            //if (user == null)
            //{
            //    errorLabel.Visibility = Visibility.Visible;
            //    return;
            //}

            //Globals.LoggedUser = user;
            //try
            //{
            //    openRoleWindow(user);
            //}
            //catch (Exception error)
            //{
            //    Notification.ShowErrorDialog(error.Message);

            //    return;
            //}
            //this.Close();
        }

        //private void openRoleWindow(User user)
        //{
        //    switch (user.Role)
        //    {
        //        //case User.UserRole.Doctor:
        //        //    DoctorWindow dw = new DoctorWindow();
        //        //    dw.Show();
        //        //    break;
        //        //case User.UserRole.Nurse:
        //        //    NurseWindow nw = new NurseWindow();
        //        //    nw.Show();
        //        //    break;
        //        //case User.UserRole.Patient:
        //        //    if (PatientService.IsPatientBlocked(user.Username))
        //        //    {
        //        //        throw new InvalidOperationException("This account has been permanently disabled.");
        //        //    }
        //        //    else
        //        //    {
        //        //        PatientWindow pd = new PatientWindow();
        //        //        pd.Show();
        //        //    }
        //        //    break;
        //        //case User.UserRole.Manager:
        //        //    ManagerWindow wm = new ManagerWindow();
        //        //    wm.Show();
        //        //    break;
        //    }
        //}

        private void LoginWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //JobManager.Initialize(new InventoryTimerRegistry());
            //RenovationSchedule.CheckRenovations();
        }


        private void loginWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                loginBtn_Click(sender, e);
        }
    }
}
