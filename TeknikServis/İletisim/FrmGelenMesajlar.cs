using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.İletisim
{
    public partial class FrmGelenMesajlar : Form
    {
        public FrmGelenMesajlar()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmGelenMesajlar_Load(object sender, EventArgs e)
        {
            labelControl12.Text = db.TBLILETIŞIM.Count().ToString();
            labelControl16.Text = db.TBLILETIŞIM.Where(x => x.KONU == "Teşekkür").Count().ToString();
            labelControl18.Text = db.TBLILETIŞIM.Where(x => x.KONU == "Rica").Count().ToString();
            labelControl20.Text = db.TBLILETIŞIM.Where(x => x.KONU == "Şikayet").Count().ToString();
            labelControl9.Text = (from x in db.TBLURUN
                                  select x.MARKA).Distinct().Count().ToString();
            labelControl1.Text = db.TBLPERSONEL.Count().ToString();
            labelControl3.Text = db.TBLCARI.Count().ToString();
            labelControl5.Text = db.TBLKATEGORİ.Count().ToString();
            labelControl7.Text = db.TBLURUN.Count().ToString();

            gridControl1.DataSource = (from x in db.TBLILETIŞIM
                                       select new
                                       {
                                           x.ID,
                                           x.ADSOYAD,
                                           x.KONU,
                                           x.MAİL,
                                           x.MESAJ
                                       }).ToList();
        }
    }
}
