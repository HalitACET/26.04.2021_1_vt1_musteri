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
namespace _26._04._2021_1_vt1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Vt bgl = new Vt();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            MusteriCrud musterikayit = new MusteriCrud();
            Musteri musteri = new Musteri();
            musteri.Ad = txtAd.Text;
            musteri.Cinsiyet1 = cmbCinsiyet.Text;
            musteri.Dtar1 =dateTimePicker1.Value.ToShortDateString();
            musteri.Dyer1 = txtDogumYeri.Text;
            musteri.Soyad = txtSoyad.Text;
            musteri.Il1 = cmbIl.SelectedValue.ToString();
            musteri.Ilce1 = cmbIlce.SelectedValue.ToString();
            musteri.Semt = richTextBox1.Text;

            musterikayit.Musterikaydet(musteri);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            bgl.ac();
            DataTable dt = new DataTable();
            SqlCommand komut = new SqlCommand("Select * from Iller",bgl.baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            dt.Load(dr);
            cmbIl.DataSource = dt;
            cmbIl.DisplayMember = "Il";
            cmbIl.ValueMember = "IlId";
            bgl.kapat();
        }

        private void cmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            bgl.kapat();
            bgl.ac();
            int sec = cmbIl.SelectedIndex+1;
            DataTable dt2 = new DataTable();
            SqlCommand komut2 = new SqlCommand("Select * from Ilceler Where IlID=@a", bgl.baglanti);
            komut2.Parameters.AddWithValue("@a",sec);
            SqlDataReader dr2 = komut2.ExecuteReader();
            dt2.Load(dr2);
            cmbIlce.DataSource = dt2;
            cmbIlce.DisplayMember = "Ilce";
            cmbIlce.ValueMember = "IlceId";
            bgl.kapat();
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            MusteriCrud ara = new MusteriCrud();

            Musteri musteri = new Musteri();

            musteri= ara.bul(txtAd.Text, txtSoyad.Text);

            if (musteri.Ad!=null)
            {
                txtAd.Text = musteri.Ad;
                txtSoyad.Text = musteri.Soyad;
                txtDogumYeri.Text = musteri.Dyer1;
                cmbCinsiyet.Text = musteri.Cinsiyet1;
                dateTimePicker1.Value = Convert.ToDateTime(musteri.Dtar1);
                cmbIl.Text = musteri.Il1;
                cmbIlce.Text = musteri.Ilce1;
                cmbSemt.Text = musteri.Semt;
            }
            else
            {
                MessageBox.Show("Bulunamadı");
            }

        }
    }
}
