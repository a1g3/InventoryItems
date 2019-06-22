using InventoryItems.Domain.Interfaces.Facades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryItems.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        public IAuthenticationFacade AuthenticationFacade { get; set; }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post(string username, string password) {
            var token = AuthenticationFacade.Login(username, password);
            return string.IsNullOrEmpty(token) ? Forbid() : (IActionResult)Ok(new { Token = token });
        }
    }
}