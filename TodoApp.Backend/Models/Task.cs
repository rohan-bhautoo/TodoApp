﻿namespace TodoApp.Backend.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }  
        public Guid UserId { get; set; }
        public Task(int Id, string Title, bool Status, string Description, Guid UserId)
        {
            this.Id = Id;
            this.Title = Title;
            this.Status = Status;
            this.Description = Description;
            this.CreatedDate = DateTime.Now;
            this.UserId = UserId;
        }

    }
}
