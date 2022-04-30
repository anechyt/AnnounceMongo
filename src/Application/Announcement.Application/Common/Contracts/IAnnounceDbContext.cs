using Announcement.Domain.Entities;
using MongoDB.Driver;

namespace Announcement.Application.Common.Contracts
{
    public interface IAnnounceDbContext
    {
        IMongoCollection<Announce> Announces { get; }
    }
}
