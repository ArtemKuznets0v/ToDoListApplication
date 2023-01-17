using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListApplication.Models
{
    public class ToDoListModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string NameTask { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime DateOfTask { get; set; }

    }
}
