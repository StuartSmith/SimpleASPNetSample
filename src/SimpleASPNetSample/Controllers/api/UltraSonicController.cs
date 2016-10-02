using Microsoft.AspNetCore.Mvc;
using SimpleASPNetSample.Models;
using SimpleASPNetSample.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleASPNetSample.Controllers.api
{
    [Route("api/[controller]")]
    public class UltraSonicController:Controller
    {
        [HttpGet("statuses")]
        public IActionResult GetStatus()
        {

            var ultraSonic = UltraSonicSensorService.Instance;
            UltraSonicSensorRequest NonAzureRetrieval = new UltraSonicSensorRequest();
            var task = ultraSonic.RetrieveSensorsData(NonAzureRetrieval);
            task.Wait();

            return Ok(task.Result);
        }
    }
}
