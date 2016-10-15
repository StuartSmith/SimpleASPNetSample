using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimpleASPNetSample.Models;
using SimpleASPNetSample.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleASPNetSample.Controllers.api
{
    [Route("api/[controller]")]
    public class UltraSonicController : Controller
    {
        [HttpGet("UltraSonicRuns")]
        public IActionResult GetStatus()
        {
            var ultraSonicService = UltraSonicSensorService.Instance;
            var AllRuns = ultraSonicService.RetrieveAllRuns();

            string output = JsonConvert.SerializeObject(AllRuns);


            return Ok(new { AllRuns }); //Ok(task.Result);
        }

        [HttpGet("UltraSonicRuns/{id}")]
        public IActionResult GetStatus(long id)
        {
            var ultraSonicService = UltraSonicSensorService.Instance;
            var RunSpecified = ultraSonicService.RetrieveUltraSonicRun(id);

            if (RunSpecified == null)
                return NotFound();

            return Ok(new { RunSpecified }); //Ok(task.Result);
        }

        [HttpGet("lastrun")]
        public IActionResult LastRun()
        {

            var ultraSonicService = UltraSonicSensorService.Instance;
            var lastRun = ultraSonicService.RetrieveLatestUltraSonicRun();

            return Ok(new { lastRun });
        }

        [HttpPost("startrun")]
        public IActionResult StartRun([FromBody] UltraSonicRunRequest runrequest)
        {

            var ultraSonicService = UltraSonicSensorService.Instance;
            bool runstarted =  ultraSonicService.StartUltraSonicRun(runrequest);

          
           
            return Ok(new { runstarted });
        }

        [HttpDelete("RemoveUltraSonicRuns")]
        public IActionResult RemoveUltraSonicRuns()
        {
           var ultraSonicService = UltraSonicSensorService.Instance;
           long RunRemovalReturned = ultraSonicService.RemoveAllUltraSonicRuns();          
            return Ok(new { RunRemovalReturned });
        }
    }
}
