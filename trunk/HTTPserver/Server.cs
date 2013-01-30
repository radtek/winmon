using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Reflection;

namespace HTTPserver
{
    public class Server
    {
        // öffentliche Felder
        public String[] http_ports = new String[] { "8080" };
        public String[] https_ports = new String[] { "4443" };
        public Boolean enabel_https = false;

        // private Felder
        private HttpListener listener = new HttpListener();
        private String root_path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        // öffentliche Methoden
        public Server()
        {


        }

        public void start_server()
        {
            
        }

        public void stop_server()
        {

        }

        // private Methoden

        private void wait_request()
        {
            IAsyncResult result = listener.BeginGetContext(callback, listener);
            result.AsyncWaitHandle.WaitOne();
        }


        private void callback(IAsyncResult result)
        {
            if (listener.IsListening)
            {
                HttpListenerContext context = listener.EndGetContext(result);
                HttpListenerRequest request = context.Request;
            }
            else
            {
                return;
            }
        }


        private void request_handler(HttpListenerResponse handler_response, HttpListenerRequest handler_request)
        {
            string document = handler_request.RawUrl;
            string docpath = Path.Combine(root_path, document);
            byte[] responsebyte;
            if (File.Exists(docpath))
            {
                handler_response.StatusCode = (int)HttpStatusCode.OK;
                responsebyte = File.ReadAllBytes(docpath);
            }
            else
            {
                handler_response.StatusCode = (int)HttpStatusCode.NotFound;
                responsebyte = File.ReadAllBytes(root_path + "\\error\\error.html");
            }
        }
    }
}