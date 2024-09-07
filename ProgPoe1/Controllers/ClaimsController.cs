using Microsoft.AspNetCore.Mvc;
using ProgPoe1.Models;
using System.Diagnostics;

namespace ProgPoe1.Controllers
{
    public class ClaimsController : Controller
    {
        // This would normally be replaced by a database context for database interaction.
        private static List<Claim> Claims = new List<Claim>();

        public IActionResult SubmitClaim()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitClaim(Claim claim, IFormFile supportingDocument)
        {
            if (supportingDocument != null && supportingDocument.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/documents", supportingDocument.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    supportingDocument.CopyTo(stream);
                }
                claim.SupportingDocumentsPath = "/documents/" + supportingDocument.FileName;
            }
            claim.Status = "Submitted";
            Claims.Add(claim);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult ApprovalDashboard()
        {
            if (Claims == null)
            {
                Claims = new List<Claim>();  // Initialize if it somehow ends up null
            }

            return View(Claims);
        }

        public IActionResult ApproveClaim(int id)
        {
            var claim = Claims.FirstOrDefault(c => c.Id == id);
            if (claim != null)
            {
                claim.Status = "Approved";
            }
            return RedirectToAction("ApprovalDashboard");
        }

        public IActionResult RejectClaim(int id)
        {
            var claim = Claims.FirstOrDefault(c => c.Id == id);
            if (claim != null)
            {
                claim.Status = "Rejected";
            }
            return RedirectToAction("ApprovalDashboard");
        }
    }
}
