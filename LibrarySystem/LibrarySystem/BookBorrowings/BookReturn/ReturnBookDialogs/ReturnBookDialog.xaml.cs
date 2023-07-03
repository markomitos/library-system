﻿using System.Windows;
using LibrarySystem.BookBorrowings.Borrowing;
using LibrarySystem.Inventory.Copies;

namespace LibrarySystem.BookBorrowings.BookReturn.ReturnBookDialogs
{
    /// <summary>
    /// Interaction logic for ReturnBookDialog.xaml
    /// </summary>
    public partial class ReturnBookDialog : Window
    {
        public BookReturnWindow BookReturnWindow;
        public ReturnBookDialog(BookBorrowing borrowing, BookReturnWindow bookReturnWindow)
        {
            DataContext = new ReturnBookViewModel(borrowing, 
                new BookBorrowingService(new BookBorrowingRepository()), new CopiesService(new CopiesRepository()),this);
            BookReturnWindow = bookReturnWindow;
            InitializeComponent();
        }
    }
}
