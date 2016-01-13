using System.Data.Entity;

namespace BankingSite.Models
{
    public class BankingSitedDb : DbContext
    {
        public BankingSitedDb()
            : base("name=DefaultConnection")
        {
        }        

        public DbSet<LoanApplication> LoanApplications { get; set; }        
    }
}