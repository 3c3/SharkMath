using CefSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SharkGUI
{
    class AppResourceHandler : IResourceHandler
    {
        private string mimeType;
        private MemoryStream stream;
        public bool ProcessRequestAsync(IRequest request, ICallback callback)
        {
            var uri = new Uri(request.Url);
            var segments = uri.Segments;
            var file = segments[segments.Length - 1];

            Task.Run(() =>
            {
                // Base to dispose of callback as it wraps a managed resource
                using (callback)
                {
                    //Perform processing here

                    // When processing complete call continue
                    callback.Continue();
                }
            });

            return true;
        }

        public Stream GetResponse(IResponse response, out long responseLength, out string redirectUrl)
        {
            //How long is your stream?
            if(stream == null){
                responseLength = 0;
                redirectUrl = null;
                return new MemoryStream();
            }
            responseLength = stream.Length;
            //Set to null if not redirecting to a different url
            redirectUrl = null;

            //Set response related stuff here
            response.StatusCode = (int)HttpStatusCode.OK;
            response.StatusText = "OK";
            response.MimeType = mimeType;

            //Return your populated stream
            return stream;
        }   
    }
}