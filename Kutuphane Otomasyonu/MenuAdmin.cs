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
    public partial class MenuAdmin : Form
    {
        public MenuAdmin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            AnaSayfa anaSayfa = new AnaSayfa();
            anaSayfa.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            AdminUyeKaydi adUye = new AdminUyeKaydi();
            adUye.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            UyeSil uyeSil = new UyeSil();
            uyeSil.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            KitapEkle kitapEkle = new KitapEkle();
            kitapEkle.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            KitapSil kitapSil = new KitapSil();
            kitapSil.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            KitapAra kitapAra = new KitapAra();
            kitapAra.Show();
            this.Hide();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            KitapGuncelle kitapGuncelle = new KitapGuncelle();
            kitapGuncelle.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            YayıneviIslemleri yayınevi = new YayıneviIslemleri();
            yayınevi.Show();
            this.Hide();

            //YayınEvi
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            OduncTablosuAdmin oduncTablosu = new OduncTablosuAdmin();
            oduncTablosu.Show();
            this.Hide();

            //Odunc Tablosu
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            UyeGuncelle uyeGuncelle = new UyeGuncelle();
            uyeGuncelle.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            YazarIslemleri yazarIslemleri = new YazarIslemleri();
            yazarIslemleri.Show();
            this.Hide();
        }

        private void MenuAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
