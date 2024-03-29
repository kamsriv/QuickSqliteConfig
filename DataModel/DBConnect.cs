﻿namespace Quickapp_del.DataModel
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Sqlite;
    using Microsoft.Extensions.Options;
    using Quickapp_del.Modal;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;

    public class DBConnect: DbContext
    {
        public DBConnect() { }
        public DBConnect(DbContextOptions options):base(options) {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
       
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<MailingAddress> Addresses { get; set; }
    }
}
