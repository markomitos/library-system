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
using LibrarySystem.BookLoan;
using LibrarySystem.Inventory.Books;
using LibrarySystem.Inventory.Copies;
using LibrarySystem.Inventory.Titles;

namespace LibrarySystem.MainUI
{
    /// <summary>
    /// Interaction logic for LibrarianWindow.xaml
    /// </summary>
    public partial class LibrarianWindow : Window
    {
        public LibrarianWindow()
        {
            InitializeComponent();
            DataContext = new BookLoanViewModel();
        }

        private void Titles_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is DataGrid dataGrid && dataGrid.SelectedItem is Title SelectedTitle)
            {
                var viewModel = DataContext as BookLoanViewModel;
                viewModel.SelectedTitle = SelectedTitle;
            }
        }

        private void Books_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is DataGrid dataGrid && dataGrid.SelectedItem is Book SelectedBook)
            {
                var viewModel = DataContext as BookLoanViewModel;
                viewModel.SelectedBook = SelectedBook;
            }
        }

        private void Copies_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is DataGrid dataGrid && dataGrid.SelectedItem is Copy SelectedCopy)
            {
                var viewModel = DataContext as BookLoanViewModel;
                viewModel.SelectedCopy = SelectedCopy;
            }
        }

    }
}
