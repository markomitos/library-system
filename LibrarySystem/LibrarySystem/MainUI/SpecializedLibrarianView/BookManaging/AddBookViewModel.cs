using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LibrarySystem.Inventory.Books;
using LibrarySystem.MainUI.SpecializedLibrarianView.BookManaging.Commands;
using LibrarySystem.Utils;

namespace LibrarySystem.MainUI.SpecializedLibrarianView.BookManaging
{
    public class AddBookViewModel : ViewModelBase
    {
        public AddBookDialog _addBookdialog;
        public SpecializedLibrarianViewModel _specializedLibrarianViewModel;
        private ObservableCollection<Book.BookFormat>? _formats;
        public ObservableCollection<Book.BookFormat>? Formats
        {
            get => _formats;
            set
            {
                _formats = value;
                OnPropertyChanged(nameof(Formats));
            }
        }
        public AddBookViewModel(AddBookDialog addBookDialog, SpecializedLibrarianViewModel specializedLibrarianViewModel)
        {
            _addBookdialog = addBookDialog;
            _specializedLibrarianViewModel = specializedLibrarianViewModel;
            LoadFormats();
        }

        private void LoadFormats()
        {
            Formats = new ObservableCollection<Book.BookFormat>();
            Formats.Add(Book.BookFormat.Physical);
            Formats.Add(Book.BookFormat.Audio);
        }

        private ICommand _addBookCommand;

        public ICommand AddBookCommand
        {
            get { return _addBookCommand ??= new AddBookCommand(this, _specializedLibrarianViewModel); }
        }
    }
}
