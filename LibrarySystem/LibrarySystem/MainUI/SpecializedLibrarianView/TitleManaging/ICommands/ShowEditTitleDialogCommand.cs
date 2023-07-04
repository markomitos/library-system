using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Inventory.Titles;
using LibrarySystem.Utils;

namespace LibrarySystem.MainUI.SpecializedLibrarianView.TitleManaging.ICommands
{
    class ShowEditTitleDialogCommand : CommandBase
    {
        SpecializedLibrarianViewModel _viewModel;
        private TitleService _titleService = new(new TitleRepository());
        public ShowEditTitleDialogCommand(SpecializedLibrarianViewModel viewModel)
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
            EditTitleDialog editTitleDialog = new EditTitleDialog(_titleService.Get(_viewModel.SelectedTitle.UDK), _viewModel);
            editTitleDialog.ShowDialog();
            
        }
    }
}
