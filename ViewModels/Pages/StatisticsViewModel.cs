﻿using System.Collections.ObjectModel;
using ViewModels.Statistics.Abstract;
using ViewModels.Statistics.Accounts;
using ViewModels.Statistics.CoffeeSorts;

namespace ViewModels.Pages
{
    public class StatisticsViewModel : aTabViewModel
    {
        public StatisticsViewModel()
        {
            Header = "Статистика";
            StatisticTabs = new ObservableCollection<aTabViewModel>
            {
                new ParentAccountsViewModel(),
                new ParentCoffeeSortsViewModel()
            };
        }

        public ObservableCollection<aTabViewModel> StatisticTabs { get; private set; }
        public string Header { get; set; }

        protected override void Load() {}
    }
}