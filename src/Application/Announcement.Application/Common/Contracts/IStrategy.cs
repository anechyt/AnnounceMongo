using Announcement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Announcement.Application.Common.Contracts
{
    public interface IStrategy
    {
        Task<IEnumerable<Announce>> GetAllAnnounce();
        Task<IEnumerable<Announce>> GetAnnouceByName(string name);
        Task CreateAnnounce(Announce annouce);
    }
}
