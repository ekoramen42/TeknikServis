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
    public partial class Frmİstatistik : Form
    {
        public Frmİstatistik()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void Frmİstatistik_Load(object sender, EventArgs e)
        {
            labelControl2.Text = db.TBLURUN.Count().ToString();
            labelControl3.Text = db.TBLKATEGORİ.Count().ToString();
            labelControl5.Text = db.TBLURUN.Sum(x => x.STOK).ToString();
            labelControl9.Text = "30";
            labelControl19.Text = (from x in db.TBLURUN
                                   orderby x.STOK descending
                                   select x.AD).FirstOrDefault();
            labelControl17.Text = (from x in db.TBLURUN
                                   orderby x.STOK ascending
                                   select x.AD).FirstOrDefault();
            labelControl7.Text = "10";
            labelControl15.Text = db.makskategoriurun().FirstOrDefault();
            labelControl12.Text = (from x in db.TBLURUN
                                   orderby x.SATISFIYAT descending
                                   select x.AD).FirstOrDefault();
            labelControl13.Text = (from x in db.TBLURUN
                                   orderby x.SATISFIYAT ascending
                                   select x.AD).FirstOrDefault();
            labelControl28.Text = db.TBLURUN.Count(x => x.KATEGORİ == 4).ToString();
            labelControl24.Text = db.TBLURUN.Count(x => x.KATEGORİ == 1).ToString();
            labelControl25.Text = db.TBLURUN.Count(x => x.KATEGORİ == 3).ToString();
            labelControl30.Text = db.TBLURUNTAKIP.Count(x => x.ACIKLAMA == "Kargoya verildi").ToString();
            labelControl33.Text = (from x in db.TBLURUN
                                   select x.MARKA).Distinct().Count().ToString();
            labelControl35.Text = (from x in db.TBLURUN
                                   orderby x.STOK descending
                                   select x.MARKA).FirstOrDefault();
            labelControl38.Text = db.TBLURUNKABUL.Count().ToString();
        }
    }
}
