using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeCounselling.Data.CustomValidation
{
    public class CustomDateValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime = Convert.ToDateTime(value);

            var result = DateTime.Compare(DateTime.Now, dateTime);

            if (result < 0 || result == 0)
            {
                return true;
            }
            return false;
            
            
        }
    }

}
