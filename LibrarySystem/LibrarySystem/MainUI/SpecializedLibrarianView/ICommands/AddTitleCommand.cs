using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Inventory.Titles;
using LibrarySystem.Utils;
using ZdravoCorp.MainUI.NotificationDialogs;

namespace LibrarySystem.MainUI.SpecializedLibrarianView.ICommands
{
    class AddTitleCommand : CommandBase
    {
        AddTitleDialogViewModel _viewModel;
        private SpecializedLibrarianViewModel _specializedLibrarianViewModel;
        public AddTitleCommand(AddTitleDialogViewModel addTitleDialogViewModel, SpecializedLibrarianViewModel specializedLibrarianViewModel)
        {
            _viewModel = addTitleDialogViewModel;
            _specializedLibrarianViewModel = specializedLibrarianViewModel;
        }

        public override void Execute(object? Parameter)
        {
            try
            {
                string name = _viewModel._addTitleDialog.nameTextBox.Text;
                string language = _viewModel._addTitleDialog.languageTextBox.Text;
                int udk = int.Parse(_viewModel._addTitleDialog.UDKTextBox.Text);
                string genre = _viewModel._addTitleDialog.GenreTextBox.Text;

                if (_viewModel._titleService.AlreadyExists(udk))
                {
                    throw new Exception("Title with this UDK already exists!");
                }

                List<string> authors = new List<string>();

                foreach (string author in _viewModel._addTitleDialog.addedAuthorsBox.Items)
                {
                    string id = author.Split("|")[0];
                    authors.Add(id);
                }

                _viewModel._titleService.Add(new Title(name, language, udk, genre, authors, new List<int>()));

                Notification.ShowSuccessDialog("Successfully added a title");
                _specializedLibrarianViewModel._SpecializedLibrarianWindow.Close();
                SpecializedLibrarianWindow window = new();
                window.Show();
                _viewModel._addTitleDialog.Close();
            }
            catch (Exception ex)
            {
                Notification.ShowErrorDialog(ex.Message);
            }
            
        }
    }
}
