﻿using Announcement.Application.Common.Contracts;
using Announcement.Domain.Entities;
using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Announcement.Application.Common.Services
{
    public class AnnounceService : IStrategy
    {
        private readonly IAnnounceDbContext _dbContext;
        public AnnounceService(IAnnounceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateAnnounce(Announce annouce)
        {
            FilterDefinition<Announce> filter = Builders<Announce>.Filter.Size("Photos", 3);
            if(filter == null)
            {
                throw new Exception();
            }
            else
            {
                await _dbContext.Announces.InsertOneAsync(annouce);
            }
        }

        public async Task<IEnumerable<Announce>> GetAllAnnounce()
        {
            return await _dbContext.Announces.Find(a => true).SortByDescending(a => a.Price).SortByDescending(a => a.Date).ToListAsync();
        }

        public async Task<IEnumerable<Announce>> GetAnnouceByName(string name)
        {
            FilterDefinition<Announce> filter = Builders<Announce>.Filter.ElemMatch(a => a.Name, name);
            return await _dbContext.Announces.Find(filter).ToListAsync();
        }
    }
}
