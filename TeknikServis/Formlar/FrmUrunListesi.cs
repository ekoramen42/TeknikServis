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
    public partial class FrmUrunListesi : Form
    {
        public FrmUrunListesi()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        void metod1()
        {
            var degerler = from u in db.TBLURUN
                           select new
                           {
                               u.ID,
                               u.AD,
                               u.MARKA,
                               KATEGORİ = u.TBLKATEGORİ.AD,
                               u.STOK,
                               u.ALISFIYAT,
                               u.SATISFIYAT
                           };
            gridControl1.DataSource = degerler.ToList();
        }
        private void FrmUrunListesi_Load(object sender, EventArgs e)
        {
            //var degerler = db.TBLURUN.ToList();
            metod1();
            lookUpEdit1.Properties.DataSource = (from x in db.TBLURUN
                                                 select new
                                                 {
                                                     x.ID,
                                                     x.AD
                                                 }).ToList();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLURUN t = new TBLURUN();
            t.AD = TxtUruAd.Text;
            t.MARKA = TxtMarka.Text;
            t.ALISFIYAT = decimal.Parse(TxtAlisFiyat.Text);
            t.SATISFIYAT = decimal.Parse(TxtSatisFİyat.Text);
            t.STOK = short.Parse(TxtStok.Text);
            t.DURUM = false;
            t.KATEGORİ = byte.Parse(lookUpEdit1.EditValue.ToString());
            db.TBLURUN.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Başarıyla Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            metod1();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                TxtId.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
                TxtUruAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
                TxtMarka.Text = gridView1.GetFocusedRowCellValue("MARKA").ToString();
                TxtAlisFiyat.Text = gridView1.GetFocusedRowCellValue("ALISFIYAT").ToString();
                TxtSatisFİyat.Text = gridView1.GetFocusedRowCellValue("SATISFIYAT").ToString();
                TxtStok.Text = gridView1.GetFocusedRowCellValue("STOK").ToString();
                //lookUpEdit1.Text = gridView1.GetFocusedRowCellValue("V.DAİRESİ").ToString();
            }
            catch (Exception)
            {

                MessageBox.Show("Hata");
            }
            
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var degerler = db.TBLURUN.Find(id);
            db.TBLURUN.Remove(degerler);
            MessageBox.Show("Ürün Başarıyla Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            metod1();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var deger = db.TBLURUN.Find(id);
            deger.AD = TxtUruAd.Text;
            deger.STOK = short.Parse(TxtStok.Text);
            deger.MARKA = TxtMarka.Text;
            deger.ALISFIYAT = decimal.Parse(TxtAlisFiyat.Text);
            deger.SATISFIYAT = decimal.Parse(TxtSatisFİyat.Text);
            deger.KATEGORİ = byte.Parse(lookUpEdit1.EditValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Ürün Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            metod1();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            metod1();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            TxtId.Text = "";
            TxtUruAd.Text = "";
            TxtMarka.Text = "";
            TxtAlisFiyat.Text = "";
            TxtSatisFİyat.Text = "";
            TxtStok.Text = "";
            lookUpEdit1.Text = "";
        }
    }
}
