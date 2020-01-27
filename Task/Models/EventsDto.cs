using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task.Models
{
    public class EventsDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Content { get; set; }
        public DateTime EventDateTime { get; set; }
        public bool IsOpen { get; set; }
    }
}