﻿using System.Windows;
using MahApps.Metro.Controls;
using ViewModels.Windows.EntityWindows;

namespace UI.Windows.EntityWindows
{
    /// <summary>
    /// Interaction logic for NewPackedCategory.xaml
    /// </summary>
    public partial class PackedCategory : MetroWindow
    {
        public PackedCategory(object argCategory = null)
        {
            InitializeComponent();
            DataContext = new vmWinPackedCategory(argCategory);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
