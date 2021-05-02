using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Net;
using System.Management;


namespace Abdal_Security_Group_App
{
    public partial class Abdal_Net_Fixer : Telerik.WinControls.UI.RadForm
    {
        private bool resetWindows = false;
        public Abdal_Net_Fixer()
        {
            InitializeComponent();
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            Text = "Abdal Net Fixer" + " " + version.Major + "." + version.Minor; //change form title
        }




        #region Dragable Form Start
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;

        #endregion



        private void EncryptToggleSwitch_ValueChanged(object sender, EventArgs e)
        {
             
        }

        private void DecryptToggleSwitch_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Call Global Chilkat Unlock
            Abdal_Security_Group_App.GlobalUnlockChilkat GlobalUnlock = new Abdal_Security_Group_App.GlobalUnlockChilkat();
            GlobalUnlock.unlock();



            radWaitingBar.Visible = false;
            pictureBox_cb_Network_Settings.Visible = false;
            pictureBox_cbReset_TCPIP.Visible = false;
            pictureBox_cb_Ip_Release.Visible = false;
            pictureBox_cb_Ip_Renew.Visible = false;
            pictureBox_cb_Reset_Dns.Visible = false;
            pictureBox_cb_Switch_Off_Windows_Proxy.Visible = false;
            pictureBox_cb_Remove_Wi_Fi_profiles.Visible = false;
            pictureBox_cb_Reset_Firewall.Visible = false;
            pictureBox_cb_disable_Windows_Firewall.Visible = false;
            pictureBox_cb_clear_all_static_routes.Visible = false;
            pictureBox_cb_Auto_DNS.Visible = false;
            pictureBox_cb_firefox_profile_del.Visible = false;
            pictureBox_cb_Remove_All_Google_Chrome_Profiles.Visible = false;

        }

        private void cmdHandelCommand(string userCommand)
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine(userCommand);
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            radRichTextEditorResult.AppendText(cmd.StandardOutput.ReadToEnd() + Environment.NewLine);
            radRichTextEditorResult.SelectionStart = radRichTextEditorResult.Text.Length;
            radRichTextEditorResult.ScrollToCaret();
        }
        private void radButton1_Click(object sender, EventArgs e)
        {

            if(cb_Network_Settings.Checked != true &&
            cbReset_TCPIP.Checked != true &&
            cb_Ip_Release.Checked != true &&
            cb_Ip_Renew.Checked != true &&
            cb_Reset_Dns.Checked != true &&
            cb_Switch_Off_Windows_Proxy.Checked != true &&
            cb_Remove_Wi_Fi_profiles.Checked != true &&
            cb_Reset_Firewall.Checked != true &&
            cb_disable_Windows_Firewall.Checked != true &&
            cb_clear_all_static_routes.Checked != true &&
            cb_Auto_DNS.Checked != true &&
            cb_firefox_profile_del.Checked != true &&
            cb_Remove_All_Google_Chrome_Profiles.Checked != true
            )
            {
                string MessageBoxTitle3 = "Abdal Net Fixer";
                string MessageBoxContent3 = "Please select one of the options !";

                MessageBox.Show(MessageBoxContent3, MessageBoxTitle3, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                string MessageBoxTitle = "Abdal Net Fixer";
                string MessageBoxContent = "May I Start Repairing Your System ?";

                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {

                    if (backgroundWorkerCmdEx.IsBusy != true)
                    {
                        radWaitingBar.Visible = false;
                        pictureBox_cb_Network_Settings.Visible = false;
                        pictureBox_cbReset_TCPIP.Visible = false;
                        pictureBox_cb_Ip_Release.Visible = false;
                        pictureBox_cb_Ip_Renew.Visible = false;
                        pictureBox_cb_Reset_Dns.Visible = false;
                        pictureBox_cb_Switch_Off_Windows_Proxy.Visible = false;
                        pictureBox_cb_Remove_Wi_Fi_profiles.Visible = false;
                        pictureBox_cb_Reset_Firewall.Visible = false;
                        pictureBox_cb_disable_Windows_Firewall.Visible = false;
                        pictureBox_cb_clear_all_static_routes.Visible = false;
                        pictureBox_cb_Auto_DNS.Visible = false;
                        pictureBox_cb_firefox_profile_del.Visible = false;
                        pictureBox_cb_Remove_All_Google_Chrome_Profiles.Visible = false;

                        radWaitingBar.Visible = true;
                        radWaitingBar.StartWaiting();
                        backgroundWorkerCmdEx.RunWorkerAsync();
                    }

                }

            }
            

            
           

        }

        private void backgroundWorkerCmdEx_DoWork(object sender, DoWorkEventArgs e)
        {
            try {

                if (cb_Network_Settings.Checked == true)
                {
                    cmdHandelCommand("netsh winsock reset");
                    pictureBox_cb_Network_Settings.Visible = true;
                    resetWindows = true;
                }
                 if (cbReset_TCPIP.Checked == true)
                {
                    cmdHandelCommand("netsh int ip reset");
                    pictureBox_cbReset_TCPIP.Visible = true;
                    resetWindows = true;
                }
                 if (cb_Ip_Release.Checked == true)
                {
                    cmdHandelCommand("ipconfig /release");
                    pictureBox_cb_Ip_Release.Visible = true;
                }
                 if (cb_Ip_Renew.Checked == true)
                {
                    cmdHandelCommand("ipconfig /renew");
                    pictureBox_cb_Ip_Renew.Visible = true;
                }
                 if (cb_Reset_Dns.Checked == true)
                {
                    cmdHandelCommand("ipconfig /flushdns");
                    pictureBox_cb_Reset_Dns.Visible = true;
                }
                if (cb_Switch_Off_Windows_Proxy.Checked == true)
                {
                    cmdHandelCommand("netsh winhttp reset proxy");
                    cmdHandelCommand("REG ADD \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings\" /v ProxyEnable /t REG_DWORD /d 0 /f");
                    pictureBox_cb_Switch_Off_Windows_Proxy.Visible = true;
                }

                if (cb_Remove_Wi_Fi_profiles.Checked == true)
                {
                    cmdHandelCommand("netsh wlan delete profile *");
                    pictureBox_cb_Remove_Wi_Fi_profiles.Visible = true;

                }


                 if (cb_Reset_Firewall.Checked == true)
                {
                    cmdHandelCommand("netsh advfirewall reset");
                    pictureBox_cb_Reset_Firewall.Visible = true;
                }
                 if (cb_disable_Windows_Firewall.Checked == true)
                {
                    cmdHandelCommand("netsh advfirewall set allprofiles state off");
                    pictureBox_cb_disable_Windows_Firewall.Visible = true;
                }

                if (cb_clear_all_static_routes.Checked == true)
                {
                    cmdHandelCommand("for /f \"skip=3 tokens=4,6\" %e in ('netsh int ipv4 sh route store^=persistent ^| findstr -v 0.0.0.0/0') do route delete -4 -p %e %f");
                    cmdHandelCommand("for /f \"skip=3 tokens=4,6\" %e in ('netsh int ipv6 sh route store^=persistent ^| findstr -v ::/0') do route delete -6 -p %e %f");
                    pictureBox_cb_clear_all_static_routes.Visible = true;
                }
              
             if (cb_Auto_DNS.Checked == true)
                {

                    NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

                    foreach (NetworkInterface adapter in interfaces)
                    {
                        cmdHandelCommand("netsh interface ip set dns  \""+ adapter.Name + "\"  dhcp");

                    }


                    
                    pictureBox_cb_Auto_DNS.Visible = true;
                }
              

                 if (cb_firefox_profile_del.Checked == true)
                {
                    //https://docs.microsoft.com/en-us/dotnet/api/system.environment.specialfolder?view=net-5.0
                    var firefox_profile_path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Mozilla";

                    Abdal_Net_Fixer_AntiProccess.AntiProccess AntiProccess = new Abdal_Net_Fixer_AntiProccess.AntiProccess();
                    AntiProccess.ProccessFinder();

                    System.Threading.Thread.Sleep(1000);
                    Directory.Delete(firefox_profile_path, true);
                    pictureBox_cb_firefox_profile_del.Visible = true;

                }
                   if (cb_Remove_All_Google_Chrome_Profiles.Checked == true)
                {

                    //https://docs.microsoft.com/en-us/dotnet/api/system.environment.specialfolder?view=net-5.0
                    var Google_Chrome_path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Google\\Chrome\\User Data\\Default";

                    Abdal_Net_Fixer_AntiProccess.AntiProccess AntiProccess = new Abdal_Net_Fixer_AntiProccess.AntiProccess();
                    AntiProccess.ProccessFinder();

                    System.Threading.Thread.Sleep(1000);

                    Directory.Delete(Google_Chrome_path, true);
                    pictureBox_cb_Remove_All_Google_Chrome_Profiles.Visible = true;

                }
                



            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
          //End try
           
           
           
           
          
        }

        private void backgroundWorkerCmdEx_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            radWaitingBar.StopWaiting();
            radWaitingBar.Visible = false;

            

            if (resetWindows == true)
            {

                string MessageBoxTitle = "Abdal Net Fixer";
                string MessageBoxContent = "Troubelshooting Is done, You must restart your computer to apply these changes";
                resetWindows = false;
                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {

                    System.Diagnostics.Process.Start("ShutDown", " -f -r -t 00");

                }

            }
            else
            {
                string MessageBoxTitle2 = "Abdal Net Fixer";
                string MessageBoxContent2 = "Troubelshooting Is done";

                MessageBox.Show(MessageBoxContent2, MessageBoxTitle2, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           


            
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            cb_Network_Settings.Checked = true;
            cbReset_TCPIP.Checked = true;
            cb_Ip_Release.Checked = true;
            cb_Ip_Renew.Checked = true;
            cb_Reset_Dns.Checked = true;
            cb_Remove_Wi_Fi_profiles.Checked = true;
            cb_Reset_Firewall.Checked = true;
            cb_disable_Windows_Firewall.Checked = true;
            cb_Switch_Off_Windows_Proxy.Checked = true;
            cb_clear_all_static_routes.Checked = true;
            cb_Auto_DNS.Checked = true;
            cb_firefox_profile_del.Checked = true;
            cb_Remove_All_Google_Chrome_Profiles.Checked = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public static bool CheckForInternetConnection()
        {
            try
            {
                if (NetworkInterface.GetIsNetworkAvailable() &&
                 new Ping().Send(new IPAddress(new byte[] { 8, 8, 8, 8 }), 2000).Status == IPStatus.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }


        }

        private void backgroundWorkerInternetCheck_DoWork(object sender, DoWorkEventArgs e)
        {
            if (CheckForInternetConnection() == true)
            {

                internetCheckUp.ForeColor = System.Drawing.Color.SpringGreen;
                internetCheckUp.Text = "Internet is Connected";
            }
            else
            {
                internetCheckUp.ForeColor = System.Drawing.Color.Crimson;
                internetCheckUp.Text = "Internet not Connected";
            }



        }

        private void timerInternetCheck_Tick(object sender, EventArgs e)
        {

            if (backgroundWorkerInternetCheck.IsBusy != true && cb_internetCheckUp.Checked == true)
            {
                backgroundWorkerInternetCheck.RunWorkerAsync();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://donate.abdalagency.ir/");
        }
    }
}
