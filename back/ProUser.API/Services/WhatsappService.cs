using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProUser.API.Services
{
    public class WhatsappService
    {
        public void Open()
        {
            var process = new ProcessStartInfo
            {
                FileName = "https://api.whatsapp.com/send?phone=92985614987",
                UseShellExecute = true
            };
            Process.Start(process);
        }
    }
}