using System.Windows;

namespace LibrarySystem.MainUI
{
    /// <summary>
    /// Interaction logic for SpecializedLibrarianWindow.xaml
    /// </summary>
    public partial class SpecializedLibrarianWindow : Window
    {
        public SpecializedLibrarianWindow()
        {
            DataContext = new SpecializedLibrarianViewModel();
            InitializeComponent();
        }
    }
}
