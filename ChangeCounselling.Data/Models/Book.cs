using ChangeCounselling.Data.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ChangeCounselling.Data.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }
       // public IEnumerable<SelectListItem> BookList { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [CustomDateValidation(ErrorMessage = "Date not Valid")]
                
        public DateTime DateTime { get; set; }


        [Required]
        public int ClientID { get; set; }

        [Required]
        public int CounsellorID { get; set; }

        public virtual Client Client { get; set; }
        
        public virtual Counsellor Counsellor { get; set; }

        public virtual ICollection <Bill> Bills { get; set; }
    }
}
