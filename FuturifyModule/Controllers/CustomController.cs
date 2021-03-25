using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FuturifyModule.Controllers
{
    [Produces("application/json")]
    [Route("api/custom")]
    public class CustomController : Controller
    {
        public CustomController() { }

        [HttpGet]
        [Route("getall")]
        public Task<string[]> GetAllAsync()
        {
            return Task.FromResult(new string[] { "a", "b", "c" });
        }


        [HttpGet("{id:int}")]
        public Task<string> GetAsync(int id)
        {
            return Task.FromResult($"Result: {id}");
        }
    }
}
