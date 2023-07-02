using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LibrarySystem.Inventory.Titles;
using LibrarySystem.MainUI.SpecializedLibrarianView.ICommands;
using LibrarySystem.Utils;

namespace LibrarySystem.MainUI
{
    public class SpecializedLibrarianViewModel : ViewModelBase
    {
        private readonly TitleService _titleService = new(new TitleRepository());

        public ObservableCollection<Title> Titles { get; set; }

        private ICommand _showAddTitleDialogCommand;

        public ICommand ShowAddTitleDialogCommand
        {
            get { return _showAddTitleDialogCommand ??= new ShowAddTitleDialogCommand(); }
        }

        public SpecializedLibrarianViewModel()
        {
            LoadTitles();
        }

        private void LoadTitles()
        {
            Titles = new ObservableCollection<Title>(_titleService.GetAll());
        }
    }
}
