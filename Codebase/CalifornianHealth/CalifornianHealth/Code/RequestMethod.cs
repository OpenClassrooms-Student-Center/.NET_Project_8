using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace CalifornianHealth.Code
{
    public class RequestMethod
    {
        string configUserName = string.Empty;
        string configPassword = string.Empty;
        string apiKey = ConfigurationManager.AppSettings["apiKey"].ToString();
        public HttpStatusCode statusCode { get; set; }

        public HttpResponseMessage PostAndGetContent(String url, String json)
        {
            try
            {
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                content.Headers.Add("apiKey", apiKey);
                if (HttpContext.Current.Session["UserId"] != null)
                    content.Headers.Add("userId", HttpContext.Current.Session["UserId"].ToString());
                var client = SetupHttpClient(configUserName, configPassword);
                client.Timeout = TimeSpan.FromMinutes(5);

                client.DefaultRequestHeaders.UserAgent.Clear();

                HttpResponseMessage _responseContent = client.PostAsync(url, content).Result;
                client.Dispose();
                return _responseContent;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HttpResponseMessage PutAndGetContent(String url, String json)
        {
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            content.Headers.Add("apiKey", apiKey);
            if (HttpContext.Current.Session["UserId"] != null)
                content.Headers.Add("userId", HttpContext.Current.Session["UserId"].ToString());
            var client = SetupHttpClient(configUserName, configPassword);
            HttpResponseMessage _responseContent = client.PutAsync(url, content).Result;
            client.Dispose();
            return _responseContent;
        }

        public HttpResponseMessage GetContent(String url)
        {
            if (!String.IsNullOrEmpty(apiKey))
                url = (url.EndsWith("?")) ? String.Format("{0}apiKey={1}", url, apiKey) : String.Format("{0}&apiKey={1}", url, apiKey);

            try
            {
                var client = SetupHttpClient(configUserName, configPassword);
                HttpResponseMessage _responseContent = client.GetAsync(url).Result;
                client.Dispose();
                return _responseContent;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Error parsing URL {0} : {1}", url, ex.Message));
            }
        }

        public HttpResponseMessage DeleteContent(String url)
        {
            if (!String.IsNullOrEmpty(apiKey))
                url = (url.EndsWith("?")) ? String.Format("{0}apiKey={1}", url, apiKey) : String.Format("{0}&apiKey={1}", url, apiKey);

            try
            {
                var client = SetupHttpClient(configUserName, configPassword);
                HttpResponseMessage _responseContent = client.DeleteAsync(url).Result;
                client.Dispose();
                return _responseContent;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Error parsing URL {0} : {1}", url, ex.Message));
            }
        }

        public HttpClient SetupHttpClient(string userName, string password)
        {
            var client = new HttpClient();
            if (!String.IsNullOrEmpty(userName) && !String.IsNullOrEmpty(password))
            {
                var buffer = Encoding.ASCII.GetBytes(userName + ":" + password);
                var authHeader = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(buffer));
                client.DefaultRequestHeaders.Authorization = authHeader;
            }
            return client;
        }
    }
}