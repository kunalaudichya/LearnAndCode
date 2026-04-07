namespace Chapter7.Entities
{
    public class DeviceRecord
    {
        private bool IsConnected;
        private bool IsActive;
        public DeviceRecord(bool isConnected, bool isActive)
        {
            IsConnected = isConnected;
            IsActive = isActive;
        }

        public bool IsDeviceConnected()
        {
            return IsConnected;
        }

        public bool IsDeviceActive()
        {
            return IsActive;
        }
    }
}
