using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Veri alışverişi için
using System.IO;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
namespace Nesne_Tabanlı_Proje
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection baglantim = new SqlConnection("Data Source=DESKTOP-LL3F1LR;Initial Catalog=kullanicilar;Integrated Security=True");
        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'kullanicilarDataSet10.duyuru' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.duyuruTableAdapter.Fill(this.kullanicilarDataSet10.duyuru);
            // TODO: Bu kod satırı 'kullanicilarDataSet9.borcbilgisi' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.borcbilgisiTableAdapter2.Fill(this.kullanicilarDataSet9.borcbilgisi);
            // TODO: Bu kod satırı 'kullanicilarDataSet8.borcbilgisi' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.borcbilgisiTableAdapter1.Fill(this.kullanicilarDataSet8.borcbilgisi);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            borclarimtabyenile();
            bilgileri_goster();
        }
        private void borclarimtabyenile() {
            try
            {
                baglantim.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("Select kategori,ad,soyad,tutar,daireno,tarih from borcbilgisi where daireno='" + Form1.daireno + "'", baglantim);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
                baglantim.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "Apartman Yönetim Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglantim.Close();

                throw;
            }
        }
        private void borclarimtab_Click(object sender, EventArgs e)
        {
            borclarimtabyenile();
        }

        private void bilgileri_goster()
        {
            try
            {
                bool kayitkontrol = false;
                baglantim.Open();
                string kontrol = Form1.tcno;
                SqlCommand command = new SqlCommand("select * from kullanicilar where tcno='" + kontrol + "'", baglantim);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    kayitkontrol = true; 
                    break;
                }
                if (kayitkontrol == true)
                {
                    label7.Text = reader.GetValue(3).ToString();
                    label8.Text = reader.GetValue(0).ToString();
                    label9.Text = reader.GetValue(4).ToString();
                    label10.Text = reader.GetValue(5).ToString();
                    label12.Text = reader.GetValue(8).ToString();
                    if (reader.GetValue(6).ToString() != null || reader.GetValue(6).ToString() != "")
                    {
                        label11.Text = reader.GetValue(6).ToString();
                    }
                }
                command.Dispose();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                baglantim.Close();
                throw;
            }
            baglantim.Close();
        }
        private void duyurulari_goster()
        {
            try
            {
                baglantim.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("Select duyuru,duyurukonusu,tarih from duyuru", baglantim);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView2.DataSource = dataTable;
                baglantim.Close();
            }
            catch (Exception hata)
            {
                baglantim.Close();
                MessageBox.Show(hata.Message);
                throw;
            }
        }
    }
}
