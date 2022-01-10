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
    public partial class UyeKitapAra : Form
    {
        private OracleConnection con;
        private OracleCommand com;
        private OracleDataReader dr;

        public UyeKitapAra()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuUye menuUye = new MenuUye();
            menuUye.Show();
            this.Hide();
        }

        private void UyeKitapAra_Load(object sender, EventArgs e)
        {
            DbCon dbcon = new DbCon();
            con = dbcon.connection();
            DataTable dataTable = new DataTable();
            OracleDataAdapter oracleDataAdapter = new OracleDataAdapter("SELECT * FROM Kitaplar", con);
            oracleDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            //kolon isimlerini değiştirme
            dataGridView1.Columns[0].HeaderText = "Kitap ID";
            dataGridView1.Columns[1].HeaderText = "Kitap Adı";
            dataGridView1.Columns[2].HeaderText = "Yazarı";
            dataGridView1.Columns[3].HeaderText = "Yayınevi";
            dataGridView1.Columns[4].HeaderText = "Sayfa Sayısı";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbCon dbcon = new DbCon();
            con = dbcon.connection();
            OracleCommand komut = new OracleCommand("SELECT * FROM Kitaplar WHERE KitapAdi LIKE '%" + textBox1.Text + "%' or Yazar like '%" + textBox1.Text + "%' or YayınEvi like '%" + textBox1.Text + "%'", con);
            DataTable dataTable2 = new DataTable();
            OracleDataAdapter dataAdapter = new OracleDataAdapter(komut);
            dataAdapter.Fill(dataTable2);
            dataGridView1.DataSource = dataTable2;
            textBox1.Clear();
        }
    }
}
