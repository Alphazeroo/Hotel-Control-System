using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OtelOtomasyonSistemi
{
    class Login
    {
        Database database = new Database();
        private string holdUn;
        private string holdPw;
        private string loginSt;

        public string HoldUn { get => holdUn; set => holdUn = value; }
        public string HoldPw { get => holdPw; set => holdPw = value; }
        public string LoginSt { get => loginSt; set => loginSt = value; }

        public void EnterSys(string username, string password, DateTime dateTime)
        {
            if(database.connection.State == System.Data.ConnectionState.Open)
            {
                database.connection.Close();
            }
            try
            {
                database.connection.Open();
                SqlCommand loginUn = new SqlCommand("select Username from Userinformations where Username=@un", database.connection);
                loginUn.Parameters.AddWithValue("@un", username);
                SqlDataReader readUsername = loginUn.ExecuteReader();
                SqlCommand loginPw = new SqlCommand("select Password from Userinformations where Password = @pw", database.connection);
                loginPw.Parameters.AddWithValue("@pw", password);
                SqlDataReader readPassword = loginPw.ExecuteReader();
                if (!readUsername.Read() || !readPassword.Read())
                {
                    MessageBox.Show("Wrong Username or Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    HoldUn = readUsername["Username"].ToString();        
                    HoldPw = readPassword["Password"].ToString();
                    LoginSt = HoldUn + " " + HoldPw;
                    SqlCommand dateUpdate = new SqlCommand("update Userinformations set Checkin=@dt where Username=@un AND Password=@pw", database.connection);
                    dateUpdate.Parameters.AddWithValue("@dt", dateTime);
                    dateUpdate.Parameters.AddWithValue("@un", HoldUn);
                    dateUpdate.Parameters.AddWithValue("@pw", HoldPw);
                    dateUpdate.ExecuteNonQuery();
                    dateUpdate.Dispose();
                }
                loginPw.Dispose();
                loginUn.Dispose();
                readUsername.Close();
                readPassword.Close();
                database.connection.Close();
            }
            catch { }
            finally
            {
                database.connection.Close();
            }
            
        }
    }
}
