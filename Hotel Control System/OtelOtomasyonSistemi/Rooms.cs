using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OtelOtomasyonSistemi
{
    class Rooms
    {
        public string Guest { get; set; }
        public string Condition { get; set; }
        public string Roombutton { get; set; }

        Database database = new Database();
        public void roomVal(string roomnumber,string condition)
        {
            if(database.connection.State == System.Data.ConnectionState.Open)
            {
                database.connection.Close();
            }
            try
            {
                database.connection.Open();
                SqlCommand HoldRoom = new SqlCommand("select * from Rooms where Roomname = @Roomname AND Condition = @Condition", database.connection);
                HoldRoom.Parameters.AddWithValue("@Roomname",roomnumber);
                HoldRoom.Parameters.AddWithValue("@Condition",condition);
                SqlDataReader sqlDataReader = HoldRoom.ExecuteReader();
                
                if (sqlDataReader.Read())
                {
                    Guest = sqlDataReader["Bookname"].ToString();
                    Condition = sqlDataReader["Condition"].ToString();
                    Roombutton = sqlDataReader["Roombutton"].ToString();
                    
                }
                HoldRoom.Dispose();
                sqlDataReader.Close();
            }
            catch (Exception hata) { System.Windows.Forms.MessageBox.Show("" + hata); }
            finally
            {
                database.connection.Close();
            }
        }
    }
}
