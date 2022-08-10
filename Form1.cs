namespace EWSS_C
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PreInit();
        }

        // »Õ»÷»¿À»«¿÷»ﬂ

        public static class Globals                             // √ÀŒ¡¿À‹Õ€≈ œ≈–≈Ã≈ÕÕ€≈
        {
            public static string selected_kms = "0.0.0.0";
        }

        public void PreInit()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            //GetNetworkII();
            UpdateVersionInfo();

            toolStripStatusLabel1.Text = "»ÌËˆË‡ÎËÁÓ‚‡Ì";
        }


        // ‘”Õ ÷»» »Õ»÷»¿À»«¿÷»»


        private string GetRegValue(string subkey, string value)
        {
            try
            {
                using (var key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(subkey, false)) // False is important!
                {
                    var s = key?.GetValue(value) as string;
                    if (!string.IsNullOrWhiteSpace(s))
                    {
                        return s;
                    }
                    else return "0";
                }
            }
            catch (Exception ex)  //just for demonstration...it's always best to handle specific exceptions
            {
                return "-1";
            }
        }

        private void UpdateVersionInfo()
        {
            label1.Text = GetRegValue("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", "ProductName");
            label2.Text = GetRegValue("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", "EditionID");
            label1.Visible = true;
            label2.Visible = true;
        }

        /**private void GetNetworkII()
        {
            foreach (System.Net.NetworkInformation.NetworkInterface nic in System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces())
            {
                comboBox1.Items.Add(nic.Name);
            }
        }**/


        // —À”∆≈¡Õ€≈ ‘”Õ ÷»»


        private void Execute(string file)
        {
            try
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                //string command = "Get-NetAdapter | Format-Table -Property Name";
                process.StartInfo.FileName = file;
                //process.StartInfo.Arguments = command;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                process.Start();
            }
            catch (System.ComponentModel.Win32Exception)
            {
                MessageBox.Show("ƒÎˇ ‚˚ÔÓÎÌÂÌËˇ ÓÔÂ‡ˆËË ÚÂ·Û˛ÚÒˇ Ô‡‚‡ ‡‰ÏËÌËÒÚ‡ÚÓ‡");
            }
        }
        private void PSExecute(string command)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            //string command = "Get-NetAdapter | Format-Table -Property Name";
            process.StartInfo.FileName = "powershell.exe";
            process.StartInfo.Arguments = command;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = false;
            process.StartInfo.RedirectStandardInput = false;
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            process.Start();

        }
        private void CMDExecute(string command)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = command;
            process.StartInfo = startInfo;
            process.StartInfo.RedirectStandardOutput = false;
            process.Start();
        }
        private string CMDExecuteOutStr(string command)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = command;
            process.StartInfo = startInfo;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();

            return process.StandardOutput.ReadLine();
        }

        private static bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            using (var pinger = new System.Net.NetworkInformation.Ping())
            {
                try
                {
                    System.Net.NetworkInformation.PingReply reply = pinger.Send(nameOrAddress);
                    pingable = reply.Status == System.Net.NetworkInformation.IPStatus.Success;
                }
                catch (System.Net.NetworkInformation.PingException)
                {
                    return false;
                }
                finally
                {
                    if (pinger != null)
                    {
                        pinger.Dispose();
                    }
                }
                return pingable;
            }
        }

        private string KMSCheck()
        {
            bool kms1 = false;
            bool kms2 = false;

            string kms1_ip = "kms8.msguides.com";
            string kms2_ip = "kms9.msguides.com";
            string none_ip = "0.0.0.0";

            label4.Text = kms1_ip;
            label5.Text = kms2_ip;

            //KMS1

            if (PingHost(kms1_ip) == true)
            {
                pictureBox3.Image = imageList1.Images[0];
                kms1 = true;
            } 
            else
            {
                pictureBox3.Image = imageList1.Images[1];
            }

            //KMS2

            if (PingHost(kms2_ip) == true)
            {
                pictureBox4.Image = imageList1.Images[0];
                kms2 = true;
            }
            else
            {
                pictureBox4.Image = imageList1.Images[1];
            }

            if (kms1 == true && kms2 == true)
            {
                label4.Font = new Font(this.Font, FontStyle.Bold);
                return kms1_ip;
            }
            else if (kms1 == true && kms2 == false)
            {
                label4.Font = new Font(this.Font, FontStyle.Bold);
                return kms1_ip;
            }
            else if (kms1 == false && kms2 == true)
            {
                label5.Font = new Font(this.Font, FontStyle.Bold);
                return kms2_ip;
            }
            else
            {
                label5.Font = new Font(this.Font, FontStyle.Bold);
                return none_ip;
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Execute("cmd");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Execute("powershell");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Execute("regedit");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Execute("SystemPropertiesAdvanced.exe");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Execute("UserAccountControlSettings.exe");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Execute("control");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Execute("msconfig");
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            label3.Text = "Œ—: " + listView1.FocusedItem.SubItems[0].Text;
            textBox1.Text = listView1.FocusedItem.SubItems[1].Text;
            Globals.selected_kms = KMSCheck();
        }
    }
}