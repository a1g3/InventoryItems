using AutoMapper;
using InventoryItems.Data.Entities;
using InventoryItems.Data.Infastructure;
using InventoryItems.Domain.Dtos;
using InventoryItems.Domain.Interfaces.Repositories;
using System.Linq;

namespace InventoryItems.Data.Repositories {
    public class UserRepository : Repository<Users>, IUserRepository {
        public UserRepository(IDatabaseFactory factory) : base(factory) {}

        public User GetUser(string username) {
            var userEntity = (from user in this.Db
                    where user.Username == username
                    select user).SingleOrDefault();

            if (userEntity == null) return null;
            return Mapper.Map<User>(userEntity);
        }
    }
}
