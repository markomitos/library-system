﻿using LibrarySystem.Utils;

namespace LibrarySystem.MainUI.SpecializedLibrarianView.TitleManaging.ICommands
{
    class RemoveAuthorCommand : CommandBase
    {
        AddTitleDialogViewModel _viewModel;
        public RemoveAuthorCommand(AddTitleDialogViewModel addTitleDialogViewModel)
        {
            _viewModel = addTitleDialogViewModel;
        }

        public override void Execute(object? Parameter)
        {
            string author = _viewModel._addTitleDialog.addedAuthorsBox.SelectedItem.ToString();
            _viewModel.Authors.Add(author);
            _viewModel._addTitleDialog.addedAuthorsBox.Items.Remove(author);
        }
    }
}
