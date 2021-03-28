﻿using Microsoft.EntityFrameworkCore;
using MyEShop.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MyEShop.PersistenceEF
{
    public class EFDataContext:DbContext
    {
        public EFDataContext()
        {

        }

        public EFDataContext(DbContextOptions<EFDataContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ProductGroup> ProductGroups { get; set; }
    }
}