using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleASPNetSample.Models
{
    public class UltraSonicSensorRunMeasurement
    {
        [Key]
        public int SonicMeasurementId { get; set; }
        public DateTime TimeOfMeasurment { get; set; }
        public double MeasurementDistance { get; set; }
        public int UltraSonicSensorRunId { get; set; }
        public UltraSonicSensorRun Run { get; set; }
    }
}
