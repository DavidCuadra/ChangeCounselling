using ChangeCounselling.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChangeCounselling.Web.Models
{
    public class BookingViewModel
    {
        public IEnumerable<Client> Counsellors { get; set; }
        public string Message { get; set; }
        public string CounsellorFirstName { get; set; }
    }
}