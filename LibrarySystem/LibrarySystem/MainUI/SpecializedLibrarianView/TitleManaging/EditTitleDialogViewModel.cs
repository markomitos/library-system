using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LibrarySystem.Inventory.Titles;
using LibrarySystem.MainUI.SpecializedLibrarianView.TitleManaging.ICommands;
using LibrarySystem.Publishing;
using LibrarySystem.Utils;

namespace LibrarySystem.MainUI.SpecializedLibrarianView.TitleManaging
{
    public class EditTitleDialogViewModel : ViewModelBase
    {
        private Title _selectedTitle;
        private SpecializedLibrarianViewModel _specializedLibrarianViewModel;
        public EditTitleDialog EditTitleDialog;
        private AuthorService _authorService = new AuthorService(new AuthorRepository());
        public ObservableCollection<string> Authors { get; set; }
        public ObservableCollection<string> AddedAuthors { get; set; }
        public int Udk;
        public List<int> Books;

        private string? _name;

        public string? Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string? _language;

        public string? Language
        {
            get => _language;
            set
            {
                _language = value;
                OnPropertyChanged(nameof(Language));
            }
        }

        private string? _genre;

        public string? Genre
        {
            get => _genre;
            set
            {
                _genre = value;
                OnPropertyChanged(nameof(Genre));
            }
        }

        private ICommand _editDialogAddAuthorCommand;
        public ICommand EditDialogAddAuthorCommand
        {
            get { return _editDialogAddAuthorCommand ??= new EditDialogAddAuthorCommand(this); }
        }

        private ICommand _editDialogRemoveAuthorCommand;
        public ICommand EditDialogRemoveAuthorCommand
        {
            get { return _editDialogRemoveAuthorCommand ??= new EditDialogRemoveAuthorCommand(this); }
        }

        private ICommand _editTitleCommand;

        public ICommand EditTitleCommand
        {
            get { return _editTitleCommand ??= new EditTitleCommand(this, _specializedLibrarianViewModel); }
        }

        public EditTitleDialogViewModel(EditTitleDialog editTitleDialog, Title selectedTitle, SpecializedLibrarianViewModel specializedLibrarianViewModel)
        {
            _selectedTitle = selectedTitle;
            EditTitleDialog = editTitleDialog;
            _specializedLibrarianViewModel = specializedLibrarianViewModel;
            LoadData();
        }

        private void LoadData()
        {
            Udk = _selectedTitle.UDK;
            Name = _selectedTitle.Name;
            Language = _selectedTitle.Language;
            Genre = _selectedTitle.Genre;
            LoadAuthors();
            Books = _selectedTitle.Books;
        }

        private void LoadAuthors()
        {
            Authors = new ObservableCollection<string>(_authorService.GetAllToStringWithout(_selectedTitle.Authors));
            AddedAuthors = new ObservableCollection<string>(_authorService.GetAllToString(_selectedTitle.Authors));
        }
    }
}
