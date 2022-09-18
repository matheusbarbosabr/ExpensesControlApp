using ExpensesControlApp.Models.Expenses;
using Microsoft.EntityFrameworkCore;

namespace ExpensesControlApp.Data
{
    public class ExpenseControlContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
            optionsBuilder.UseSqlite("Data Source=ExpensesControl.db");
    }
}
