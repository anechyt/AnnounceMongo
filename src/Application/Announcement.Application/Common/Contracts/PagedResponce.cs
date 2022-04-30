﻿using System.Collections.Generic;

namespace Announcement.Application.Common.Contracts
{
    public class PagedResponce<T>
    {
        public PagedResponce() { }
        public PagedResponce(IEnumerable<T> data)
        {
            Data = data;
        }
        public IEnumerable<T> Data { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string NextPage { get; set; }
        public string PreviousPage { get; set; }
    }
}
