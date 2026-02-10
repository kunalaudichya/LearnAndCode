namespace Chapter6
{
    public class Paperboy
    {
        public void CollectPayment(Customer customer, float paymentAmount)
        {
            bool paymentCollected = customer.PayAmount(paymentAmount);

            if (!paymentCollected)
            {
                Console.WriteLine("Come back later.");
            }
        }
    }
}
