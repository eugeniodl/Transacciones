﻿using Ejemplo02.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo02.Data
{
    public class Bank1Context : DbContext 
    {
        public DbSet<AccountTransaction> AccountTransactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configurar la cadena de conexión para Bank1Context
            string connection =
                ConfigurationManager.ConnectionStrings["constring1"].ConnectionString;
            optionsBuilder.UseSqlServer(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountTransaction>().HasData(
                new AccountTransaction()
                {
                    Id = 1,
                    AccountNumber = "10",
                    Credit = 400M,
                    Debit = 0M
                });

            modelBuilder.Entity<AccountTransaction>()
                .Property(x => x.Credit)
                .HasColumnType("decimal(18,2)");


            modelBuilder.Entity<AccountTransaction>()
                .Property(x => x.Debit)
                .HasColumnType("decimal(18,2)");
        }
    }
}