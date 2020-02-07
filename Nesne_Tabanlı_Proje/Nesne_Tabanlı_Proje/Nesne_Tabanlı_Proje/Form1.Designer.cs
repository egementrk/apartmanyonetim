namespace Nesne_Tabanlı_Proje
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.kullaniciadiText = new System.Windows.Forms.TextBox();
            this.sifreText = new System.Windows.Forms.TextBox();
            this.yoneticiRadio = new System.Windows.Forms.RadioButton();
            this.kullaniciRadio = new System.Windows.Forms.RadioButton();
            this.girisButton = new System.Windows.Forms.Button();
            this.sifreButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(38, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Kullanıcı Adı";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(38, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Şifre";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(38, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Yetki";
            // 
            // kullaniciadiText
            // 
            this.kullaniciadiText.Location = new System.Drawing.Point(265, 44);
            this.kullaniciadiText.Name = "kullaniciadiText";
            this.kullaniciadiText.Size = new System.Drawing.Size(100, 22);
            this.kullaniciadiText.TabIndex = 1;
            // 
            // sifreText
            // 
            this.sifreText.Location = new System.Drawing.Point(265, 103);
            this.sifreText.Name = "sifreText";
            this.sifreText.Size = new System.Drawing.Size(100, 22);
            this.sifreText.TabIndex = 1;
            // 
            // yoneticiRadio
            // 
            this.yoneticiRadio.AutoSize = true;
            this.yoneticiRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.yoneticiRadio.Location = new System.Drawing.Point(185, 168);
            this.yoneticiRadio.Name = "yoneticiRadio";
            this.yoneticiRadio.Size = new System.Drawing.Size(87, 21);
            this.yoneticiRadio.TabIndex = 2;
            this.yoneticiRadio.TabStop = true;
            this.yoneticiRadio.Text = "Yönetici";
            this.yoneticiRadio.UseVisualStyleBackColor = true;
            // 
            // kullaniciRadio
            // 
            this.kullaniciRadio.AutoSize = true;
            this.kullaniciRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kullaniciRadio.Location = new System.Drawing.Point(334, 168);
            this.kullaniciRadio.Name = "kullaniciRadio";
            this.kullaniciRadio.Size = new System.Drawing.Size(90, 21);
            this.kullaniciRadio.TabIndex = 2;
            this.kullaniciRadio.TabStop = true;
            this.kullaniciRadio.Text = "Kullanıcı";
            this.kullaniciRadio.UseVisualStyleBackColor = true;
            // 
            // girisButton
            // 
            this.girisButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.girisButton.Location = new System.Drawing.Point(26, 264);
            this.girisButton.Name = "girisButton";
            this.girisButton.Size = new System.Drawing.Size(118, 82);
            this.girisButton.TabIndex = 3;
            this.girisButton.Text = "Giriş Yap";
            this.girisButton.UseVisualStyleBackColor = true;
            this.girisButton.Click += new System.EventHandler(this.girisButton_Click_1);
            // 
            // sifreButton
            // 
            this.sifreButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sifreButton.Location = new System.Drawing.Point(26, 405);
            this.sifreButton.Name = "sifreButton";
            this.sifreButton.Size = new System.Drawing.Size(118, 92);
            this.sifreButton.TabIndex = 3;
            this.sifreButton.Text = "Şifremi Unuttum";
            this.sifreButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(728, 776);
            this.Controls.Add(this.sifreButton);
            this.Controls.Add(this.girisButton);
            this.Controls.Add(this.kullaniciRadio);
            this.Controls.Add(this.yoneticiRadio);
            this.Controls.Add(this.sifreText);
            this.Controls.Add(this.kullaniciadiText);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox kullaniciadiText;
        private System.Windows.Forms.TextBox sifreText;
        private System.Windows.Forms.RadioButton yoneticiRadio;
        private System.Windows.Forms.RadioButton kullaniciRadio;
        private System.Windows.Forms.Button girisButton;
        private System.Windows.Forms.Button sifreButton;
    }
}

