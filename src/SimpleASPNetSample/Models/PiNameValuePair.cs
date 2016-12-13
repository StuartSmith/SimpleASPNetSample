using SimpleASPNetSample.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleASPNetSample.Models
{
    public class PiNameValuePair: IPiNameValuePair
    {
        [Key]
        public int NameValuePairId { get; set; }
        public string Name { get; set; }
        public string Value {get; set;}
    }
}
