

namespace Application.DTOs.Todo
{
    public class TodoItemDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public bool IsCompleted { get; set; }

        public Guid CategoryId { get; set; }
        public string? CategoryName { get; set; }

    }
}
