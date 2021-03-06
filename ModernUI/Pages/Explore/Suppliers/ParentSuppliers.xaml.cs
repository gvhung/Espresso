﻿using System.Windows.Controls;
using UI.Windows.EntityWindows;
using ViewModels.Pages.Explore;

namespace UI.Pages.Explore.Suppliers
{
    /// <summary>
    /// Interaction logic for ParentSuppliers.xaml
    /// </summary>
    public partial class ParentSuppliers : UserControl
    {
        public ParentSuppliers()
        {
            InitializeComponent();
        }

        private void OnNewClick(object sender, System.Windows.RoutedEventArgs e)
        {
            new Supplier().ShowDialog();
            var viewModel = (vmSuppliers) DataContext;
            viewModel.cmdReload.Execute(null);

        }

        private void OnEditClick(object sender, System.Windows.RoutedEventArgs e)
        {
            var selected = tabs.SelectedItem as Model.Entity.Supplier;
            if (selected != null)
            {
                new Supplier(selected).ShowDialog();
                var viewModel = (vmSuppliers)DataContext;
                viewModel.cmdReload.Execute(null);
            }
        }
    }
}
