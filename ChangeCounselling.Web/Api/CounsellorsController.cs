using ChangeCounselling.Data.Models;
using ChangeCounselling.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChangeCounselling.Web.Api
{
    public class CounsellorsController : ApiController
    {
        private readonly ICounsellorData db;

        public CounsellorsController(ICounsellorData db)
        {
            this.db = db;
        }

        public IEnumerable<Counsellor> Get()
        {
            var result = db.GetAll().ToList();


            List<Counsellor> counsellors = new List<Counsellor>();
            foreach (var item in result)
            {
                counsellors.Add(new Counsellor
                {
                    CounsellorID = item.CounsellorID,
                    CouncellorFirstName = item.CouncellorFirstName,
                    CouncellorLastName = item.CouncellorLastName,
                    CouncellorAddressLine1 = item.CouncellorAddressLine1,
                    CouncellorAddressLine2 = item.CouncellorAddressLine2,
                    CouncellorAddressLine3 = item.CouncellorAddressLine3,
                    CouncellorEmail = item.CouncellorEmail,
                    CouncellorPhone = item.CouncellorPhone,
                    CouncellorRate = item.CouncellorRate

                });
            }

            return counsellors;
        }
    }
}
