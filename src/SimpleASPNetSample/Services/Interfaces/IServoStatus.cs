using SimpleASPNetSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleASPNetSample.Services.Interfaces
{
    public interface IServoStatus
    {
        Task<List<Servo>> RetrieveServos();

        List<string> ServoStatuses { get; }
       
        Task<bool> SetServo(Servo servo);
    }
}
