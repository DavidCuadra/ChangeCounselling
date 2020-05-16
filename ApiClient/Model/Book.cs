using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient.Model
{
   public class Book
    {
        public int BookID { get; set; }
        public DateTime DateTime { get; set; }
        public int ClientID { get; set; }
        public int CounsellorID { get; set; }
    }
}
