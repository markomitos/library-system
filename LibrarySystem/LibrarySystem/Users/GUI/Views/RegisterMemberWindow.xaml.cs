﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LibrarySystem.Users.GUI.ViewModels;

namespace LibrarySystem.Users.GUI.Views
{
    /// <summary>
    /// Interaction logic for RegisterMemberWindow.xaml
    /// </summary>
    public partial class RegisterMemberWindow : Window
    {
        public RegisterMemberWindow(MembersHandlingWindow? membersHandlingWindow)
        {
            InitializeComponent();
            RegisterMemberViewModel registerMemberViewModel = new(membersHandlingWindow);
            this.DataContext = registerMemberViewModel;
        }
    }
}
