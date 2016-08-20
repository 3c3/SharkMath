using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharkGUI
{
    class AppSchemeHandlerFactory : ISchemeHandlerFactory
    {
        public IResourceHandler Create(IBrowser browser, IFrame frame, string schemeName, IRequest request)
        {
            return new AppResourceHandler();
        }
    }
}
