namespace Chapter5.Exceptions
{
    public class PaymentException: Exception
    {
        public PaymentException(string message): base(message)
        {
        }
    }
}
