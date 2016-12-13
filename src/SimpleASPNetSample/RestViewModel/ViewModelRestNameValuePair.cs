using SimpleASPNetSample.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleASPNetSample.RestViewModel
{
    public class ViewModelRestNameValuePair : IPiNameValuePair
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
