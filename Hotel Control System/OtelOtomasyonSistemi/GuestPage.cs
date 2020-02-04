using System;
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
    public partial class GuestPage : Form
    {
        public GuestPage()
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void InformationsPage_Load(object sender, EventArgs e)
        {
            Guests guests = new Guests();
            dataGridView1.DataSource = guests.Table();
        }
        int id { get; set; }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
            txtName.Text = dataGridView1.Rows[e.RowIndex].Cells["Names"].Value.ToString();
            txtSurname.Text = dataGridView1.Rows[e.RowIndex].Cells["Surname"].Value.ToString();
            txtPhonenumber.Text = dataGridView1.Rows[e.RowIndex].Cells["Phonenumber"].Value.ToString();
            txtPrice.Text = dataGridView1.Rows[e.RowIndex].Cells["Price"].Value.ToString();
            txtRooms.Text = dataGridView1.Rows[e.RowIndex].Cells["Roomnumber"].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["Checkin"].Value);
            dateTimePicker2.Value = Convert.ToDateTime( dataGridView1.Rows[e.RowIndex].Cells["Checkout"].Value);
        }

        private void query_Click(object sender, EventArgs e)
        {
            Guests guests = new Guests();
            dataGridView1.DataSource = guests.Table();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtSurname.Text = "";
            txtPhonenumber.Text = "";
            txtPrice.Text = "";
            txtRooms.Text = "";
            dateTimePicker1.Value = Convert.ToDateTime(DateTime.Now.ToLongDateString());
            dateTimePicker2.Value = Convert.ToDateTime(DateTime.Now.ToLongDateString());
        }
        public DateTime Check_in { get; set; }
        public DateTime Check_out { get; set; }
        private void update_Click(object sender, EventArgs e)
        {
            Check_in = Convert.ToDateTime(dateTimePicker1.Value);
            Check_out = Convert.ToDateTime(dateTimePicker2.Value);
            Guests guests = new Guests();
            guests.GuestUd(id, txtName.Text, txtSurname.Text, txtPhonenumber.Text, txtPrice.Text, txtRooms.Text, Check_in, Check_out);
            dataGridView1.DataSource = guests.Table();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            Guests guests = new Guests();
            guests.GuestDel(id);
            dataGridView1.DataSource = guests.Table();
        }

        private void search_Click(object sender, EventArgs e)
        {
            Guests guests = new Guests();
            dataGridView1.DataSource = guests.Search(textBox1.Text);
        }
    }
}
