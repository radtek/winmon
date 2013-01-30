using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.ServiceProcess;

namespace WinMon
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceBase.Run(new WinMonService());
        }
    }
}
