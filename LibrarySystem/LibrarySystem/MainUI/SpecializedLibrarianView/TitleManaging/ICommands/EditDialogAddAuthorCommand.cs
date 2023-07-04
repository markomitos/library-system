using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Utils;

namespace LibrarySystem.MainUI.SpecializedLibrarianView.TitleManaging.ICommands
{
    class EditDialogAddAuthorCommand : CommandBase
    {
        EditTitleDialogViewModel _viewModel;
        public EditDialogAddAuthorCommand(EditTitleDialogViewModel editTitleDialogViewModel)
        {
            _viewModel = editTitleDialogViewModel;
        }

        public override void Execute(object? Parameter)
        {
            string author = _viewModel.EditTitleDialog.loadedAuthorsBox.SelectedItem.ToString();
            _viewModel.Authors.Remove(author);
            _viewModel.AddedAuthors.Add(author);
        }
    }
}
