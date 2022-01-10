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
    public partial class UyeOdunc : Form
    {
        private OracleConnection con;
        private OracleConnection con2;

        private OracleCommand com;
        private OracleDataReader dr;
        private OracleDataReader drk;


        int secilenKitapId;

        public UyeOdunc()
        {
            InitializeComponent();
        }

        private void UyeOdunc_Load(object sender, EventArgs e)
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

         

            UyeCagir();
            if (dr.Read())
            {
                textBox2.Text = dr[0].ToString();
                textBox1.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();
                textBox4.Text = dr[3].ToString();
                textBox5.Text = dr[4].ToString();
                textBox6.Text = dr[5].ToString();
            }
            con.Close();
        }

        private void UyeCagir()
        {
            com = new OracleCommand();
            com.Connection = con;
            com.CommandText = "SELECT * FROM Uyeler WHERE UyeTc ='" + UyeLogin.metin + "'";

            dr = com.ExecuteReader();
        }
        private void KitapKontrol()
        {
            com = new OracleCommand();
            com.Connection = con;
            com.CommandText = "SELECT * FROM OduncAlma WHERE KitapId ='" + secilenKitapId + "'";

            drk = com.ExecuteReader();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuUye menuUye = new MenuUye();
            menuUye.Show();
            this.Hide();
        }


        //KİTAP ARAMA
        private void button1_Click(object sender, EventArgs e)
        {
            DbCon dbcon = new DbCon();
            con = dbcon.connection();
            OracleCommand komut = new OracleCommand("SELECT * FROM Kitaplar WHERE KitapAdi LIKE '%" + textBox7.Text + "%'", con);
            DataTable dataTable2 = new DataTable();
            OracleDataAdapter dataAdapter = new OracleDataAdapter(komut);
            dataAdapter.Fill(dataTable2);
            dataGridView1.DataSource = dataTable2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DbCon dbcon = new DbCon();
            con = dbcon.connection();
            com = new OracleCommand();
            com.Connection = con;

            UyeCagir();
            secilenKitapId = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
           

            KitapKontrol();
            if (drk.Read())
            {
                MessageBox.Show("Bu Kitap Daha Önce Alınmış");
            }
            else
            {
                DateTime time = Convert.ToDateTime(DateTime.Now.AddDays(15));
                com.CommandText = "INSERT INTO OduncAlma (UyeId, KitapId,OduncTarihi, IadeTarihi) " +
           "VALUES (" +Convert.ToInt32(textBox2.Text) + "," + secilenKitapId + ",'"+ DateTime.Now.ToString("dd/MM/yyyy") + "','"+
           DateTime.Now.AddDays(15).ToString("dd/MM/yyyy") + "')";
                com.ExecuteNonQuery();
                MessageBox.Show("Ödünç Verme Başarılı");
            }
           
            }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    }

