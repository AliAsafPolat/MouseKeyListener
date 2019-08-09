using Gma.System.MouseKeyHook;
using System;
using System.Windows.Forms;

namespace MouseKeyTry
{
    partial class Form1
    {
        private static IKeyboardMouseEvents m_GlobalHook;

        public void subscribe()
        {
            m_GlobalHook = Hook.GlobalEvents();

            m_GlobalHook.MouseDownExt += GlobalHookMouseDownExt;
            m_GlobalHook.KeyPress += GlobalHookKeyPress;
        }

        private void GlobalHookKeyPress(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine("KeyPress: \t{0}", e.KeyChar);
        }

        private void GlobalHookMouseDownExt(object sender, MouseEventExtArgs e)
        {
            Console.WriteLine("MouseDown: \t{0}; \t System Timestamp: \t{1}", e.Button, e.Timestamp);

            // uncommenting the following line will suppress the middle mouse button click
            // if (e.Buttons == MouseButtons.Middle) { e.Handled = true; }
        }
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.radioKayitEt = new System.Windows.Forms.RadioButton();
            this.radioKayitOynat = new System.Windows.Forms.RadioButton();
            this.radioAskerBas = new System.Windows.Forms.RadioButton();
            this.radioKahramanaBak = new System.Windows.Forms.RadioButton();
            this.lblLogText = new System.Windows.Forms.Label();
            this.pnlSol = new System.Windows.Forms.Panel();
            this.GrBxKayıt = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioYagmaYap = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnKaydiOynat = new System.Windows.Forms.Button();
            this.btnYeniKayit = new System.Windows.Forms.Button();
            this.btnOtoPilot = new System.Windows.Forms.Button();
            this.pnlSol.SuspendLayout();
            this.GrBxKayıt.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLog.Location = new System.Drawing.Point(534, 73);
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(412, 376);
            this.txtLog.TabIndex = 1;
            this.txtLog.Text = "";
            // 
            // radioKayitEt
            // 
            this.radioKayitEt.AutoSize = true;
            this.radioKayitEt.Location = new System.Drawing.Point(6, 23);
            this.radioKayitEt.Name = "radioKayitEt";
            this.radioKayitEt.Size = new System.Drawing.Size(88, 24);
            this.radioKayitEt.TabIndex = 4;
            this.radioKayitEt.TabStop = true;
            this.radioKayitEt.Text = "Kayıt Et";
            this.radioKayitEt.UseVisualStyleBackColor = true;
            // 
            // radioKayitOynat
            // 
            this.radioKayitOynat.AutoSize = true;
            this.radioKayitOynat.Location = new System.Drawing.Point(6, 64);
            this.radioKayitOynat.Name = "radioKayitOynat";
            this.radioKayitOynat.Size = new System.Drawing.Size(116, 24);
            this.radioKayitOynat.TabIndex = 5;
            this.radioKayitOynat.TabStop = true;
            this.radioKayitOynat.Text = "Kayıt Oynat";
            this.radioKayitOynat.UseVisualStyleBackColor = true;
            // 
            // radioAskerBas
            // 
            this.radioAskerBas.AutoSize = true;
            this.radioAskerBas.Location = new System.Drawing.Point(6, 75);
            this.radioAskerBas.Name = "radioAskerBas";
            this.radioAskerBas.Size = new System.Drawing.Size(108, 24);
            this.radioAskerBas.TabIndex = 2;
            this.radioAskerBas.TabStop = true;
            this.radioAskerBas.Text = "Asker Bas";
            this.radioAskerBas.UseVisualStyleBackColor = true;
            this.radioAskerBas.CheckedChanged += new System.EventHandler(this.radioAskerBas_CheckedChanged);
            // 
            // radioKahramanaBak
            // 
            this.radioKahramanaBak.AutoSize = true;
            this.radioKahramanaBak.Location = new System.Drawing.Point(6, 48);
            this.radioKahramanaBak.Name = "radioKahramanaBak";
            this.radioKahramanaBak.Size = new System.Drawing.Size(149, 24);
            this.radioKahramanaBak.TabIndex = 1;
            this.radioKahramanaBak.TabStop = true;
            this.radioKahramanaBak.Text = "Kahramana Bak";
            this.radioKahramanaBak.UseVisualStyleBackColor = true;
            this.radioKahramanaBak.CheckedChanged += new System.EventHandler(this.radioKahramanaBak_CheckedChanged);
            // 
            // lblLogText
            // 
            this.lblLogText.AutoSize = true;
            this.lblLogText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblLogText.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblLogText.Location = new System.Drawing.Point(541, 39);
            this.lblLogText.Name = "lblLogText";
            this.lblLogText.Size = new System.Drawing.Size(131, 20);
            this.lblLogText.TabIndex = 11;
            this.lblLogText.Text = "Komut Sistemi";
            // 
            // pnlSol
            // 
            this.pnlSol.BackColor = System.Drawing.Color.Gray;
            this.pnlSol.Controls.Add(this.GrBxKayıt);
            this.pnlSol.Controls.Add(this.groupBox1);
            this.pnlSol.Location = new System.Drawing.Point(0, -1);
            this.pnlSol.Name = "pnlSol";
            this.pnlSol.Size = new System.Drawing.Size(535, 450);
            this.pnlSol.TabIndex = 12;
            // 
            // GrBxKayıt
            // 
            this.GrBxKayıt.Controls.Add(this.radioKayitOynat);
            this.GrBxKayıt.Controls.Add(this.radioKayitEt);
            this.GrBxKayıt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.GrBxKayıt.Location = new System.Drawing.Point(38, 179);
            this.GrBxKayıt.Name = "GrBxKayıt";
            this.GrBxKayıt.Size = new System.Drawing.Size(200, 100);
            this.GrBxKayıt.TabIndex = 13;
            this.GrBxKayıt.TabStop = false;
            this.GrBxKayıt.Text = "İşlemler";
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.Controls.Add(this.radioAskerBas);
            this.groupBox1.Controls.Add(this.radioYagmaYap);
            this.groupBox1.Controls.Add(this.radioKahramanaBak);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(302, 172);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(197, 107);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "";
            this.groupBox1.Text = "Kayıt Olayları";
            // 
            // radioYagmaYap
            // 
            this.radioYagmaYap.AutoSize = true;
            this.radioYagmaYap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.radioYagmaYap.Location = new System.Drawing.Point(6, 21);
            this.radioYagmaYap.Name = "radioYagmaYap";
            this.radioYagmaYap.Size = new System.Drawing.Size(114, 24);
            this.radioYagmaYap.TabIndex = 0;
            this.radioYagmaYap.TabStop = true;
            this.radioYagmaYap.Text = "Yagma Yap";
            this.radioYagmaYap.UseVisualStyleBackColor = true;
            this.radioYagmaYap.CheckedChanged += new System.EventHandler(this.radioYagmaYap_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CadetBlue;
            this.panel1.Controls.Add(this.btnKaydiOynat);
            this.panel1.Controls.Add(this.btnYeniKayit);
            this.panel1.Controls.Add(this.btnOtoPilot);
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(535, 122);
            this.panel1.TabIndex = 13;
            // 
            // btnKaydiOynat
            // 
            this.btnKaydiOynat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnKaydiOynat.Image = global::MouseKeyTry.Properties.Resources.play;
            this.btnKaydiOynat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKaydiOynat.Location = new System.Drawing.Point(183, 23);
            this.btnKaydiOynat.Name = "btnKaydiOynat";
            this.btnKaydiOynat.Size = new System.Drawing.Size(178, 68);
            this.btnKaydiOynat.TabIndex = 2;
            this.btnKaydiOynat.Text = "Kayıt Oynat";
            this.btnKaydiOynat.UseVisualStyleBackColor = true;
            this.btnKaydiOynat.Click += new System.EventHandler(this.btnKaydiOynat_Click);
            // 
            // btnYeniKayit
            // 
            this.btnYeniKayit.FlatAppearance.BorderSize = 0;
            this.btnYeniKayit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnYeniKayit.Image = global::MouseKeyTry.Properties.Resources.sign;
            this.btnYeniKayit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnYeniKayit.Location = new System.Drawing.Point(12, 23);
            this.btnYeniKayit.Name = "btnYeniKayit";
            this.btnYeniKayit.Size = new System.Drawing.Size(165, 68);
            this.btnYeniKayit.TabIndex = 3;
            this.btnYeniKayit.Text = "Yeni Kayıt";
            this.btnYeniKayit.UseVisualStyleBackColor = true;
            this.btnYeniKayit.Click += new System.EventHandler(this.btnYeniKayit_Click);
            // 
            // btnOtoPilot
            // 
            this.btnOtoPilot.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOtoPilot.Image = global::MouseKeyTry.Properties.Resources.auto;
            this.btnOtoPilot.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOtoPilot.Location = new System.Drawing.Point(367, 23);
            this.btnOtoPilot.Name = "btnOtoPilot";
            this.btnOtoPilot.Size = new System.Drawing.Size(165, 68);
            this.btnOtoPilot.TabIndex = 10;
            this.btnOtoPilot.Text = "Otopilot Al";
            this.btnOtoPilot.UseVisualStyleBackColor = true;
            this.btnOtoPilot.Click += new System.EventHandler(this.btnOtoPilot_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(945, 451);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlSol);
            this.Controls.Add(this.lblLogText);
            this.Controls.Add(this.txtLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(967, 505);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "TravianTry";
            this.TransparencyKey = System.Drawing.SystemColors.ControlDark;
            this.pnlSol.ResumeLayout(false);
            this.GrBxKayıt.ResumeLayout(false);
            this.GrBxKayıt.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private RichTextBox txtLog;
        private Button btnKaydiOynat;
        private Button btnYeniKayit;
        private RadioButton radioKayitEt;
        private RadioButton radioKayitOynat;
        private RadioButton radioAskerBas;
        private RadioButton radioKahramanaBak;
        private RadioButton radioYagmaYap;
        private Button btnOtoPilot;
        private Label lblLogText;
        private Panel pnlSol;
        private GroupBox groupBox1;
        private GroupBox GrBxKayıt;
        private Panel panel1;
    }
}

