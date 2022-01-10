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
    public partial class OduncTablosuAdmin : Form
    {
        private OracleConnection con;
        private OracleCommand com;
        private OracleDataReader dr;

        public OduncTablosuAdmin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuAdmin menuAdmin = new MenuAdmin();
            menuAdmin.Show();
            this.Hide();
        }

        private void GeriVer_Load(object sender, EventArgs e)
        {
            DbCon dbcon = new DbCon();
            con = dbcon.connection();
            DataTable dataTable = new DataTable();
            OracleDataAdapter oracleDataAdapter = new OracleDataAdapter("SELECT o.ISLEMID,u.UyeTc,k.KitapAdi,o.OduncTarihi,o.IadeTarihi FROM ODUNCALMA o,Uyeler u,Kitaplar k where u.uyeId = o.uyeId and  k.kitapId = o.kitapId", con);
            oracleDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            //kolon isimlerini değiştirme
            dataGridView1.Columns[0].HeaderText = "ISLEM ID";
            dataGridView1.Columns[1].HeaderText = "UYE TC";
            dataGridView1.Columns[2].HeaderText = "Kitap Adı";
            dataGridView1.Columns[3].HeaderText = "Ödünç Tarihi";
            dataGridView1.Columns[4].HeaderText = "İade Tarihi";
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            OracleCommand komut = new OracleCommand("SELECT * FROM KitapIslemleri WHERE KitapID LIKE '%" + textBox8.Text + "%'", con);
            DataTable dataTable2 = new DataTable();
            OracleDataAdapter dataAdapter = new OracleDataAdapter(komut);
            dataAdapter.Fill(dataTable2);
            dataGridView1.DataSource = dataTable2;
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
