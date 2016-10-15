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

            //var ultraSonic = UltraSonicSensorService.Instance;
            //UltraSonicSensorRequest NonAzureRetrieval = new UltraSonicSensorRequest();
            //var task = ultraSonic.RetrieveSensorsData(NonAzureRetrieval);
            //task.Wait();

            return Ok(new { Amount = 108, Message = "Hello" }); //Ok(task.Result);
        }

        [HttpGet("lastrun")]
        public IActionResult LastRun()
        {

            var ultraSonicService = UltraSonicSensorService.Instance;
            var lastRun =  ultraSonicService.RetrieveLatestUltraSonicRun();
            
            return Ok(lastRun);
        }

        [HttpPost("startrun")]
        public IActionResult StartRun([FromBody] UltraSonicRunRequest runrequest)
        {
           

            var ultraSonicService = UltraSonicSensorService.Instance;
            ultraSonicService.StartUltraSonicRun(runrequest);
            //UltraSonicSensorRequest UltraSonicRequest = new UltraSonicSensorRequest();


            //var task = ultraSonic.RetrieveSensorsData(NonAzureRetrieval);
            //task.Wait();

            bool bResult = ultraSonicService.StartUltraSonicRun(runrequest);

            return Ok(true);
        }
    }
}
