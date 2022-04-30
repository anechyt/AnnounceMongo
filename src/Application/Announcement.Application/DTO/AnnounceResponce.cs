using System;
using System.Net;

namespace Announcement.Application.DTO
{
    public class AnnounceResponce
    {
        public Guid Id { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
