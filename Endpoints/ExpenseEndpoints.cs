using ExpenseTracker.Data;
using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Endpoints {
    public static class ExpenseEndpoints {
        public static WebApplication expenseEndpoints(this WebApplication app) {

            app.MapGet("expenses", async (ExpenseContext dbContext) => {
                var expenses = await dbContext.Expenses.ToListAsync();

                return Results.Ok(expenses);
            });

            app.MapGet("expenses/{id}", async (int id, ExpenseContext dbContext) => {
                return await dbContext.Expenses.FindAsync(id) is Expense exp ? Results.Ok(exp) : Results.NotFound();
            }).WithName("GetExpenses");

            app.MapPost("expenses", async (CreateExpenseDto dto, ExpenseContext dbContext) => {

                var expense = new Expense { Title = dto.Title, Amount = dto.Amount, Category = dto.Category, Date = dto.Date };
                dbContext.Expenses.Add(expense);
                await dbContext.SaveChangesAsync();

                return Results.CreatedAtRoute("GetExpenses", new { id = expense.Id }, expense);
            });

            app.MapPut("expenses/{id}", async (int id, UpdateExpenseDto dto, ExpenseContext dbContext) => {
                var expense = await dbContext.Expenses.FindAsync(id);
                if (expense is null) return Results.NotFound();

                expense.Title = dto.Title;
                expense.Amount = dto.Amount;
                expense.Date = dto.Date;
                expense.Category = dto.Category;

                await dbContext.SaveChangesAsync();

                return Results.NoContent();
            });

            app.MapDelete("expenses/{id}", async (int id, ExpenseContext dbContext) => {
                await dbContext.Expenses.Where(expense => expense.Id == id).ExecuteDeleteAsync();

                return Results.NoContent();
            });

            return app;
        }
    }
}
