﻿using CosmosDBv1.Models;
using CosmosDBv1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmosDBv1.Services
{
    public class CandidateService
    {
        private readonly DocumentDbRepository<Candidate> _candidateRepo;

        public CandidateService(DocumentDbRepository<Candidate> candidateRepo)
        {
            _candidateRepo = candidateRepo;
        }

        //Read
        public async Task<Candidate> GetById(string id, string campus)
        {
            var candidate = await _candidateRepo.GetByIdAsync(id, campus);
            return candidate;
        }

        public async Task<List<Candidate>> GetForCampus(string campus)
        {
            return await _candidateRepo.GetItemsAsync(doc => doc.Type == "candidate", campus);
        }

        //Create
        public async Task CreateCandidate(Candidate candidate)
        {
            var newCandidate = await _candidateRepo.CreateAsync(candidate);
        }

        //Update
        public async Task UpdateCandidate(Candidate candidate)
        {
            var updatedCandidate = await _candidateRepo.UpdateAsync(candidate);
        }

        //Delete
        public async Task DeleteCandidate(Candidate candidate)
        {
            await _candidateRepo.DeleteAsync(candidate, candidate.Campus);
        }
    }
}
