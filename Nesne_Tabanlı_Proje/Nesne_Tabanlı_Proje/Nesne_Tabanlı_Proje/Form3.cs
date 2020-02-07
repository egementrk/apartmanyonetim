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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection baglantim = new SqlConnection("Data Source=DESKTOP-LL3F1LR;Initial Catalog=kullanicilar;Integrated Security=True");
        private void Form3_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }

        private void Form3_Load_1(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'kullanicilarborck.borcbilgisi' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.borcbilgisiTableAdapter.Fill(this.kullanicilarborck.borcbilgisi);

        }
    }
}
