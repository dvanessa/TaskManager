using System.ComponentModel.DataAnnotations;
using TaskManager.Application.Validations;

namespace TaskManager.API.DTOs
{
    [DateRange("StartDate", "EndDate", ErrorMessage = "La fecha de inicio debe ser menor que la fecha de fin.")]
    public class TaskItemDto
    {
        [Required(ErrorMessage = "El título es obligatorio")]
        [StringLength(100, ErrorMessage = "El título no puede tener más de 100 caracteres")]
        [NoNumbers]
        public string Title { get; set; } = "";

        [StringLength(500, ErrorMessage = "La descripción no puede tener más de 500 caracteres")]
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        [FutureDate]
        public DateTime? DueDate { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}