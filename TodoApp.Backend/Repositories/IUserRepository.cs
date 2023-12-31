﻿using TodoApp.Backend.Models;

namespace TodoApp.Backend.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(Guid userId);
        void AddUser(User user);
        void UpdateUser(User existingUser, User newUser);
        void DeleteUser(Guid userId);
    }
}
