using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LibrarySystem.MainUI.SpecializedLibrarianView.CopyManaging.Commands;
using LibrarySystem.Utils;

namespace LibrarySystem.MainUI.SpecializedLibrarianView.CopyManaging
{
    public class AddCopyViewModel : ViewModelBase
    {
        public AddCopyDialog _addCopyDialog;
        public SpecializedLibrarianViewModel _specializedLibrarianViewModel;
        public AddCopyViewModel(AddCopyDialog addCopyDialog, SpecializedLibrarianViewModel specializedLibrarianViewModel)
        {
            _addCopyDialog = addCopyDialog;
            _specializedLibrarianViewModel = specializedLibrarianViewModel;
        }

        private ICommand _addCopyCommand;

        public ICommand AddCopyCommand
        {
            get { return _addCopyCommand ??= new AddCopyCommand(this, _specializedLibrarianViewModel); }
        }

    }
}
