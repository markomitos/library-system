using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Utils;

namespace LibrarySystem.MainUI.SpecializedLibrarianView.ICommands
{
    class ShowAddTitleDialogCommand : CommandBase
    {
        public SpecializedLibrarianViewModel _viewModel;

        public ShowAddTitleDialogCommand(SpecializedLibrarianViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object? Parameter)
        {
            AddTitleDialog addTitleDialog = new AddTitleDialog(_viewModel);
            addTitleDialog.ShowDialog();
        }
    }
}
