using SimpleASPNetSample.Interfaces;
using SimpleASPNetSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleASPNetSample.RestViewModel
{
    public class ViewModelUltraSonicSensorRunMeasurement : IUltraSonicSensorRunMeasurement
    {
        public ViewModelUltraSonicSensorRunMeasurement()
        {
        }

        public ViewModelUltraSonicSensorRunMeasurement(UltraSonicSensorRunMeasurement RunMeasurement )
        {
            MeasurementDistance = RunMeasurement.MeasurementDistance;
            SonicMeasurementId = RunMeasurement.SonicMeasurementId;
            TimeOfMeasurment = RunMeasurement.TimeOfMeasurment;
            UltraSonicSensorRunId = RunMeasurement.UltraSonicSensorRunId;
        }

        public double MeasurementDistance { get; set; }     

        public int SonicMeasurementId { get; set; }       

        public DateTime TimeOfMeasurment { get; set; }
        

        public int UltraSonicSensorRunId { get; set; }
       
    }
}
