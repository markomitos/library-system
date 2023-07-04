using System.Collections.ObjectModel;
using System.ComponentModel;
using LibrarySystem.Inventory.Copies;
using LibrarySystem.Utils;

namespace LibrarySystem.MainUI.SpecializedLibrarianView.CopyManaging.Commands
{
    class UpdateCopyDataGridCommand : CommandBase
    {
        SpecializedLibrarianViewModel _viewModel;

        public UpdateCopyDataGridCommand(SpecializedLibrarianViewModel viewModel)
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
            _viewModel.Copies = new ObservableCollection<Copy>();
            foreach (var copy in _viewModel._copyService.GetCopiesById(_viewModel.SelectedBook.Copies))
            {
                _viewModel.Copies.Add(copy);
            }
        }
    }
}
