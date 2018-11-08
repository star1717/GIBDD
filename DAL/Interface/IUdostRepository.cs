using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IUdostRepository:IRepository<Udostover>
    {
        string Raw(SqlParameter param);
    }
}
