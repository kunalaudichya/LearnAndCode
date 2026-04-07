namespace Chapter7.Exceptions
{
    public class AccountNotFoundException : Exception
    {
        public AccountNotFoundException(string message) : base(message)
        {

        }
    }
}
