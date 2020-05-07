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
            var model = db.GetAll();
            return model;
        }
    }
}
