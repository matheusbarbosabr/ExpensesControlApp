using ExpensesControlApp.Data;
using ExpensesControlApp.Models.Expenses;
using Microsoft.EntityFrameworkCore;

namespace ExpensesControlApp.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly ExpenseControlContext _context;

        public ExpenseService(ExpenseControlContext context)
        {
            _context = context;
        }

        public async Task Create(DTOs.CreateExpenseDTO createExpenseDTO)
        {
            await _context.Expenses.AddAsync(new Expense()
            {
                Description = createExpenseDTO.Description,
                Value = createExpenseDTO.Value,
                Date = createExpenseDTO.Date
            });

            await _context.SaveChangesAsync();
        }

        public async Task<List<Expense>> FindBy(DateTime initialDate, DateTime finalDate)
        {
            if (initialDate > finalDate)
            {
                throw new Exception("Final date must be greater than initial date");
            }

            var items = await _context.Expenses.Where(e => e.Date >= initialDate && e.Date <= finalDate).AsNoTracking().ToListAsync();

            return items;
        }
    }
}
