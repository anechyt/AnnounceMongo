using Announcement.Domain.Entities;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Announcement.Application.Common.Contracts
{
    public interface IStrategy
    {
        Task<IEnumerable<Announce>> GetAllAnnounce(PaginationFilter paginationFilter = null);
        Task<IEnumerable<Announce>> GetAnnouceByName(string name);
        Task CreateAnnounce(Announce annouce);
    }
}
