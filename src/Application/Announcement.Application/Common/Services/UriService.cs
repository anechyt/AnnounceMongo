using Announcement.Application.Common.Contracts;
using Announcement.Application.Common.Contracts.Queries;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Announcement.Application.Common.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseuri;
        public UriService(string baseuri)
        {
            _baseuri = baseuri;
        }
        public Uri GetAllPostUri(PaginationQuery pagination = null)
        {
            var uri = new Uri(_baseuri);

            if(pagination == null)
            {
                return uri;
            }

            var modifiedUri = QueryHelpers.AddQueryString(_baseuri, "pageNumber", pagination.PageNumber.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "pageSize", pagination.PageSize.ToString());

            return new Uri(modifiedUri);
        }

        public Uri GetPostUri(string postId)
        {
            return new Uri(_baseuri + postId);
        }
    }
}
