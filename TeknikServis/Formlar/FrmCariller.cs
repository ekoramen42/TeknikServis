using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TeknikServis.Formlar
{
    public partial class FrmCariller : Form
    {
        public FrmCariller()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-M167R4S;Initial Catalog=DbTeknikServis;Integrated Security=True");
        private void FrmCariller_Load(object sender, EventArgs e)
        {
            //chartControl1.Series["Series 1"].Points.AddPoint("Ankara", 22);
            //chartControl1.Series["Series 1"].Points.AddPoint("İstanbul", 12);
            //chartControl1.Series["Series 1"].Points.AddPoint("İzmir", 8);
            //chartControl1.Series["Series 1"].Points.AddPoint("Bursa", 14);

            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-M167R4S;Initial Catalog=DbTeknikServis;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT IL , COUNT(*) FROM TBLCARI GROUP BY IL", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            baglanti.Close();
            gridControl1.DataSource = db.TBLCARI.OrderBy(x => x.IL).GroupBy(y => y.IL).Select(z => new { İL = z.Key, TOPLAM = z.Count() }).ToList();



        }

    }
}
