namespace BankingSite.Models
{
    public class CreditHistoryChecker : ICreditHistoryChecker
    {
        public bool CheckCreditHistory(string firstName, string lastName)
        {
            // Simulate actual credit check

            if (firstName.ToUpperInvariant() == "SARAH" 
                && lastName.ToUpperInvariant() == "SMITH")
            {
                return false;
            }

            return true;
        }
    }
}