using System.ComponentModel.DataAnnotations;

namespace TodoApp.Backend.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public string Email { get; set; }
        [Required] public string Password { get; set; }
        public string Salt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public User(Guid UserId, string FirstName, string LastName, string Email, string Password, string Salt, DateTime CreatedAt)
        {
            this.UserId = UserId;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Password = Password;
            this.Salt = Salt;
            this.CreatedAt = CreatedAt;
        }

        public void UpdateUser(User updatedUser)
        {
            FirstName = updatedUser.FirstName;
            LastName = updatedUser.LastName;
            Email = updatedUser.Email;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
