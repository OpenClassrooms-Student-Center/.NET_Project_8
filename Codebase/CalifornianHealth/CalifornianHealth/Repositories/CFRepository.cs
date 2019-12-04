using CalifornianHealth.Code;
using CalifornianHealth.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace CalifornianHealth.Repositories
{
    public class CFRepository
    {
        public ISerialization _serializer;
        private readonly string restService = ConfigurationManager.AppSettings["restService"].ToString();
        private RequestMethod requestMethod = new RequestMethod();
        public ReturnErrorModel modelStateErrors { get; set; }
        public ExceptionHandler modelExceptionErrors { get; set; }

        public bool CreateBooking(BookingModel model)
        {
            try
            {
                string json = Serialize(model);
                HttpResponseMessage responseContent = requestMethod.PostAndGetContent(string.Format("{0}CreateBooking", restService), json);
                if (responseContent.StatusCode == HttpStatusCode.Created)
                {
                    var createdCarnetAttachmentModel = Deserialize<BookingModel>(responseContent.Content.ReadAsStringAsync().Result);
                    return true;
                }
                else if (responseContent.StatusCode == HttpStatusCode.BadRequest)
                {
                    modelStateErrors = Deserialize<ReturnErrorModel>(responseContent.Content.ReadAsStringAsync().Result);
                    return false;
                }
                else if (responseContent.StatusCode == HttpStatusCode.InternalServerError)
                {
                    modelExceptionErrors = Deserialize<ExceptionHandler>(responseContent.Content.ReadAsStringAsync().Result);
                    string message = String.Format("System Error in {0} : {1} ", System.Reflection.MethodBase.GetCurrentMethod().Name, modelExceptionErrors.exceptionMessage);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ConsultantCalendar GetConsultantCalendar(int consultantId)
        {
            try
            {
                HttpResponseMessage responseContent = requestMethod.GetContent(string.Format("{0}ConsultantCalendar/{1}?", restService, id));
                if (responseContent.StatusCode == HttpStatusCode.OK)
                {
                    var consultantCalendar = Deserialize<ConsultantCalendar>(responseContent.Content.ReadAsStringAsync().Result);
                    return consultantCalendar;
                }
                else if (responseContent.StatusCode == HttpStatusCode.BadRequest)
                {
                    modelStateErrors = Deserialize<ReturnErrorModel>(responseContent.Content.ReadAsStringAsync().Result);
                    return null;
                }
                else if (responseContent.StatusCode == HttpStatusCode.InternalServerError)
                {
                    modelExceptionErrors = Deserialize<ExceptionHandler>(responseContent.Content.ReadAsStringAsync().Result);
                    return null;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string Serialize<T>(T obj)
        {
            var retVal = _serializer.Serialize<T>(obj);
            return retVal;
        }

        private T Deserialize<T>(string responseContent)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Formatting = Formatting.None;
            settings.StringEscapeHandling = StringEscapeHandling.Default;
            return JsonConvert.DeserializeObject<T>(responseContent, settings);
        }
    }
}