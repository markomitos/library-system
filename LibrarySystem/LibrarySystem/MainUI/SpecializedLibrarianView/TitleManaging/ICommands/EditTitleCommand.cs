using LibrarySystem.Inventory.Titles;
using LibrarySystem.NotificationDialogs;
using LibrarySystem.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.MainUI.SpecializedLibrarianView.TitleManaging.ICommands
{
    class EditTitleCommand : CommandBase
    {
        EditTitleDialogViewModel _viewModel;
        private SpecializedLibrarianViewModel _specializedLibrarianViewModel;
        TitleService _titleService = new TitleService(new TitleRepository());
        public EditTitleCommand(EditTitleDialogViewModel addTitleDialogViewModel, SpecializedLibrarianViewModel specializedLibrarianViewModel)
        {
            _viewModel = addTitleDialogViewModel;
            _specializedLibrarianViewModel = specializedLibrarianViewModel;
        }

        public override void Execute(object? Parameter)
        {
            try
            {
                string name = _viewModel.Name;
                string language = _viewModel.Language;
                string genre = _viewModel.Genre;

                List<string> authors = new List<string>();

                foreach (string author in _viewModel.AddedAuthors)
                {
                    string id = author.Split("|")[0];
                    authors.Add(id);
                }

                _titleService.Edit(new Title(name, language, _viewModel.Udk, genre, authors, _viewModel.Books));

                _specializedLibrarianViewModel._SpecializedLibrarianWindow.Close();
                SpecializedLibrarianWindow window = new();
                window.Show();
                _viewModel.EditTitleDialog.Close();
            }
            catch (Exception ex)
            {
                Notification.ShowErrorDialog(ex.Message);
            }

        }
    }
}
