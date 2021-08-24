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
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            gridControl2.DataSource = (from x in db.TBLURUN
                                       select new
                                       {
                                           x.AD,
                                           x.STOK
                                       }).Where(x => x.STOK < 30).ToList();

            gridControl1.DataSource = (from x in db.TBLCARI
                                       select new
                                       {
                                           x.AD,
                                           x.SOYAD,
                                           x.IL,
                                           x.ILCE,
                                           x.TELEFON
                                       }).ToList();

            gridControl3.DataSource = db.urunkategori().ToList();

            var degerler = from x in db.TBLURUNKABUL
                             select new
                             {
                                 x.ISLEMID,
                                 CARİ = x.TBLCARI.AD + " " + x.TBLCARI.SOYAD,
                                 PERSONEL = x.TBLPERSONEL.AD + " " + x.TBLPERSONEL.SOYAD,
                                 x.GELISTARIH,
                                 x.CIKISTARIHI,
                                 x.URUNSERİNO,
                                 x.URUNDURUMDETAY
                             };
            gridControl4.DataSource = degerler.ToList();

            //string ad1, konu1, ad2, konu2, ad3, konu3, ad4, konu4, ad5, konu5;
            //konu1 = db.TBLILETIŞIM.First(x => x.ID == 1).KONU;
            //ad1 = db.TBLILETIŞIM.First(x => x.ID == 1).ADSOYAD;
            //labelControl7.Text = konu1 + " - " + ad1;

            //konu2 = db.TBLILETIŞIM.First(x => x.ID == 2).KONU;
            //ad2 = db.TBLILETIŞIM.First(x => x.ID == 2).ADSOYAD;
            //labelControl2.Text = konu2 + " - " + ad2;

            //konu3 = db.TBLILETIŞIM.First(x => x.ID == 3).KONU;
            //ad3 = db.TBLILETIŞIM.First(x => x.ID == 3).ADSOYAD;
            //labelControl3.Text = konu3 + " - " + ad3;

            //konu4 = db.TBLILETIŞIM.First(x => x.ID == 4).KONU;
            //ad4 = db.TBLILETIŞIM.First(x => x.ID == 4).ADSOYAD;
            //labelControl11.Text = konu4 + " - " + ad4;

            //konu5 = db.TBLILETIŞIM.First(x => x.ID == 5).KONU;
            //ad5 = db.TBLILETIŞIM.First(x => x.ID == 5).ADSOYAD;
            //labelControl4.Text = konu5 + " - " + ad5;
        }

    }
}
