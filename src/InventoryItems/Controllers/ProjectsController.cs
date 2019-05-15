using AutoMapper;
using InventoryItems.Domain.Interfaces.Facades;
using InventoryItems.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace InventoryItems.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        public IProjectFacade ProjectFacade { get; set; }

        [HttpGet]
        [Route("[action]")]
        public JsonResult GetProjectList() {
            var viewModel = new List<ProjectViewModel>() {
                new ProjectViewModel(){ Name = "Project 1", Id = Guid.NewGuid() },
                new ProjectViewModel(){ Name = "Project 2", Id = Guid.NewGuid() }
            };
            return new JsonResult(viewModel);
        }

        [HttpGet]
        public JsonResult Get(Guid projectId) {
            var project = ProjectFacade.GetById(projectId);
            return new JsonResult(Mapper.Map<ProjectViewModel>(project));
        }
    }
}