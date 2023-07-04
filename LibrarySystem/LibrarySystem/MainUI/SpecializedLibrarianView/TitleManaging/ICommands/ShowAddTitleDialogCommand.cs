using LibrarySystem.Utils;

namespace LibrarySystem.MainUI.SpecializedLibrarianView.TitleManaging.ICommands
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
