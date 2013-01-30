using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration.Install;
using System.ComponentModel;
using System.ServiceProcess;

namespace WinMon
{
    [RunInstaller(true)]
    public class serviceinstaller : Installer
    {
        public serviceinstaller()
        {
            ServiceProcessInstaller sp_installer = new ServiceProcessInstaller();
            ServiceInstaller s_installer = new ServiceInstaller();
            sp_installer.Account = ServiceAccount.LocalSystem;
            s_installer.DisplayName = "WinMon Service";
            s_installer.StartType = ServiceStartMode.Automatic;
            this.Installers.Add(sp_installer);
            this.Installers.Add(s_installer);
        }
    }
}
