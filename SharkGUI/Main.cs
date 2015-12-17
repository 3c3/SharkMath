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

namespace SharkGUI
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            InitBrowser();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

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

            settings.LogSeverity = LogSeverity.Verbose;
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
            browser.RegisterJsObject("app", new AppObject());
            browser.LoadError += browser_LoadError;
           // browser = new ChromiumWebBrowser("main");


            var handler = browser.ResourceHandlerFactory as DefaultResourceHandlerFactory;


            handler.RegisterHandler("app://bundle.js", ResourceHandler.FromString(Utf8String(Resources.bundle), Encoding.UTF8));
            handler.RegisterHandler("app://main", ResourceHandler.FromString(Utf8String(Resources.index), Encoding.UTF8));
            

            browser.IsBrowserInitializedChanged += browser_IsBrowserInitializedChanged;
            this.Controls.Add(browser);
            //IBrowser b = browser.GetBrowser();
            browser.Dock = DockStyle.Fill;
        }

        void browser_LoadError(object sender, LoadErrorEventArgs e)
        {
            Console.WriteLine("Load error: {0}, url: {1}, coed: {2}, from: {3}", e.ErrorText, e.FailedUrl, e.ErrorCode, sender.GetType());
        }

        void browser_IsBrowserInitializedChanged(object sender, IsBrowserInitializedChangedEventArgs e)
        {

            if (browser.IsBrowserInitialized)
            {
              //  Console.WriteLine(Resources.index);
                browser.Load("app://main");
                //browser.Load(@"app://main/index");
                browser.ShowDevTools();
            }
  
            Console.WriteLine("Browser init {0}", browser.IsBrowserInitialized);

        }
    }
}
