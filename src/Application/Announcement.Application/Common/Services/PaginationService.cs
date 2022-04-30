using Announcement.Application.Common.Contracts;
using Announcement.Application.Common.Contracts.Queries;
using Announcement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Announcement.Application.Common.Services
{
    public class PaginationService
    {
        public static object CreatePaginatedResponse<T>(IUriService uriService, PaginationFilter paginationFilter, List<T> announces)
        {
            var nextPage = paginationFilter.PageNumber >= 1 ? uriService
                .GetAllPostUri(new PaginationQuery(paginationFilter.PageNumber + 1, paginationFilter.PageSize)).ToString() : null;

            var previousPage = paginationFilter.PageNumber - 1 >= 1 ? uriService
                .GetAllPostUri(new PaginationQuery(paginationFilter.PageNumber - 1, paginationFilter.PageSize)).ToString() : null;

            return new PagedResponse<T>
            {
                Data = announces,
                PageNumber = paginationFilter.PageNumber >= 1 ? paginationFilter.PageNumber : (int?)null,
                PageSize = paginationFilter.PageSize >= 1 ? paginationFilter.PageSize : (int?)null,
                NextPage = announces.Any() ? nextPage : null,
                PreviousPage = previousPage
            };
        }
    }
}
