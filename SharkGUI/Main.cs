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

namespace SharkGUI
{

    class AppResourceHandler : IResourceHandler
    {
        private Dictionary<string, string> ResourceDictionary;
        private MemoryStream stream;
        private string mimeType;

        public AppResourceHandler()
        {
            ResourceDictionary = new Dictionary<string, string>
            {
                { "/", Resources.index },
                { "/bundle.js", Resources.bundle }
            };
        }
        public System.IO.Stream GetResponse(IResponse response, out long responseLength, out string redirectUrl)
        {
            responseLength = stream.Length;
            redirectUrl = null;

            response.StatusCode = (int)HttpStatusCode.OK;
            response.StatusText = "OK";
            response.MimeType = mimeType;

            return stream;
        }

        public bool ProcessRequestAsync(IRequest request, ICallback callback)
        {
            var uri = request.Url.Split(new char[]{'/'}).Last();
            var fileName = uri;
            string resource;
            if (ResourceDictionary.TryGetValue(fileName, out resource) && !string.IsNullOrEmpty(resource))
            {
                Console.WriteLine("Loading: {0}", uri);

                Task.Run(() =>
                {
                    using (callback)
                    {
                        var bytes = Encoding.UTF8.GetBytes(resource);
                        stream = new MemoryStream(bytes);

                        var fileExtension = Path.GetExtension(fileName);
                        mimeType = ResourceHandler.GetMimeType(fileExtension);
                        Console.WriteLine("Loaded: {0} {1}", fileName, resource);

                        callback.Continue();
                    }
                });
            }
            else
            {
                callback.Dispose();
            }
            return true;
        }
    }
    class AppSchemeHandlerFactory : ISchemeHandlerFactory {

        public IResourceHandler Create(IBrowser browser, IFrame frame, string schemeName, IRequest request)
        {
            return new AppResourceHandler();
        }
    }

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

        public ChromiumWebBrowser browser;
        public void InitBrowser()
        {
            var settings = new CefSettings();


            settings.MultiThreadedMessageLoop = true;
            settings.RegisterScheme(new CefCustomScheme() {
                SchemeName = "app",
                SchemeHandlerFactory = new AppSchemeHandlerFactory()
            });

            settings.RegisterScheme(new CefCustomScheme()
            {
                SchemeName = "app",
                SchemeHandlerFactory = new AppSchemeHandlerFactory()
            });

            Cef.OnContextInitialized = delegate
            {
                var cookieManager = Cef.GetGlobalCookieManager();
                cookieManager.SetStoragePath("cookies", true);
                cookieManager.SetSupportedSchemes("app");
            };

            settings.LogSeverity = LogSeverity.Verbose;
            Cef.Initialize(settings);

            browser = new ChromiumWebBrowser("");
            browser.RegisterJsObject("app", new Binded());
           // browser = new ChromiumWebBrowser("main");


            var handler = browser.ResourceHandlerFactory as DefaultResourceHandlerFactory;
            handler.RegisterHandler("app://bundle.js", ResourceHandler.FromString(Resources.bundle));
            browser.IsBrowserInitializedChanged += browser_IsBrowserInitializedChanged;
            this.Controls.Add(browser);
            //IBrowser b = browser.GetBrowser();
            browser.Dock = DockStyle.Fill;
        }

        void browser_IsBrowserInitializedChanged(object sender, IsBrowserInitializedChangedEventArgs e)
        {

            if (browser.IsBrowserInitialized)
            {
                Console.WriteLine(Resources.index);
                browser.LoadHtml(Resources.index , "app://main");
                browser.ShowDevTools();
               //browser.Load(@"app://index/");
            }
  
            Console.WriteLine("Browser init {0}", browser.IsBrowserInitialized);

        }
    }

    class Binded {
        public string Show(string name) {
            MessageBox.Show("Hello " + name, "Greeter", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return "Hello " + name;
        }
    }
}
