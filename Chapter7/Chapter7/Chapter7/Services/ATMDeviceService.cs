using Chapter7.Entities;
using Chapter7.Exceptions;

namespace Chapter7.Services
{
    public class ATMDeviceService
    {
        private const string DEV1 = "DEV1";
        private Dictionary<string, double> accounts = new()
        {
            { "01", 1000.0 },
            { "02", 500.0 }
        };
        public void Withdraw(string accountId, double amount)
        {
            DeviceHandle device = GetDevice(DEV1);
            DeviceRecord deviceRecord = RetrieveDeviceRecord(device);
            CheckDeviceStatus(deviceRecord, device);
            CheckDeviceConnection(deviceRecord, device);
            EnsureSufficientBalance(accountId, amount);
            DispenseCash(device, amount);
        }

        private DeviceHandle GetDevice(string deviceId)
        {
            bool deviceExists = true;

            if (!deviceExists)
                throw new DeviceNotFoundException($"Could not connect to Device: {deviceId}");

            return new DeviceHandle(deviceId);
        }

        private DeviceRecord RetrieveDeviceRecord(DeviceHandle device)
        {
            DeviceRecord record = new DeviceRecord(isConnected: true, isActive: true);

            if(record == null)
            {
                throw new DeviceNotFoundException($"{device.GetDeviceId()} not found.");
            }

            return record;
        }

        private void CheckDeviceConnection(DeviceRecord record, DeviceHandle device)
        {
            if (!record.IsDeviceConnected())
            {
                throw new NetworkConnectionException($"{device.GetDeviceId()} is not properly connected to the network.");
            }
        }

        private void CheckDeviceStatus(DeviceRecord record, DeviceHandle device)
        {
            if (!record.IsDeviceActive())
            {
                throw new DeviceNotActiveException($"{device.GetDeviceId()} is not active at the moment.");
            }
        }
        private void EnsureSufficientBalance(string accountId, double amount)
        {
            double balance = GetBalance(accountId);
            if(balance < amount)
            {
                throw new InsufficientFundsException($"Account: {accountId} does not have enough balance to withdraw cash.");
            }
        }

        private double GetBalance(string accountId)
        {
            if (!accounts.ContainsKey(accountId))
                throw new AccountNotFoundException($"Account {accountId} not found");

            return accounts[accountId];
        }

        private void DispenseCash(DeviceHandle device, double amount)
        {
            Console.WriteLine($"Dispensing {amount} from device { device.GetDeviceId()}");
        }
    }
}
