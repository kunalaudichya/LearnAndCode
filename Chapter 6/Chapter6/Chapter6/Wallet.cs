namespace Chapter6
{
    public class Wallet
    {
        private float value;

        public float GetTotalMoney()
        {
            return value;
        }

        public void SetTotalMoney(float newValue)
        {
            value = newValue;
        }

        public void SubtractMoney(float debit)
        {
            if(value >= debit)
            {
                value -= debit;
            }
        }

    }
}
