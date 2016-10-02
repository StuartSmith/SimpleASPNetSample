using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleASPNetSample.Models
{

    public enum AzureDataObjectType {
            Light,
            Servo,
            UltraSonic
    }
        

    /// <summary>
    /// Data to send to Azure
    /// when a request comes through 
    /// </summary>
    public class AzureRequestData
    {
        string MachineName { get; set;}
        
        /// <summary>
        /// Serialized string data of an object to send to Azure
        /// </summary>
        string Data { get; set; }

        AzureDataObjectType AzureDataTye { get; set; }
    }
}
