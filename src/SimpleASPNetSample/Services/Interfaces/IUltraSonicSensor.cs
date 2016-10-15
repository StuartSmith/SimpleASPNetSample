using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleASPNetSample.Models;
using SimpleASPNetSample.RestViewModel;

namespace SimpleASPNetSample.Services.Interfaces
{
    interface IUltraSonicSensor
    {
        ViewModelUltraSonicSensorRun RetrieveLatestUltraSonicRun();

        List<ViewModelUltraSonicSensorRun> RetrieveAllRuns();

        ViewModelUltraSonicSensorRun RetrieveUltraSonicRun(long RunId);

        bool StartUltraSonicRun(UltraSonicRunRequest runrequest);

        bool IsUltraSonicServiceRunning();

        bool RemoveAllUltraSonicRuns();
    }
}
