using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Announcement.Application.Common.Contracts
{
    public class Responce<T>
    {
        public Responce() { }
        public Responce(T responce)
        {
            Data = responce;
        }
        public T Data { get; set; }
    }
}
