using AutoMapper;
using InventoryItems.Data.Entities;
using InventoryItems.Data.Infastructure;
using InventoryItems.Domain.EntityDtos;
using InventoryItems.Domain.Interfaces.Repositories;
using System.Linq;

namespace InventoryItems.Data.Repositories {
    public class UserRepository : Repository<Users>, IUserRepository {
        public IMapper Mapper { get; set; }
        public UserRepository(IDatabaseFactory factory) : base(factory) {}

        public UserEntityDto GetUser(string username) {
            var userEntity = (from user in this.Db
                    where user.Username == username
                    select user).SingleOrDefault();

            if (userEntity == null) return null;
            return Mapper.Map<UserEntityDto>(userEntity);
        }
    }
}
