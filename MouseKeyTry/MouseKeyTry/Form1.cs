using Gma.System.MouseKeyHook;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace MouseKeyTry
{
    public partial class Form1 : Form
    {
        #region Field Tanımları
        private static IKeyboardMouseEvents m_Events;
        private static bool KayitDevamEdiyorMu = false;
        private static string dosyaAdi="";
        private const int minSecim= 1;
        private const int maxSecim = 3;
        private bool OtoPilotDevam = false;
        private string yagmaYap = "YagmaDosyasi.txt";
        private string askerBas = "AskerBasmaDosyasi.txt";
        private string kahramanaBak = "KahramanaBakmaDosyasi.txt";
        #endregion

        #region Form Constructoru
        public Form1()
        {
   
            InitializeComponent();
            subscribeGlobal(Hook.GlobalEvents());
        }
        #endregion

        #region Event Tanımları
        public void subscribeGlobal(IKeyboardMouseEvents events)
        {
            
            m_Events = events;
            m_Events.KeyDown += OnKeyDown;
            m_Events.KeyUp += OnKeyUp;
            m_Events.KeyPress += HookManager_KeyPress;

            m_Events.MouseUp += OnMouseUp;
            m_Events.MouseClick += OnMouseClick;
            m_Events.MouseDoubleClick += OnMouseDoubleClick;
            m_Events.MouseWheel += M_Events_MouseWheel;
            m_Events.MouseMove += HookManager_MouseMove;
          
           
        }


        private void unsubscribeGlobal(IKeyboardMouseEvents events)
        {
            m_Events = events;
            m_Events.KeyDown -= OnKeyDown;
            m_Events.KeyUp += OnKeyUp;
            m_Events.KeyPress -= HookManager_KeyPress;

            m_Events.MouseUp -= OnMouseUp;
            m_Events.MouseClick -= OnMouseClick;
            m_Events.MouseDoubleClick -= OnMouseDoubleClick;
            

            m_Events.MouseMove -= HookManager_MouseMove;
        }

        #endregion

        #region Key Eventları
        private void HookManager_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            //OtoPilotDevam = false;
            #region Kayıt Bitirme Kısmı
            if (e.KeyChar == '*')                       // yıldıza basıldığı anda kaydı bitiriyor. Sonrasında txtlog a yazılanlar bir şeyi değiştirmez.
            {
                radioKayitEt.Checked = false;
                KayitDevamEdiyorMu = false;
                string str = "";

                using (StreamWriter sw = new StreamWriter(dosyaAdi, false))
                {

                    foreach (char s in txtLog.Text)
                    {
                        if (s != '\n')      // char char okuma yaptığı için boşluk karakterine kadar okuma yapsın.
                            str += s;
                        else
                        {
                            sw.WriteLine(str);
                            str = "";
                        }
                    }
                    sw.Close();
                }
                string log = dosyaAdi;
                string logg = log.Substring(0, log.Length - 4);         // sonuna .txt yazdırmak için.
                txtLog.AppendText(logg + "islemi kaydedildi.\n");
                KayitSecimleriniSifirla();
                txtLog.Text ="";
                #endregion
                e.Handled = true;
               // unsubscribeGlobal(Hook.GlobalEvents());
            }
            else if (e.KeyChar == (char)13)                                         // Entera basılmış demektir.
            {
                if(KayitDevamEdiyorMu)
                txtLog.AppendText("#e" + "\n" +"Enter Basildi" + "\n");
                e.Handled = true;
            }
            else                                                                    //* geldiyse sonlandırması gerektiğini anlıyorum.
            {
                if (KayitDevamEdiyorMu)
                txtLog.AppendText("#c"+"\n"+e.KeyChar+"\n");                        // Text geldiği zaman ekrana klavye tuşlarını basması lazım.Burada yazdırırken yine txtLog a yazma yapıyor.
                else
                {                
                    e.Handled = true;
                }   
            }
            
        }
      
        public void OnKeyDown(object sender, KeyEventArgs e)        
        {
            if (e.KeyData == Keys.End)                              // End tuşuna basıldığı zaman otopilottan çıksın.
            {
                OtoPilotDevam = false;
                KayitSecimleriniSifirla();
                txtLog.Text = "";
                //MessageBox.Show("Program Sonlanmistir");          // Mesaj da gösterilebilir fakat tamam tuşuna basmak durumunda kalınıyor.
                this.Close();
            }
           // txtLog.AppendText(e.KeyValue.ToString()+ "\n");
           // txtLog.ScrollToCaret();
        }

        public void OnKeyUp(object sender, KeyEventArgs e)
        {
          //  txtLog.AppendText(e.KeyValue.ToString() + "\n");
           // txtLog.ScrollToCaret();
        }
        #endregion

        #region Mouse Eventları
        public void OnMouseUp(object sender,MouseEventArgs e)
        {
         //   txtLog.AppendText(e.X.ToString() + "\n" + e.Y.ToString() + "\n");
         //   txtLog.ScrollToCaret();
        }

        public void OnMouseClick(object sender,MouseEventArgs e)                                // Click eventi geldiği zaman click yapmasını istiyorum.
        {
            int cur_x = System.Windows.Forms.Cursor.Position.X;
            int cur_y = System.Windows.Forms.Cursor.Position.Y;
            switch (e.Button)
            {
                case MouseButtons.Left:
                   
                    if (KayitDevamEdiyorMu)
                        txtLog.AppendText("#m" + "\n" + cur_x.ToString() + "\n" + cur_y.ToString() + "\n");
                    txtLog.ScrollToCaret();
                    break;
                case MouseButtons.Right:
                
                    if (KayitDevamEdiyorMu)
                        txtLog.AppendText("#rm" + "\n" + cur_x.ToString() + "\n" + cur_y.ToString() + "\n");
                    txtLog.ScrollToCaret();
                    break;
            }
            
        }

        

        private void HookManager_MouseMove(object sender, MouseEventArgs e)
        {

            //OtoPilotDevam = false;
                int cur_x = System.Windows.Forms.Cursor.Position.X;
                int cur_y = System.Windows.Forms.Cursor.Position.Y;
                
                if(KayitDevamEdiyorMu)
                     txtLog.AppendText(cur_x.ToString() + "\n" + cur_y.ToString() + "\n");

                txtLog.ScrollToCaret();
            
        }

        public void OnMouseDoubleClick(object sender,MouseEventArgs e)
        {
            int cur_x = System.Windows.Forms.Cursor.Position.X;
            int cur_y = System.Windows.Forms.Cursor.Position.Y;
            if (KayitDevamEdiyorMu)
                txtLog.AppendText("#dm" + "\n" + cur_x.ToString() + "\n" + cur_y.ToString() + "\n");
            txtLog.ScrollToCaret();
        }

        private void M_Events_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0 && KayitDevamEdiyorMu)   // Eğer böyle bir şey var ise delta değeri 120 dir ve yukarı hareket ediyordur.
            {
                txtLog.AppendText("#up" + "\n" + "\n");
            }
            else if (e.Delta < 0 && KayitDevamEdiyorMu)
            {
                txtLog.AppendText("#down" + "\n" + "\n");
            }
        }

        #endregion

        #region Buton Tıklamaları

        private void btnYeniKayit_Click(object sender, EventArgs e)
        {
            OtoPilotDevam = false;                                              // Otopilot çalışırken yeni kayıt denemesi gelirse otopilot sonlansın.

            if (radioKayitEt.Checked&&!radioKayitOynat.Checked&&dosyaAdi!=null)                                    //Kayıt Butonuna basıldığında kayıt yapsın istiyorum. Aksi hallerde yazdırmasını istiyorum.
            {
                txtLog.Clear();     // Yeni kayıttan önce kutuyu her zaman temizle.

                this.Cursor = new Cursor(Cursor.Current.Handle);
                Cursor.Position = new Point(0, 0);                        // Butona basıldığı zaman tam butonun kordinatına gelsin.
                Cursor.Clip = new Rectangle(Cursor.Position, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size);

                KayitDevamEdiyorMu = true;
                

                this.ShowIcon = false;                                      // Bu windowun penceresinde bulunan iconu yokeder.
                this.ShowInTaskbar = true;                                    // Default olarak true dır bunun değeri.
                this.WindowState = FormWindowState.Minimized;               // Bu kısım başladığında direkt aşağı çekiyor.
            }
           
        }

        private void btnKaydiOynat_Click(object sender, EventArgs e)
        {
            KayitDevamEdiyorMu = false;
            if ((radioKayitOynat.Checked && !radioKayitEt.Checked))
            {
                this.WindowState = FormWindowState.Minimized;
                // unsubscribeGlobal(Hook.GlobalEvents());                             // Yeni Kayıt yapılmadan önceki kayıtlar kullanılacak ise bu tanımlama gerekecektir.
                //OtoPilotDevam = true;
                string line  = "";
                string line2 = "";
                int x = 0, y = 0;

                using (StreamReader sr = new StreamReader(dosyaAdi))                // Seçilen butona göre dosya adini aliyor.
                {
                    while ((line = sr.ReadLine()) != null && (line2 = sr.ReadLine()) != null)      // false kısmına kontrol gelicek.
                    {
                        if (line.CompareTo("#c") == 0)                  // eğer bu kısım sıfırsa line2 bunu almıştır.
                        {
                            SendKeys.SendWait(line2);
                            Thread.Sleep(100);
                            // SendKeys.Send(line2);
                            //line2;    
                        }
                        else if (line2.CompareTo("#c") == 0)           // Tekrardan okuma yapmam gerekecek çünkü bir sonraki satıra yazdırdım.
                        {
                            line = sr.ReadLine();
                            SendKeys.Send(line);
                            Thread.Sleep(100);
                            //SendKeys.Send(line);
                        }
                        else if (line.CompareTo("#m") == 0)
                        {
                            line = sr.ReadLine();                       // mouse click line2 X değerini alacak line ise Y değerini alacak.
                            x = Convert.ToInt32(line2);
                            y = Convert.ToInt32(line);
                            Cursor.Position = new Point(x, y);
                            LeftClick(x, y);
                            Thread.Sleep(50);
                        }else if (line.CompareTo("#dm")==0)             //Double click eventı için
                        {
                            line = sr.ReadLine();                       // mouse click line2 X değerini alacak line ise Y değerini alacak.
                            x = Convert.ToInt32(line2);
                            y = Convert.ToInt32(line);
                            Cursor.Position = new Point(x, y);
                            Double_Click(x, y);
                            Thread.Sleep(50);
                        }else if (line.CompareTo("#rm") == 0)
                        {
                            line = sr.ReadLine();                       // mouse click line2 X değerini alacak line ise Y değerini alacak.
                            x = Convert.ToInt32(line2);
                            y = Convert.ToInt32(line);
                            Cursor.Position = new Point(x, y);
                            RightClick(x, y);
                            Thread.Sleep(50);
                        }
                        else if (line.CompareTo("#e") == 0)
                        {
                            SendKeys.SendWait("{ENTER}");                   // Enter tuşuna basıldığında gerçekleşen event.
                            Thread.Sleep(50);
                        }
                        else if (line.CompareTo("#up") == 0)
                        {
                            mouse_event(MOUSEEVENTF_WHEEL, 0, 0, 120, 0);
                            Thread.Sleep(100);
                        }
                        else if (line.CompareTo("#down") == 0)
                        {
                            mouse_event(MOUSEEVENTF_WHEEL, 0, 0, -120, 0);
                            Thread.Sleep(100);
                        }
                        else
                        {
                            x = Convert.ToInt32(line);
                            y = Convert.ToInt32(line2);
                            SetCursorPos(x, y);
                            //Cursor.Position = new Point(x, y);
                            Thread.Sleep(15);
                        }
                    }
                    sr.Close();
                }
                
            }
            
        }

        private async void btnOtoPilot_ClickAsync(object sender, EventArgs e)
        {
            OtoPilotDevam = true;
            this.WindowState = FormWindowState.Minimized;               // Otopilot başladığında alta alsın.
            Random rnd = new Random();
            //Thread dongu = new Thread(() =>
            await System.Threading.Tasks.Task.Run(()=>
            {
 
            
          
                while (OtoPilotDevam)
                {
                    
                   
                    //int s = rnd.Next(minSecim, maxSecim + 1);
                    int s = 1;

                    switch (s)
                    {
                        case 1:                                             // Gerekli kaydı oynatması için ayarlamalar yapılıyor ve buton click eventı çağırılıyor.
                            txtLog.AppendText("Yagmalama Secildi. - ");
                            radioYagmaYap.Checked = true;
                            radioKayitOynat.Checked = true;
                            btnKaydiOynat_Click(sender, e);                 //Buradaki eventa gidince kendini Döngü değişkenine değer ataması yapalım yine.
                            DateTime now = DateTime.Now;
                            txtLog.AppendText(now.ToString()+"\n");
                            Thread.Sleep(30);

                             break;
                        case 2:
                            txtLog.AppendText("Kahramana Bak Secildi.\n");
                            radioKahramanaBak.Checked = true;
                            radioKayitOynat.Checked = true;
                            btnKaydiOynat_Click(sender, e);
                            DateTime now1 = DateTime.Now;
                            txtLog.AppendText(now1.ToString());
                            Thread.Sleep(30);
                             break;
                        case 3:
                            txtLog.AppendText("Asker Bas Secildi.\n");
                            radioAskerBas.Checked = true;
                            radioKayitOynat.Checked = true;
                            btnKaydiOynat_Click(sender, e);
                            DateTime now2 = DateTime.Now;
                            txtLog.AppendText(now2.ToString());
                            Thread.Sleep(30);
                            break;
                    }
                   
                    int minval= int.Parse(cmbBoxTimeMin.SelectedItem.ToString());
                    int maxval= int.Parse(cmbBoxTimeMax.SelectedItem.ToString());

                    int tr = rnd.Next(minval, maxval);
                    int dak = rnd.Next(50, 70);
                    int ms = rnd.Next(921, 1211);

                    Thread.Sleep(tr * dak * ms);
                }
            }
            );

            //dongu.Start();


        }

        #endregion

        #region Mouse Altyapısı

        [DllImport("user32")]
        public static extern int SetCursorPos(int x, int y);


        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        private const int MOUSEEVENTF_MOVE = 0x0001;
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const int MOUSEEVENTF_RIGHTUP = 0x0010;
        private const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        private const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        private const int MOUSEEVENTF_ABSOLUTE = 0x8000;
        private const int MOUSEEVENTF_WHEEL = 0x0800;    // mouse_event(MOUSEEVENTF_WHEEL, 0, 0, 120, 0);  bu -120 olunca aşağı 120 olunca yukarı kaydırıyormuş.



        public enum MouseEventFlags
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            MIDDLEDOWN = 0x00000020,
            MIDDLEUP = 0x00000040,
            MOVE = 0x00000001,
            ABSOLUTE = 0x00008000,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010
        }
        public static void LeftClick(int x, int y)
        {
            Cursor.Position = new System.Drawing.Point(x, y);
            mouse_event((int)(MouseEventFlags.LEFTDOWN), 0, 0, 0, 0);
            mouse_event((int)(MouseEventFlags.LEFTUP), 0, 0, 0, 0);
        }

        public static void Double_Click(int x,int y)
        {
            Cursor.Position = new System.Drawing.Point(x, y);
            mouse_event((int)(MouseEventFlags.LEFTDOWN), 0, 0, 0, 0);
            mouse_event((int)(MouseEventFlags.LEFTUP), 0, 0, 0, 0);
            mouse_event((int)(MouseEventFlags.LEFTDOWN), 0, 0, 0, 0);
            mouse_event((int)(MouseEventFlags.LEFTUP), 0, 0, 0, 0);
        }
        public static void RightClick(int x, int y)
        {
            Cursor.Position = new System.Drawing.Point(x, y);
            mouse_event((int)(MouseEventFlags.RIGHTDOWN), 0, 0, 0, 0);
            mouse_event((int)(MouseEventFlags.RIGHTUP), 0, 0, 0, 0);
        }

        public static void LeftClick()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
        }

        public static void LeftDown()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
        }

        public static void LeftUp()
        {
            mouse_event(MOUSEEVENTF_LEFTUP, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
        }

        public static void RightClick()
        {
            mouse_event(MOUSEEVENTF_RIGHTDOWN, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
            mouse_event(MOUSEEVENTF_RIGHTUP, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
        }

        public static void RightDown()
        {
            mouse_event(MOUSEEVENTF_RIGHTDOWN, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
        }

        public static void RightUp()
        {
            mouse_event(MOUSEEVENTF_RIGHTUP, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
        }
        #endregion

        #region radiobuton Eventları
        private void radioYagmaYap_CheckedChanged(object sender, EventArgs e)
        {
            dosyaAdi = yagmaYap;
            //txtLog.AppendText("\n"+dosyaAdi+"\n");**
        }

        private void radioKahramanaBak_CheckedChanged(object sender, EventArgs e)
        {
            dosyaAdi = kahramanaBak;
        }

        private void radioAskerBas_CheckedChanged(object sender, EventArgs e)
        {
            dosyaAdi = askerBas;
        }

        #endregion

        

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            unsubscribeGlobal(Hook.GlobalEvents());
        }

        public void KayitSecimleriniSifirla()
        {
            radioAskerBas.Checked = false;
            radioYagmaYap.Checked = false;
            radioKahramanaBak.Checked = false;
            radioKayitEt.Checked = false;
            radioKayitOynat.Checked = false;
            dosyaAdi = "";
        }
    }
}