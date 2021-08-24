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
    public partial class FrmCariEkle : Form
    {
        public FrmCariEkle()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        int secilen;
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                TBLCARI t = new TBLCARI();
                t.AD = TxtAd.Text;
                t.SOYAD = TxtSoyad.Text;
                t.TELEFON = TxtTelefon.Text;
                t.MAIL = TxtMail.Text;
                t.IL = lookUpEdit2.Text;
                t.ILCE = lookUpEdit3.Text;
                t.BANKA = TxtBanka.Text;
                t.VERGIDAİRESİ = TxtVergiDairesi.Text;
                t.VERGINO = TxtVergiNo.Text;
                t.STATU = TxtStatu.Text;
                t.ADRES = TxtAdres.Text;
                db.TBLCARI.Add(t);
                db.SaveChanges();
                MessageBox.Show("Müşteri Ekleme Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

                MessageBox.Show("Müşteri Eklenirken Hata Oluştu !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureEdit14_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCariEkle_Load(object sender, EventArgs e)
        {
            lookUpEdit2.Properties.DataSource = (from x in db.TBLILLER
                                                 select new
                                                 {
                                                     x.id,
                                                     x.sehir
                                                 }).ToList();

            lookUpEdit3.Properties.DataSource = (from x in db.TBLILCELER
                                                 select new
                                                 {
                                                     x.id,
                                                     x.ilce
                                                 }).ToList();

        }

        private void lookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {
            secilen = int.Parse(lookUpEdit2.EditValue.ToString());
            lookUpEdit3.Properties.DataSource = (from y in db.TBLILCELER
                                                 select new
                                                 {
                                                     y.id,
                                                     y.ilce,
                                                     y.sehir
                                                 }).Where(z => z.sehir == secilen).ToList();
        }

    }
}
