﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApp16
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Connection : DbContext
    {
        public Connection()
            : base("name=Connection")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Box> Box { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Discount> Discount { get; set; }
        public virtual DbSet<history> history { get; set; }
        public virtual DbSet<Profile> Profile { get; set; }
        public virtual DbSet<Service> Service { get; set; }
    }
}