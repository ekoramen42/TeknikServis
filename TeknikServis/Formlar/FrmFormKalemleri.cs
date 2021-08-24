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
    public partial class FrmFormKalemleri : Form
    {
        public FrmFormKalemleri()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void BtnAra_Click(object sender, EventArgs e)
        {
            if (TxtID.Text != "")
            {


                int id = Convert.ToInt32(TxtID.Text);
                var degerler = (from x in db.TBLFATURADETAY
                                select new
                                {
                                    x.FATURADETAYID,
                                    x.URUN,
                                    x.ADET,
                                    x.FIYAT,
                                    x.TUTAR,
                                    x.FATURAID
                                }).Where(x => x.FATURAID == id);
                gridControl1.DataSource = degerler.ToList();
            }
            var arama = (from x in db.TBLFATURADETAY.Where(x=>x.TBLFATURABILGI.SERİ == TxtSeriNo.Text | x.TBLFATURABILGI.SIRANO == TxtSiraNo.Text)
                         select new
                         {
                             x.FATURADETAYID,
                             x.URUN,
                             x.ADET,
                             x.FIYAT,
                             x.TUTAR,
                             x.FATURAID,
                             CARI = x.TBLFATURABILGI.TBLCARI.AD + " " + x.TBLFATURABILGI.TBLCARI.SOYAD
                         });
            gridControl1.DataSource = arama.ToList();
        }

        private void FrmFormKalemleri_Load(object sender, EventArgs e)
        {
            
        }
    }
}
