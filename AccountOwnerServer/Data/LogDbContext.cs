using System;
using AccountOwnerServer.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountOwnerServer.Data 
{
    public class LogDbContext : DbContext
    {
        public LogDbContext(DbContextOptions<LogDbContext> options)
            :base(options)
        {
        }

        public DbSet<LogEntry> LogEntries { get; set; }
        public DbSet<LogNlog> LogNlogs { get; set; }
       
    }
}