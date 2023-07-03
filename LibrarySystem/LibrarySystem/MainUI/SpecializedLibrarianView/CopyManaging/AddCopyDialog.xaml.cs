using System.Windows;

namespace LibrarySystem.MainUI.SpecializedLibrarianView.CopyManaging
{
    /// <summary>
    /// Interaction logic for AddCopyDialog.xaml
    /// </summary>
    public partial class AddCopyDialog : Window
    {
        public AddCopyDialog(SpecializedLibrarianViewModel specializedLibrarianViewModel)
        {
            DataContext = new AddCopyViewModel(this, specializedLibrarianViewModel);
            InitializeComponent();
        }
    }
}
