using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Formlar.FrmUrunListesi fr3;
        private void BtnUrunListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr3 == null || fr3.IsDisposed)
            {
                fr3 = new Formlar.FrmUrunListesi();
                fr3.MdiParent = this;
                fr3.Show();
            }

        }
        Formlar.FrmYeniUrun fr12;
        private void BtnYeniUrun_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr12 == null || fr12.IsDisposed)
            {
                fr12 = new Formlar.FrmYeniUrun();
                fr12.Show();
            }
        }
        Formlar.FrmKategori fr11;
        private void BtnKategoriListe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr11 == null || fr11.IsDisposed)
            {
                fr11 = new Formlar.FrmKategori();
                fr11.MdiParent = this;
                fr11.Show();
            }
        }
        Formlar.FrmYeniKategori fr2;
        private void BtnYeniKategori_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr2 == null || fr2.IsDisposed)
            {
                fr2 = new Formlar.FrmYeniKategori();
                //fr.MdiParent = this;
                fr2.Show();
            }

        }
        Formlar.Frmİstatistik fr4;
        private void BtnUrurnİstatistik_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr4 == null || fr4.IsDisposed)
            {
                fr4 = new Formlar.Frmİstatistik();
                fr4.MdiParent = this;
                fr4.Show();
            }

        }
        Formlar.FrmMarkalar fr5;
        private void BtnMarkaİstatistik_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr5 == null || fr5.IsDisposed)
            {
                fr5 = new Formlar.FrmMarkalar();
                fr5.MdiParent = this;
                fr5.Show();
            }


        }
        Formlar.FrmCariEkle fr10;
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (fr10 == null || fr10.IsDisposed)
            {
                fr10 = new Formlar.FrmCariEkle();
                fr10.Show();
            }

        }
        Formlar.FrmCariller fr9;
        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr9 == null || fr9.IsDisposed)
            {
                fr9 = new Formlar.FrmCariller();
                fr9.MdiParent = this;
                fr9.Show();
            }

        }
        Formlar.FrmDepartman fr19;
        private void BtnDepartmanListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr19 == null || fr19.IsDisposed)
            {
                fr19 = new Formlar.FrmDepartman();
                fr19.MdiParent = this;
                fr19.Show();
            }
        }
        Formlar.FrmYeniDepartman fr20;
        private void BtnYeniDepartman_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr20 == null || fr20.IsDisposed)
            {
                fr20 = new Formlar.FrmYeniDepartman();
                //fr.MdiParent = this;
                fr20.Show();
            }
        }
        Formlar.FrmPersonel fr18;
        private void BtnPersonelListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr18 == null || fr18.IsDisposed)
            {
                fr18 = new Formlar.FrmPersonel();
                fr18.MdiParent = this;
                fr18.Show();
            }
        }

        private void BtnHesapMakinesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }
        Formlar.FrmKurlar fr22;
        private void BtnDoviz_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr22 == null || fr.IsDisposed)
            {
                fr22 = new Formlar.FrmKurlar();
                fr22.MdiParent = this;
                fr22.Show();
            }

        }

        private void BtnWord_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("winword");
        }

        private void BtnExel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("Excel");
        }
        Formlar.FrmYoutube fr23;
        private void BtnYoutube_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr23 == null || fr23.IsDisposed)
            {
                fr23 = new Formlar.FrmYoutube();
                fr23.MdiParent = this;
                fr23.Show();
            }

        }
        Formlar.FrmNotlar fr21;
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr21 == null || fr21.IsDisposed)
            {
                fr21 = new Formlar.FrmNotlar();
                fr21.MdiParent = this;
                fr21.Show();
            }

        }
        Formlar.FrmArizaListesi fr6;
        private void BtnArizaliUrun_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (fr6 == null || fr6.IsDisposed)
            {
                fr6 = new Formlar.FrmArizaListesi();
                fr6.MdiParent = this;
                fr6.Show();
            }
        }
        Formlar.FrmUrunSatis fr16;
        private void BtnYeniUrunSatis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr16 == null || fr16.IsDisposed)
            {
                fr16 = new Formlar.FrmUrunSatis();
                //fr.MdiParent = this;
                fr16.Show();
            }
        }
        Formlar.FrmSatislar fr17;
        private void BtnSatisListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr17 == null || fr17.IsDisposed)
            {
                fr17 = new Formlar.FrmSatislar();
                fr17.MdiParent = this;
                fr17.Show();
            }
        }
        Formlar.FrmArizaliUrunKaydi fr13;
        private void BtnYeniArizaliUrun_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr13 == null || fr13.IsDisposed)
            {
                fr13 = new Formlar.FrmArizaliUrunKaydi();
                fr13.Show();
            }
        }
        Formlar.FrmCariListesi fr8;
        private void BtnCariListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr8 == null || fr8.IsDisposed)
            {
                fr8 = new Formlar.FrmCariListesi();
                fr8.MdiParent = this;
                fr8.Show();
            }
        }
        Formlar.FrmArizaDetaylar fr14;
        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr14 == null || fr14.IsDisposed)
            {
                fr14 = new Formlar.FrmArizaDetaylar();
                fr14.Show();
            }
        }
        Formlar.FrmArizaliUrunDetayListesi fr7;
        private void BtnArizaliUrunDetay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr7 == null || fr7.IsDisposed)
            {
                fr7 = new Formlar.FrmArizaliUrunDetayListesi();
                fr7.MdiParent = this;
                fr7.Show();
            }
        }

        private void BtnQrCode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmQRCode fr15 = new Formlar.FrmQRCode();
            //fr.MdiParent = this;
            fr15.Show();
        }

        private void BtnFaturaListele_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmFaturaListesi fr = new Formlar.FrmFaturaListesi();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnFaturaKalem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmFaturaKalem fr = new Formlar.FrmFaturaKalem();
            fr.MdiParent = this;
            fr.Show();
        }
        Formlar.FrmFormKalemleri fr27;
        private void BtnFaturaKalemListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr27 == null || fr27.IsDisposed)
            {
                fr27 = new Formlar.FrmFormKalemleri();
                fr27.MdiParent = this;
                fr27.Show();
            }
            
        }
        Formlar.FrmHakkimizda fr24;
        private void BtnHakkımızda_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr24 == null || fr24.IsDisposed)
            {
                fr24 = new Formlar.FrmHakkimizda();
                fr24.MdiParent = this;
                fr24.Show();
            }
        }
        Formlar.FrmHarita fr25;
        private void BtnHaritalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr25 == null || fr25.IsDisposed)
            {
                fr25 = new Formlar.FrmHarita();
                fr25.MdiParent = this;
                fr25.Show();
            }
        }
        Formlar.FrmRapor fr26;
        private void BtnRaporlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr26 == null || fr26.IsDisposed)
            {
                fr26 = new Formlar.FrmRapor();
                //fr.MdiParent = this;
                fr26.Show();
            }
        }
        Formlar.FrmAnaSayfa fr;
        private void Form1_Load(object sender, EventArgs e)
        {
            if (fr == null || fr.IsDisposed)
            {
                fr = new Formlar.FrmAnaSayfa();

                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void BtnAnaSayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr == null || fr.IsDisposed)
            {
                fr = new Formlar.FrmAnaSayfa();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        İletisim.FrmRehber fr28;
        private void barButtonItem34_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr28 == null ||fr28.IsDisposed)
            {
                fr28 = new İletisim.FrmRehber();
                fr28.MdiParent = this;
                fr28.Show();
            }
           
        }
        İletisim.FrmGelenMesajlar fr29;
        private void barButtonItem35_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr29 == null || fr29.IsDisposed)
            {
                fr29 = new İletisim.FrmGelenMesajlar();
                fr29.MdiParent = this;
                fr29.Show();
            }
        }
        İletisim.FrmMail fr30;
        private void barButtonItem36_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr30 == null || fr30.IsDisposed)
            {
                fr30 = new İletisim.FrmMail();
                fr30.Show();
            }
        }
    }
}
