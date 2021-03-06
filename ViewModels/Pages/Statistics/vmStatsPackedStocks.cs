﻿using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Model;
using Model.Entity;
using ViewModels.Auxiliary;

namespace ViewModels.Pages.Statistics
{
    public class vmStatsPackedStocks : aTabViewModel
    {
        public vmStatsPackedStocks()
        {
            Header = "По фасованному кофе";

            cmdFilter30Days = new Command(cmdFilter30Days_Execute);
            cmdFilterAll = new Command(cmdFilterAll_Execute);
            cmdFilterCurrentMonth = new Command(cmdFilterCurrentMonth_Execute);
            cmdFilter = new Command(cmdFilter_Execute);
            cmdRowSelected = new Command(cmdRowSelected_Execute);
        }

        protected override void Load()
        {
            cmdFilterCurrentMonth.Execute(null);

            PackedStocks = new ObservableCollection<dPackedStocks>();
            Packings = new ObservableCollection<Packing>();
        }

        private void Refresh()
        {
            PackedStocks.Clear();
            Packings.Clear();

            foreach (var stock in ContextManager.Context.dPackedStocks)
                PackedStocks.Add(stock);
        }

        public ObservableCollection<dPackedStocks> PackedStocks;
        public ObservableCollection<Packing> Packings;

        private DateTime _filterFrom;
        public DateTime FilterFrom
        {
            get { return _filterFrom; }
            set
            {
                _filterFrom = value;
                OnPropertyChanged();
                _filterMonth = null;
                OnPropertyChanged("FilterMonth");
                _filterYear = value.Year;
                OnPropertyChanged("FilterYear");
            }
        }

        private DateTime _filterTo;
        public DateTime FilterTo
        {
            get { return _filterTo; }
            set
            {
                _filterTo = value;
                OnPropertyChanged();
                _filterMonth = null;
                OnPropertyChanged("FilterMonth");
                _filterYear = value.Year;
                OnPropertyChanged("FilterYear");
            }
        }

        private Month? _filterMonth;
        public Month? FilterMonth
        {
            get { return _filterMonth; }
            set
            {
                _filterMonth = value;
                OnPropertyChanged();

                _filterTo = new DateTime(FilterYear, FilterMonth.GetHashCode(),
                    DateTime.DaysInMonth(FilterYear, FilterMonth.GetHashCode()));
                OnPropertyChanged("FilterTo");

                _filterFrom = new DateTime(FilterYear, FilterMonth.GetHashCode(), 1);
                OnPropertyChanged("FilterFrom");

                Refresh();
            }
        }

        private int _filterYear;
        public int FilterYear
        {
            get { return _filterYear; }
            set
            {
                _filterYear = value;
                OnPropertyChanged();
                _filterFrom = new DateTime(value, _filterFrom.Month, _filterFrom.Day);
                OnPropertyChanged("FilterFrom");
                _filterTo = new DateTime(value, _filterTo.Month, _filterTo.Day);
                OnPropertyChanged("FilterTo");
                Refresh();
            }
        }

        public ICommand cmdFilter30Days { get; }
        private void cmdFilter30Days_Execute()
        {
            _filterTo = DateTime.Now;
            OnPropertyChanged("FilterTo");
            _filterFrom = DateTime.Now.AddDays(-30);
            OnPropertyChanged("FilterFrom");
            _filterMonth = null;
            OnPropertyChanged("FilterMonth");
            _filterYear = DateTime.Now.Year;
            OnPropertyChanged("FilterYear");
            Refresh();
        }

        public ICommand cmdFilterAll { get; }
        private void cmdFilterAll_Execute()
        {
            _filterTo = DateTime.Now;
            OnPropertyChanged("FilterTo");
            _filterFrom = FilterTo.AddDays(-365);
            OnPropertyChanged("FilterFrom");
            _filterMonth = null;
            OnPropertyChanged("FilterMonth");
            _filterYear = DateTime.Now.Year;
            OnPropertyChanged("FilterYear");
            Refresh();
        }

        public ICommand cmdFilterCurrentMonth { get; }
        private void cmdFilterCurrentMonth_Execute()
        {
            _filterTo = DateTime.Now;
            OnPropertyChanged("FilterTo");
            _filterFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            OnPropertyChanged("FilterFrom");
            _filterMonth = (Month)DateTime.Now.Month;
            OnPropertyChanged("FilterMonth");
            _filterYear = DateTime.Now.Year;
            OnPropertyChanged("FilterYear");
            Refresh();
        }

        public ICommand cmdFilter { get; }
        private void cmdFilter_Execute()
        {
            Refresh();
        }

        public ICommand cmdRowSelected { get; private set; }
        private void cmdRowSelected_Execute(object argSelected)
        {
            
        }

    }
}
