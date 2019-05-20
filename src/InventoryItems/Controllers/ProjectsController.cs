using AutoMapper;
using InventoryItems.Domain.Exceptions;
using InventoryItems.Domain.Interfaces.Facades;
using InventoryItems.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

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

        [HttpPut]
        public HttpResponseMessage Create(string name) {
            try {
                ProjectFacade.CreateProject(name);
                return new HttpResponseMessage(HttpStatusCode.Created);
            } catch (NameAlreadyExistsException) {
                return new HttpResponseMessage(HttpStatusCode.Conflict);
            }
        }

        [HttpPut]
        [Route("[action]")]
        public HttpResponseMessage CreateProject(CoinViewModel coin) {
            string documentContents;
            using (Stream receiveStream = this.Request.Body) {
                using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8)) {
                    documentContents = readStream.ReadToEnd();
                }
            }
            return new HttpResponseMessage(HttpStatusCode.Created);
        }
    }
}