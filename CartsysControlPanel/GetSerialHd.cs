using System;
using System.Collections.Generic;
using System.Management;
using System.Text;

namespace CartsysControlPanel
{
    public static class GetSerialHd
    {
        public static string GetHdSerial()
        {
            try
            {
                string drive = "C";
                ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"" + drive + ":\"");
                disk.Get();
                return disk["VolumeSerialNumber"].ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show($"Ocorreu um erro ao tentar obter o serial do HD: {e.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }
    }
}
