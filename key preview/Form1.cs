using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Utilities;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace key_preview {
	public partial class Form1 : Form {
		globalKeyboardHook gkh = new globalKeyboardHook();

        [DllImport("User32.dll")]
        static extern int SetForegroundWindow(IntPtr point);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);

        [DllImport("user32")]
        public static extern int SetCursorPos(int x, int y);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;


		public Form1() {
			InitializeComponent();
		}

        public void getAllResult(System.Windows.Forms.ComboBox cmbFrm)
        {
            cmbFrm.Items.Clear();
            cmbFrm.Items.Add("Yeni Kayıt");
            int resultCount = 0;
            string[] fileEntries = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory);
            foreach (string fileName in fileEntries)
            {
                if (fileName.IndexOf("brt") > 0)
                {
                    resultCount += 1;
                    string fileResultName = Path.GetFileName(fileName);
                    cmbFrm.Items.Add(fileResultName.Substring(0, fileResultName.IndexOf('.')));
                }
            }
            if (cmbFrm.Items.Count > 0)
            {
                cmbFrm.SelectedIndex = 0;
            }
        }

        public void txtToList(string txtPath, System.Windows.Forms.ListBox txtList)
        {
            using (StreamReader r = new StreamReader(txtPath))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    txtList.Items.Add(line);
                }
            }
        }

        public void getResult(string fileNameResult, System.Windows.Forms.ListBox lstFrm)
        {
            lstFrm.Items.Clear();
            int resultCount = 0;
            string[] fileEntries = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory);
            foreach (string fileName in fileEntries)
            {
                if (fileName.IndexOf(fileNameResult) > 0)
                {
                    resultCount += 1;
                    string fileResultName = AppDomain.CurrentDomain.BaseDirectory + Path.GetFileName(fileName);
                    string ResultFile = fileResultName.Substring(0, fileResultName.IndexOf('.'));
                    Console.WriteLine(ResultFile);
                    Console.WriteLine(fileResultName);
                    txtToList(fileResultName, lstFrm);
                }
            }
        }

		private void Form1_Load(object sender, EventArgs e) {

            getAllResult(KayitDosyasi);

            if (KayitDosyasi.Items.Count > 0 && KayitDosyasi.Items[KayitDosyasi.SelectedIndex].ToString() != "Yeni Kayıt")
            {
                getResult(KayitDosyasi.Items[KayitDosyasi.SelectedIndex].ToString(), listBox1);
            }

            gkh.HookedKeys.Add(Keys.A);
            gkh.HookedKeys.Add(Keys.B);
            gkh.HookedKeys.Add(Keys.C);
            gkh.HookedKeys.Add(Keys.D);
            gkh.HookedKeys.Add(Keys.E);
            gkh.HookedKeys.Add(Keys.F);
            gkh.HookedKeys.Add(Keys.G);
            gkh.HookedKeys.Add(Keys.H);
            gkh.HookedKeys.Add(Keys.I);
            gkh.HookedKeys.Add(Keys.J);
            gkh.HookedKeys.Add(Keys.K);
            gkh.HookedKeys.Add(Keys.L);
            gkh.HookedKeys.Add(Keys.M);
            gkh.HookedKeys.Add(Keys.N);
            gkh.HookedKeys.Add(Keys.O);
            gkh.HookedKeys.Add(Keys.P);
            gkh.HookedKeys.Add(Keys.R);
            gkh.HookedKeys.Add(Keys.S);
            gkh.HookedKeys.Add(Keys.T);
            gkh.HookedKeys.Add(Keys.U);
            gkh.HookedKeys.Add(Keys.V);
            gkh.HookedKeys.Add(Keys.Y);
            gkh.HookedKeys.Add(Keys.Z);
            gkh.HookedKeys.Add(Keys.W);
            gkh.HookedKeys.Add(Keys.Q);
            gkh.HookedKeys.Add(Keys.D0);
            gkh.HookedKeys.Add(Keys.D1);
            gkh.HookedKeys.Add(Keys.D2);
            gkh.HookedKeys.Add(Keys.D3);
            gkh.HookedKeys.Add(Keys.D4);
            gkh.HookedKeys.Add(Keys.D5);
            gkh.HookedKeys.Add(Keys.D6);
            gkh.HookedKeys.Add(Keys.D7);
            gkh.HookedKeys.Add(Keys.D8);
            gkh.HookedKeys.Add(Keys.D9);
            gkh.HookedKeys.Add(Keys.Back);
            gkh.HookedKeys.Add(Keys.Enter);
            gkh.HookedKeys.Add(Keys.Up);
            gkh.HookedKeys.Add(Keys.Down);
            gkh.HookedKeys.Add(Keys.Left);
            gkh.HookedKeys.Add(Keys.Right);

            gkh.KeyDown += new KeyEventHandler(gkh_KeyDown);
            gkh.KeyUp += new KeyEventHandler(gkh_KeyUp);
            gkh.unhook();
		}

		void gkh_KeyUp(object sender, KeyEventArgs e) {
            string key = e.KeyCode.ToString().ToUpper();

            if (key == "Q")
            {
                listBox1.Items.Add("Server,Kuruluyor");
                listBox1.Items.Add("Delay," + "1000");
            }
            else if (key == "BACKSPACE")
            {
                for (int i = 0; i < 20; i++)
                {
                    listBox1.Items.Add("Keyboard,BACK"); 
                }
                listBox1.Items.Add("Delay," + "1000");
            }
            else if (key == "RETURN")
            {
                listBox1.Items.Add("Keyboard,ENTER");
                listBox1.Items.Add("Delay," + "1000");
            }
            else if (key == "D0")
            {
                listBox1.Items.Add("Keyboard,0");
                listBox1.Items.Add("Delay," + "1000");
            }
            else if (key == "D1")
            {
                listBox1.Items.Add("Keyboard,1");
                listBox1.Items.Add("Delay," + "1000");
            }
            else if (key == "D2")
            {
                listBox1.Items.Add("Keyboard,2");
                listBox1.Items.Add("Delay," + "1000");
            }
            else if (key == "D3")
            {
                listBox1.Items.Add("Keyboard,3");
                listBox1.Items.Add("Delay," + "1000");
            }
            else if (key == "D4")
            {
                listBox1.Items.Add("Keyboard,4");
                listBox1.Items.Add("Delay," + "1000");
            }
            else if (key == "D5")
            {
                listBox1.Items.Add("Keyboard,5");
                listBox1.Items.Add("Delay," + "1000");
            }
            else if (key == "D6")
            {
                listBox1.Items.Add("Keyboard,6");
                listBox1.Items.Add("Delay," + "1000");
            }
            else if (key == "D7")
            {
                listBox1.Items.Add("Keyboard,7");
                listBox1.Items.Add("Delay," + "1000");
            }
            else if (key == "D8")
            {
                listBox1.Items.Add("Keyboard,8");
                listBox1.Items.Add("Delay," + "1000");
            }
            else if (key == "D9")
            {
                listBox1.Items.Add("Keyboard,9");
                listBox1.Items.Add("Delay," + "1000");
            }
            else
            {
                listBox1.Items.Add("Keyboard," + key);
                listBox1.Items.Add("Delay," + "1000");
            }
			
			e.Handled = true;
		}
        
		void gkh_KeyDown(object sender, KeyEventArgs e) {
            //listBox1.Items.Add("Down\t" + e.KeyCode.ToString());
			e.Handled = true;
		}

        private void button1_Click(object sender, EventArgs e)
        {
            gkh.hook();
            timer1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            for (int j = 0; j < Convert.ToInt32(textBox1.Text); j++)
            {

            foreach (Process proc in Process.GetProcesses())
            {
                if (proc.MainWindowTitle == "Hyper-V Manager")
                {
                    IntPtr h = proc.MainWindowHandle;
                    SetForegroundWindow(h);
                    break;
                }
            }

            foreach (Process proc in Process.GetProcesses())
            {
                if (proc.MainWindowTitle == "New Virtual Machine Wizard")
                {
                    IntPtr h = proc.MainWindowHandle;
                    SetForegroundWindow(h);
                    break;
                }
            }

            int toplamlist = listBox1.Items.Count;
            for (int i = 0; i < toplamlist; i++)
            {
                string islem = listBox1.Items[i].ToString();
                string[] parse = islem.Split(',');
                if (parse[0] == "Delay")
                {
                    System.Threading.Thread.Sleep(Convert.ToInt32(parse[1]));
                }

                if (parse[0] == "Mouse")
                {
                    int X = Convert.ToInt32(parse[1]);
                    int Y = Convert.ToInt32(parse[2]);
                    SetCursorPos(X, Y);
                    Thread.Sleep(100);
                    mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                    mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                }

                if (parse[0] == "Keyboard")
                {
                    SendKeys.SendWait("{" + parse[1] + "}");
                }

                if (parse[0] == "Server")
                {
                    int suankiserver = j + Convert.ToInt32(textBox2.Text);
                    string swadi = suankiserver.ToString();
                    for (int k = 0; k < swadi.Length; k++)
                    {
                        SendKeys.SendWait("{" + swadi.Substring(k,1) + "}");  
                    }

                    
                }

            }
            System.Threading.Thread.Sleep(5000);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            listBox1.Items.Add("Mouse," + Cursor.Position.X + "," + Cursor.Position.Y);
            listBox1.Items.Add("Delay," + "1000");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gkh.unhook();
            timer1.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var saveFile = new SaveFileDialog();
            saveFile.Filter = "Recorder Kayıt Dosyası (*.brt)|*.brt";
            saveFile.InitialDirectory = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory);
            saveFile.RestoreDirectory = true;
            saveFile.AutoUpgradeEnabled = false;
            if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamWriter Kayit = new StreamWriter(saveFile.FileName);
                for (int i = 0; i < listBox1.Items.Count - 1; i++)
                {
                    Kayit.WriteLine(listBox1.Items[i].ToString());
                }
                Kayit.Close();
            }
            getAllResult(KayitDosyasi);
        }

        private void KayitDosyasi_Click(object sender, EventArgs e)
        {
            getAllResult(KayitDosyasi);
        }

        private void KayitDosyasi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (KayitDosyasi.Items[KayitDosyasi.SelectedIndex].ToString() == "Yeni Kayıt")
            {
                listBox1.Items.Clear();
            }
            else if (KayitDosyasi.Items.Count > 0)
            {
                getResult(KayitDosyasi.Items[KayitDosyasi.SelectedIndex].ToString(), listBox1);
            }
        }

     
	}
}