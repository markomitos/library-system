using System.Windows;

namespace LibrarySystem.MainUI.SpecializedLibrarianView.BookManaging
{
    /// <summary>
    /// Interaction logic for AddBookDialog.xaml
    /// </summary>
    public partial class AddBookDialog : Window
    {
        public AddBookDialog(SpecializedLibrarianViewModel specializedLibrarianViewModel)
        {
            DataContext = new AddBookViewModel(this, specializedLibrarianViewModel);
            InitializeComponent();
        }
    }
}
