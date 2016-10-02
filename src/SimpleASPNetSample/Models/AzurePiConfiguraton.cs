using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleASPNetSample.Models
{
    public class AzurePiConfiguraton
    {
        public AzurePiConfiguraton()
        {
            AllowSendingofData = false;
            AllowSendingToastLightData = true;
            AllowSendingToastServoData = true;
            AllowSendingUltraSonicData = true;
        }

        public bool AllowSendingToastLightData { get; set; }

        public bool AllowSendingofData { get; set; }

        public bool AllowSendingToastServoData { get; set; }

        public bool AllowSendingUltraSonicData { get; set; }
    }
}
