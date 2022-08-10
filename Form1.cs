namespace EWSS_C
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // »Õ»÷»¿À»«¿÷»ﬂ


        public void PreInit()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            //GetNetworkII();
        }


        // ‘”Õ ÷»» »Õ»÷»¿À»«¿÷»»


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
    }
}