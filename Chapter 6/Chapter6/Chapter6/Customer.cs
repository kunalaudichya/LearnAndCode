namespace Chapter6
{
    public class Customer
    {
        private string firstName;
        private string lastName;
        private Wallet wallet;
        public string GetFirstName()
        {
            return firstName;
        }

        public string GetLastName()
        {
            return lastName;
        }
        
        public bool PayAmount(float amountToPay)
        {
            float currentBalance = wallet.GetTotalMoney();

            if (amountToPay <= currentBalance)
            {
                wallet.SubtractMoney(amountToPay);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
