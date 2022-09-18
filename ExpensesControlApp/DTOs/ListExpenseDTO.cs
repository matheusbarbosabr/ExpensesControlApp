using ExpensesControlApp.Models.Expenses;

namespace ExpensesControlApp.DTOs
{
    public class ListExpenseDTO
    {
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public List<Expense> Items { get; set; }

        public ListExpenseDTO()
        {
            InitialDate = DateTime.Now.AddDays(-7);
            FinalDate = DateTime.Now.AddDays(3);
            Items = new List<Expense>();
        }
    }
}
