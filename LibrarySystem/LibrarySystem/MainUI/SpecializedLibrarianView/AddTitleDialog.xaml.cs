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

namespace LibrarySystem.MainUI.SpecializedLibrarianView
{
    /// <summary>
    /// Interaction logic for AddTitleDialog.xaml
    /// </summary>
    public partial class AddTitleDialog : Window
    {
        public AddTitleDialog(SpecializedLibrarianViewModel viewModel)
        {
            DataContext = new AddTitleDialogViewModel(this, viewModel);
            InitializeComponent();
        }
    }
}
