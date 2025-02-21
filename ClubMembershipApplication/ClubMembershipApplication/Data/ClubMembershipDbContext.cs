using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ClubMembershipApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ClubMembershipApplication.Data
{
    public class ClubMembershipDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source = {AppDomain.CurrentDomain.BaseDirectory}ClubMembersipDb.db");
            base.OnConfiguring(optionsBuilder);

        }

        public DbSet<User> Users { get; set; }  
    }
}
