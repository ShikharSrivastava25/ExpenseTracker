namespace ExpenseTracker.Models {
    public record UpdateExpenseDto(
        string Title,
        decimal Amount,
        DateTime Date,
        string Category
    );
}
