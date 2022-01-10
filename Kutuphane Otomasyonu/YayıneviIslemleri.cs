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
    public partial class YayıneviIslemleri : Form
    {
        private OracleConnection con;
        private OracleCommand com;
        DataTable dataTable;
        OracleDataReader dr;
        public YayıneviIslemleri()
        {
            InitializeComponent();
        }
        private void YayıneviIslemleri_Load(object sender, EventArgs e)
        {
            DbCon dbcon = new DbCon();
            con = dbcon.connection();
            com = new OracleCommand();
            com.Connection = con;

            TabloyuGetir();

            dataGridView1.Columns[0].HeaderText = "Yayınevi ID";
            dataGridView1.Columns[1].HeaderText = "Yayınevi Adı";
        }

        private void TabloyuGetir()
        {
            dataTable = new DataTable();
            OracleDataAdapter oracleDataAdapter = new OracleDataAdapter("Select * From Yayınevi", con);
            oracleDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            com.CommandText = "Insert Into Yayınevi(YayıneviAdi)" + "Values ('" + textBox1.Text + "')";
            dr = com.ExecuteReader();
                MessageBox.Show("Yayınevi Eklendi");
            textBox1.Clear();
            TabloyuGetir();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                com.CommandText = "Delete From Yayınevi Where YAYINEVIID = '" + textBox2.Text + "'";
                dr = com.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Böyle yayınevi bulunamadı");
                }
                else
                {
                    MessageBox.Show("Yayınevi silindi");
                }
                textBox2.Clear();
                TabloyuGetir();
            }
            catch
            {
                MessageBox.Show("Hata");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MenuAdmin menuAdmin = new MenuAdmin();
            menuAdmin.Show();
            this.Hide();
        }
    }
}
