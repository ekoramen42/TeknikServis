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
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        public void Listele()
        {
            gridControl1.DataSource = db.TBLNOTLARIM.Where(x => x.DURUM == false).ToList();
            gridControl2.DataSource = db.TBLNOTLARIM.Where(y => y.DURUM == true).ToList();
        }
        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLNOTLARIM t = new TBLNOTLARIM();
            t.BASLIK = TxtBaslık.Text;
            t.ICERIK = Txtİcerik.Text;
            t.DURUM = false;
            t.TARİH = DateTime.Parse(TxtTarih.Text);
            db.TBLNOTLARIM.Add(t);
            db.SaveChanges();
            MessageBox.Show("Not Başarıyla Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (checkEdit1.Checked == true)
            {
                int id = int.Parse(TxtId.Text);
                var deger = db.TBLNOTLARIM.Find(id);
                deger.DURUM = true;

                db.SaveChanges();
                MessageBox.Show("Not Durumu Değiştirildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Listele();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtId.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtBaslık.Text = gridView1.GetFocusedRowCellValue("BASLIK").ToString();
            Txtİcerik.Text = gridView1.GetFocusedRowCellValue("ICERIK").ToString();
            TxtTarih.Text = gridView1.GetFocusedRowCellValue("TARİH").ToString();
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtId.Text = gridView2.GetFocusedRowCellValue("ID").ToString();
            TxtBaslık.Text = gridView2.GetFocusedRowCellValue("BASLIK").ToString();
            Txtİcerik.Text = gridView2.GetFocusedRowCellValue("ICERIK").ToString();
            TxtTarih.Text = gridView2.GetFocusedRowCellValue("TARİH").ToString();
        }
    }
}
