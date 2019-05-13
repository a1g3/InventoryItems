using Microsoft.AspNetCore.Mvc;

namespace InventoryItems.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        [HttpGet]
        [Route("[action]")]
        public JsonResult GetAll() {
            return new JsonResult("");
        }
    }
}