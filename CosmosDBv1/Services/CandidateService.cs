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
        private readonly DocumentDbRepository<CandidateNotes> _candidateNotesRepo;

        public CandidateService(DocumentDbRepository<Candidate> candidateRepo, DocumentDbRepository<CandidateNotes> candidateNotesRepo)
        {
            _candidateRepo = candidateRepo;
            _candidateNotesRepo = candidateNotesRepo;
        }

        //Read
        public async Task<Candidate> GetById(string id)
        {
            var candidate = await _candidateRepo.GetByIdAsync(id);
            candidate.Notes = await _candidateNotesRepo.GetItemsAsync(doc => doc.CandidateId == id, candidate.Campus);

            return candidate;
        }

        public async Task<List<Candidate>> GetForCampus(string campus)
        {
            return await _candidateRepo.GetItemsAsync(doc => doc.Campus == campus, campus);
        }

        //Create
        public async Task CreateCandidate(Candidate candidate)
        {
            var newCandidate = await _candidateRepo.CreateAsync(candidate);

            var noteTasks = new List<Task>();
            foreach(var note in candidate.Notes)
            {
                note.CandidateId = newCandidate.Id;
                noteTasks.Add(_candidateNotesRepo.CreateAsync(note));
            }

            await Task.WhenAll(noteTasks);
        }

        //Update
        public async Task UpdateCandidate(Candidate candidate)
        {
            var updatedCandidate = await _candidateRepo.UpdateAsync(candidate);
            var noteTasks = new List<Task>();
            foreach (var note in candidate.Notes)
            {
                noteTasks.Add(_candidateNotesRepo.UpsertAsync(note));
            }

            await Task.WhenAll(noteTasks);
        }

        //Delete
        public async Task DeleteCandidate(Candidate candidate)
        {
            var noteTasks = new List<Task>();
            foreach (var note in candidate.Notes)
            {
                noteTasks.Add(_candidateNotesRepo.DeleteAsync(note));
            }

            await Task.WhenAll(noteTasks);
            await _candidateRepo.DeleteAsync(candidate);
        }
    }
}