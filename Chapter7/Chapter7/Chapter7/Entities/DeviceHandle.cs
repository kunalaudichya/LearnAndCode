namespace Chapter7.Entities
{
    public class DeviceHandle
    {
        private string DeviceId;
        public DeviceHandle(string deviceId)
        {
            DeviceId = deviceId;
        }
        public string GetDeviceId()
        {
            return DeviceId;
        }
    }
}
