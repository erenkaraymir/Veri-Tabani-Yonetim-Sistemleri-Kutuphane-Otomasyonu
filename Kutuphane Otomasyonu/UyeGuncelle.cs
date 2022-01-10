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
    public partial class UyeGuncelle : Form
    {
        private OracleConnection con;
        private OracleCommand com;

        public UyeGuncelle()
        {
            InitializeComponent();
            DbCon dbcon = new DbCon();
            con = dbcon.connection();
            com = new OracleCommand();
            com.Connection = con;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuAdmin menuAdmin = new MenuAdmin();
            menuAdmin.Show();
            this.Hide();
        }

        private void UyeGuncelle_Load(object sender, EventArgs e)
        {
            DbCon dbcon = new DbCon();
            con = dbcon.connection();
            DataTable dataTable = new DataTable();
            OracleDataAdapter oracleDataAdapter = new OracleDataAdapter("SELECT * FROM Uyeler", con);
            oracleDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns[6].Visible = false;
            //kolon isimlerini değiştirme
            dataGridView1.Columns[0].HeaderText = "Üye ID";
            dataGridView1.Columns[1].HeaderText = "TC Kimlik No";
            dataGridView1.Columns[2].HeaderText = "Adı";
            dataGridView1.Columns[3].HeaderText = "Soyadı";
            dataGridView1.Columns[4].HeaderText = "Cinsiyet";
            dataGridView1.Columns[5].HeaderText = "Telefon No";
            dataGridView1.Columns[6].HeaderText = "Şifre";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox6.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                com.CommandText = "UPDATE Uyeler set UyeTc='" + textBox1.Text + "',UyeAd='" + textBox2.Text + "',UyeSoyad='" + textBox3.Text + "',UyeTel='"
                                + textBox4.Text + "',UyeSıfre='" + textBox5.Text + "' where UyeID=" + textBox6.Text + "";
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Güncelleme Başarılı");
            }
            catch
            {
                MessageBox.Show("Hata");
            }
            DataTable dataTable = new DataTable();
            OracleDataAdapter oracleDataAdapter = new OracleDataAdapter("SELECT * FROM Uyeler", con);
            oracleDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                textBox5.UseSystemPasswordChar = true;
                checkBox1.Text = "Gizle";
            }
            else if (checkBox1.CheckState == CheckState.Unchecked)
            {
                textBox5.UseSystemPasswordChar = false;
                checkBox1.Text = "Göster";
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
