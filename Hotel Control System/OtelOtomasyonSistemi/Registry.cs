using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OtelOtomasyonSistemi
{
    class Registry
    {
        Database database = new Database();

        private string fullname;
        public string Fullname { get => fullname; set => fullname = value; }

        public static void RoomUpDate(string roomname,string bookname)
        {
            Database database = new Database();
            if (database.connection.State == System.Data.ConnectionState.Open)
            {
                database.connection.Close();
            }
            try
            {
                database.connection.Open(); 
                SqlCommand Change = new SqlCommand("update Rooms set Bookname=@Bookname, Condition=@Condition where Roomname=@Roomname", database.connection);
                Change.Parameters.AddWithValue("@Bookname", bookname);
                Change.Parameters.AddWithValue("@Condition", "Dolu");
                Change.Parameters.AddWithValue("@Roomname", roomname);
                Change.ExecuteNonQuery();
                Change.Dispose();

            }
            catch (Exception hata) { System.Windows.Forms.MessageBox.Show("" + hata); }
            finally
            {
                database.connection.Close();
            }
        }

        public static void RoomUpDate(string roomname)
        {
            string bookname="";
            Database database = new Database();
            if (database.connection.State == System.Data.ConnectionState.Open)
            {
                database.connection.Close();
            }
            try
            {
                database.connection.Open();
                SqlCommand Change = new SqlCommand("update Rooms set Bookname=@Bookname, Condition=@Condition where Roomname=@Roomname", database.connection);
                Change.Parameters.AddWithValue("@Bookname", bookname);
                Change.Parameters.AddWithValue("@Condition", "Boş");
                Change.Parameters.AddWithValue("@Roomname", roomname);
                Change.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Room" + roomname + "Deleted", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                Change.Dispose();

            }
            catch (Exception hata) { System.Windows.Forms.MessageBox.Show("" + hata); }
            finally
            {
                database.connection.Close();
            }
        }
        public void roomDel(string roomnumber)
        {
            RoomUpDate(roomnumber);
        }
        public void Register(string name,string surname,string phonenumber,string price,string roomnumber,DateTime checkin,DateTime checkout)
        {
            if(database.connection.State == System.Data.ConnectionState.Open)
            {
                database.connection.Close();
            }
            try
            {
                database.connection.Open();
                SqlCommand openReg = new SqlCommand("insert into Customers values(@Name,@Surname,@Phonenumber,@Price,@Roomnumber,@Checkin,@Checkout)", database.connection);
                openReg.Parameters.AddWithValue("@Name", name);
                openReg.Parameters.AddWithValue("@Surname", surname);
                openReg.Parameters.AddWithValue("@Phonenumber", phonenumber);
                openReg.Parameters.AddWithValue("@Price", price);
                openReg.Parameters.AddWithValue("@Roomnumber", roomnumber);
                openReg.Parameters.AddWithValue("@Checkin", checkin);
                openReg.Parameters.AddWithValue("@Checkout", checkout);
                openReg.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Customer register created!" + " " + name + " " + surname + " oda numarası: " + roomnumber, "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                openReg.Dispose();

                
            Fullname = name + " " + surname;
            RoomUpDate(roomnumber, Fullname);

            }
            catch (Exception hata) { System.Windows.Forms.MessageBox.Show("" + hata); }
            finally
            {
                database.connection.Close();
            }
        }
      
        
    }
}
