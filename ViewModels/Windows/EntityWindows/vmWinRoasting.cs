﻿using System;
using System.Configuration;
using System.Linq;
using Model;
using Model.Entity;

namespace ViewModels.Windows.EntityWindows
{
    public class vmWinRoasting: Abstract.aEntityWindowViewModel
    {
        public vmWinRoasting(object argRoasting = null)
        {
            if (argRoasting != null)
            {
                Roasting = argRoasting as Roasting;
                ShrinkagePercent = (int) (100 - (Roasting.RoastedAmount*100/Roasting.InitialAmount));
            }
            else
            {
                CreatingNew = true;
                Refresh();
            }
        }

        protected override void Refresh()
        {
            Roasting = new Roasting
            {
                Date = DateTime.Now,
                CoffeeSort = ContextManager.ActiveCoffeeSorts.FirstOrDefault()
            };
            ShrinkagePercent = Properties.ShrinkagePercent;
        }

        private int _shrinkagePercent;
        public int ShrinkagePercent
        {
            get { return _shrinkagePercent; }
            set
            {
                _shrinkagePercent = value;
                OnPropertyChanged();
            }
        }

        private Roasting _roasting;
        public Roasting Roasting
        {
            get { return _roasting; }
            set
            {
                _roasting = value;
                OnPropertyChanged();
            }
        }

        protected override void cmdSave_Execute()
        {
            if (Roasting.InitialAmount <= 0)
            {
                FlyErrorMsg = "Введите количество кофе";
                IsFlyErrorOpened = true;
                return;
            }

            if (ShrinkagePercent < 1|| ShrinkagePercent > 100)
            {
                FlyErrorMsg = "Введите процент ужарки от одного до ста";
                IsFlyErrorOpened = true;
                return;
            }


            if (Roasting.InitialAmount >
                ContextManager.Context.dGreenStocks.First(p => p.CoffeeSort.Id == Roasting.CoffeeSort.Id).Quantity)
            {
                FlyErrorMsg = "Недостаточно зелёного кофе в наличии, чтобы пожарить введённое количество";
                IsFlyErrorOpened = true;
                return;
            }

            Roasting.RoastedAmount = Roasting.InitialAmount * (100-ShrinkagePercent) /100;
            Properties.ShrinkagePercent = ShrinkagePercent;

            var roastedStock = ContextManager.Context.dRoastedStocks.First(
                p => p.CoffeeSort.Id == Roasting.CoffeeSort.Id);
            roastedStock.dCost = roastedStock.Quantity / (roastedStock.Quantity + Roasting.RoastedAmount) * roastedStock.dCost
                                 + Roasting.RoastedAmount / (roastedStock.Quantity + Roasting.RoastedAmount)
                                 * ContextManager.Context.dGreenStocks.First(p => p.CoffeeSort.Id == Roasting.CoffeeSort.Id)
                                    .dCost * (100 - ShrinkagePercent) / 100;

            if (CreatingNew)
                ContextManager.Context.Roastings.Add(Roasting);
            SaveContext();
        }
    }
}
