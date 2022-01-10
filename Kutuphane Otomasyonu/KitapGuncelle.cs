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
    public partial class KitapGuncelle : Form
    {
        private OracleConnection con;
        private OracleCommand com;
        private OracleDataReader dr;
        int yazarId;
        int yayineviId;

        public KitapGuncelle()
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

        private void KitapGuncelle_Load(object sender, EventArgs e)
        {
            //DbCon dbcon = new DbCon();
            //con = dbcon.connection();
            DataTable dataTable = new DataTable();
            OracleDataAdapter oracleDataAdapter = new OracleDataAdapter("SELECT k.kitapId,k.kitapAdi,yaz.YazarAdi,yay.YAYINEVIADI,k.SayfaNumarası FROM Kitaplar k,YAYINEVI yay,Yazar yaz where k.yazarId = yaz.yazarId and k.YAYINEVIID = yay.YAYINEVIID", con);
            oracleDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            //kolon isimlerini değiştirme
            dataGridView1.Columns[0].HeaderText = "Kitap ID";
            dataGridView1.Columns[1].HeaderText = "Kitap Adı";
            dataGridView1.Columns[2].HeaderText = "Yazar Adı";
            dataGridView1.Columns[3].HeaderText = "Yayınevi Adı";
            dataGridView1.Columns[4].HeaderText = "Sayfa Sayısı";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox5.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
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

            com.CommandText = null;
            try
            {
                com.CommandText = "update Kitaplar set KitapAdi='" + textBox1.Text + "',YazarId=" + yazarId + ",YayıneviId=" + yayineviId + ",SayfaNumarası='"
                                + Convert.ToDecimal(textBox3.Text) + "' where KitapId=" + Convert.ToInt32(textBox5.Text) + "";
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Güncelleme Başarılı");
            }
            catch
            {
                MessageBox.Show("Yazar Veya Yayınevi bulunamadı");
            }
            
            DataTable dataTable = new DataTable();
            OracleDataAdapter oracleDataAdapter = new OracleDataAdapter("SELECT k.kitapId,k.kitapAdi,yaz.YazarAdi,yay.YAYINEVIADI,k.SayfaNumarası FROM Kitaplar k,YAYINEVI yay,Yazar yaz where k.yazarId = yaz.yazarId and k.YAYINEVIID = yay.YAYINEVIID", con);
            oracleDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
