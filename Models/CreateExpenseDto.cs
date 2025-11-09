namespace ExpenseTracker.Models {
    public record CreateExpenseDto(
        string Title,
        decimal Amount,
        DateTime Date,
        string Category
    );
}
