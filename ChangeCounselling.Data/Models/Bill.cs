using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Bill Created Date Time")]
        public DateTime DateTime { get; set; }
        [Required]
        public string ClientFirstName { get; set; }
        [Required]
        public string ClientLastName { get; set; }
        [Required]
        public string ClientEmail { get; set; }
        [Required]
        public string CounsellorFirstName { get; set; }
        [Required]
        public string CounsellorLastName { get; set; }

        [Required]
        public string CounsellorEmail { get; set; }


        [Required]
        public int BookID { get; set; }
        public virtual Book Book { get; set; }
    }
}
