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
    public partial class KitapEkle : Form
    {
        private OracleConnection con;
        private OracleCommand com;
        private OracleDataReader dr;
        int yazarId;
        int yayineviId;

        bool yayinevi = false;
        bool yazar = false;
        public KitapEkle()
        {
            InitializeComponent();
            DbCon dbcon = new DbCon();
            con = dbcon.connection();
            com = new OracleCommand();
            com.Connection = con;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            com.CommandText = "Select YazarId From Yazar where YazarAdi = '" + textBox2.Text + "'";
            dr = com.ExecuteReader();
            Console.WriteLine(dr.GetType());
           
            while (dr.Read())
            {
               yazarId = Convert.ToInt32(dr["YazarId"].ToString());
                yazar = true;
            }
          
            com.CommandText = null;
            dr = null;

            com.CommandText = "Select YAYINEVIID From YAYINEVI where YAYINEVIADI = '" + textBox4.Text + "'";
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                yayineviId = Convert.ToInt32(dr["YAYINEVIID"].ToString());
                yayinevi = true;
            }
         
                try
                {
                    com.CommandText = "INSERT INTO Kitaplar (KitapAdi, YazarId, YayıneviId, SayfaNumarası) " +
            "VALUES ('" + textBox1.Text + "'," + yazarId + "," + yayineviId + ","
            + Convert.ToDecimal(textBox3.Text) + ")";
                    com.ExecuteNonQuery();
                    MessageBox.Show("Kitap eklendi");
                }
                catch
                {
                    MessageBox.Show("yazar veya yayınevi bulunamadı");
                }
                


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuAdmin menuAdmin = new MenuAdmin();
            menuAdmin.Show();
            this.Hide();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
