using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SqlTableGenerator
{
    public class DbController : IDbController
    {
        private String dbName;
        public String DbName
        {
            get
            {
                return dbName ?? "master";
            }
            set
            {
                dbName = value;
            }
        }

        public String GetConnectionString()
        {
            return $"Server = PC45912\\SQLEXPRESS; Integrated security = SSPI; database = {DbName}";
        }

        public void CreateDb(Database db)
        {
            var conn = new SqlConnection(GetConnectionString());
            var command = new SqlCommand(db.GetCreateDDL(), conn);

            try
            {
                conn.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("kreirana baza");
                DbName = db.Name;
            }
            catch (Exception ex)
            {
                throw ;
            }
            finally
            {
                if ((conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
        }

        public void CreateTable(Table table)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(table.GetCreateDDL(), con))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
