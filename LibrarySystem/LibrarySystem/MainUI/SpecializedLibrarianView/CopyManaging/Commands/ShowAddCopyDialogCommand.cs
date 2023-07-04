using System.ComponentModel;
using LibrarySystem.Utils;

namespace LibrarySystem.MainUI.SpecializedLibrarianView.CopyManaging.Commands
{
    class ShowAddCopyDialogCommand : CommandBase
    {
        SpecializedLibrarianViewModel _viewModel;
        public ShowAddCopyDialogCommand(SpecializedLibrarianViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SpecializedLibrarianViewModel.SelectedBook))
            {
                OnCanExecutedChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return _viewModel.SelectedBook != null && base.CanExecute(parameter);
        }
        public override void Execute(object? Parameter)
        {
            AddCopyDialog addCopyDialog= new(_viewModel);
            addCopyDialog.ShowDialog();
        }
    }
}
