namespace Tester_todo_app.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Todo[] todos { get; set; }
    }
}
