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
using System.Windows.Shapes;
using LibrarySystem.Inventory.Titles;

namespace LibrarySystem.MainUI.SpecializedLibrarianView.TitleManaging
{
    /// <summary>
    /// Interaction logic for EditTitleDialog.xaml
    /// </summary>
    public partial class EditTitleDialog : Window
    {
        public EditTitleDialog(Title selectedTitle, SpecializedLibrarianViewModel specializedLibrarianViewModel)
        {
            DataContext = new EditTitleDialogViewModel(this, selectedTitle, specializedLibrarianViewModel);
            InitializeComponent();
        }
    }
}
