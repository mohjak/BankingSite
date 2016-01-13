namespace BankingSite.Models
{
    public interface IRepository
    {
        void Create(LoanApplication application);
        LoanApplication Find(int id);
    }
}