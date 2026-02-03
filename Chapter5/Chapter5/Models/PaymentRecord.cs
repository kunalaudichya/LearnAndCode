namespace Chapter5.Models
{
    public class PaymentRecord
    {
        public string CustomerId { get; set; }
        public decimal Amount { get; set; }
        public DateTime ProcessedAt { get; set; }

        public PaymentRecord(string CustomerId, decimal Amount, DateTime ProcessedAt)
        {
            this.CustomerId = CustomerId;
            this.Amount = Amount;
            this.ProcessedAt = ProcessedAt;
        }
    }
}
