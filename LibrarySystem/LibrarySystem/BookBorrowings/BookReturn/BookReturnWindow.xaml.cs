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
using LibrarySystem.BookBorrowings.Borrowing;
using LibrarySystem.Users.Members;

namespace LibrarySystem.BookBorrowings.BookReturn
{
    /// <summary>
    /// Interaction logic for BookReturnWindow.xaml
    /// </summary>
    public partial class BookReturnWindow : Window
    {
        public BookReturnWindow()
        {
            DataContext = new BookReturnViewModel(new MemberService(new MemberRepository()),new BookBorrowingService(new BookBorrowingRepository()),this);
            InitializeComponent();
        }

    }
}
