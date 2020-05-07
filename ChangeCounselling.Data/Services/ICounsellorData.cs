using ChangeCounselling.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeCounselling.Data.Services
{
    public interface ICounsellorData
    {
        IEnumerable<Counsellor> GetAll();

        Counsellor Get(int id);
        void Add(Counsellor counsellor);
        void Update(Counsellor counsellor);
        void Delete(int id);
    }

    
}
