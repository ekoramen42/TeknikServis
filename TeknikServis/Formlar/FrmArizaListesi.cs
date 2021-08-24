using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class FrmArizaListesi : Form
    {
        public FrmArizaListesi()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        public void Listele()
        {
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
            gridControl1.DataSource = degerler.ToList();
        }
        private void FrmArizaListesi_Load(object sender, EventArgs e)
        {
            Listele();

            labelControl5.Text = db.TBLURUNKABUL.Count(x => x.URUNDURUM == true).ToString();
            labelControl3.Text = db.TBLURUNKABUL.Count(x=>x.URUNDURUM==false).ToString();
            labelControl11.Text = db.TBLURUN.Count().ToString();
            labelControl7.Text = db.TBLURUNKABUL.Count(x=>x.URUNDURUMDETAY =="Parça bekliyor").ToString();
            labelControl7.Text = db.TBLURUNKABUL.Count(x=>x.URUNDURUMDETAY =="Parça bekliyor").ToString();
            labelControl13.Text = db.TBLURUNKABUL.Count(x => x.URUNDURUMDETAY == "Ödeme bekliyor").ToString();
            labelControl15.Text = db.TBLURUNKABUL.Count(x => x.URUNDURUMDETAY == "İptal bekliyor").ToString();

            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-M167R4S;Initial Catalog=DbTeknikServis;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT URUNDURUMDETAY , COUNT(*) FROM TBLURUNKABUL GROUP BY URUNDURUMDETAY ", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            baglanti.Close();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmArizaDetaylar fr = new FrmArizaDetaylar();
            fr.id = gridView1.GetFocusedRowCellValue("ISLEMID").ToString();
            fr.serino = gridView1.GetFocusedRowCellValue("URUNSERİNO").ToString();
            fr.Show();
        }
    }
}
