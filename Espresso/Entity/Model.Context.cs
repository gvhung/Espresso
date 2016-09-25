﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ContextContainer : DbContext
    {
        public ContextContainer()
            : base("name=ContextContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CoffeePurchase> CoffeePurchases { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<CoffeePurchaseDetails> CoffeePurchaseDetails { get; set; }
        public virtual DbSet<CoffeeSort> CoffeeSorts { get; set; }
        public virtual DbSet<dCoffeeStock> dCoffeeStocks { get; set; }
        public virtual DbSet<Roasting> Roastings { get; set; }
        public virtual DbSet<Mix> Mixes { get; set; }
        public virtual DbSet<Mix_Details> Mix_Details { get; set; }
        public virtual DbSet<Packing> Packings { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<PackagePurchase> PackagePurchases { get; set; }
        public virtual DbSet<dPackedStocks> dPackedStocks { get; set; }
        public virtual DbSet<dPackageStocks> dPackageStocks { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Recipient> Recipients { get; set; }
        public virtual DbSet<SaleDetailCoffee> SaleDetailsCoffee { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<CoffeeTransfer> CoffeeTransfers { get; set; }
        public virtual DbSet<dAccountsBalance> dAccountsBalances { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<MonthlyExpense> MonthlyExpenses { get; set; }
        public virtual DbSet<OtherProfit> OtherProfits { get; set; }
        public virtual DbSet<MonthlyPayment> MonthlyPayments { get; set; }
        public virtual DbSet<dTransaction> dTransactions { get; set; }
        public virtual DbSet<MoneyTransfer> MoneyTransfers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductPurchase> ProductPurchases { get; set; }
        public virtual DbSet<SaleDetailProduct> SaleDetailsProduct { get; set; }
        public virtual DbSet<dProductStock> dProductStocks { get; set; }
        public virtual DbSet<Loss> Losses { get; set; }
    }
}
