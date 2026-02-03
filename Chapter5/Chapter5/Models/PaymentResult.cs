namespace Chapter5.Models
{
    public class PaymentResult
    {
        public bool IsSuccessful { get; set; }
        public string StatusMessage { get; set; }
        public string TransactionId { get; set; }

        public PaymentResult(bool IsSuccessful, string StatusMessage, string TransactionId)
        {
            this.IsSuccessful = IsSuccessful;
            this.StatusMessage = StatusMessage;
            this.TransactionId = TransactionId;
        }
    }
}
