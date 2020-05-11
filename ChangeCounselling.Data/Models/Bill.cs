using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeCounselling.Data.Models
{
    public class Bill
    {
        [Key]
        public int BillID { get; set; }

        [Required]
        //Data from book
        public DateTime DateTime { get; set; }

        [Required]
        public string ClientEmail { get; set; }

        [Required]
        public string CounsellorEmail { get; set; }


        [Required]
        public int BookID { get; set; }
        public virtual Book Book { get; set; }
    }
}
