using LibrarySystem.Inventory.Books;
using LibrarySystem.Inventory.Copies;
using LibrarySystem.Inventory.Titles;
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
using LibrarySystem.BookBorrowings.ViewModel;

namespace LibrarySystem.MainUI
{
    /// <summary>
    /// Interaction logic for BookBorrowingView.xaml
    /// </summary>
    public partial class BookBorrowingView : Window
    {
        public BookBorrowingView()
        {
            InitializeComponent();
            DataContext = new BookBorrowingViewModel(this);
        }

        private void Titles_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is DataGrid dataGrid && dataGrid.SelectedItem is TitleViewModel SelectedTitle)
            {
                var viewModel = DataContext as BookBorrowingViewModel;
                viewModel.SelectedTitle = SelectedTitle;
            }
        }

        private void Books_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is DataGrid dataGrid && dataGrid.SelectedItem is BookViewModel SelectedBook)
            {
                var viewModel = DataContext as BookBorrowingViewModel;
                viewModel.SelectedBook = SelectedBook;
            }
        }

        private void Copies_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is DataGrid dataGrid && dataGrid.SelectedItem is Copy SelectedCopy)
            {
                var viewModel = DataContext as BookBorrowingViewModel;
                viewModel.SelectedCopy = SelectedCopy;
            }
        }

    }


}

