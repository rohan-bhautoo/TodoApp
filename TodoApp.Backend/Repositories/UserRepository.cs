using Microsoft.EntityFrameworkCore;
using TodoApp.Backend.Data;
using TodoApp.Backend.Models;

namespace TodoApp.Backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TodoAppBackendContext dbContext;

        public UserRepository(TodoAppBackendContext dbContext) {
            this.dbContext = dbContext;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return dbContext.User.ToList();
        }

        public User GetUserById(Guid id)
        {
            return dbContext.User.Find(id);
        }

        public void AddUser(User user)
        {
            dbContext.User.Add(user);
            dbContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            dbContext.Entry(user).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public void DeleteUser(Guid id)
        {
            var user = dbContext.User.Find(id);
            dbContext.User.Remove(user);
            dbContext.SaveChanges();
        }

    }
}
