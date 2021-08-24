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
    public partial class FrmCariListesi : Form
    {
        public FrmCariListesi()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        public void Lİstele()
        {
            gridControl1.DataSource = (from x in db.TBLCARI
                                       select new
                                       {
                                           x.ID,
                                           x.AD,
                                           x.SOYAD,
                                           x.MAIL,
                                           x.IL,
                                           x.ILCE
                                       }).ToList();
        }
        int secilen;
        private void FrmCariListesi_Load(object sender, EventArgs e)
        {
            Lİstele();
            labelControl12.Text = db.TBLCARI.Count().ToString();
            labelControl18.Text = db.TBLCARI.Select(x => x.IL).Distinct().Count().ToString();
            labelControl20.Text = db.TBLCARI.Select(x => x.ILCE).Distinct().Count().ToString();

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

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtAd.Text != "" & TxtSoyad4.Text !="" & TxtAd.Text.Length<=20)
            {
                TBLCARI t = new TBLCARI();
                t.AD = TxtAd.Text;
                t.SOYAD = TxtSoyad4.Text;
                t.TELEFON = TxtTelefon.Text;
                t.MAIL = TxtMail.Text;
                t.IL = lookUpEdit2.Text;
                t.ILCE = lookUpEdit3.Text;
                t.BANKA = TxtBanka.Text;
                t.VERGIDAİRESİ = TxtVergiD.Text;
                t.VERGINO = TxtVergiNo.Text;
                t.STATU = TxtStatu.Text;
                t.ADRES = TxtAdres.Text;
                db.TBLCARI.Add(t);
                db.SaveChanges();
                MessageBox.Show("Cari Başarılı Bİr Şekilde Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Lİstele();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yendiden Deneyin!!!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var degerler = db.TBLCARI.Find(id);
            db.TBLCARI.Remove(degerler);
            db.SaveChanges();
            MessageBox.Show("Ürün Başarıyla Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            Lİstele();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = db.TBLCARI.ToList();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            TxtId.Text = "";
            TxtAd.Text = "";
            TxtSoyad4.Text = "";
            TxtTelefon.Text = "";
            TxtMail.Text = "";
            TxtBanka.Text = "";
            TxtVergiD.Text = "";
            TxtVergiNo.Text = "";
            TxtStatu.Text = "";
            TxtAdres.Text = "";
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
           // TxtId.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
           // TxtAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
           // TxtSoyad4.Text = gridView1.GetFocusedRowCellValue("SOYAD").ToString();
           // TxtMail.Text = gridView1.GetFocusedRowCellValue("MAIL").ToString();
           // //TxtTelefon.Text = gridView1.GetFocusedRowCellValue("TELEFON").ToString();
           // TxtBanka.Text = gridView1.GetFocusedRowCellValue("BANKA").ToString();
           // TxtStatu.Text = gridView1.GetFocusedRowCellValue("STATU").ToString();
           // TxtVergiD.Text = gridView1.GetFocusedRowCellValue("VERGIDAİRESİ").ToString();
           // TxtVergiNo.Text = gridView1.GetFocusedRowCellValue("VERGINO").ToString();
           //// TxtAdres.Text = gridView1.GetFocusedRowCellValue("ADRES").ToString();
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

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var deger = db.TBLCARI.Find(id);
            deger.AD = TxtAd.Text;
            deger.SOYAD = TxtSoyad4.Text;
            deger.MAIL = TxtTelefon.Text;
            deger.IL = lookUpEdit2.Text;
            deger.ILCE = lookUpEdit3.Text;
            db.SaveChanges();
            MessageBox.Show("Ürün Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Lİstele();
        }
    }
}
