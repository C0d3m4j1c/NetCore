using System.Collections.Generic;
using System.Linq;
using AT.DataAccess.Data;
using AT.IDataAccess.IRepository;
using AT.Model.Common;

namespace AT.DataAccess.Repository
{
    public class UserRepository : IRepository<User>
    {
        private readonly ATDbContext context;
        public UserRepository(ATDbContext Context)
        {
            context = Context;
        }
        public User Create(User Entity)
        {
            context.Users.Add(Entity);
            context.SaveChanges();
            return Entity;
        }

        public User Delete(User Entity)
        {
            var userToBeDeleted = context.Users.Find(Entity.Id);
            if(userToBeDeleted != null)
            {
                context.Users.Remove(userToBeDeleted);
                context.SaveChanges();
                return userToBeDeleted;
            }
            return null; 
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users.ToList();
        }

        public User GetById(int Id)
        {
            return context.Users.Find(Id);
        }

        public User Update(User Entity)
        {
            var userToBeUpdated = context.Users.Find(Entity.Id);
            if(userToBeUpdated != null)
            {
                userToBeUpdated.UserName = Entity.UserName;
                userToBeUpdated.IsDeleted = Entity.IsDeleted;
                context.Users.Update(userToBeUpdated);
                context.SaveChanges();
                return userToBeUpdated;
            }
            return null; 
        }        
    }
}