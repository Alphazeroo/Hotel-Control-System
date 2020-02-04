using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OtelOtomasyonSistemi
{
    public partial class RegistryPage : Form
    {
        public RegistryPage()
        {
            InitializeComponent();
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                    {
                        m.Result = (IntPtr)0x2;
                    }
                    return;
            }
            base.WndProc(ref m);
        }
        private void Exit_Click(object sender, EventArgs e) => this.Hide();

        ArrayList rooms = new ArrayList();
        ArrayList ArrayList = new ArrayList();
        void Room()
        {
            string room = "";
            for(int i = 0; i < rooms.Count; i++)
            {
                room += rooms[i].ToString() + ",";
            }
            if(rooms.Count >= 1)
            {
                room = room.Remove(room.Length - 1, 1);
            }
            txtRooms.Text = room;
            
        }
        void Room2()
        {
            string room = "";
            for (int i = 0; i < ArrayList.Count; i++)
            {
                room += ArrayList[i].ToString() + ",";
            }
            if (ArrayList.Count >= 1)
            {
                room = room.Remove(room.Length - 1, 1);
            }
            txtDel.Text = room;

        }
        private void btnRooms(object sender, EventArgs e)
        {
            if(((Button)sender).BackColor == Color.Green)
            {
                ((Button)sender).BackColor = Color.Orange;
                if (!rooms.Contains(((Button)sender).Text))
                {
                    rooms.Add(((Button)sender).Text);
                }
                else if (rooms.Contains(((Button)sender).Text))
                {
                    rooms.Remove(((Button)sender).Text);
                }
                Room();
            }            
            else if (((Button)sender).BackColor == Color.Red)
            {
                ((Button)sender).BackColor = Color.Pink;
                if (!ArrayList.Contains(((Button)sender).Text))
                {
                    ArrayList.Add(((Button)sender).Text);
                }
                else if (ArrayList.Contains(((Button)sender).Text))
                {
                    ArrayList.Remove(((Button)sender).Text);
                }
                Room2();
                
            }
            


        }
        public DateTime Check_in { get; set; }
        public DateTime Check_out { get; set; }
        private void book_Click(object sender, EventArgs e)
        {
            Check_in = Convert.ToDateTime(dateTimePicker1.Value);
            Check_out = Convert.ToDateTime(dateTimePicker2.Value);
            Registry registry = new Registry();
            for (int i = 0; i < rooms.Count; i++)
            {
                string roomnumbers = rooms[i].ToString();
                registry.Register(txtName.Text, txtSurname.Text,txtPhonenumber.Text,txtPrice.Text,roomnumbers,Check_in,Check_out);

            }
            timer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Registry registry = new Registry();
            for (int i = 0; i < ArrayList.Count; i++)
            {
                string roomnumber = ArrayList[i].ToString();
                registry.roomDel(roomnumber);

            }
            timer1.Start();

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Database database = new Database();
            if(database.connection.State == ConnectionState.Open)
            {
                database.connection.Close();
            }            
            try
            {
                database.connection.Open();
                SqlCommand convert = new SqlCommand("select * from Rooms where Condition=@Condition", database.connection);
                convert.Parameters.AddWithValue("@Condition", "Dolu");
                SqlDataReader readConvert = convert.ExecuteReader();
                while (readConvert.Read())
                {
                    string roombutton = readConvert["Roombutton"].ToString();
                    string condition = readConvert["Condition"].ToString();
                    if(roombutton == "R1" && condition == "Dolu")
                    {
                        R1.BackColor = Color.Red;
                    } else if (roombutton == "R2" && condition == "Dolu")
                    {
                        R2.BackColor = Color.Red;
                    }
                    else if (roombutton == "R3" && condition == "Dolu")
                    {
                        R3.BackColor = Color.Red;
                    }
                    else if (roombutton == "R4" && condition == "Dolu")
                    {
                        R4.BackColor = Color.Red;
                    }
                    else if (roombutton == "R5" && condition == "Dolu")
                    {
                        R5.BackColor = Color.Red;
                    }
                    else if (roombutton == "R6" && condition == "Dolu")
                    {
                        R6.BackColor = Color.Red;
                    }
                    else if (roombutton == "R7" && condition == "Dolu")
                    {
                        R7.BackColor = Color.Red;
                    }
                    else if (roombutton == "R8" && condition == "Dolu")
                    {
                        R8.BackColor = Color.Red;
                    }
                    else if (roombutton == "R9" && condition == "Dolu")
                    {
                        R9.BackColor = Color.Red;
                    }
                    else if (roombutton == "R10" && condition == "Dolu")
                    {
                        R10.BackColor = Color.Red;
                    }
                    else if (roombutton == "R11" && condition == "Dolu")
                    {
                        R11.BackColor = Color.Red;
                    }
                    else if (roombutton == "R12" && condition == "Dolu")
                    {
                        R12.BackColor = Color.Red;
                    }
                    else if (roombutton == "R13" && condition == "Dolu")
                    {
                        R13.BackColor = Color.Red;
                    }
                    else if (roombutton == "R14" && condition == "Dolu")
                    {
                        R14.BackColor = Color.Red;
                    }
                    else if (roombutton == "R15" && condition == "Dolu")
                    {
                        R15.BackColor = Color.Red;
                    }
                    else if (roombutton == "R16" && condition == "Dolu")
                    {
                        R16.BackColor = Color.Red;
                    }
                    else if (roombutton == "R17" && condition == "Dolu")
                    {
                        R17.BackColor = Color.Red;
                    }
                    else if (roombutton == "R18" && condition == "Dolu")
                    {
                        R18.BackColor = Color.Red;
                    }
                    else if (roombutton == "R19" && condition == "Dolu")
                    {
                        R19.BackColor = Color.Red;
                    }
                    else if (roombutton == "R20" && condition == "Dolu")
                    {
                        R20.BackColor = Color.Red;
                    }
                    else if (roombutton == "R21" && condition == "Dolu")
                    {
                        R21.BackColor = Color.Red;
                    }
                    else if (roombutton == "R22" && condition == "Dolu")
                    {
                        R22.BackColor = Color.Red;
                    }
                    else if (roombutton == "R23" && condition == "Dolu")
                    {
                        R23.BackColor = Color.Red;
                    }
                    else if (roombutton == "R24" && condition == "Dolu")
                    {
                        R24.BackColor = Color.Red;
                    }
                    else if (roombutton == "R25" && condition == "Dolu")
                    {
                        R25.BackColor = Color.Red;
                    }
                }
                convert.Dispose();
                readConvert.Close();
                database.connection.Close();
            }
            catch { }
            finally
            {
                database.connection.Close();
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Database database = new Database();
            if (database.connection.State == ConnectionState.Open)
            {
                database.connection.Close();
            }
            try
            {
                database.connection.Open();
                SqlCommand convert = new SqlCommand("select * from Rooms where Condition=@Condition", database.connection);
                convert.Parameters.AddWithValue("@Condition", "Boş");
                SqlDataReader readConvert = convert.ExecuteReader();
                while (readConvert.Read())
                {
                    string roombutton = readConvert["Roombutton"].ToString();
                    string condition = readConvert["Condition"].ToString();
                    if (roombutton == "R1" && condition == "Boş")
                    {
                        R1.BackColor = Color.Green;
                    }
                    else if (roombutton == "R2" && condition == "Boş")
                    {
                        R2.BackColor = Color.Green;
                    }
                    else if (roombutton == "R3" && condition == "Boş")
                    {
                        R3.BackColor = Color.Green;
                    }
                    else if (roombutton == "R4" && condition == "Boş")
                    {
                        R4.BackColor = Color.Green;
                    }
                    else if (roombutton == "R5" && condition == "Boş")
                    {
                        R5.BackColor = Color.Green;
                    }
                    else if (roombutton == "R6" && condition == "Boş")
                    {
                        R6.BackColor = Color.Green;
                    }
                    else if (roombutton == "R7" && condition == "Boş")
                    {
                        R7.BackColor = Color.Green;
                    }
                    else if (roombutton == "R8" && condition == "Boş")
                    {
                        R8.BackColor = Color.Green;
                    }
                    else if (roombutton == "R9" && condition == "Boş")
                    {
                        R9.BackColor = Color.Green;
                    }
                    else if (roombutton == "R10" && condition == "Boş")
                    {
                        R10.BackColor = Color.Green;
                    }
                    else if (roombutton == "R11" && condition == "Boş")
                    {
                        R11.BackColor = Color.Green;
                    }
                    else if (roombutton == "R12" && condition == "Boş")
                    {
                        R12.BackColor = Color.Green;
                    }
                    else if (roombutton == "R13" && condition == "Boş")
                    {
                        R13.BackColor = Color.Green;
                    }
                    else if (roombutton == "R14" && condition == "Boş")
                    {
                        R14.BackColor = Color.Green;
                    }
                    else if (roombutton == "R15" && condition == "Boş")
                    {
                        R15.BackColor = Color.Green;
                    }
                    else if (roombutton == "R16" && condition == "Boş")
                    {
                        R16.BackColor = Color.Green;
                    }
                    else if (roombutton == "R17" && condition == "Boş")
                    {
                        R17.BackColor = Color.Green;
                    }
                    else if (roombutton == "R18" && condition == "Boş")
                    {
                        R18.BackColor = Color.Green;
                    }
                    else if (roombutton == "R19" && condition == "Boş")
                    {
                        R19.BackColor = Color.Green;
                    }
                    else if (roombutton == "R20" && condition == "Boş")
                    {
                        R20.BackColor = Color.Green;
                    }
                    else if (roombutton == "R21" && condition == "Boş")
                    {
                        R21.BackColor = Color.Green;
                    }
                    else if (roombutton == "R22" && condition == "Boş")
                    {
                        R22.BackColor = Color.Green;
                    }
                    else if (roombutton == "R23" && condition == "Boş")
                    {
                        R23.BackColor = Color.Green;
                    }
                    else if (roombutton == "R24" && condition == "Boş")
                    {
                        R24.BackColor = Color.Green;
                    }
                    else if (roombutton == "R25" && condition == "Boş")
                    {
                        R25.BackColor = Color.Green;
                    }
                }
                convert.Dispose();
                readConvert.Close();
                database.connection.Close();
            }
            catch { }
            finally
            {
                database.connection.Close();
            }

        }

        private void RegistryPage_Load(object sender, EventArgs e)
        {
            timer.Start();
            timer1.Start();
        }

        
    }
}
