using System.Web.Mvc;
using BankingSite.Models;

namespace BankingSite.Controllers
{
    public class LoanApplicationSearchController : Controller
    {
        private readonly IRepository _repository;

        public LoanApplicationSearchController(IRepository repository)
        {
            _repository = repository;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ApplicationStatus(int applicationId)
        {
            var application = _repository.Find(applicationId);

            if (application == null)
            {
                return HttpNotFound();
            }

            return View(application);
        }
    }
}