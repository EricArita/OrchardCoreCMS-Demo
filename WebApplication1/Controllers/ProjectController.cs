using YessqlApi.Indexes;
using YessqlApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YesSql;

namespace MyModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : Controller
    {
        private readonly IStore _store;

        public ProjectController(IStore store)
        {
            _store = store;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateNewProjectApi(ApiProjectModel viewModel)
        {
            _store.RegisterIndexes<ApiProjectIndexProvider>();
            using (var session = _store.CreateSession())
            {
                try {
                    session.Save(viewModel);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }

            return Ok();
        }
    }
}