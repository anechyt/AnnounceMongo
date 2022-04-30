using Announcement.Application.Common.Contracts;
using Announcement.Domain.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Announcement.Dal.Data
{
    public class AnnounceDbContext : IAnnounceDbContext
    {
        public AnnounceDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);

            Announces = database.GetCollection<Announce>("Announces");
        }
        public IMongoCollection<Announce> Announces { get; }
    }
}
