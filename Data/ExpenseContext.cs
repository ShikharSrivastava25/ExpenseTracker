using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Data {
    public class ExpenseContext(DbContextOptions<ExpenseContext> options) : DbContext(options) {
        public DbSet<Expense> Expenses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Expense>().HasData(
                new Expense {
                    Id = 1,
                    Title = "Groceries",
                    Amount = 150.75m,
                    Category = "Food",
                    Date = new DateTime(2025, 11, 7)
                },
                new Expense {
                    Id = 2,
                    Title = "Electricity Bill",
                    Amount = 60.00m,
                    Category = "Utilities",
                    Date = new DateTime(2025, 10, 30)
                },
                new Expense {
                    Id = 3,
                    Title = "Movie Tickets",
                    Amount = 30.00m,
                    Category = "Entertainment",
                    Date = new DateTime(2025, 11, 4)
                }
            );
        }
    }
}
