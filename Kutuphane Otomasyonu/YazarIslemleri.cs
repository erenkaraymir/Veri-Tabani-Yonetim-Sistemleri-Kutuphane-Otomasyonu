using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane_Otomasyonu
{
    public partial class YazarIslemleri : Form
    {
        private OracleConnection con;
        private OracleCommand com;
        DataTable dataTable;
        OracleDataReader dr;
        public YazarIslemleri()
        {
            InitializeComponent();
         
        }

        private void YazarIslemleri_Load(object sender, EventArgs e)
        {
            DbCon dbcon = new DbCon();
            con = dbcon.connection();
            com = new OracleCommand();
            com.Connection = con;

            TabloyuGetir();

            dataGridView1.Columns[0].HeaderText = "Yazar ID";
            dataGridView1.Columns[1].HeaderText = "Yazar Adı";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //yazar ekle
            com.CommandText = "Insert Into Yazar(YazarAdi)" + "Values ('" + textBox1.Text + "')";
            com.ExecuteNonQuery();
            MessageBox.Show("Yazar Eklendi");
            textBox1.Clear();
            TabloyuGetir();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                com.CommandText = "Delete From Yazar Where yazarId = '" + textBox2.Text + "'";
                dr = com.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Böyle bir yazar bulunamadı");
                }
                else
                {
                    MessageBox.Show("Yazar silindi");
                }
                textBox2.Clear();
                TabloyuGetir();
            }
            catch
            {
                MessageBox.Show("Böyle yazar bulunamadı");
            }
            
        }

        private void TabloyuGetir()
        {
            dataTable = new DataTable();
            OracleDataAdapter oracleDataAdapter = new OracleDataAdapter("Select * From Yazar", con);
            oracleDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MenuAdmin menuAdmin = new MenuAdmin();
            menuAdmin.Show();
            this.Hide();
        }
    }
}
