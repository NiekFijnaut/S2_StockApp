using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL
{
    public class DeleteDAL
    {
        SqlConnection Sqlcon = DataString.connection;

        public void DeleteStock(AccountDAL accountDAL)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Stock WHERE Id = @StockID", Sqlcon);

            command.Parameters.AddWithValue("@StockID", StockID);

            Sqlcon.Open();

            command.ExecuteNonQuery();

            Sqlcon.Close();
        }
    }
}
