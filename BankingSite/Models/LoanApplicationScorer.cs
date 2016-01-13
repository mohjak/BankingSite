namespace BankingSite.Models
{
    public class LoanApplicationScorer : ILoanApplicationScorer
    {
        private readonly ICreditHistoryChecker _creditHistoryChecker;

        public LoanApplicationScorer(ICreditHistoryChecker creditHistoryChecker)
        {
            _creditHistoryChecker = creditHistoryChecker;
        }

        public void ScoreApplication(LoanApplication application)
        {
            var isBasicCriteriaMet = ValidateBasicCriteria(application);

            if (isBasicCriteriaMet)
            {
                var isCreditHistoryGood = 
                    _creditHistoryChecker.CheckCreditHistory(
                                            application.FirstName,
                                            application.LastName);

                application.IsAccepted = isCreditHistoryGood;
            }
            else
            {
                application.IsAccepted = false;
            }
        }

        private bool ValidateBasicCriteria(LoanApplication application)
        {
            // Basic simulated business rules

            // If applicant earns over a million dollars then 
            // other criteria don't matter
            if (application.AnnualIncome > 1000000)
            {
                return true;
            }

            // Don't lend to younger applicants
            if (application.Age <= 21)
            {
                return false;
            }

            return true;
        }
    }
}