using IdentityServer4.EntityFramework.Options;
using InventoryItems.Domain.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace InventoryItems.Identity
{
    public class UserContext : ApiAuthorizationDbContext<User>
    {
        public UserContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions) { }
    }
}
