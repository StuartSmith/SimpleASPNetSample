using Microsoft.AspNetCore.Mvc;
using SimpleASPNetSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleASPNetSample.Controllers.api
{
    [Route("api/[controller]")]
    public class ServoController : Controller
    {
        [HttpGet("statuses")]
        public IActionResult GetStatus()
        {
            ServoStatusService servoStatusServer = ServoStatusService.Instance;
            var task = servoStatusServer.RetrieveServos();
            task.Wait();

            return Ok(task.Result);
        }

        [HttpPost("statuses")]
        public IActionResult SetServoStatus([FromBody] Servo servo)
        {
            ServoStatusService servoStatusServer = ServoStatusService.Instance;
            var task = servoStatusServer.SetServo(servo);
            task.Wait();

            return Ok(task.Result);
        }



        [HttpGet("ServoPositions")]
        public IActionResult GetServoStatuses()
        {
            ServoStatusService servoStatusServer = ServoStatusService.Instance;
            return Ok(servoStatusServer.ServoStatuses);
        }
    }
}
