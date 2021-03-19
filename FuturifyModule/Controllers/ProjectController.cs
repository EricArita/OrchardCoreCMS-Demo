using FuturifyModule.Indexes;
using FuturifyModule.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YesSql;

namespace MyModule.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class ProjectController : Controller
    {
        private readonly IStore _store;

        public ProjectController(IStore store)
        {
            _store = store;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<ApiProjectModel> listProjects = null;
            using (var session = _store.CreateSession())
            {
                listProjects = await session.Query<ApiProjectModel, ApiProjectIndex>(x => x.IsDeleted == 0).ListAsync();
            }
            return View(listProjects);
        }

        public async Task<IActionResult> IndexWithLeader()
        {
            IEnumerable<ProjectLeadModel> listProjects = null;

            using (var session = _store.CreateSession())
            {
                listProjects = await session.Query<ProjectLeadModel>().ListAsync();
                 //var tmp = await session.Query<ProjectLeadModel>()
                 //   .Any(
                 //       x => x.With<PersonIdentity>(x => x.Identity == "Hanselman"),
                 //       x => x.With<PersonIdentity>(x => x.Identity == "Guthrie"))
                 //   .CountAsync()
            }
            return View(listProjects);
        }

        [HttpGet]
        public IActionResult CreateNewProject()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateNewProject(ApiProjectModel viewModel)
        {
            _store.RegisterIndexes<ApiProjectIndexProvider>();
            using (var session = _store.CreateSession())
            {
                session.Save(viewModel);
            }
            return RedirectToAction("Index");
        }

        [HttpGet("EditProject/{Id}")]
        public async Task<IActionResult> EditProject(int Id)
        {
            ProjectModel project = null;
            using (var session = _store.CreateSession())
            {
                project = await session.GetAsync<ProjectModel>(Id);
            }
            return View(project);
        }

        [HttpPost]
        public async Task<IActionResult> EditProject(ProjectModel viewModel)
        {
            using (var session = _store.CreateSession())
            {
                var project = await session.GetAsync<ProjectModel>(viewModel.Id);
                project = viewModel;
            }
            return RedirectToAction("Index");
        }

        [HttpGet("DeleteProject/{Id}")]
        public async Task<IActionResult> DeleteProject(int Id)
        {
            using (var session = _store.CreateSession())
            {
                var project = await session.GetAsync<ProjectModel>(Id);
                project.IsDeleted = 1;
                session.Save(project);
            }
            return RedirectToAction("Index");
        }

        //[HttpPost("create")]
        //public async Task<IActionResult> CreateNewProjectApi(ApiProjectModel viewModel)
        //{
        //    _store.RegisterIndexes<ApiProjectIndexProvider>();
        //    using (var session = _store.CreateSession())
        //    {
        //        try {
        //            session.Save(viewModel);
        //        }
        //        catch (Exception ex)
        //        {
        //            return BadRequest(ex);
        //        }
        //    }

        //    return Ok();
        //}
    }
}