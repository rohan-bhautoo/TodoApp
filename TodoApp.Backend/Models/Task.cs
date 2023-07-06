namespace TodoApp.Backend.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }  
        public string UserId { get; set; }
        public Task(int Id, string Title, string Status, string Description, string UserId)
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
