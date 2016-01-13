namespace BankingSite.Models
{
    public class Repository : IRepository
    {      
        public void Create(LoanApplication application)
        {
            using (var db = new BankingSitedDb())
            {
                db.LoanApplications.Add(application);
                db.SaveChanges();
            }            
        }

        public LoanApplication Find(int id)
        {
            using (var db = new BankingSitedDb())
            {
                return db.LoanApplications.Find(id);
            }              
        }
    }
}