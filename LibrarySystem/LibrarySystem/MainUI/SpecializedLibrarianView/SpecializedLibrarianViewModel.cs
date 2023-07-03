﻿using System.Collections.ObjectModel;
using System.Windows.Input;
using LibrarySystem.Inventory.Books;
using LibrarySystem.Inventory.Copies;
using LibrarySystem.Inventory.Titles;
using LibrarySystem.MainUI.SpecializedLibrarianView.BookManaging.Commands;
using LibrarySystem.MainUI.SpecializedLibrarianView.CopyManaging.Commands;
using LibrarySystem.MainUI.SpecializedLibrarianView.TitleManaging.ICommands;
using LibrarySystem.Utils;

namespace LibrarySystem.MainUI.SpecializedLibrarianView
{
    public class SpecializedLibrarianViewModel : ViewModelBase
    {
        private readonly TitleService _titleService = new(new TitleRepository());
        public BookService _bookService = new(new BookRepository());
        public CopiesService _copyService = new(new CopiesRepository());

        public SpecializedLibrarianWindow _SpecializedLibrarianWindow;
        public ObservableCollection<Title> Titles { get; set; }
        private ObservableCollection<Copy>? _copies;

        public ObservableCollection<Copy>? Copies
        {
            get => _copies;
            set
            {
                _copies = value;
                OnPropertyChanged(nameof(Copies));
            }
        }

        private ObservableCollection<Book>? _books;
        public ObservableCollection<Book>? Books
        {
            get => _books;
            set
            {
                _books = value;
                OnPropertyChanged(nameof(Books));
            }
        }

        private Title? _selectedTitle;

        public Title? SelectedTitle
        {
            get => _selectedTitle;
            set
            {
                _selectedTitle = value;
                OnPropertyChanged(nameof(SelectedTitle));
            }
        }

        private Book? _selectedBook;

        public Book? SelectedBook
        {
            get => _selectedBook;
            set
            {
                _selectedBook = value;
                OnPropertyChanged(nameof(SelectedBook));
            }
        }

        private ICommand _showAddTitleDialogCommand;

        public ICommand ShowAddTitleDialogCommand
        {
            get { return _showAddTitleDialogCommand ??= new ShowAddTitleDialogCommand(this); }
        }

        private ICommand _showAddBookDialogCommand;

        public ICommand ShowAddBookDialogCommand
        {
            get { return _showAddBookDialogCommand ??= new ShowAddBookDialogCommand(this); }
        }

        private ICommand _showAddCopyDialogCommand;

        public ICommand ShowAddCopyDialogCommand
        {
            get { return _showAddCopyDialogCommand ??= new ShowAddCopyDialogCommand(this); }
        }

        private ICommand _updateBookDataGridCommand;

        public ICommand UpdateBookDataGridCommand
        {
            get { return _updateBookDataGridCommand ??= new UpdateBookDataGridCommand(this); }
        }

        private ICommand _updateCopyDataGridCommand;

        public ICommand UpdateCopyDataGridCommand
        {
            get { return _updateCopyDataGridCommand ??= new UpdateCopyDataGridCommand(this); }
        }

        public SpecializedLibrarianViewModel(SpecializedLibrarianWindow specializedLibrarianWindow)
        {
            LoadTitles();
            _SpecializedLibrarianWindow = specializedLibrarianWindow;

        }

        private void LoadTitles()
        {
            Titles = new ObservableCollection<Title>(_titleService.GetAll());
        }
    }
}