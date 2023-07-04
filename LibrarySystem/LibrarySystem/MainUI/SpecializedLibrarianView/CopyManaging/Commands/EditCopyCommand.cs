using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Inventory.Copies;
using LibrarySystem.NotificationDialogs;
using LibrarySystem.Utils;

namespace LibrarySystem.MainUI.SpecializedLibrarianView.CopyManaging.Commands
{
    class EditCopyCommand : CommandBase
    {
        EditCopyDialogViewModel _viewModel;
        private SpecializedLibrarianViewModel _specializedLibrarianViewModel;
        CopiesService _copiesService = new CopiesService(new CopiesRepository());
        public EditCopyCommand(EditCopyDialogViewModel editCopyDialogViewModel, SpecializedLibrarianViewModel specializedLibrarianViewModel)
        {
            _viewModel = editCopyDialogViewModel;
            _specializedLibrarianViewModel = specializedLibrarianViewModel;
        }

        public override void Execute(object? Parameter)
        {
            try
            {
                Copy.CopyStatus status = _viewModel.SelectedStatus;
                int price = _viewModel.Price;
                bool isDamaged = _viewModel.IsChecked;
                int id = _viewModel.Id;
                _copiesService.Edit(id ,new Copy(status, price, isDamaged));

                _specializedLibrarianViewModel._SpecializedLibrarianWindow.Close();
                SpecializedLibrarianWindow window = new();
                window.Show();
                _viewModel.EditCopyDialog.Close();
            }
            catch (Exception ex)
            {
                Notification.ShowErrorDialog(ex.Message);
            }

        }
    }
}
