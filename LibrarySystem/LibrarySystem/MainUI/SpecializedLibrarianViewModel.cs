using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LibrarySystem.Inventory.Books;
using LibrarySystem.Inventory.Copies;
using LibrarySystem.Inventory.Titles;
using LibrarySystem.MainUI.SpecializedLibrarianView.ICommands;
using LibrarySystem.Utils;

namespace LibrarySystem.MainUI
{
    public class SpecializedLibrarianViewModel : ViewModelBase
    {
        private readonly TitleService _titleService = new(new TitleRepository());
        private readonly BookService _bookService = new(new BookRepository());
        public SpecializedLibrarianWindow _SpecializedLibrarianWindow;
        public ObservableCollection<Title> Titles { get; set; }

        private ICommand _showAddTitleDialogCommand;

        public ICommand ShowAddTitleDialogCommand
        {
            get { return _showAddTitleDialogCommand ??= new ShowAddTitleDialogCommand(this); }
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
