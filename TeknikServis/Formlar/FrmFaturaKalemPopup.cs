using System;
using System.Data;
using System.Linq;
using System.Diagnostics;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class FrmFaturaKalemPopup : Form
    {
        public FrmFaturaKalemPopup()
        {
            InitializeComponent();
        }
        public int id;
        private void FrmFaturaKalemPopup_Load(object sender, EventArgs e)
        {
            DbTeknikServisEntities db = new DbTeknikServisEntities();
            gridControl1.DataSource = db.TBLFATURADETAY.Where(x => x.FATURAID == id).ToList();
            gridControl2.DataSource = db.TBLFATURABILGI.Where(x => x.ID == id).ToList();
        }
        public void ExportExcel(DevExpress.XtraGrid.Views.Grid.GridView GridView, string DosyaAdi) // excelee almak için

        {

            SaveFileDialog dialog = new SaveFileDialog()

            {

                Filter = "Excel Çalışma Kitabı | *.xlsx",

                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),

                FileName = DosyaAdi

            };

            dialog.ShowDialog();

            gridView1.ExportToXlsx(dialog.FileName);

        }

        private void pictureEdit3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureEdit2_Click(object sender, EventArgs e)
        {
            ExportExcel(gridView1, "Faturaya ait Kalemler");
        }
       
        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (view != null)
            {
                view.ExportToPdf("MainViewData.pdf");
                Process pdfExport = new Process();
                pdfExport.StartInfo.FileName = "AcroRd32.exe";
                pdfExport.StartInfo.Arguments = "MainViewData.pdf";
                pdfExport.Start();
            }
        }
    }
}
