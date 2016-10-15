using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleASPNetSample.Models
{
    public class UltraSonicSensorRun:UltraSonicSensorRequest
    {
       public  UltraSonicSensorRun()
        {
            SendRequestToAzure = false;
            RequestSentToAzure = false;
            MeasurementIn = "Inches";
            RunDate = DateTime.UtcNow;
            PinGPIOTrigger = RaspberryPiGPI0Pin.GPIO20;
            PinGPIOEcho = RaspberryPiGPI0Pin.GPIO21;
            List<UltraSonicSensorRunMeasurement> SonicMeasurements = new List<UltraSonicSensorRunMeasurement>();
        }


        public bool RequestSentToAzure { get; set; }
        public string MeasurementIn { get; set; }
        public double TotalDistance { get; set; }        
        public RaspberryPiGPI0Pin PinGPIOTrigger { get; set; }
        public RaspberryPiGPI0Pin PinGPIOEcho { get; set; }
        [Key]
        public int SonicId { get; set; }
        public DateTime RunDate { get; set; }
        public List<UltraSonicSensorRunMeasurement> SonicMeasurements { get; set; }
    }
}
