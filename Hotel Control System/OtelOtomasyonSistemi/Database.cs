using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OtelOtomasyonSistemi
{
    public class Database
    {
        public static string Adress = System.IO.File.ReadAllText(@"C:\Test.txt");
        public SqlConnection connection = new SqlConnection(@Adress);


    }
}
