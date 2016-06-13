﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Espresso.ViewModels
{
    class PackagePurchasesViewModel
    {
        private Entity.ContextContainer _context;

        public PackagePurchasesViewModel()
        {
            _context = new Entity.ContextContainer();
            _context.PackagePurchases.Load();
            _context.Accounts.Load();
            _context.Suppliers.Load();
            _context.Packages.Load();

            _filterTo = DateTime.Now;
            _filterFrom = DateTime.Now.AddDays(-30);

            cmdSave = new Auxiliary.Command(cmdSave_Execute);
            cmdDelete = new Auxiliary.Command(cmdDelete_Execute);
            cmdNew = new Auxiliary.Command(cmdNew_Execute);
            cmdFilter30Days = new Auxiliary.Command(cmdFilter30Days_Execute);
            cmdFilterAll = new Auxiliary.Command(cmdFilterAll_Execute);

            Refresh();
        }

        private void Refresh()
        {
            var query = _context.PackagePurchases.Local.Where(p => p.Date >= _filterFrom && p.Date <= _filterTo);
            PackagePurchases = new ObservableCollection<Entity.PackagePurchase>(query);
        }

        #region Binding Properties and INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<Entity.PackagePurchase> _roastings;
        public ObservableCollection<Entity.PackagePurchase> PackagePurchases
        {
            get { return _roastings; }
            set
            {
                _roastings = value;
                OnPropertyChanged("PackagePurchases");
            }
        }

        public ObservableCollection<Entity.Account> Accounts
        {
            get { return _context.Accounts.Local; }
        }

        public ObservableCollection<Entity.Supplier> Suppliers
        {
            get { return _context.Suppliers.Local; }
        }

        public ObservableCollection<Entity.Package> Packages
        {
            get { return _context.Packages.Local; }
        }
        private DateTime _filterFrom;
        public DateTime FilterFrom
        {
            get { return _filterFrom; }
            set
            {
                _filterFrom = value;
                OnPropertyChanged("FilterFrom");
                Refresh();
            }
        }

        private DateTime _filterTo;
        public DateTime FilterTo
        {
            get { return _filterTo; }
            set
            {
                _filterTo = value;
                OnPropertyChanged("FilterTo");
                Refresh();
            }
        }

        #endregion

        #region Commands

        public ICommand cmdSave
        { get; private set; }

        private void cmdSave_Execute()
        {
            _context.SaveChanges();
            Refresh();
        }

        public ICommand cmdDelete
        { get; private set; }

        private void cmdDelete_Execute(object argSelected)
        {
            if (argSelected == null)
            {
                MessageBox.Show("Вы не выбрали счёт!");
                return;
            }

            var selected = argSelected as Entity.PackagePurchase;
            try
            {
                _context.PackagePurchases.Remove(selected);
                _context.SaveChanges();
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    public ICommand cmdNew
        { get; private set; }

        private void cmdNew_Execute(object argSelected)
        {
            new Views.NewPackagePurchase().ShowDialog();
            _context.PackagePurchases.Load();
            Refresh();
        }

        public ICommand cmdFilter30Days
        { get; private set; }

        private void cmdFilter30Days_Execute()
        {
            _filterTo = DateTime.Now;
            FilterFrom = DateTime.Now.AddDays(-30);
        }

        public ICommand cmdFilterAll
        { get; private set; }

        private void cmdFilterAll_Execute()
        {
            _filterTo = DateTime.Now;
            FilterFrom = DateTime.MinValue;
        }
        #endregion

    }
}