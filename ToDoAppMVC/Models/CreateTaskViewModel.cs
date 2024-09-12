using System.ComponentModel.DataAnnotations;

namespace ToDoAppMVC.Models
{
    public class CreateTaskViewModel
    {
        [Required(ErrorMessage = "El campo es requerido")]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
