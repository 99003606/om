using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Using
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conn;
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TSQL;Integrated Security=true";
            using (conn = new SqlConnection(connString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"SELECT productid,productname,unitprice FROM Production.Products";
                conn.Open();
                Console.WriteLine(conn.State);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                        Console.WriteLine("{0}\t{1}", dr[0].ToString(),dr[1].ToString());
                }
            }
            Console.WriteLine(conn.State);
        }
    }
}
  
