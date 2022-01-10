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
    public partial class UyeKitapBagis : Form
    {
        private OracleConnection con;
        private OracleCommand com;
        private OracleDataReader dr;
        int yazarId;
        int yayineviId;
        public UyeKitapBagis()
        {
            InitializeComponent();
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
            com.CommandText = "Select YazarId From Yazar where YazarAdi = '" + textBox2.Text + "'";
            dr = com.ExecuteReader();
            Console.WriteLine(dr.GetType());

            while (dr.Read())
            {
                yazarId = Convert.ToInt32(dr["YazarId"].ToString());
            }

            com.CommandText = null;
            dr = null;

            com.CommandText = "Select YAYINEVIID From YAYINEVI where YAYINEVIADI = '" + textBox4.Text + "'";
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                yayineviId = Convert.ToInt32(dr["YAYINEVIID"].ToString());
            }
            try
            {
                com.CommandText = "INSERT INTO Kitaplar (KitapAdi, YazarId, YayıneviId, SayfaNumarası) " +
                              "VALUES ('" + textBox1.Text + "'," + yazarId + "," + yayineviId + ","
                              + Convert.ToDecimal(textBox3.Text) + ")";
                com.ExecuteNonQuery();
                MessageBox.Show("Kayıt Başarılı");
            }
            catch
            {
                MessageBox.Show("Hata");
            }
          
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
