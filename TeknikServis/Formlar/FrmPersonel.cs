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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        public void Listele()
        {
            var degerler = from u in db.TBLPERSONEL
                           select new
                           {
                               u.ID,
                               u.AD,
                               u.SOYAD,
                               u.MAİL,
                               u.TELEFON
                           };
            gridControl1.DataSource = degerler.ToList();
        }
        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            Listele();
            

            lookUpEdit1.Properties.DataSource = (from x in db.TBLDEPARTMAN
                                                select new
                                                {
                                                    x.ID,
                                                    x.AD
                                                }).ToList();

            string ad1, soyad1,ad2,soyad2,ad3,soyad3,ad4,soyad4,ad5,soyad5;
            ad1 = db.TBLPERSONEL.First(x => x.ID == 1).AD;
            soyad1 = db.TBLPERSONEL.First(x => x.ID == 1).SOYAD;
            labelControl4.Text = db.TBLPERSONEL.First(x => x.ID == 1).TBLDEPARTMAN.AD; ;
            labelControl6.Text = db.TBLPERSONEL.First(x => x.ID == 1).MAİL;
            labelControl3.Text = ad1 + " " + soyad1;

            ad2 = db.TBLPERSONEL.First(x => x.ID == 2).AD;
            soyad2 = db.TBLPERSONEL.First(x => x.ID == 2).SOYAD;
            labelControl11.Text = db.TBLPERSONEL.First(x => x.ID == 2).TBLDEPARTMAN.AD; ;
            labelControl9.Text = db.TBLPERSONEL.First(x => x.ID == 2).MAİL;
            labelControl14.Text = ad2 + " " + soyad2;

            ad3 = db.TBLPERSONEL.First(x => x.ID == 3).AD;
            soyad3 = db.TBLPERSONEL.First(x => x.ID == 3).SOYAD;
            labelControl18.Text = db.TBLPERSONEL.First(x => x.ID == 3).TBLDEPARTMAN.AD; ;
            labelControl16.Text = db.TBLPERSONEL.First(x => x.ID == 3).MAİL;
            labelControl20.Text = ad3 + " " + soyad3;

            ad4 = db.TBLPERSONEL.First(x => x.ID == 4).AD;
            soyad4 = db.TBLPERSONEL.First(x => x.ID == 4).SOYAD;
            labelControl24.Text = db.TBLPERSONEL.First(x => x.ID == 4).TBLDEPARTMAN.AD; ;
            labelControl22.Text = db.TBLPERSONEL.First(x => x.ID == 4).MAİL;
            labelControl26.Text = ad4 + " " + soyad4;

            ad5 = db.TBLPERSONEL.First(x => x.ID == 5).AD;
            soyad5 = db.TBLPERSONEL.First(x => x.ID == 5).SOYAD;
            labelControl30.Text = db.TBLPERSONEL.First(x => x.ID == 5).TBLDEPARTMAN.AD; ;
            labelControl28.Text = db.TBLPERSONEL.First(x => x.ID == 5).MAİL;
            labelControl32.Text = ad5 + " " + soyad5;
        }
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLPERSONEL t = new TBLPERSONEL();
            t.AD = TxtAd.Text;
            t.SOYAD = TxtSoyad.Text;
            t.DEPATRMAN = byte.Parse(lookUpEdit1.EditValue.ToString());
            t.MAİL = TxtMail.Text;
            t.TELEFON = TxtTelefon.Text;
            t.FOTOĞRAF = TxtFoto.Text;

            db.TBLPERSONEL.Add(t);
            db.SaveChanges();
            MessageBox.Show("Personel Ekleme İşlemi Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Listele();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var deger = db.TBLPERSONEL.Find(id);
            db.TBLPERSONEL.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Personel Silme İşlemi Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var deger = db.TBLPERSONEL.Find(id);
            deger.AD = TxtAd.Text;
            deger.SOYAD = TxtSoyad.Text;
            deger.MAİL = TxtMail.Text;
            deger.TELEFON = TxtTelefon.Text;
            deger.FOTOĞRAF = TxtFoto.Text;
            deger.DEPATRMAN = byte.Parse(lookUpEdit1.EditValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Personel Güncelleme İşlemi Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtId.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            TxtSoyad.Text = gridView1.GetFocusedRowCellValue("SOYAD").ToString();
            TxtMail.Text = gridView1.GetFocusedRowCellValue("MAİL").ToString();
            TxtTelefon.Text = gridView1.GetFocusedRowCellValue("TELEFON").ToString();
            //TxtFoto.Text = gridView1.GetFocusedRowCellValue("FOTOGRAF").ToString();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }
    }
}
