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

        public async Task<IActionResult> Index()
        {
            var campus = _claimSvc.GetUserCampus(HttpContext);
            var candidates = await _candidateSvc.GetForCampus(campus);
            return View(candidates);
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

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var campus = _claimSvc.GetUserCampus(HttpContext);
            var candidate = await _candidateSvc.GetById(id, campus);
            return View(candidate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Candidate candidate)
        {
            await _candidateSvc.UpdateCandidate(candidate);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var candidate = await _candidateSvc.GetById(id, _claimSvc.GetUserCampus(HttpContext));
            await _candidateSvc.DeleteCandidate(candidate);
            return RedirectToAction("Index");
        }
    }
}
