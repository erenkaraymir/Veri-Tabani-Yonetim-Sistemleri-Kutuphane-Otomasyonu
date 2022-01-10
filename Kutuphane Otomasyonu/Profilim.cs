using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;
using Oracle.ManagedDataAccess.Client;

namespace Kutuphane_Otomasyonu
{
    public partial class Profilim : Form
    {
        private OracleConnection con;
        private OracleCommand com;
        private OracleDataReader dr;

        public Profilim()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuUye menuUye = new MenuUye();
            menuUye.Show();
            this.Hide();
        }

        private void Profilim_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            DbCon dbcon = new DbCon();

            con = dbcon.connection();
            com = new OracleCommand();
            com.Connection = con;
            com.CommandText = "SELECT * FROM Uyeler WHERE UyeTc ='" + UyeLogin.metin + "'";

            dr = com.ExecuteReader();
            
            if (dr.Read())
            {
                textBox2.Text = dr[2].ToString();
                textBox1.Text = dr[3].ToString();
                textBox4.Text = dr[5].ToString();
                textBox3.Text = dr[0].ToString();
                textBox5.Text = dr[1].ToString();
               // textBox6.Text = dr[6].ToString();
                label3.Text = dr[2].ToString() + " " + dr[3].ToString();
            } 
            con.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AnaSayfa anaSayfa = new AnaSayfa();
            anaSayfa.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DbCon dbcon = new DbCon();
            con = dbcon.connection();
            com = new OracleCommand();
            com.Connection = con;
            com.CommandText = "UPDATE Uyeler SET UyeTc='" + textBox5.Text + "',UyeAd='" + textBox2.Text + "',UyeSoyad='" + textBox1.Text + "',UyeTel='"
                + textBox4.Text + "',UyeSıfre='" + textBox6.Text + "' where UyeID=" + textBox3.Text + "";
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Değişiklikler Kaydedildi");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }
    }
}
