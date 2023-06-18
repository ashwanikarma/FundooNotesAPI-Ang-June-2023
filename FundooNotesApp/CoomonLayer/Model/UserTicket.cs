using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class UserTicket
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string token { get; set; }
        public DateTime issueDateTime { get; set; }
    }
}
