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
    public partial class UyeLogin : Form
    {
        private OracleConnection con;
        private OracleCommand com;
        private OracleDataReader dr;

        public UyeLogin()
        {
            InitializeComponent();
        }
        public static string metin;
     
        private void button2_Click(object sender, EventArgs e)
        {
            AnaSayfa anaSayfa = new AnaSayfa();
            anaSayfa.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            metin = textBox1.Text;
            DbCon dbcon = new DbCon();

            con = dbcon.connection();
            com = new OracleCommand();
            com.Connection = con;
            com.CommandText = "SELECT * FROM Uyeler WHERE UyeTc ='" + textBox1.Text + "' AND UyeSifre='" + textBox2.Text + "'";
            dr = com.ExecuteReader();

            if (dr.Read())
            {
                MenuUye menuUye = new MenuUye();
                menuUye.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Kullanıcı Adı ve ya Şifre Hatalı");
            }
            con.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
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

        private void UyeLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
