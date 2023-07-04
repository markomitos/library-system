using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LibrarySystem.Utils
{
    internal class LogoutCommand : CommandBase
    {

        private readonly Window _window;
        public LogoutCommand(Window windowToClose)
        {
            _window = windowToClose;
        }

        public override void Execute(object? parameter)
        {
            MainWindow mainWindow = new();
            mainWindow.Show();

            Globals.LoggedUser = null;
            _window.Close();
        }
    }
}
