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
        [DisplayName("Bill ID")]
        public int BillID { get; set; }

        [Required]
        //Data from book
        [DisplayName("Bill Created Date Time")]
        public DateTime DateTime { get; set; }
        [Required]
        [DisplayName("Client First Name")]
        public string ClientFirstName { get; set; }
        [Required]
        [DisplayName("Client Last Name")]
        public string ClientLastName { get; set; }
        [Required]
        [DisplayName("Counsellor First Name")]
        public string ClientEmail { get; set; }
        [Required]
        [DisplayName("Counsellor First Name")]
        public string CounsellorFirstName { get; set; }
        [Required]
        [DisplayName("Counsellor Last Name")]
        public string CounsellorLastName { get; set; }

        [Required]
        [DisplayName("Counsellor Email")]
        public string CounsellorEmail { get; set; }


        [Required]
        public int BookID { get; set; }
        public virtual Book Book { get; set; }
    }
}
