using SimpleASPNetSample.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleASPNetSample.Models;
using SimpleASPNetSample.RestViewModel;
using SimpleASPNetSample.Configuration;
using SimpleASPNetSample.Interfaces;

namespace SimpleASPNetSample.Services
{
    public class PiCongfigurationService : IPiConfigurationStatus
    {
        private static PiCongfigurationService _instance;

        public static PiCongfigurationService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PiCongfigurationService();
                }
                return _instance;
            }
        }

        public List<ViewModelRestNameValuePair> PINameValuePairs
        {
            get
            {
                AzurePiConfiguraton azurePiConfig = new AzurePiConfiguraton();
                List<ViewModelRestNameValuePair> returnList = new List<ViewModelRestNameValuePair>();

                var keyValuePairList = new AzurePiConfiguraton().GetAllValues();

                foreach (var keyValuePair in keyValuePairList)
                {
                    ViewModelRestNameValuePair RestReturnItem = new ViewModelRestNameValuePair();
                    azurePiConfig.CopyKeyValuePair(keyValuePair, RestReturnItem);
                    keyValuePairList.Add(RestReturnItem);
                }
               
                return returnList;
            }
        }

        public Task<bool> SetNameValuePairs(List<ViewModelRestNameValuePair> ViewModelRestNameValuePair)
        {
            AzurePiConfiguraton azurePiConfig = new AzurePiConfiguraton();

            Task<bool> RetVal = Task.Factory.StartNew(() => azurePiConfig.UpdateValues(ViewModelRestNameValuePair.Select(x => x as IPiNameValuePair).ToList<IPiNameValuePair>()));
            return RetVal;
        }
    }
    
}
