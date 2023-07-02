using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LibrarySystem.Inventory.Titles;
using LibrarySystem.MainUI.SpecializedLibrarianView.ICommands;
using LibrarySystem.Publishing;
using LibrarySystem.Utils;

namespace LibrarySystem.MainUI.SpecializedLibrarianView
{
    public class AddTitleDialogViewModel: ViewModelBase
    {
        public AddTitleDialog _addTitleDialog;
        private readonly AuthorService _authorService = new(new AuthorRepository());
        public TitleService _titleService = new(new TitleRepository());
        public ObservableCollection<string> Authors { get; set; }

        private ICommand _AddAuthorCommand;
        public ICommand AddAuthorCommand
        {
            get { return _AddAuthorCommand ??= new AddAuthorCommand(this); }
        }

        private ICommand _RemoveAuthorCommand;
        public ICommand RemoveAuthorCommand
        {
            get { return _RemoveAuthorCommand ??= new RemoveAuthorCommand(this); }
        }

        private ICommand _AddTitleCommand;

        public ICommand AddTitleCommand
        {
            get { return _AddTitleCommand ??= new AddTitleCommand(this); }
        }

        public AddTitleDialogViewModel(AddTitleDialog addTitleDialog)
        {
            LoadAuthors();
            _addTitleDialog = addTitleDialog;
        }

        private void LoadAuthors()
        {
            Authors = new ObservableCollection<string>(_authorService.GetAllToString());
        }
    }
}
