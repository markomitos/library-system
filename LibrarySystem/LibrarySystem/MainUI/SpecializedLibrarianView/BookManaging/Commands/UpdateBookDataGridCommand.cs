using System.Collections.ObjectModel;
using System.ComponentModel;
using LibrarySystem.Inventory.Books;
using LibrarySystem.Utils;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibrarySystem.MainUI.SpecializedLibrarianView.BookManaging.Commands
{
    class UpdateBookDataGridCommand : CommandBase
    {
        SpecializedLibrarianViewModel _viewModel;

        public UpdateBookDataGridCommand(SpecializedLibrarianViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SpecializedLibrarianViewModel.SelectedTitle))
            {
                OnCanExecutedChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return _viewModel.SelectedTitle != null && base.CanExecute(parameter);
        }

        public override void Execute(object? Parameter)
        {
            _viewModel.Books = new ObservableCollection<Book>();
            int udk = _viewModel.SelectedTitle.UDK;
            foreach (var book in _viewModel._bookService.GetBooksByUDK(udk))
            {
                _viewModel.Books.Add(book);
            }
        }
    }
}
