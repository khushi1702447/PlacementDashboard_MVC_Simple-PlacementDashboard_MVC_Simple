using System.Web.Mvc;
using PlacementDashboard.Data;

namespace PlacementDashboard.Controllers
{
    public class PlacementController : Controller
    {
        private PlacementRepository repo = new PlacementRepository();

        public ActionResult Index()
        {
            return View(repo.GetDashboard());
        }

        public ActionResult Report()
        {
            return View();
        }
    }
}
