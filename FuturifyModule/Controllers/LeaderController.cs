using FuturifyModule.Indexes;
using FuturifyModule.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YesSql;

namespace FuturifyModule.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class LeaderController : Controller
    {
        private readonly IStore _store;

        public LeaderController(IStore store)
        {
            _store = store;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<ApiLeaderModel> listLeaders = null;
            using (var session = _store.CreateSession())
            {
                listLeaders = await session.Query<ApiLeaderModel, ApiLeaderIndex>().ListAsync();
            }
            return View(listLeaders);
        }

        [HttpGet]
        public IActionResult CreateNewLeader()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateNewLeader(ApiLeaderModel viewModel)
        {
            _store.RegisterIndexes<ApiLeaderIndexProvider>();
            using (var session = _store.CreateSession())
            {
                session.Save(viewModel);
            }
            return RedirectToAction("Index");
        }
    }
}
