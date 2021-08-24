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
    public partial class FrmYeniUrun : Form
    {
        public FrmYeniUrun()
        {
            InitializeComponent();
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                DbTeknikServisEntities db = new DbTeknikServisEntities();
                TBLURUN t = new TBLURUN();
                t.AD = TxtAd.Text;
                t.ALISFIYAT = decimal.Parse(TxtAlisFiyat.Text);
                t.SATISFIYAT = decimal.Parse(TxtSatisFiyat.Text);
                t.STOK = short.Parse(TxtStok.Text);
                t.KATEGORİ = byte.Parse(lookUpEdit1.EditValue.ToString());
                t.MARKA = TxtMarka.Text;
                db.TBLURUN.Add(t);
                db.SaveChanges();
                MessageBox.Show("Ürün Ekleme Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

                MessageBox.Show("Ürün Eklenirken Hata Oluştu !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmYeniUrun_Load(object sender, EventArgs e)
        {
            lookUpEdit1.Properties.DataSource = (from x in db.TBLKATEGORİ
                                                 select new
                                                 {
                                                     x.ID,
                                                     x.AD
                                                 }).ToList();
        }

        private void TxtAd_Click(object sender, EventArgs e)
        {
            TxtAd.Text = "";
            TxtAd.Focus();
        }

        private void TxtMarka_Click(object sender, EventArgs e)
        {
            TxtMarka.Text = "";
            TxtMarka.Focus();
        }

        private void TxtAlisFiyat_Click(object sender, EventArgs e)
        {
            TxtAlisFiyat.Text = "";
            TxtAlisFiyat.Focus();
        }

        private void TxtSatisFiyat_Click(object sender, EventArgs e)
        {
            TxtSatisFiyat.Text = "";
            TxtSatisFiyat.Focus();
        }

        private void TxtStok_Click(object sender, EventArgs e)
        {
            TxtStok.Text = "";
            TxtStok.Focus();
        }

        private void pictureEdit8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureEdit8_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
