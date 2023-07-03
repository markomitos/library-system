﻿using System;
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
using LibrarySystem.BookBorrowings.BookReturn;
using LibrarySystem.Inventory.Books;
using LibrarySystem.Inventory.Copies;
using LibrarySystem.Inventory.Titles;
using LibrarySystem.Users.GUI.Views;

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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BookBorrowingView bbv = new BookBorrowingView();
            bbv.ShowDialog();
        }

        private void handleMembersButton_Click(object sender, RoutedEventArgs e)
        {
            MembersHandlingWindow membersHandlingWindow = new MembersHandlingWindow();
            membersHandlingWindow.ShowDialog();
        }

        private void ReturnBookButton_OnClick(object sender, RoutedEventArgs e)
        {
            BookReturnWindow bookReturnWindow = new BookReturnWindow();
            bookReturnWindow.ShowDialog();
        }
    }
}
