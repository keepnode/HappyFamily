using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HappyFamily.UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizesController : ControllerBase
    {

        private readonly Sys_OrganizeManager sys_OrganizeManager = new Sys_OrganizeManager();
        // GET: api/Organizes
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Organizes/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Organizes
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Organizes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
