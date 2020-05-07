using ChangeCounselling.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChangeCounselling.Data.Services
{
    public class InMemoryCounsellorData : ICounsellorData
    {
        List<Counsellor> counsellors;

        public InMemoryCounsellorData()
        {
            //counsellors = new List<Counsellor>()
            //    {
            //        new Counsellor {CounsellorID = 1, CouncellorFirstName = "David", CouncellorLastName = "Cuadra", CouncellorAddressLine1 = "6 Anner Road", CouncellorAddressLine2 = "Kilmainham", CouncellorAddressLine3 = "Dublin", CouncellorEmail = "davidcuadra@yahoo.com", CouncellorPhone = "086777234", CouncellorRate = RateType.Plus},
            //        new Counsellor {CounsellorID = 2, CouncellorFirstName = "Catherine", CouncellorLastName = "Mcfadden", CouncellorAddressLine1 = "12 Nice Road", CouncellorAddressLine2 = "Graystones", CouncellorAddressLine3 = "Wiclow", CouncellorEmail = "Catherine@yahoo.com", CouncellorPhone = "677000333", CouncellorRate = RateType.Economy },
            //        new Counsellor {CounsellorID = 3, CouncellorFirstName = "Carol", CouncellorLastName = "Cromer", CouncellorAddressLine1 = "8 Where Road", CouncellorAddressLine2 = "Lixslip", CouncellorAddressLine3 = "Kilder", CouncellorEmail = "Carol@yahoo.com", CouncellorPhone = "55555555", CouncellorRate = RateType.Regular}
            //    };
        }

        public void Add(Counsellor counsellor)
        {
            counsellors.Add(counsellor);
            counsellor.CounsellorID = counsellors.Max(c => c.CounsellorID) + 1;
        }

        public void Update(Counsellor counsellor)
        {
            var existing = Get(counsellor.CounsellorID);
            if(existing != null)
            {
                existing.CounsellorID = counsellor.CounsellorID;
                existing.CouncellorFirstName = counsellor.CouncellorFirstName;
                existing.CouncellorLastName = counsellor.CouncellorLastName;
                existing.CouncellorAddressLine1 = counsellor.CouncellorAddressLine1;
                existing.CouncellorAddressLine2 = counsellor.CouncellorAddressLine2;
                existing.CouncellorAddressLine3 = counsellor.CouncellorAddressLine3;
                existing.CouncellorEmail = counsellor.CouncellorEmail;
                existing.CouncellorPhone = counsellor.CouncellorPhone;
                existing.CouncellorRate = counsellor.CouncellorRate;
              
            }
        }

        public Counsellor Get(int id)
        {
            return counsellors.FirstOrDefault(c => c.CounsellorID == id);
        }

        public IEnumerable<Counsellor> GetAll()
        {
            return counsellors.OrderBy(r => r.CouncellorFirstName);
        }

        public void Delete(int id)
        {
            var counsellor = Get(id);
            if(counsellor != null )
            {
                counsellors.Remove(counsellor);
            }
        }




        
    }
}
