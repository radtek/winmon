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
        public Boolean debug = false;
        // private Felder
        private HttpListener listener = new HttpListener();
        private String root_path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        // öffentliche Methoden
        public Server()
        {
            foreach (string port in http_ports)
            {
                string temp_prefix = "http://*:" + port + "/";
                listener.Prefixes.Add(temp_prefix);
            }
            if (enabel_https)
            {
                foreach (string port in https_ports)
                {
                    string temp_prefix = "http://*:" + port + "/";
                    listener.Prefixes.Add(temp_prefix);
                }
            }
        }
        public void start_server()
        {
            listener.Start();
            while (listener.IsListening)
            {
                wait_request();
            }
        }
        public void stop_server()
        {
            listener.Stop();
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
                HttpListenerResponse response = context.Response;
                request_handler(response, request);
            }
            else
            {
                return;
            }
        }
        private void request_handler(HttpListenerResponse handler_response, HttpListenerRequest handler_request)
        {
            string document = handler_request.RawUrl;
            string docpath = root_path + document;
            byte[] responsebyte;
            if (File.Exists(docpath))
            {
                handler_response.StatusCode = (int)HttpStatusCode.OK;
                handler_response.ContentType = "text/html";
                responsebyte = File.ReadAllBytes(docpath);
            }
            else
            {
                if (debug)
                {
                    handler_response.StatusCode = (int)HttpStatusCode.NotFound;
                    string responsestring = "Server running! ";
                    responsestring += "document: " + document + " ";
                    responsestring += "documentpath: " + docpath + " ";
                    responsestring += "root_path " + root_path + " ";
                    responsebyte = System.Text.Encoding.UTF8.GetBytes(responsestring);
                }
                else
                {
                    handler_response.StatusCode = (int)HttpStatusCode.NotFound;
                    handler_response.ContentType = "text/html";
                    responsebyte = File.ReadAllBytes(root_path + "//error//error.html");
                }
            }
            handler_response.ContentLength64 = responsebyte.Length;
            System.IO.Stream output = handler_response.OutputStream;
            output.Write(responsebyte, 0, responsebyte.Length);
            output.Close();
        }
    }
}