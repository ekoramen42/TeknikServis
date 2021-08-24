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
    public partial class FrmKategori : Form
    {
        public FrmKategori()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        public void Listele()
        {
            var degerler = from x in db.TBLKATEGORİ
                           select new
                           {
                               x.ID,
                               x.AD
                           };
            gridControl1.DataSource = degerler.ToList(); ;
        }
        private void FrmKategori_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtAd.Text != "" && TxtAd.Text.Length <= 30)
            {
                TBLKATEGORİ t = new TBLKATEGORİ();
                t.AD = TxtAd.Text;
                db.TBLKATEGORİ.Add(t);
                db.SaveChanges();
                MessageBox.Show("Kategori Başarıyla Kaydedildi");
                Listele();
            }
            else
            {
                MessageBox.Show("Kategori Adı Boş Geçilemez Veya 30 Kaakterden Uzun Olamaz!!!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            var degerler = from x in db.TBLKATEGORİ
                           select new
                           {
                               x.ID,
                               x.AD
                           };
            gridControl1.DataSource = degerler.ToList();
            Listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtId.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Kategoriyi Gerçekten Silmek İstiyor Musunuz?", "UYARI", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (secenek == DialogResult.Cancel)
            {
                MessageBox.Show("Silme İşlemi İptal Edildi!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                int id = int.Parse(TxtId.Text);
                var degerler = db.TBLKATEGORİ.Find(id);
                db.TBLKATEGORİ.Remove(degerler);
                db.SaveChanges();
                MessageBox.Show("Kategori Başarıyla Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Listele();
            }

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var deger = db.TBLKATEGORİ.Find(id);
            deger.AD = TxtAd.Text;
            db.SaveChanges();
            MessageBox.Show("Kategori Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Listele();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            TxtAd.Text = "";
            TxtId.Text = "";
        }
    }
}
