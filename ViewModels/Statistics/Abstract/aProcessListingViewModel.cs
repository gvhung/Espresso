﻿using System;
using System.Windows.Input;
using MahApps.Metro.Controls.Dialogs;
using Model;
using Model.Entity;
using ViewModels.Auxiliary;

namespace ViewModels.Statistics.Abstract
{
    public abstract class aProcessListingViewModel: aTabViewModel
    {
        protected ContextContainer _context;

        protected aProcessListingViewModel()
        {
            cmdSave = new Command(cmdSave_Execute);
            cmdDelete = new Command(cmdDelete_Execute);
            cmdFilter30Days = new Command(cmdFilter30Days_Execute);
            cmdFilterAll = new Command(cmdFilterAll_Execute);
            cmdReload = new Command(Load);
        }
        protected void SaveContext()
        {
            try
            {
                _context.SaveChanges();
                ContextManager.ReloadContext();
            }
            catch (Exception ex)
            {
                DialogCoordinator.Instance.ShowMessageAsync(this, "Ошибка", ex.Message,
                    MessageDialogStyle.Affirmative, new MetroDialogSettings { ColorScheme = MetroDialogColorScheme.Accented });
            }
        }

        protected bool IsEmpty(object argSelected)
        {
            if (argSelected == null)
            {
                DialogCoordinator.Instance.ShowMessageAsync(this, "Ошибка", "Вы ничего не выбрали",
                    MessageDialogStyle.Affirmative, new MetroDialogSettings { ColorScheme = MetroDialogColorScheme.Accented });
                return true;
            }
            return false;
        }

        protected abstract void Refresh();

        #region Binding Properties

        protected DateTime _filterFrom;
        public DateTime FilterFrom
        {
            get { return _filterFrom; }
            set
            {
                _filterFrom = value;
                OnPropertyChanged();
                Refresh();
            }
        }

        protected DateTime _filterTo;
        public DateTime FilterTo
        {
            get { return _filterTo; }
            set
            {
                _filterTo = value;
                OnPropertyChanged();
                Refresh();
            }
        }

        #endregion

        #region Commands

        public ICommand cmdReload
        { get; private set; }

        public ICommand cmdSave
        { get; private set; }
        protected virtual void cmdSave_Execute()
        {
            _context.SaveChanges();
            DialogCoordinator.Instance.ShowMessageAsync(this, "Успех", "Сохранение завершено");
        }

        public ICommand cmdDelete
        { get; private set; }
        protected abstract void cmdDelete_Execute(object argSelected);

        public ICommand cmdFilter30Days
        { get; private set; }
        protected void cmdFilter30Days_Execute()
        {
            _filterTo = DateTime.Now;
            OnPropertyChanged(nameof(FilterTo));
            FilterFrom = DateTime.Now.AddDays(-30);
        }

        public ICommand cmdFilterAll
        { get; private set; }
        protected void cmdFilterAll_Execute()
        {
            _filterTo = DateTime.Now;
            OnPropertyChanged(nameof(FilterTo));
            FilterFrom = DateTime.MinValue;
        }

        #endregion
    }
}
