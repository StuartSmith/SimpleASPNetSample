using Microsoft.EntityFrameworkCore;
using SimpleASPNetSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleASPNetSample.Context
{
    /// <summary>
    /// To add a migration run following for example..
    ///
    ///  Add-Migration AddPiNameValuePairs -Context UltraSonicContext
    /// 
    /// </summary>
    public class UltraSonicContext : DbContext
    {
        public DbSet<UltraSonicSensorRun> UltraSonicSensorRuns { get; set; }
        public DbSet<UltraSonicSensorRunMeasurement> UltraSonicSensorRunMeasurements { get; set; }

       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=UltraSonic.db");
        }
       

    }
}
