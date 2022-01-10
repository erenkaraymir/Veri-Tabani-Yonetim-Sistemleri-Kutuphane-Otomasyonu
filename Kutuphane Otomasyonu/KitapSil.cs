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
    public partial class KitapSil : Form
    {
        private OracleConnection con;
        private OracleCommand com;
        private OracleDataReader dr;
        public KitapSil()
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

        private void KitapSil_Load(object sender, EventArgs e)
        {
            KitapGetir();
        }

        void KitapGetir()
        {
            DbCon dbcon = new DbCon();
            con = dbcon.connection();
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

        private void button3_Click(object sender, EventArgs e)
        {
            
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult kitapSil = MessageBox.Show("Gerçekten Silmek İstiyor musunuz? ",
            "Silme İşlemi", MessageBoxButtons.YesNo);
            if (kitapSil == DialogResult.Yes)
            {
                com.CommandText = "DELETE FROM Kitaplar WHERE KitapId ='" + textBox1.Text + "'";
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Silme Başarılı");
                KitapGetir();
            }
            else
            {
                MessageBox.Show("İşlem İptal Edildi.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }

