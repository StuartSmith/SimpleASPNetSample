using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleASPNetSample.Models
{
    public class UltraSonicSensorRunMeasurement
    {
        public int SonicMeasurementId { get; set; }
        public DateTime TimeOfMeasurment { get; set; }
        public long MeasurementDistance { get; set; }
        public int UltraSonicSensorRunId { get; set; }
        public UltraSonicSensorRun Run { get; set; }
    }
}
