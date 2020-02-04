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

namespace OtelOtomasyonSistemi
{
    public partial class RoomPage : Form
    {
        public RoomPage()
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

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        ArrayList room = new ArrayList();

        private void RoomPage_Load(object sender, EventArgs e)
        {
            
            string roomnumber = "";
            string value = "";

            for(int i = 1; i < this.Controls.Count; i++)
            {
                
                roomnumber = Convert.ToString(this.Controls.Find("R" + i.ToString(), true).FirstOrDefault() as Button);
                value = roomnumber.Split(':').Last().Trim();
                room.Add(value);               
            }

            roomCondition();     

        }

        void roomCondition()
        {
            string holdroom = "";
            Rooms rooms = new Rooms();
            try
            {
                foreach(string roomnumber in room)
                {
                    
                    rooms.roomVal(roomnumber, "Dolu");
                    if(rooms.Condition == "Dolu")
                    {
                        holdroom = roomnumber;
                        this.Controls.Find(rooms.Roombutton, true)[0].BackColor = Color.Red;
                        this.Controls.Find(rooms.Roombutton, true)[0].Text = holdroom + "\n" + rooms.Guest;
                        rooms.Condition = "";
                    }
                    if (rooms.Condition == "Boş")
                    {
                        this.Controls.Find(rooms.Roombutton, true)[0].BackColor = Color.Green;
                    }


                }
            }
            catch (Exception hata) { System.Windows.Forms.MessageBox.Show("" + hata); }


        }

        
    }
}
