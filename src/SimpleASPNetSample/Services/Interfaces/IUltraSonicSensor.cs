using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleASPNetSample.Models;

namespace SimpleASPNetSample.Services.Interfaces
{
    interface IUltraSonicSensor
    {
        UltraSonicSensorRun RetrieveLatestUltraSonicRun();

        List<UltraSonicSensorRun> RetrieveAllRuns();

        UltraSonicSensorRun RetrieveUltraSonicRun(int RunId);

        bool StartUltraSonicRun(UltraSonicRunRequest runrequest);

        bool IsUltraSonicServiceRunning();

        



    }
}
