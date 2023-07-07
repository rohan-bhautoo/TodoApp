using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
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

        private string HashPassword(string password, byte[] salt)
        {
            using (var hmac = new HMACSHA256(salt))
            {
                var hashedPassword = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedPassword);
            }
        }

        private byte[] GenerateSalt()
        {
            var salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        public User GetUserById(Guid userId)
        {
            return dbContext.User.Find(userId)!;
        }

        public void AddUser(User user)
        {
            var salt = GenerateSalt();
            var hashedPassword = HashPassword(user.Password, salt);

            User userVal = new(user.UserId,user.FirstName,user.LastName,user.Email,hashedPassword);

            dbContext.User.Add(userVal);
            dbContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            dbContext.Entry(user).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public void DeleteUser(Guid userId)
        {
            User user = dbContext.User.Find(userId)!;
            dbContext.User.Remove(user);
            dbContext.SaveChanges();
        }

    }
}
