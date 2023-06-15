using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataString
    {
        public const string DATA_CON_STRING = "Server = mssqlstud.fhict.local; Database=dbi519852;User Id = dbi519852; Password=Carry010;TrustServerCertificate=True";
        public static readonly SqlConnection connection = new SqlConnection(DATA_CON_STRING);
    }
}
