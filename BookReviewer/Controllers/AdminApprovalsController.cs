using BookReviewer.Models;
using BookReviewer.Models.DbModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BookReviewer.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminApprovalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            ICollection<AdminApproval> approvals = db.AdminApprovals
                .Where(a => !a.IsApproved)
                .OrderBy(a => a.ApplicationUser.UserName)
                .ToList();

            return View(approvals);
        }

        [HttpPost]
        public JsonResult Approve(string adminId)
        {
            AdminApproval approval = db.AdminApprovals.Find(adminId);

            if (approval != null)
            {
                approval.IsApproved = true;
                db.SaveChanges();
                return Json(new { isSuccessful = true }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { isSuccessful = false }, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
