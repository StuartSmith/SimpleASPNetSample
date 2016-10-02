using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleASPNetSample.Models;

namespace SimpleASPNetSample.Services.Interfaces
{
    interface IUltraSonicSensor
    {
        Task<List<UltraSonicSensor>> RetrieveSensorsData(UltraSonicSensorRequest request); 
                
    }
}
