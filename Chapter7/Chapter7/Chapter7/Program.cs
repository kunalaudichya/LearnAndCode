using Chapter7.Exceptions;
using Chapter7.Services;

namespace Chapter7
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var atmService = new ATMDeviceService();
            string accountId = "01";
            double requestedAmount = 100.0;

            Console.WriteLine("Starting transaction...\n");

            try
            {
                atmService.Withdraw(accountId, requestedAmount);
                Console.WriteLine("\nSUCCESS: Please take your cash.");
            }
            catch (InsufficientFundsException e)
            {
                Console.WriteLine($"DECLINED: {e.Message}");
            }
            catch (DeviceNotFoundException e)
            {
                Console.WriteLine($"OUT OF ORDER: {e.Message}");
            }
            catch (NetworkConnectionException e)
            {
                Console.WriteLine($"NETWORK ERROR: {e.Message} Please try again later.");
            }
            catch (DeviceNotActiveException e)
            {
                Console.WriteLine($"FATAL SYSTEM ERROR: {e.Message}. Contact bank administrator immediately.");
            }
            catch(AccountNotFoundException e)
            {
                Console.WriteLine($"INVALID ACCOUNT: {e.Message}. Please check your account details and try again.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"AN UNKNOWN ERROR OCCURRED: {e.Message}. Transaction cancelled.");
            }
        }
    }

}
