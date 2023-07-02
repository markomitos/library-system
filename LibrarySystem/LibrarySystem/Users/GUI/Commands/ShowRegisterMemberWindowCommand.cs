using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LibrarySystem.Users.GUI.ViewModels;
using LibrarySystem.Users.GUI.Views;
using LibrarySystem.Utils;
using ZdravoCorp.MainUI.NotificationDialogs;

namespace LibrarySystem.Users.GUI.Commands
{
    class ShowRegisterMemberWindowCommand : CommandBase
    {
        public ShowRegisterMemberWindowCommand()
        {
        }

        public override void Execute(object? parameter)
        {
            var membersHandlingWindow = parameter as MembersHandlingWindow;

            RegisterMemberWindow registerMemberWindow = new(membersHandlingWindow);
            registerMemberWindow.Owner = membersHandlingWindow;
            registerMemberWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            registerMemberWindow.ShowDialog();

        }
    }
}
