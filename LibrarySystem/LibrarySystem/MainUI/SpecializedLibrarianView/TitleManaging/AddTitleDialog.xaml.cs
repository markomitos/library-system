using System.Windows;

namespace LibrarySystem.MainUI.SpecializedLibrarianView.TitleManaging
{
    /// <summary>
    /// Interaction logic for AddTitleDialog.xaml
    /// </summary>
    public partial class AddTitleDialog : Window
    {
        public AddTitleDialog(SpecializedLibrarianViewModel viewModel)
        {
            DataContext = new AddTitleDialogViewModel(this, viewModel);
            InitializeComponent();
        }
    }
}
