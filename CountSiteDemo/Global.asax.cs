using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace CountSiteDemo
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            int count = 0;
            string filePath = Server.MapPath("APP_Data/counter.txt");
            StreamReader sr = File.OpenText(filePath);
            while (sr.Peek() != -1)
            {
                string str = sr.ReadLine();
                count = int.Parse(str);
            }
            sr.Close();
            Application.Lock();
            Application["CurNum"] = 0;
            Application["TotNum"] = (object)count;
            Application.UnLock();
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Application.Lock();
            Application["CurNum"] = Convert.ToInt32(Application["CurNum"]) + 1;
            Application["TotNum"] = Convert.ToInt32(Application["TotNum"]) + 1;
            Application.UnLock();
            string filepath = Server.MapPath("APP_Data/counter.txt");
            StreamWriter sw = new StreamWriter(filepath, false);
            sw.WriteLine(Convert.ToInt32(Application["TotNum"]));
            sw.Close();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            Application.Lock();
            Application["CurNum"] = Convert.ToInt32(Application["CurNum"]) - 1;
            Application.UnLock();
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}