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
using LibrarySystem.Users.Members;

namespace LibrarySystem.Users.GUI.Views
{
    /// <summary>
    /// Interaction logic for EditMemberWindow.xaml
    /// </summary>
    public partial class EditMemberWindow : Window
    {
        public EditMemberWindow(MembersHandlingWindow membersHandlingWindow, Member editedMember)
        {
            InitializeComponent();
            DataContext = new EditMemberViewModel(membersHandlingWindow, this, editedMember);
        }
    }
}
