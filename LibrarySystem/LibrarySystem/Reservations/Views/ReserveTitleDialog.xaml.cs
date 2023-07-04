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
using LibrarySystem.Reservations.ViewModels;

namespace LibrarySystem.Reservations.Views
{
    /// <summary>
    /// Interaction logic for ReserveTitleDialog.xaml
    /// </summary>
    public partial class ReserveTitleDialog : Window
    {
        public ReserveTitleDialog()
        {
            DataContext = new ReserveTitleDialogViewModel(this,new TitleService(new TitleRepository()));
            InitializeComponent();
        }
    }
}
