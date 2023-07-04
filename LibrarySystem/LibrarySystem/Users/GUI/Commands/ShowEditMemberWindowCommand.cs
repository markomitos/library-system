using LibrarySystem.Users.GUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LibrarySystem.NotificationDialogs;
using LibrarySystem.Users.GUI.ViewModels;
using LibrarySystem.Utils;

namespace LibrarySystem.Users.GUI.Commands
{
    public class ShowEditMemberWindowCommand : CommandBase
    {
        private MembersHandlingViewModel _membersHandlingViewModel;
        public ShowEditMemberWindowCommand(MembersHandlingViewModel membersHandlingViewModel)
        {
            _membersHandlingViewModel = membersHandlingViewModel;
        }
        public override void Execute(object? parameter)
        {
            try
            {
                var membersHandlingWindow = parameter as MembersHandlingWindow;

                if (_membersHandlingViewModel.SelectedMember == null)
                {
                    throw new InvalidOperationException("Member must be selected");
                }

                EditMemberWindow editMemberWindow = new(membersHandlingWindow, _membersHandlingViewModel.SelectedMember);
                editMemberWindow.Owner = membersHandlingWindow;
                editMemberWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                editMemberWindow.ShowDialog();
            }
            catch (Exception error)
            {
                Notification.ShowErrorDialog(error.Message);
            }
        }
    }
}
