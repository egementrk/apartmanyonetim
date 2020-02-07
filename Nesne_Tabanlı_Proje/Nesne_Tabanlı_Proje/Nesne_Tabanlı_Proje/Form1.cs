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

namespace Nesne_Tabanlı_Proje
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            /*BAŞLIK Çalışmadı
            Form1 f1 = new Form1();
            f1.Text = "Kullanıcı Girişi";
            f1.ShowDialog();
            this.Text = "Giriş Ekranı";*/

            //Butonlar tanımlandı
            this.AcceptButton = girisButton;
            this.CancelButton = sifreButton;
            // ÇALIŞMADI yöneticiRadio.Checked = true;
            //Formun Başlangıç konumu belirlendi
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }
        //Veri tabanı belirlenmesi ve string yolunun gösterilmesi
        SqlConnection baglantim = new SqlConnection("Data Source=DESKTOP-LL3F1LR;Initial Catalog=kullanicilar;Integrated Security=True");
       

        //Public Değişkenler
        public static string  tcno,adi, soyadi, yetki;
        
        bool durum = false;

        private void girisButton_Click_1(object sender, EventArgs e)
        {
            baglantim.Open();
            //Veri tabanının Kullanicilar tablosundan ne seçileceğini belirttik
            SqlCommand command = new SqlCommand("Select kullaniciadi,sifre,yetki,tcno,ad,soyad from Kullanicilar", baglantim);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (yoneticiRadio.Checked == true)
                {
                    if (reader["kullaniciadi"].ToString() == kullaniciadiText.Text &&
                       reader["sifre"].ToString() == sifreText.Text &&
                       reader["yetki"].ToString() == "Yönetici")
                    {
                        durum = true;
                        tcno = reader.GetValue(3).ToString();
                        adi = reader.GetValue(4).ToString();
                        soyadi = reader.GetValue(5).ToString();
                        yetki = reader.GetValue(2).ToString();
                        // Form Gizlendi
                        this.Hide();
                        Form2 frm2 = new Form2();
                        frm2.Show();
                        break;
                        
                    }
                }
                if (kullaniciRadio.Checked == true)
                {
                    if (reader["kullaniciadi"].ToString() == kullaniciadiText.Text &&
                       reader["sifre"].ToString() == sifreText.Text &&
                       reader["yetki"].ToString() == "Kullanıcı")
                    {
                        durum = true;
                        tcno = reader.GetValue(3).ToString();
                        adi = reader.GetValue(4).ToString();
                        soyadi = reader.GetValue(5).ToString();
                        yetki = reader.GetValue(2).ToString();
                        // Form Gizlendi
                        this.Hide();
                        Form3 frm3 = new Form3();

                        frm3.Show();
                        break;

                    }
                }
            }
            reader.Close();
            command.Dispose();
            baglantim.Close();
            if (durum == false)
            {
                MessageBox.Show("Kullanıcı adı veya Şİfre hatalıdır");
                //break;
            }
        }
    } 
}