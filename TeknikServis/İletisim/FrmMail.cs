using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace TeknikServis.İletisim
{
    public partial class FrmMail : Form
    {
        public FrmMail()
        {
            InitializeComponent();
        }

        private void BtnGonder_Click(object sender, EventArgs e)
        {
            MailMessage mail = new MailMessage();
            mail.Attachments.Add(new Attachment(TxtEkler.Text));
            string fromail = "ekremuarr6@gmail.com";
            string sifre = "Ekoramen42";
            string alici = TxtAlici.Text;
            string konu = TxtKonu.Text;
            string icerik = Txtİcerik.Text;
            mail.From = new MailAddress(fromail);
            mail.To.Add(alici);
            mail.Subject = konu;
            mail.Body = icerik;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com",587);
            smtp.Credentials = new NetworkCredential(fromail, sifre);
            smtp.EnableSsl = true;
            smtp.Send(mail);
            MessageBox.Show("Mail Gönderildi","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private object Add(Attachment attachment)
        {
            throw new NotImplementedException();
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textEdit1_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
           
        }
        
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            TxtEkler.ResetText();
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                TxtEkler.Text = file.FileName.ToString();
            }
        }
    }
}
