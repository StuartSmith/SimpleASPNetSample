using SimpleASPNetSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleASPNetSample.Services.Interfaces
{
    public interface ILightStatus
    {
        Task<List<Light>> RetrieveLightStatuses();

        Task<List<Light>> RetrieveLightStatus(string LightType);

        Task<bool> SetLight(Light light);
    }
}
