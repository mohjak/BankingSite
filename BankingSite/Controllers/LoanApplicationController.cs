using System.Web.Mvc;
using BankingSite.Models;

namespace BankingSite.Controllers
{
    public class LoanApplicationController : Controller
    {
        private readonly IRepository _repository;
        private readonly ILoanApplicationScorer _scorer;

        public LoanApplicationController(IRepository repository, ILoanApplicationScorer scorer)
        {
            _repository = repository;
            _scorer = scorer;
        }


        public ActionResult Apply()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Apply(LoanApplication application)
        {
            if (!ModelState.IsValid)
            {
                return View(application);
            }

            _scorer.ScoreApplication(application);

            _repository.Create(application);

            if (application.IsAccepted)
            {
                return RedirectToAction("Accepted", new { id = application.ID });
            }
            else
            {
                return RedirectToAction("Declined", new { id = application.ID });
            }
        }


        public ActionResult Accepted(int id)
        {
            var application = _repository.Find(id);

            return View(application);
        }

        public ActionResult Declined(int id)
        {
            var application = _repository.Find(id);

            return View(application);            
        }
    }
}