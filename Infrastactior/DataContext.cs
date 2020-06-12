using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Infrastactior
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        protected override void  OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Owner>().HasData(
                new Owner()
                {
                    ID = Guid.Parse("deba0367-8bec-4e64-b362-84936eaadf0d"),
                    Avatar = "avatar.jpg",
                    FullName = "Abdelazeem Mousa",
                    Profile = "Microsoft Developer / .NEt"
                }
                ) ;


        }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<PortflioItem> PortflioItems { get; set; }

    }
}