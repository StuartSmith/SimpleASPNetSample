using SimpleASPNetSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleASPNetSample.ServicesInternal.Interfaces
{
    public interface IAzureSendDataTo
    {

        Task<bool> SendServoData(List<Servo> data);

        //Task<bool> SendUltraSonicData(List<UltraSonicSensor> data);

        Task<bool> SendLightData(List<Light> data);

    }
}
