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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglantim = new SqlConnection("Data Source=DESKTOP-LL3F1LR;Initial Catalog=kullanicilar;Integrated Security=True");
        
        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'kullanicilarDataSet7.borcbilgisi' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.borcbilgisiTableAdapter2.Fill(this.kullanicilarDataSet7.borcbilgisi);
            // TODO: Bu kod satırı 'kullanicilarDataSet6.borcbilgisi' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.borcbilgisiTableAdapter1.Fill(this.kullanicilarDataSet6.borcbilgisi);
            // TODO: Bu kod satırı 'kullanicilarDataSet5.borcbilgisi' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.borcbilgisiTableAdapter.Fill(this.kullanicilarDataSet5.borcbilgisi);
            // TODO: Bu kod satırı 'kullanicilarDataSet4.duyuru' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.duyuruTableAdapter1.Fill(this.kullanicilarDataSet4.duyuru);
            // TODO: Bu kod satırı 'kullanicilarDataSet3.duyuru' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.duyuruTableAdapter.Fill(this.kullanicilarDataSet3.duyuru);
            // TODO: Bu kod satırı 'kullanicilarDataSet1.kullanicilar' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.kullanicilarTableAdapter2.Fill(this.kullanicilarDataSet1.kullanicilar);
            // TODO: Bu kod satırı 'mydbDataSet4.Kullanicilar' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            //this.kullanicilarTableAdapter1.Fill(this.mydbDataSet4.Kullanicilar);
            // TODO: Bu kod satırı 'kullanicilarDataSet.kullanicilar' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.kullanicilarTableAdapter.Fill(this.kullanicilarDataSet.kullanicilar);

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;

            //Gİriş sınırlandırılmaları
            ketcBox.MaxLength = 11;
            kesifreBox.MaxLength = 10;
            aetcBox.MaxLength = 11;
            pstcnoBox.MaxLength = 11;
            kstcBox.MaxLength = 11;

            //tooltip uyarı mesajılarının tanımlaması
            toolTip1.SetToolTip(this.ketcBox, "Lütfen 11 karakter giriniz!");
            //Gelen değerleri büyük harfe çevirdik
            keadBox.CharacterCasing = CharacterCasing.Upper;
            kesoyadBox.CharacterCasing = CharacterCasing.Upper;
            aeadBox.CharacterCasing = CharacterCasing.Upper;
            aesoyadBox.CharacterCasing = CharacterCasing.Upper;
            aeplakaBox.CharacterCasing = CharacterCasing.Upper;
            psadBox.CharacterCasing = CharacterCasing.Upper;
            pssoyadBox.CharacterCasing = CharacterCasing.Upper;
            ksadBox.CharacterCasing = CharacterCasing.Upper;
            kssoyadBox.CharacterCasing = CharacterCasing.Upper;
            //kullanicilari_goster();
            //Daireye Göre ComboBox Değerleri Belirlendi
            comboBox2.Items.Add("Doğalgaz");
            comboBox2.Items.Add("Elektrik");
            comboBox2.Items.Add("Su");
            comboBox2.Items.Add("Aidat");
            comboBox2.Items.Add("Tamir-Servis");

            DateTime dateTime = DateTime.Now;
            int yil = int.Parse(dateTime.ToString("yyyy"));
            int ay = int.Parse(dateTime.ToString("MM"));
            int gün = int.Parse(dateTime.ToString("dd"));
            //kontrol et
            dateTimePicker1.MinDate = new DateTime(dateTime.Year, dateTime.Month,dateTime.Day);
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            
            dateTimePicker2.MinDate = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
            dateTimePicker2.Format = DateTimePickerFormat.Short;
            bilgileri_goster();
            duyurulari_goster();
            borclari_goster();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

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
                    label39.Text = reader.GetValue(3).ToString();
                    label40.Text = reader.GetValue(0).ToString();
                    label41.Text = reader.GetValue(4).ToString();
                    label42.Text = reader.GetValue(5).ToString();
                    label44.Text = reader.GetValue(8).ToString();
                    if (reader.GetValue(6).ToString()!=null||reader.GetValue(6).ToString()!="")
                    {
                        label43.Text = reader.GetValue(6).ToString();
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
        private void kullanicilari_goster()
        {

            try
            {
                baglantim.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("Select kullaniciadi,yetki,tcno,ad,soyad,plakano,daireno from Kullanicilar", baglantim);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                baglantim.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "Apartman Yönetim Otomasyonu",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void borclari_goster()
        {
            try
            {
                baglantim.Open();
                String daireno = Form1.daireno;
                SqlDataAdapter adapter = new SqlDataAdapter("select kategori,ad,soyad,tutar,daireno,tarih from borcbilgisi  where daireno='" + daireno + "'", baglantim);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView3.DataSource = dataTable;
                baglantim.Close();
            }
            catch(Exception hata)
            {
                baglantim.Close();
                MessageBox.Show(hata.Message);
                throw;
            }
        }
        private void kullanicilarTab_Click(object sender, EventArgs e)
        {
            kullanicilari_goster();
        }

        //Kullanıcı eklemedeki gerekl kısıtlamalar .MaskedText çalışmadı!
        private void tckontrol_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57 || (int)e.KeyChar == 8) e.Handled = false;
            else e.Handled = true;
        }
        private void sayi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57 || (int)e.KeyChar == 8) e.Handled = false;
            else e.Handled = true;
        }

        private void tckontrol_TextChanged(object sender, EventArgs e)
        {
            if (ketcBox.Text.Length < 11)
                errorProvider1.SetError(ketcBox, "Lütfen 11 karakter giriniz!");
            else
                errorProvider1.Clear();
        }

        private void keadBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsSeparator(e.KeyChar) == true)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void kesoyadBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsSeparator(e.KeyChar) == true)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void kekulladıBox_TextChanged(object sender, EventArgs e)
        {
            if (kekulladıBox.Text.Length < 5)
                errorProvider1.SetError(kekulladıBox, "Kullanıcı Adı 5 karakterden büyük olmalıdır");
            else
                errorProvider1.Clear();
        }
        private void kekulladıBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsDigit(e.KeyChar) == true)
                e.Handled = false;
            else
                e.Handled = true;
        }


        private void sifrekontrol_TextChanged(object sender, EventArgs e)
        {
            string sifre = kesifreBox.Text;
            string regexSifre = "";
            //regex türkçe karakterleri kabul etmiyor!
            regexSifre = sifre;
            regexSifre = regexSifre.Replace('İ', 'I');
            regexSifre = regexSifre.Replace('ı', 'i');
            regexSifre = regexSifre.Replace('Ç', 'C');
            regexSifre = regexSifre.Replace('ç', 'c');
            regexSifre = regexSifre.Replace('Ş', 'S');
            regexSifre = regexSifre.Replace('ş', 's');
            regexSifre = regexSifre.Replace('Ğ', 'G');
            regexSifre = regexSifre.Replace('ğ', 'g');
            regexSifre = regexSifre.Replace('Ü', 'U');
            regexSifre = regexSifre.Replace('ü', 'u');
            regexSifre = regexSifre.Replace('Ö', 'O');
            regexSifre = regexSifre.Replace('ö', 'o');
            if (sifre != regexSifre)
            {
                sifre = regexSifre;
                kesifreBox.Text = sifre;
                MessageBox.Show("Paroladaki Türkçe karakterler ingilizce karakter dönüştürülmüştür!!!");
            }
            int az_karakter_sayisi = sifre.Length - Regex.Replace(sifre, "[a-z]", "").Length;
            int AZ_karakter_sayisi = sifre.Length - Regex.Replace(sifre, "[A-Z]", "").Length;
            int rakamSayisi = sifre.Length - Regex.Replace(sifre, "[0-9]", "").Length;
            int sembolSayisi = sifre.Length - az_karakter_sayisi - AZ_karakter_sayisi - rakamSayisi;
            //Düzenle giriş butonunun içine atılabilir
            if (az_karakter_sayisi >= 1 && AZ_karakter_sayisi >= 1 && rakamSayisi >= 1 && sembolSayisi >= 1) { errorProvider1.Clear(); }


            else
                errorProvider1.SetError(kesifreBox, "Güvenli şifre en az 1 tane küçük, büyük, sayı ve özel karakter içermelidir");
        }

        private void sifretkontrol_TextChanged(object sender, EventArgs e)
        {
            if (kesifretBox.Text != kesifreBox.Text)
                errorProvider1.SetError(kesifretBox, "Parolalar eşleşmiyor!");
            else
                errorProvider1.Clear();
        }
        private void kullanıcıeklepageTemizle()
        {
            ketcBox.Clear(); keadBox.Clear(); kesoyadBox.Clear(); kekulladıBox.Clear(); kesifreBox.Clear(); kesifretBox.Clear(); kedairenoBox.Clear();
            kstcBox.Clear();
        }
        private void plakapeageTemizle()
        {
            aetcBox.Clear(); aedairenoBox.Clear(); aeadBox.Clear(); aesoyadBox.Clear(); aeplakaBox.Clear();
            pstcnoBox.Clear(); psadBox.Clear(); pssoyadBox.Clear(); psdairenoBox.Clear();
        }
        private void borceklepageTemizle() {
            bedairenoBox.Clear(); betutarBox.Clear();
        }
        private void duyurueklepageTemizle()
        {
            dekonuBox.Clear(); deacıklamaBox.Clear();
        }

        private void keButton_Click(object sender, EventArgs e)
        {
            string yetki = "";
            //daha önce aynı kayıt olup olmadığını kontrol etmek için
            bool kayitkontrol = false;
            baglantim.Open();
            SqlCommand command = new SqlCommand("select * from kullanicilar where tcno='" + ketcBox.Text + "'", baglantim);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                kayitkontrol = true;
                break;
            }
            baglantim.Close();
            if (kayitkontrol == false)
            {   //tc no
                if (ketcBox.Text.Length < 11 || ketcBox.Text == "")
                    label1.ForeColor = Color.Red;
                else
                    label1.ForeColor = Color.Black;
                //ad
                if (keadBox.Text.Length < 2 || keadBox.Text == "")
                    label2.ForeColor = Color.Red;
                else
                    label2.ForeColor = Color.Black;
                //soyad
                if (kesoyadBox.Text.Length < 2 || kesoyadBox.Text == "")
                    label3.ForeColor = Color.Red;
                else
                    label3.ForeColor = Color.Black;
                //kullanıcı adı
                if (kekulladıBox.Text.Length < 4 || kekulladıBox.Text == "")
                    label5.ForeColor = Color.Red;
                else
                    label5.ForeColor = Color.Black;
                //sifre tekrar
                if (kesifretBox.Text == "" || kesifretBox.Text != kesifreBox.Text)
                    label1.ForeColor = Color.Red;
                else
                    label1.ForeColor = Color.Black;

                if (ketcBox.Text.Length == 11 && keadBox.Text.Length > 1 && kesoyadBox.Text.Length > 1 &&
                        kesifreBox.Text.Length > 1 && kesifretBox.Text == kesifreBox.Text)
                {
                    if (radioButton1.Checked == true)
                        yetki = "Yönetici";
                    else if (radioButton2.Checked == true)
                        yetki = "Kullanıcı";
                    try
                    {
                        baglantim.Open();
                        SqlCommand kullanicicbilgisiekleme = new SqlCommand("insert into kullanicilar(kullaniciadi,sifre,yetki,tcno,ad,soyad,daireno) values (@kullaniciadi,@sifre,@yetki,@tcno,@ad,@soyad,@daireno)", baglantim);
                        kullanicicbilgisiekleme.Parameters.AddWithValue("@kullaniciadi", kekulladıBox.Text);
                        kullanicicbilgisiekleme.Parameters.AddWithValue("@sifre", kesifreBox.Text);
                        kullanicicbilgisiekleme.Parameters.AddWithValue("@yetki", yetki);
                        kullanicicbilgisiekleme.Parameters.AddWithValue("@tcno", ketcBox.Text);
                        kullanicicbilgisiekleme.Parameters.AddWithValue("@ad", keadBox.Text);
                        kullanicicbilgisiekleme.Parameters.AddWithValue("@soyad", kesoyadBox.Text);
                        kullanicicbilgisiekleme.Parameters.AddWithValue("@daireno", kedairenoBox.Text);
                        kullanicicbilgisiekleme.ExecuteNonQuery();
                        kullanicicbilgisiekleme.Dispose();

                        /*SqlCommand borctable = new SqlCommand("insert into borcbilgisi(tcno,ad,soyad) values(@tcno,@ad,@soyad)", baglantim);
                        borctable.Parameters.AddWithValue("@tcno", ketcBox.Text);
                        borctable.Parameters.AddWithValue("@ad", keadBox.Text);
                        borctable.Parameters.AddWithValue("@soyad", kesoyadBox.Text);
                        borctable.ExecuteNonQuery();
                        borctable.Dispose();
                        baglantim.Close();
                        MessageBox.Show("Yeni kullanıcı kaydı oluşturuldu.", "Apartman Yönetim Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        kullanıcıeklepageTemizle();*/
                        kullanıcıeklepageTemizle();
                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show(hata.Message);
                        baglantim.Close();
                        throw;
                    }
                }
                else
                    MessageBox.Show("Lütfen girilen bilgileri gözden geçiriniz!!!", "Apartman Yönetim Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Girilen Tc kimlik numrası daha önceden kayıtlıdır!!!", "Apartman Yönetim Sistemi",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
            kullanicilari_goster();
            reader.Close();
            baglantim.Close();
        }

        private void ksButton_Click(object sender, EventArgs e)
        {
            bool kayitkontrol = false;
            baglantim.Open();
            SqlCommand kontrol = new SqlCommand("select * from kullanicilar where tcno=@tcno", baglantim);
            kontrol.Parameters.AddWithValue("@tcno", kstcBox.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(kontrol);
            SqlDataReader reader = kontrol.ExecuteReader();
            //eğer değer okunursa
            if (reader.Read())
            {
                string kbilgisi = reader["ad"].ToString() + " " + reader["soyad"].ToString() + " Daire No: " + reader["daireno"].ToString();
                reader.Close();
                DialogResult dialogResult = MessageBox.Show(kbilgisi + " bilgili kaydı silmek istediğinize emin misiniz?", "Kullanıcı Silme", MessageBoxButtons.YesNo);

                if (DialogResult.Yes == dialogResult)
                {
                    try
                    {
                        SqlCommand kullanicisilme = new SqlCommand("Delete from kullanicilar where tcno=@tcno", baglantim);
                        kullanicisilme.Parameters.AddWithValue("@tcno", kstcBox.Text);
                        kullanicisilme.ExecuteNonQuery();
                        kullanicisilme.Dispose();

                        /*SqlCommand kullaniciborctable = new SqlCommand("Delete from borcbilgisi where tcno=@tcno", baglantim);
                        kullaniciborctable.Parameters.AddWithValue("@tcno", kstcBox.Text);
                        kullaniciborctable.ExecuteNonQuery();
                        kullaniciborctable.Dispose();*/
                        
                        MessageBox.Show("Kullanıcı Silme Başarılı", "Kullanıcı Silme");
                        baglantim.Close();
                        kullanıcıeklepageTemizle();
                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show(hata.Message);
                        baglantim.Close();
                        throw;
                    }
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı Bulunamadı!!!", "Kullanıcı Silme");
                baglantim.Close();
            }
            reader.Close();
            kullanicilari_goster();
            baglantim.Close();
            kontrol.Dispose();
            
        }

        private void plakaekle_Click(object sender, EventArgs e)
        {
            baglantim.Open();
            //Select from * kullanicilar (daireno,ad,soyad,plakano) values (@daireno,@ad,@soyad,@plakano)", baglantim
            SqlCommand command = new SqlCommand("select * from kullanicilar where tcno ='" + aetcBox.Text + "'", baglantim);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                //&& reader["plakano"] == null 
                if (reader["tcno"].ToString() == aetcBox.Text && reader["daireno"].ToString() == aedairenoBox.Text && reader["ad"].ToString() == aeadBox.Text && reader["soyad"].ToString() == aesoyadBox.Text ) 
                {
                    SqlCommand plakaekle = new SqlCommand("update kullanicilar set plakano=@plakano where tcno= '" + aetcBox.Text + "'", baglantim);
                    reader.Close();
                    command.Dispose();
                    try
                    {
                        plakaekle.Parameters.AddWithValue("@plakano", aeplakaBox.Text);
                        plakaekle.ExecuteNonQuery();
                        MessageBox.Show("Plaka Başarıyla Eklendi.");
                        baglantim.Close();
                        plakaekle.Dispose();
                        plakapeageTemizle();
                        kullanicilari_goster();
                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show(hata.Message);
                        baglantim.Close();
                        throw;
                    }
                    
                }
                else if (reader["plakano"] != null) 
                    MessageBox.Show("Kullanıcı bilgilerinde zaten plaka var!!!", "Plaka Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                else
                    MessageBox.Show("Kullanıcı Bulunamadı girilen değerleri kontrol ediniz!","Araç Ekleme",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                break;
            }
            reader.Close();
            command.Dispose();
            baglantim.Close();
        }

        private void plakasil_Click(object sender, EventArgs e)
        {
            baglantim.Open();
            SqlCommand command = new SqlCommand("select * from kullanicilar where tcno='" + pstcnoBox.Text + "'", baglantim);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                //&& reader["plakano"].ToString() == psplakanoBox.Text
                if (reader["tcno"].ToString() == pstcnoBox.Text && reader["daireno"].ToString() == psdairenoBox.Text && reader["ad"].ToString() == psadBox.Text && reader["soyad"].ToString() == pssoyadBox.Text )
                {
                    SqlCommand plakasil = new SqlCommand("update kullanicilar set plakano=@plakano where tcno= '" + pstcnoBox.Text + "'", baglantim);
                    reader.Close();
                    command.Dispose();
                    try
                    {
                        plakasil.Parameters.AddWithValue("@plakano", "");
                        plakasil.ExecuteNonQuery();
                        MessageBox.Show("Plaka Başarıyla Silindi.");
                        baglantim.Close();
                        plakasil.Dispose();
                        plakapeageTemizle();
                        kullanicilari_goster();
                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show(hata.Message);
                        baglantim.Close();
                        throw;
                    }
                }
                else
                    MessageBox.Show("Kullanıcı Bulunamadı girilen değerleri kontrol ediniz!", "Plaka Silme ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                break;
            }
            reader.Close();
            command.Dispose();
            baglantim.Close();
        }

        private void duyurubutton_Click(object sender, EventArgs e)
        {
            
            try{
                baglantim.Open();
                SqlCommand command = new SqlCommand("insert into duyuru (duyuru,duyurukonusu,tarih) values (@duyuru,@duyurukonusu,@tarih)", baglantim);
                command.Parameters.AddWithValue("@duyuru", deacıklamaBox.Text);
                command.Parameters.AddWithValue("@duyurukonusu", dekonuBox.Text);
                command.Parameters.AddWithValue("@tarih", dateTimePicker2.Value);
                command.ExecuteNonQuery();
                command.Dispose();
                baglantim.Close();
                duyurueklepageTemizle();
                MessageBox.Show("Duyuru Oluşturuldu.", "Apartman Yönetim Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                duyurulari_goster();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                baglantim.Close();
                throw;
            }
            baglantim.Close();
        }

        private void duyurusil_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView2.Rows)
            {
                int n = dataGridView2.Rows.Cast<DataGridViewRow>().Where(p=>Convert.ToBoolean(p.Cells["Selected"].Value)==true).Count();
                //dataGridView2.Rows[n].Cells[1].Value = item["duyukonusu"].ToString();
                if (n>=1)
                   // && MessageBox.Show("Seçilenleri silmek istediğinize emin misiniz?", "Duyuru", MessageBoxButtons.YesNo) == DialogResult.Yes
                {
                    if (MessageBox.Show("Seçilen duyurular silinsin mi?", "Başlık", MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                    {
                        for (int i = dataGridView2.RowCount-1 ; i >=0 ; i--)
                        {
                            DataGridViewRow row = dataGridView2.Rows[i];
                            if (Convert.ToBoolean(row.Cells["Selected"].Value)==true)
                            {
                                try
                                {
                                    baglantim.Open();
                                    SqlCommand command = new SqlCommand("Delete from duyuru where duyuru=@duyuru", baglantim);
                                    command.Parameters.AddWithValue("@duyuru",Convert.ToString(row.Cells["duyuru"].Value));
                                    command.ExecuteNonQuery();
                                    command.Dispose();                                    
                                    baglantim.Close();
                                    MessageBox.Show("Seçilen duyurular silindi", "Duyuru");
                                    duyurulari_goster();
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
                    
                }
                break;
            }
        }

       
        private void daireyeborcekle_Click(object sender, EventArgs e)
        {
            baglantim.Open();
            SqlCommand command = new SqlCommand("select * from kullanicilar where daireno='" + bedairenoBox.Text + "'", baglantim);
            SqlDataReader reader = command.ExecuteReader();
            bool kayitkontrol = false;

            while (reader.Read())
            {
                kayitkontrol = true;
                if (reader["daireno"].ToString() == bedairenoBox.Text)
                {
                    try
                    {
                        SqlCommand kborcekle = new SqlCommand("insert into borcbilgisi(kategori,ad,soyad,tutar,daireno,tarih) values (@kategori,@ad,@soyad,@tutar,@daireno,@tarih)", baglantim);
                        kborcekle.Parameters.AddWithValue("@kategori", comboBox2.Text);
                        kborcekle.Parameters.AddWithValue("@ad", reader["ad"].ToString());
                        kborcekle.Parameters.AddWithValue("@soyad", reader["soyad"].ToString());
                        kborcekle.Parameters.AddWithValue("@tutar", betutarBox.Text);
                        kborcekle.Parameters.AddWithValue("@daireno", bedairenoBox.Text);
                        kborcekle.Parameters.AddWithValue("@tarih", dateTimePicker3.Value);
                        reader.Close();
                        kborcekle.ExecuteNonQuery();
                        kborcekle.Dispose();
                        baglantim.Close();
                        MessageBox.Show("Kullanıcıya borc eklenedi", "Borç Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        label17.ForeColor = Color.Black;
                        kullanicilari_goster();
                        command.Dispose();
                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show(hata.Message);
                        baglantim.Close();
                        throw;
                    }
                }
                else if (reader["daireno"].ToString() != bedairenoBox.Text)
                {
                    label17.ForeColor = Color.Red;
                    MessageBox.Show("Lütfen daire numarasını kontrol ediniz", "Borç Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                break;
            }
            if (kayitkontrol == false)
                MessageBox.Show("Kullanıcı bulunamadı", "Borç Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Error);
            reader.Close();
            baglantim.Close();
            command.Dispose();
            kullanicilari_goster();
            borceklepageTemizle();
            borclari_goster();
        }

        
    }
}