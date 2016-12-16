using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleASPNetSample.RestViewModel;
using SimpleASPNetSample.Configuration;
using SimpleASPNetSample.Configuration.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleASPNetSample.Controllers.api
{
    [Route("api/[controller]")]
    public class ConfigurationController : Controller
    {
     
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            

            var Results = (from nameValuePair in new AzurePiConfiguraton().GetAllValues()
                           select new ViewModelRestNameValuePair() { Name = nameValuePair.Name, Value = nameValuePair.Value }
                          ).ToList<ViewModelRestNameValuePair>();

            return Ok(Results); 
        }

        // GET api/values/5
        [HttpGet("{Name}")]
        public IActionResult Get(string Name)
        {
            var piNameValuePairDBSettings = new PiNameValuePairDBSettings();

            var PiNameValueFromDb = new PiNameValuePairDBSettings().GetPiNameValuePair(Name);

            if (PiNameValueFromDb == null)
                return NotFound();


            return Ok(PiNameValueFromDb.Value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]List<ViewModelRestNameValuePair> values)
        {
            new AzurePiConfiguraton().UpdateValues((values.ToList<IPiNameValuePair>()));
            
        }

        // PUT api/values/5
        [HttpPut("{Name}")]
        public void Put(string name, [FromBody]string value)
        {
            new PiNameValuePairDBSettings().SetNameValuePair(name, value);
        }

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
