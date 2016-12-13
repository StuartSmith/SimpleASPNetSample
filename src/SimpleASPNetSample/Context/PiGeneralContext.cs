using Microsoft.EntityFrameworkCore;
using SimpleASPNetSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleASPNetSample.Context
{
    public class PiGeneralContext : DbContext
    {

        public DbSet<PiNameValuePair> PiNameValuePairs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=General.db");
        }
    }
}
