using System.Windows;

namespace LibrarySystem.NotificationDialogs.Presentation
{
    /// <summary>
    /// Interaction logic for ErrorDialog.xaml
    /// </summary>
    public partial class ErrorDialog : Window
    {
        public ErrorDialog(string message)
        {
            InitializeComponent();
            messageTextBlock.Text = message;
        }

        private void okayBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
