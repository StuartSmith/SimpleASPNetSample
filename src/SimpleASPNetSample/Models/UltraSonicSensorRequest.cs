using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleASPNetSample.Models
{

    public class UltraSonicSensorRequest
    {

        public UltraSonicSensorRequest()
        {
            SendRequestToAzure = false;
        }

        public bool SendRequestToAzure { get; set; }
       

    }
}
