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
    public partial class FrmFaturaListesi : Form
    {
        public FrmFaturaListesi()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        public void Listele()
        {
            var degerler = from u in db.TBLFATURABILGI
                           select new
                           {
                               u.ID,
                               u.SERİ,
                               u.SIRANO,
                               u.TARIH,
                               u.SAAT,
                               u.VERGİIDAIRE,
                               CARI = u.TBLCARI.AD + " " + u.TBLCARI.SOYAD,
                               PERSONEL = u.TBLPERSONEL.AD + " " + u.TBLPERSONEL.SOYAD
                           };
            gridControl1.DataSource = degerler.ToList();
        }
        private void FrmFaturaListesi_Load(object sender, EventArgs e)
        {
            Listele();

            lookUpEdit1.Properties.DataSource = (from x in db.TBLCARI
                                                 select new
                                                 {
                                                     x.ID,
                                                     AD = x.AD+" "+x.SOYAD
                                                 }).ToList();
            lookUpEdit2.Properties.DataSource = (from x in db.TBLPERSONEL
                                                 select new
                                                 {
                                                     x.ID,
                                                     AD = x.AD+" "+x.SOYAD
                                                 }).ToList();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLFATURABILGI t = new TBLFATURABILGI();
            t.SERİ = TxtSeri.Text;
            t.SIRANO = TxtSira.Text;
            t.TARIH = Convert.ToDateTime(TxtTarih.Text);
            t.SAAT = TxtSaat.Text;
            t.VERGİIDAIRE = TxtVergiDairesi.Text;
            t.CARI = int.Parse(lookUpEdit1.EditValue.ToString());
            t.PERSONEL = short.Parse(lookUpEdit2.EditValue.ToString());
            db.TBLFATURABILGI.Add(t);
            db.SaveChanges();
            MessageBox.Show("Fatura Ekleme İşlemi Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmFaturaKalemPopup fr = new FrmFaturaKalemPopup();
            fr.id = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            fr.Show();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtSeri.Text = gridView1.GetFocusedRowCellValue("SERİ").ToString();
            TxtSira.Text = gridView1.GetFocusedRowCellValue("SIRANO").ToString();
            TxtTarih.Text = gridView1.GetFocusedRowCellValue("TARIH").ToString();
            TxtSaat.Text = gridView1.GetFocusedRowCellValue("SAAT").ToString();
            TxtVergiDairesi.Text = gridView1.GetFocusedRowCellValue("VERGİIDAIRE").ToString();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            TxtID.Text = "";
            TxtSeri.Text = "";
            TxtSira.Text = "";
            TxtTarih.Text = "";
            TxtSaat.Text = "";
            TxtVergiDairesi.Text = "";
            lookUpEdit1.Text = "";
            lookUpEdit2.Text = "";
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLFATURABILGI.Find(id);
            db.TBLFATURABILGI.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Fatura Silme İşlemi Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLFATURABILGI.Find(id);
            deger.SERİ = TxtSeri.Text;
            deger.SIRANO = TxtSira.Text;
            deger.TARIH = DateTime.Parse(TxtTarih.Text);
            deger.SAAT = TxtSaat.Text;
            deger.VERGİIDAIRE = TxtVergiDairesi.Text;
            deger.CARI = int.Parse(lookUpEdit1.EditValue.ToString());
            deger.PERSONEL = byte.Parse(lookUpEdit2.EditValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Fatura Güncelleme İşlemi Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }
    }
}
