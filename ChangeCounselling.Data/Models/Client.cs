using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ChangeCounselling.Data.Models
{
    public class Client
    {
        [Key]
        [DisplayName("Client ID")]
        public int ClientID { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        [Display(Name = "Client First Name")]
        public string ClientFirstName { get; set; }
        public IEnumerable<SelectListItem> ClientList { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        [Display(Name = "Client Last Name")]
        public string ClientLastName { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        [Display(Name = "Client Address Line 1")]
        public string ClientAddressLine1 { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        [Display(Name = "Client Address Line 2")]
        public string ClientAddressLine2 { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        [Display(Name = "Client Address Line 3")]
        public string ClientAddressLine3 { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(10)]
        [Display(Name = "Client Phone Number")]
        public string ClientPhone { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Client Email")]
        public string ClientEmail { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
