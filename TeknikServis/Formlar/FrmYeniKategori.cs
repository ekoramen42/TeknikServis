using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class FrmYeniKategori : Form
    {
        public FrmYeniKategori()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtAd.Text != "" && TxtAd.Text.Length <= 30)
            {
                TBLKATEGORİ t = new TBLKATEGORİ();
                t.AD = TxtAd.Text;
                db.TBLKATEGORİ.Add(t);
                db.SaveChanges();
                MessageBox.Show("Kategori Başarıyla Kaydedildi");
            }
            else
            {
                MessageBox.Show("Kategori Adı Boş Geçilemez Veya 30 Kaakterden Uzun Olamaz!!!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureEdit2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmYeniKategori_Load(object sender, EventArgs e)
        {

        }
    }
}
