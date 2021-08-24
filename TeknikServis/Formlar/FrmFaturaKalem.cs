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
    public partial class FrmFaturaKalem : Form
    {
        public FrmFaturaKalem()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLFATURADETAY t = new TBLFATURADETAY();
            t.URUN = TxtUrun.Text;
            t.ADET = short.Parse(TxtAdet.Text);
            t.FIYAT = decimal.Parse(TxtFiyat.Text);
            t.TUTAR = decimal.Parse(TxtTutar.Text);
            t.FATURAID = int.Parse(TxtFaturaID.Text);
            db.TBLFATURADETAY.Add(t);
            db.SaveChanges();
            MessageBox.Show("Faturaya ait kalem girişi başarılı bir şekilde yapıldı");
        }

        private void FrmFaturaKalem_Load(object sender, EventArgs e)
        {
            var degerler = from x in db.TBLFATURADETAY
                           select new
                           {
                               x.FATURADETAYID,
                               x.URUN,
                               x.ADET,
                               x.FIYAT,
                               x.TUTAR,
                               x.FATURAID
                           };
            gridControl1.DataSource = degerler.ToList();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            var degerler = from x in db.TBLFATURADETAY
                           select new
                           {
                               x.FATURADETAYID,
                               x.URUN,
                               x.ADET,
                               x.FIYAT,
                               x.TUTAR,
                               x.FATURAID
                           };
            gridControl1.DataSource = degerler.ToList();
        }
    }
}
