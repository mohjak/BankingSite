namespace BankingSite.Models
{
    public interface ILoanApplicationScorer
    {
        void ScoreApplication(LoanApplication application);
    }
}