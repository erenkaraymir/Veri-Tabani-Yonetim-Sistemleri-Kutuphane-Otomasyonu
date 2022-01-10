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
    public partial class MenuUye : Form
    {
        public MenuUye()
        {
            InitializeComponent();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            AnaSayfa anaSayfa = new AnaSayfa();
            anaSayfa.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            UyeKitapAra uyeKitapAra = new UyeKitapAra();
            uyeKitapAra.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Profilim profilim = new Profilim();
            profilim.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            UyeKitapBagis uyeKitapBagis = new UyeKitapBagis();
            uyeKitapBagis.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            UyeOdunc uyeOdunc = new UyeOdunc();
            uyeOdunc.Show();
            this.Hide();
       
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            UyeKitapIade uyeKitapIade = new UyeKitapIade();
            uyeKitapIade.Show();
            this.Hide();
        }
    }
}
