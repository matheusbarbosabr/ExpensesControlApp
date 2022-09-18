using System.ComponentModel.DataAnnotations;

namespace ExpensesControlApp.DTOs
{
    public class CreateExpenseDTO
    {
        public CreateExpenseDTO()
        {
            Date = DateTime.Now;
        }

        [Required(ErrorMessage = "A description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "A value is required.")]
        [Range(0.01, 999999999, ErrorMessage = "The value must be greater than zero.")]
        public double Value { get; set; }

        [Required(ErrorMessage = "A date is required.")]
        public DateTime Date { get; set; }
    }
}
