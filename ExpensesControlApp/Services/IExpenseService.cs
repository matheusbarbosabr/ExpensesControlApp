using ExpensesControlApp.Models.Expenses;

namespace ExpensesControlApp.Services
{
    public interface IExpenseService
    {
        Task Create(DTOs.CreateExpenseDTO createExpenseDTO);
        Task<List<Expense>> FindBy(DateTime startDate, DateTime endDate);
    }
}
