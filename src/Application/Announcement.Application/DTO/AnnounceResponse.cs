using MongoDB.Bson;
using System;
using System.Net;

namespace Announcement.Application.DTO
{
    public class AnnounceResponse
    {
        public ObjectId Id { get; set; }
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
    }
}
