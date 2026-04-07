namespace Chapter7.Exceptions
{
    public class DeviceNotActiveException : Exception
    {
        public DeviceNotActiveException(string message) : base(message)
        {

        }
    }
}
