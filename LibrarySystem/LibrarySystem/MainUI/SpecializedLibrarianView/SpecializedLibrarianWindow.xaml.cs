using System.Windows;

namespace LibrarySystem.MainUI.SpecializedLibrarianView
{
    /// <summary>
    /// Interaction logic for SpecializedLibrarianWindow.xaml
    /// </summary>
    public partial class SpecializedLibrarianWindow : Window
    {
        public SpecializedLibrarianWindow()
        {
            DataContext = new SpecializedLibrarianViewModel(this);
            InitializeComponent();
        }
    }
}
