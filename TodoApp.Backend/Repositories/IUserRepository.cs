using TodoApp.Backend.Models;

namespace TodoApp.Backend.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(Guid id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(Guid id);
    }
}
