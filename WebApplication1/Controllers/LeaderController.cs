using YessqlApi.Indexes;
using YessqlApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YesSql;

namespace YessqlApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaderController : ControllerBase
    {
        private readonly IStore _store;

        public LeaderController(IStore store)
        {
            _store = store;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateNewLeaderApi(ApiLeaderModel viewModel)
        {
            _store.RegisterIndexes<ApiLeaderIndexProvider>();
            using (var session = _store.CreateSession())
            {
                try
                {
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
