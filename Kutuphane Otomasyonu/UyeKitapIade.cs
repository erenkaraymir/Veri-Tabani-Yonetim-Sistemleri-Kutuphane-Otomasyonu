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
    public partial class UyeKitapIade : Form
    {
        private OracleConnection con;
        private OracleCommand com;
        private OracleDataReader dr;
        int uyeId;
        public UyeKitapIade()
        {
            InitializeComponent();
        }

        private void UyeKitapIade_Load(object sender, EventArgs e)
        {
           

            DbCon dbcon = new DbCon();
            con = dbcon.connection();
            UyeCagir();
            TabloCagir();
            //kolon isimlerini değiştirme
            dataGridView1.Columns[0].HeaderText = "ISLEM ID";
            dataGridView1.Columns[1].HeaderText = "UYE TC";
            dataGridView1.Columns[2].HeaderText = "Kitap Adı";
            dataGridView1.Columns[3].HeaderText = "Ödünç Tarihi";
            dataGridView1.Columns[4].HeaderText = "İade Tarihi";

        }

        private void TabloCagir()
        {
            DataTable dataTable = new DataTable();
            OracleDataAdapter oracleDataAdapter = new OracleDataAdapter("SELECT o.ISLEMID,u.UyeTc,k.KitapAdi,o.OduncTarihi,o.IadeTarihi FROM ODUNCALMA o,Uyeler u,Kitaplar k where u.uyeId = o.uyeId and  k.kitapId = o.kitapId and o.uyeId = " + uyeId + "", con);
            oracleDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            con.Close();
        }
        private void UyeCagir()
        {
            com = new OracleCommand();
            com.Connection = con;
            com.CommandText = "SELECT * FROM Uyeler WHERE UyeTc ='" + UyeLogin.metin + "'";

            dr = com.ExecuteReader();

            if (dr.Read())
            {
                uyeId = Convert.ToInt32(dr[0].ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DbCon dbcon = new DbCon();
            con = dbcon.connection();
            OracleCommand komut = new OracleCommand("SELECT * FROM KitapIslemleri WHERE KitapAdi LIKE '%" + textBox8.Text + "%'", con);
            DataTable dataTable2 = new DataTable();
            OracleDataAdapter dataAdapter = new OracleDataAdapter(komut);
            dataAdapter.Fill(dataTable2);
            dataGridView1.DataSource = dataTable2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuUye menuUye = new MenuUye();
            menuUye.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbCon dbcon = new DbCon();
            con = dbcon.connection();
            com = new OracleCommand();
            com.Connection = con;

            int secilenIslemId = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
            try
            {
                com.CommandText = "DELETE FROM Oduncalma WHERE IslemID ='" + secilenIslemId + "'";
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("İade İşlemi Başarılı TEŞEKKÜR EDERİZ");
            }
            catch
            {
                MessageBox.Show("İade İşlemi Başarısız");
            }
            TabloCagir();
            con.Close();
            textBox8.Clear();
        }
    }
}
