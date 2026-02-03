namespace Chapter5.Services
{
    public class NotificationService
    {
        public void Send(string customerId, string message)
        {
            Console.WriteLine($"Notification: '{message}' sent to {customerId}");
        }
    }
}
