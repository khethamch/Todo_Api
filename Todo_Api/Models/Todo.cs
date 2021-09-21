using System.ComponentModel.DataAnnotations;

namespace Todo_Api.Models
{
    public class Todo
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public bool Completed { get; set; } = false;
    }
}