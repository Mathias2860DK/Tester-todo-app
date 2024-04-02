namespace Tester_todo_app.Entities
{
    public class Todo
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; } = false;
        public DateTime? DueDate { get; set; }
        public Tag[]? Tags { get; set; }
    }
}

