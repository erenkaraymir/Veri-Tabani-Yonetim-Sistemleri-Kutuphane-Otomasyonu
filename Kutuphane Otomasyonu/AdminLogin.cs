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
    public partial class AdminLogin : Form
    {
        private OracleConnection con;
        private OracleCommand com;
        private OracleDataReader dr;

        public AdminLogin()
        {
            InitializeComponent();
            DbCon dbcon = new DbCon();
            con = dbcon.connection();
            com = new OracleCommand();
            com.Connection = con;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            com.CommandText = "SELECT * FROM ADMIN where ADMINTC ='"+ textBox1.Text + "' AND SIFRE='"+ textBox2.Text + "'";
            dr = com.ExecuteReader();

            if (dr.Read())
            {
                MenuAdmin menu = new MenuAdmin();
                menu.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Kullanıcı Adı ve ya Şifre Hatalı");
            }
            con.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            AnaSayfa anaSayfa = new AnaSayfa();
            anaSayfa.Show();
            this.Hide();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {  
                if (checkBox1.CheckState == CheckState.Checked)
                {
                    textBox2.UseSystemPasswordChar = true;
                    checkBox1.Text = "Gizle";
                }
                else if (checkBox1.CheckState == CheckState.Unchecked)
                {
                    textBox2.UseSystemPasswordChar = false;
                    checkBox1.Text = "Göster";
                }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
