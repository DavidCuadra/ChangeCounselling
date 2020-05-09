using ChangeCounselling.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeCounselling.Data.Services
{
   public interface ILoginData
    {
        IEnumerable<Login> GetAll();

        Login Get(int id);
        void Add(Login item);
        void Update(Login item);
        void Delete(int id);
        bool Auth(Login login);

    }
}

