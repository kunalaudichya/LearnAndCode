namespace Chapter5.Models
{
    public class PaymentRequest
    {
        public string CustomerId { get; set; }
        public decimal Amount { get; set; }

        public PaymentRequest(string CustomerId, decimal Amount)
        {
            this.CustomerId = CustomerId;
            this.Amount = Amount;
        }
    }
}
