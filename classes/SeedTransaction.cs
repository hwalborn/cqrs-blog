namespace cqrs_budget.classes
{
    public class SeedTransaction
    {
        public string? title { get; set; }
        public string? Description { get; set; }
        public decimal? Amount { get; set; }
        public int? TransactionTypeId { get; set; }
        public int? AccountId { get; set; }
    }
}