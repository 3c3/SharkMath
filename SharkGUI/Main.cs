using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using SharkGUI.Properties;
using System.Net;
using System.IO;
using SharkMath;
using System.Runtime.InteropServices;
using System.Windows.Forms.VisualStyles;  

namespace SharkGUI
{
    public partial class Main : Form
    {
        public Main()
        {

            InitializeComponent();
            this.BrowserDock.MouseDown += BrowserDock_MouseDown;

            InitBrowser();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private const int WM_NCHITTEST = 0x84;
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCLIENT = 0x1;
        private const int HT_CAPTION = 0x2;


        public static string Utf8String(string s) {
            byte[] bytes = Encoding.Default.GetBytes(s);
            return Encoding.UTF8.GetString(bytes);
        }

        public ChromiumWebBrowser browser;
        public void InitBrowser()
        {
            var settings = new CefSettings();


            settings.MultiThreadedMessageLoop = true;
           /* settings.RegisterScheme(new CefCustomScheme() {
                SchemeName = "app"//,
            //    SchemeHandlerFactory = new AppSchemeHandlerFactory()
            });
*/

            Cef.OnContextInitialized = delegate
            {
                var cookieManager = Cef.GetGlobalCookieManager();
                cookieManager.SetStoragePath("cookies", true);
                cookieManager.SetSupportedSchemes("app");
                cookieManager.SetSupportedSchemes("chrome-devtools");
            };

            settings.LogSeverity = LogSeverity.Disable;
            settings.Locale = "bg";
            settings.RegisterScheme(new CefCustomScheme() { 
               SchemeName = "app",
               SchemeHandlerFactory = new AppSchemeHandlerFactory()
            });

            BrowserSettings browser_settigns = new BrowserSettings
            {
                DefaultEncoding = "utf-8"
            };
            
            
            Cef.Initialize(settings);



            browser = new ChromiumWebBrowser("");
            browser.BrowserSettings = browser_settigns;
            browser.RegisterJsObject("app", new AppObject(this.Handle));
            browser.LoadError += browser_LoadError;
            //browser.Click += browser_Click;
           // browser = new ChromiumWebBrowser("main");


            var handler = browser.ResourceHandlerFactory as DefaultResourceHandlerFactory;


            handler.RegisterHandler("app://bundle.js", ResourceHandler.FromString(Resources.bundle, Encoding.UTF8));
            handler.RegisterHandler("app://main", ResourceHandler.FromString(Resources.index, Encoding.UTF8));
            

            browser.IsBrowserInitializedChanged += browser_IsBrowserInitializedChanged;
            this.BrowserDock.Controls.Add(browser);
            //IBrowser b = browser.GetBrowser();
            browser.Dock = DockStyle.Fill;
        }


        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        void BrowserDock_MouseDown(object sender, MouseEventArgs e)
        {

        }

        void browser_Click(object sender, EventArgs e)
        {
            //Console.WriteLine("event: click");
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        void browser_LoadError(object sender, LoadErrorEventArgs e)
        {
            //Console.WriteLine("Load error: {0}, url: {1}, coed: {2}, from: {3}", e.ErrorText, e.FailedUrl, e.ErrorCode, sender.GetType());
        }

        void browser_IsBrowserInitializedChanged(object sender, IsBrowserInitializedChangedEventArgs e)
        {

            if (browser.IsBrowserInitialized)
            {
              //  Console.WriteLine(Resources.index);
                browser.Load("app://main");
                //browser.Load(@"app://main/index");
                //browser.ShowDevTools();
            }
  
            //Console.WriteLine("Browser init {0}", browser.IsBrowserInitialized);

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            //Console.WriteLine("event: mouse down");
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minimiza_button_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

    }
}
