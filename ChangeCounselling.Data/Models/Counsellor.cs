using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ChangeCounselling.Data.Models
{
    public class Counsellor
    {

        
        public int CounsellorID { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        [Display(Name ="First Name")]
        public string CouncellorFirstName { get; set; }

        public IEnumerable<SelectListItem> CounsellorList { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        [Display(Name = "Last Name")]
        public string CouncellorLastName { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        [Display(Name = "Address Line 1")]
        public string CouncellorAddressLine1 { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        [Display(Name = "Address Line 2")]
        public string CouncellorAddressLine2 { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        [Display(Name = "Address Line 3")]
        public string CouncellorAddressLine3 { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(10)]
        [Display(Name = "Phone Number")]
        public string CouncellorPhone { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string CouncellorEmail { get; set; }

        [Required]
        [Display(Name = "Rate")]
        public RateType CouncellorRate { get; set; }

        public virtual ICollection<Book> Books { get; set; }

    }
}
