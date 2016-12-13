using SimpleASPNetSample.Models;
using SimpleASPNetSample.RestViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleASPNetSample.Services.Interfaces
{
    interface IPiConfigurationStatus
    {
        List<ViewModelRestNameValuePair> PINameValuePairs { get; }

        Task<bool> SetNameValuePairs(List<ViewModelRestNameValuePair> ViewModelRestNameValuePair);

    }
}
