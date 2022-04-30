using Announcement.Application.Common.Contracts.Queries;
using System;

namespace Announcement.Application.Common.Contracts
{
    public interface IUriService
    {
        Uri GetPostUri(string postId);
        Uri GetAllPostUri(PaginationQuery pagination = null);
    }
}
