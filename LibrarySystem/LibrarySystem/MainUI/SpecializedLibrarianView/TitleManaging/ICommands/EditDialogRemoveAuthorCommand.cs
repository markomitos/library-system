using LibrarySystem.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.MainUI.SpecializedLibrarianView.TitleManaging.ICommands
{
    class EditDialogRemoveAuthorCommand : CommandBase
    {
        EditTitleDialogViewModel _viewModel;
        public EditDialogRemoveAuthorCommand(EditTitleDialogViewModel editTitleDialogViewModel)
        {
            _viewModel = editTitleDialogViewModel;
        }

        public override void Execute(object? Parameter)
        {
            string author = _viewModel.EditTitleDialog.addedAuthorsBox.SelectedItem.ToString();
            _viewModel.Authors.Add(author);
            _viewModel.AddedAuthors.Remove(author);
        }
    }
}
