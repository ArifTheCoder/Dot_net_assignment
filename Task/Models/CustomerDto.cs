using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task.Models
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Cin { get; set; }
        public string Name { get; set; }
        public IQueryable<EventsDto> Events { get; set; }

    }
}