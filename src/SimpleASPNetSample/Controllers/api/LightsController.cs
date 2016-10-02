using Microsoft.AspNetCore.Mvc;
using SimpleASPNetSample.Models;
using SimpleASPNetSample.Services;
using SimpleASPNetSample.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleASPNetSample.Controllers.api
{


    [Route("api/[controller]")]
    public class LightsController: Controller
    {
        public object LightStatuService { get; private set; }

        [HttpGet("statuses")]
        public IActionResult GetStatuses()
        {
            LightStatusService lightStatusService = LightStatusService.Instance;
            var task =  lightStatusService.RetrieveLightStatuses();
            task.Wait();

            return Ok(task.Result);
        }

        [HttpGet("statuses/{description}")]
        public IActionResult GetStatuses(string description)
        {
            LightStatusService lightStatusService = LightStatusService.Instance;
            var task = lightStatusService.RetrieveLightStatus(description);
            task.Wait();

            if (!(task.Result.Any()))
                return NotFound();

             return Ok(task.Result);
        }

        [HttpPost("statuses")]
        public IActionResult SetLightStatus([FromBody] Light data)
        {
            ILightStatus lightStatusServer = LightStatusService.Instance;           
            var task = lightStatusServer.RetrieveLightStatus(data.Description);
            task.Wait();

            if (!(task.Result.Any()))
                return base.BadRequest();

            lightStatusServer.SetLight(data);

            return Created($"/lights/statuses/{data.Description}", data);
        }

       

    }
}
