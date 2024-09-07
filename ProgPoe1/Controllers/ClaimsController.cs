using Microsoft.AspNetCore.Mvc;
using ProgPoe1.Models;
using System.Diagnostics;

namespace ProgPoe1.Controllers
{
    public class ClaimsController : Controller
    {
        // Static list to hold claims, typically this would be managed by a database context.
        private static List<Claim> Claims = new List<Claim>();

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Displays the view for submitting a new claim.
        /// </summary>
        /// <returns>View for submitting a claim.</returns>
        public IActionResult SubmitClaim()
        {
            return View();
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Processes the submitted claim along with an optional supporting document.
        /// </summary>
        /// <param name="claim">The claim details submitted by the user.</param>
        /// <param name="supportingDocument">The supporting document file, if any.</param>
        /// <returns>Redirects to the Home index page after submission.</returns>
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

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Displays the approval dashboard with all submitted claims.
        /// </summary>
        /// <returns>View displaying the list of claims for approval.</returns>
        public IActionResult ApprovalDashboard()
        {
            if (Claims == null)
            {
                Claims = new List<Claim>();  // Initialize if it somehow ends up null
            }

            return View(Claims);
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Approves a claim based on the given ID.
        /// </summary>
        /// <param name="id">ID of the claim to be approved.</param>
        /// <returns>Redirects to the approval dashboard.</returns>
        public IActionResult ApproveClaim(int id)
        {
            var claim = Claims.FirstOrDefault(c => c.Id == id);
            if (claim != null)
            {
                claim.Status = "Approved";
            }
            return RedirectToAction("ApprovalDashboard");
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Rejects a claim based on the given ID.
        /// </summary>
        /// <param name="id">ID of the claim to be rejected.</param>
        /// <returns>Redirects to the approval dashboard.</returns>
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

//------------------------------------------...ooo000 END OF FILE 000ooo...----------------------------------------------------------------------------------------------------------------------//
