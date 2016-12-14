using SimpleASPNetSample.Configuration;
using SimpleASPNetSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleASPNetSample.ServicesInternal
{
    public class AzureSendDataTo
    {

        private static AzureSendDataTo _instance;
        private  AzurePiConfiguraton _piConfig;

        private AzureSendDataTo()
        {
            AzurePiConfiguraton _piConfig = new AzurePiConfiguraton();
        }

        public static AzureSendDataTo Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AzureSendDataTo();
                }
                return _instance;
            }
        }

        public async Task<bool> SendLightData(List<Light> data)
        {         


            if ((_piConfig.AllowSendingofData == true) && (_piConfig.AllowSendingToastLightData == true))
            {
                throw new NotImplementedException();
            }

            Task<bool> SendData = Task<bool>.Factory.StartNew(() =>
            {
                return true;

            });

            return SendData.Result;
        }


        public async Task<bool> SendServoData(List<Servo> data)
        {
            

            if ((_piConfig.AllowSendingofData == true) && (_piConfig.AllowSendingToastServoData == true))
            {
                throw new NotImplementedException();
            }

            Task<bool> SendData = Task<bool>.Factory.StartNew(() =>
            {
                return true;

            });

            return SendData.Result;
        }
    }
}
