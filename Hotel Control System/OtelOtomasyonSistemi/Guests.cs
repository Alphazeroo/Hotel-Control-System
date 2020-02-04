using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace OtelOtomasyonSistemi
{
    class Guests
    {
        Database database = new Database();
        public string tempUp { get; set; }
        public string tempDel { get; set; }
        public DataTable Table()
        {
            if(database.connection.State == ConnectionState.Open)
            {
                database.connection.Close();
            }
            try
            {
                database.connection.Open();
                SqlCommand data = new SqlCommand("select * from Customers", database.connection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(data);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch { return null; }
            finally
            {
                database.connection.Close();
            }
        } 
        public void GuestUd(int id,string name,string surname,string pn,string price,string rn,DateTime ci,DateTime co)


        {
            if(database.connection.State == ConnectionState.Open)
            {
                database.connection.Close();
            }
            try
            {
                database.connection.Open();
                SqlCommand sqlCommand = new SqlCommand("update Customers set Name=@n,Surname=@sn,Phonenumber=@pn,Price=@price,Roomnumber=@rn,Checkin=@ci,Checkout=@co where ID=@id", database.connection);
                sqlCommand.Parameters.AddWithValue("@n", name);
                sqlCommand.Parameters.AddWithValue("@sn", surname);
                sqlCommand.Parameters.AddWithValue("@pn", pn);
                sqlCommand.Parameters.AddWithValue("@price", price);
                sqlCommand.Parameters.AddWithValue("@rn", rn);
                sqlCommand.Parameters.AddWithValue("@ci", ci);
                sqlCommand.Parameters.AddWithValue("@co", co);
                sqlCommand.Parameters.AddWithValue("@id", id);
                sqlCommand.ExecuteNonQuery();
                tempUp = name + " " + surname + "'s informations are updated";
                

            }
            catch { }
            finally
            {
                database.connection.Close();
            }
        }
        public void GuestDel(int id)
        {
            if(database.connection.State == ConnectionState.Open)
            {
                database.connection.Close();
            }
            try
            {
                database.connection.Open();
                SqlCommand sqlCommand = new SqlCommand("delete Customers where ID=@id", database.connection);
                sqlCommand.Parameters.AddWithValue("@id", id);
                sqlCommand.ExecuteNonQuery();
                tempDel = "Deleted";
            }
            catch { }
            finally
            {
                database.connection.Close();
            }
        }
        public DataTable Search(string name)
        {
            if (database.connection.State == ConnectionState.Open)
            {
                database.connection.Close();
            }
            try
            {
                database.connection.Open();
                SqlCommand sqlCommand = new SqlCommand("select * from Customers where Name LIKE '%' + @name + '%'", database.connection);
                sqlCommand.Parameters.AddWithValue("@name", name);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch { return null; }
            finally
            {
                database.connection.Close();
            }
        }


    }
}
