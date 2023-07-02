using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using LibrarySystem.Publishing;
using LibrarySystem.Utils;

namespace LibrarySystem.MainUI.SpecializedLibrarianView.ICommands
{
    class AddAuthorCommand : CommandBase
    {
        AddTitleDialogViewModel _viewModel;
        public AddAuthorCommand(AddTitleDialogViewModel addTitleDialogViewModel)
        {
            _viewModel = addTitleDialogViewModel;
        }

        public override void Execute(object? Parameter)
        {
            string author = _viewModel._addTitleDialog.loadedAuthorsBox.SelectedItem.ToString();
            _viewModel.Authors.Remove(author);
            _viewModel._addTitleDialog.addedAuthorsBox.Items.Add(author);
        }
    }
}
