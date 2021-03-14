using FuturifyModule.Indexes;
using FuturifyModule.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using YesSql;

namespace MyModule.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IStore _store;

        public ProjectController(IStore store)
        {
            _store = store;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<ProjectModel> listProjects = null;
            using (var session = _store.CreateSession())
            {
                listProjects = await session.Query<ProjectModel, ProjectIndex>(x => x.IsDeleted == 0).ListAsync();
            }
            return View(listProjects);
        }

        [HttpGet]
        public IActionResult CreateNewProject()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateNewProject(ProjectModel viewModel)
        {
            _store.RegisterIndexes<ProjectIndexProvider>();
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
            }
            return RedirectToAction("Index");
        }
    }
}