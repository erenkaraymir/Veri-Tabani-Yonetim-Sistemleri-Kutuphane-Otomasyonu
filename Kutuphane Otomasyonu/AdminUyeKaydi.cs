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
    public partial class AdminUyeKaydi : Form
    {
        private OracleConnection con;
        private OracleCommand com;

        public AdminUyeKaydi()
        {
            InitializeComponent();
            DbCon dbcon = new DbCon();
            con = dbcon.connection();
            com = new OracleCommand();
            com.Connection = con;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textCinsiyet.Text = "Erkek";
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            textCinsiyet.Text = "Kadın";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                com.CommandText = "INSERT INTO Uyeler (UyeTc, UyeAd, UyeSoyad, UyeCinsiyet, UyeTel, UyeSifre) " +
                                "VALUES ('" + Convert.ToDecimal(textBox1.Text) + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textCinsiyet.Text + "','"
                                + Convert.ToDecimal(textBox4.Text) + "','" + textBox5.Text + "')";
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Kayıt Gerçekleştirildi");
            }
            catch
            {
                MessageBox.Show("Hata");
            }
            
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            checkBox1.Checked = false;
            checkBox2.Checked = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuAdmin menuAdmin = new MenuAdmin();
            menuAdmin.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
           // e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.CheckState == CheckState.Checked)
            {
                textBox5.UseSystemPasswordChar = true;
                checkBox3.Text = "Gizle";
            }
            else if (checkBox3.CheckState == CheckState.Unchecked)
            {
                textBox5.UseSystemPasswordChar = false;
                checkBox3.Text = "Göster";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
