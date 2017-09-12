using CosmosDBv1.Models;
using CosmosDBv1.Services;
using CosmosDBv1.Services.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmosDBv1.Controllers
{
    [Authorize]
    public class CandidateController : Controller
    {
        private readonly CandidateService _candidateSvc;
        private readonly ClaimService _claimSvc;

        public CandidateController(ClaimService claimSvc, CandidateService candidateSvc)
        {
            _candidateSvc = candidateSvc;
            _claimSvc = claimSvc;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Candidate() { Campus = _claimSvc.GetUserCampus(HttpContext) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Candidate candidate)
        {
            await _candidateSvc.CreateCandidate(candidate);
            return RedirectToAction("Index");
        }

        //[HttpGet]
        //public IActionResult Detail()
        //{
        //    //var vm = new CandidateViewModel();
        //    //return View(vm);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Detail(Candidate candidate)
        {
            return RedirectToAction("Index");
        }
    }
}
