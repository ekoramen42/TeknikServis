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
    public partial class FrmDepartman : Form
    {
        public FrmDepartman()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        public void Listele()
        {
            var degerler = from u in db.TBLDEPARTMAN
                           select new
                           {
                               u.ID,
                               u.AD,
                               u.ACIKLAMA
                           };
            gridControl1.DataSource = degerler.ToList();
        }
        private void FrmDepartman_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLDEPARTMAN t = new TBLDEPARTMAN();
            if (TxtAd.Text.Length<=50 && TxtAd.Text!=""&& richTextBox1.Text.Length>=1)
            {
                t.AD = TxtAd.Text;
                t.ACIKLAMA = richTextBox1.Text;
                db.TBLDEPARTMAN.Add(t);
                db.SaveChanges();
                MessageBox.Show("Deparman Kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
            }
            else
            {
                MessageBox.Show("Kayıt Yapılamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var degerler = db.TBLDEPARTMAN.Find(id);
            db.TBLDEPARTMAN.Remove(degerler);
            MessageBox.Show("Departman Başarıyla Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            Listele();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                TxtId.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
                TxtAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
                richTextBox1.Text = gridView1.GetFocusedRowCellValue("ACIKLAMA").ToString();
            }
            catch (Exception)
            {

                MessageBox.Show("Eksik veya Hatalı Bilgi Getirdiniz.");
            }
           
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var deger = db.TBLDEPARTMAN.Find(id);
            deger.AD = TxtAd.Text;
            db.SaveChanges();
            MessageBox.Show("Departman Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Listele();
        }
    }
}
