using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EnWebside
{
    class WebHandler : IRequest<WebRequest,string>, IWebResponse<WebResponse, WebRequest>
    {
        public WebResponse GetResponse(WebRequest request)
        {
            return request.GetResponse();
        }

        public WebRequest MakeRequest(string website)
        {
            return WebRequest.Create(website);
        }

        public string GetWebContent(IRequest<WebRequest, string> request, IWebResponse<WebResponse, WebRequest> response, string website)
        {
            //Prints out the status of the website
            WebRequest webRequest = request.MakeRequest(website);
            WebResponse webResponse = response.GetResponse(webRequest);
            Console.WriteLine(((HttpWebResponse)webResponse).StatusDescription);
            string responseHtml;
            using (StreamReader responseStream = new StreamReader(webResponse.GetResponseStream()))
            {
                responseHtml = responseStream.ReadToEnd().Trim();
            }
            return responseHtml;
        }
    }
}
