using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Viags.Base;

namespace Viags.WebApp
{
    public partial class file : System.Web.UI.Page
    {
        public string path = "";
        protected bool checkIDM { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            var isRunning = Process.GetProcessesByName("IDMan");//.Any();
            var isRunning_ = Process.GetProcessesByName("IEMonitor");//.Any();
            var xxx = Process.GetProcesses();
            if (isRunning.Any() || isRunning_.Any())
            {
                checkIDM = true;
                isRunning.FirstOrDefault().Kill();
                isRunning_.FirstOrDefault().Kill();
            }


            var rq = Request["v"];
            if(!string.IsNullOrEmpty(rq))
            {
                path = rq;
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        private string EncryptURL(string input)
        {
            var _return = "";
            foreach (char c in input.ToLower())
            {
                switch (c.ToString())
                {
                    case "1": _return += "n"; break;
                    case "2": _return += "m"; break;
                    case "3": _return += "/"; break;
                    case "4": _return += "."; break;
                    case "5": _return += "1"; break;
                    case "6": _return += "2"; break;
                    case "7": _return += "3"; break;
                    case "8": _return += "4"; break;
                    case "9": _return += "5"; break;
                    case "0": _return += "6"; break;
                    case "q": _return += "7"; break;
                    case "w": _return += "8"; break;
                    case "e": _return += "9"; break;
                    case "r": _return += "0"; break;
                    case "t": _return += "q"; break;
                    case "y": _return += "w"; break;
                    case "u": _return += "e"; break;
                    case "i": _return += "r"; break;
                    case "o": _return += "t"; break;
                    case "p": _return += "y"; break;
                    case "a": _return += "u"; break;
                    case "s": _return += "i"; break;
                    case "d": _return += "o"; break;
                    case "f": _return += "p"; break;
                    case "g": _return += "a"; break;
                    case "h": _return += "s"; break;
                    case "j": _return += "d"; break;
                    case "k": _return += "f"; break;
                    case "l": _return += "g"; break;
                    case "z": _return += "h"; break;
                    case "x": _return += "j"; break;
                    case "c": _return += "k"; break;
                    case "v": _return += "l"; break;
                    case "b": _return += "z"; break;
                    case "n": _return += "x"; break;
                    case "m": _return += "c"; break;
                    case "/": _return += "v"; break;
                    case ".": _return += "b"; break;
                    case " ": _return += "$"; break;
                    default: _return += c.ToString(); break;
                }
            }
            return _return.Trim();
        }
        private string DecryptURL(string input)
        {
            var _return = "";
            foreach (char c in input.ToLower())
            {
                switch (c.ToString())
                {
                    case "n": _return += "1"; break;
                    case "m": _return += "2"; break;
                    case "/": _return += "3"; break;
                    case ".": _return += "4"; break;
                    case "1": _return += "5"; break;
                    case "2": _return += "6"; break;
                    case "3": _return += "7"; break;
                    case "4": _return += "8"; break;
                    case "5": _return += "9"; break;
                    case "6": _return += "0"; break;
                    case "7": _return += "q"; break;
                    case "8": _return += "w"; break;
                    case "9": _return += "e"; break;
                    case "0": _return += "r"; break;
                    case "q": _return += "t"; break;
                    case "w": _return += "y"; break;
                    case "e": _return += "u"; break;
                    case "r": _return += "i"; break;
                    case "t": _return += "o"; break;
                    case "y": _return += "p"; break;
                    case "u": _return += "a"; break;
                    case "i": _return += "s"; break;
                    case "o": _return += "d"; break;
                    case "p": _return += "f"; break;
                    case "a": _return += "g"; break;
                    case "s": _return += "h"; break;
                    case "d": _return += "j"; break;
                    case "f": _return += "k"; break;
                    case "g": _return += "l"; break;
                    case "h": _return += "z"; break;
                    case "j": _return += "x"; break;
                    case "k": _return += "c"; break;
                    case "l": _return += "v"; break;
                    case "z": _return += "b"; break;
                    case "x": _return += "n"; break;
                    case "c": _return += "m"; break;
                    case "v": _return += "/"; break;
                    case "b": _return += "."; break;
                    case "$": _return += " "; break;
                    default: _return += c.ToString(); break;
                }
            }
            return _return.Trim();
        }
    }
}