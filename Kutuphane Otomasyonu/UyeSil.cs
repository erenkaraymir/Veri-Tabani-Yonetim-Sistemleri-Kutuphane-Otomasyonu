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
    public partial class UyeSil : Form
    {
        private OracleConnection con;
        private OracleCommand com;
        private OracleDataReader dr;

        public UyeSil()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            checkBox1.Visible = true;
            DbCon dbcon = new DbCon();
            con = dbcon.connection();
            com = new OracleCommand();
            com.Connection = con;
            com.CommandText = "SELECT * FROM Uyeler WHERE UyeTc ='" + textBox1.Text + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                textBox2.Text = dr["UyeID"].ToString();
                textBox3.Text = dr[2].ToString();
                textBox4.Text = dr[3].ToString();
                textBox5.Text = dr[4].ToString();
                textBox6.Text = dr[5].ToString();
                textBox7.Text = dr[6].ToString();
            }
            else
            {
                MessageBox.Show("Üye Bulunamadı");
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuAdmin menuadmin = new MenuAdmin();
            menuadmin.Show();
            this.Hide();
        }

        private void UyeSil_Load(object sender, EventArgs e)
        {
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            checkBox1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult uyeSil = MessageBox.Show("Gerçekten Silmek İstiyor musunuz? ", 
            "Silme İşlemi", MessageBoxButtons.YesNo);
            if(uyeSil == DialogResult.Yes)
            {
                DbCon dbcon = new DbCon();
                con = dbcon.connection();
                com = new OracleCommand();
                com.Connection = con;
                com.CommandText = "DELETE FROM Uyeler WHERE UyeID ='" + textBox2.Text + "'";
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Silme Başarılı");
            }
            else
            {
                MessageBox.Show("İşlem İptal Edildi.");
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                textBox7.UseSystemPasswordChar = true;
                checkBox1.Text = "Gizle";
            }
            else if (checkBox1.CheckState == CheckState.Unchecked)
            {
                textBox7.UseSystemPasswordChar = false;
                checkBox1.Text = "Göster";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
