using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace WinMon
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class tools
    {
        static void start_listener()
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://*:8080");
            listener.Start();



        }


    }
}
