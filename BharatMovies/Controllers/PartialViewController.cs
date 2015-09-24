using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace BharatMovies.Controllers
{
    public class PartialViewController : Controller 
    {
        
        // GET: PartialView
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Missionary(object item)
        {
            ViewBag.Item = item;
            return PartialView("_missionary");
        }
        public ActionResult Mixnmatch(object item)
        {
            ViewBag.Item = item;
            return PartialView("_mixnmatch");
        }
        public ActionResult Smallcard(object item)
        {
            ViewBag.Item = item;
            return PartialView("_smallcard");
        }
        public ActionResult Newspanel(object item)
        {
            ViewBag.Item = item;
            return PartialView("_newspanel");
        }
        public ActionResult Smallverticals(object item)
        {
            ViewBag.Item = item;
            return PartialView("_smallverticals");
        }
        public ActionResult EventCollection(object item)
        {
            ViewBag.Item = item;
            return PartialView("_eventCollection");
        }
        public ActionResult MediumCollection(object item)
        {
            ViewBag.Item = item;
            return PartialView("_mediumCollection");
        }
        public ActionResult LargeCollection(object item)
        {
            ViewBag.Item = item;
            return PartialView("_largeCollection");
        }
        public ActionResult CardPanel(string cardType, string cNo,string did)
        {
            using (var client = new HttpClient())
            {
                string baseUri = ConfigurationManager.AppSettings.Get("BaseUri");
                string returnUrl = ConfigurationManager.AppSettings.Get("ReturnUrl");
                string returnUrl3 = ConfigurationManager.AppSettings.Get("ReturnUrl3");
                string id = ConfigurationManager.AppSettings.Get("Template");
                string campainID = cNo != "" ? cNo : id;
                string uri = baseUri + "api/summary/?id=" + campainID;

                var response = client.GetAsync(uri).Result;
                
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;
                    dynamic deserializedObj = (RootObject)Newtonsoft.Json.JsonConvert.DeserializeObject(responseString, typeof(RootObject));

                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    dynamic item = serializer.Deserialize<object>(responseString);
                    

                    ViewBag.Summary = responseString;

                    ViewBag.ID = deserializedObj.ID;
                    ViewBag.Name = deserializedObj.Name;
                    ViewBag.Description = deserializedObj.Description;
                    ViewBag.SearchQuery = deserializedObj.SearchQuery;
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.ReturnUrl3 = returnUrl3;
                    ViewBag.Did = did;
                }
                else
                {
                    ViewBag.ID = campainID;
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.ReturnUrl3 = returnUrl3;
                    ViewBag.Summary = null;
                    ViewBag.Did = did;
                }
            }
            return PartialView("_CardPanel");
        }
        public ActionResult ImgGallary(string cardType, string cNo,string did)
        {
            using (var client = new HttpClient())
            {
                string baseUri = ConfigurationManager.AppSettings.Get("BaseUri");
                string returnUrl = ConfigurationManager.AppSettings.Get("ReturnUrl");
                string returnUrl3 = ConfigurationManager.AppSettings.Get("ReturnUrl3");
                string id = ConfigurationManager.AppSettings.Get("Template");
                string campainID = cNo != "" ? cNo : id;
                string uri = baseUri + "api/summary/?id=" + campainID;
                var response = client.GetAsync(uri).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;
                    dynamic deserializedObj = (RootObject)Newtonsoft.Json.JsonConvert.DeserializeObject(responseString, typeof(RootObject));

                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    dynamic item = serializer.Deserialize<object>(responseString);
                    

                    ViewBag.Summary = responseString;

                    ViewBag.ID = deserializedObj.ID;
                    ViewBag.Name = deserializedObj.Name;
                    ViewBag.Description = deserializedObj.Description;
                    ViewBag.SearchQuery = deserializedObj.SearchQuery;
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.ReturnUrl3 = returnUrl3;
                    ViewBag.Did = did;
                }
                else
                {
                    ViewBag.ID = campainID;
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.ReturnUrl3 = returnUrl3;
                    ViewBag.Summary = null;
                    ViewBag.Did = did;
                }
            }
            return PartialView("_ImgGallary");
        }
        public ActionResult Large(string cardType, string cNo,string did)
        {
            using (var client = new HttpClient())
            {
                string baseUri = ConfigurationManager.AppSettings.Get("BaseUri");
                string returnUrl = ConfigurationManager.AppSettings.Get("ReturnUrl");
                string returnUrl3 = ConfigurationManager.AppSettings.Get("ReturnUrl3");
                string id = ConfigurationManager.AppSettings.Get("Template");
                string campainID = cNo != "" ? cNo : id;
                string uri = baseUri + "api/summary/?id=" + campainID;
                
                var response = client.GetAsync(uri).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;
                    dynamic deserializedObj = (RootObject)Newtonsoft.Json.JsonConvert.DeserializeObject(responseString, typeof(RootObject));

                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    dynamic item = serializer.Deserialize<object>(responseString);
                    

                    ViewBag.Summary = responseString;

                    ViewBag.ID = deserializedObj.ID;
                    ViewBag.Name = deserializedObj.Name;
                    ViewBag.Description = deserializedObj.Description;
                    ViewBag.SearchQuery = deserializedObj.SearchQuery;
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.ReturnUrl3 = returnUrl3;
                    ViewBag.Did = did;
                }
                else
                {
                    ViewBag.ID = campainID;
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.ReturnUrl3 = returnUrl3;
                    ViewBag.Summary = null;
                    ViewBag.Did = did;
                }
            }
            return PartialView("_Large");
        }
        public ActionResult Medium(string cardType, string cNo,string did)
        {
            using (var client = new HttpClient())
            {
                string baseUri = ConfigurationManager.AppSettings.Get("BaseUri");
                string returnUrl = ConfigurationManager.AppSettings.Get("ReturnUrl");
                string returnUrl3 = ConfigurationManager.AppSettings.Get("ReturnUrl3");
                string id = ConfigurationManager.AppSettings.Get("Template");
                string campainID = cNo != "" ? cNo : id;
                string uri = baseUri + "api/summary/?id=" + campainID;
                
                var response = client.GetAsync(uri).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;
                    dynamic deserializedObj = (RootObject)Newtonsoft.Json.JsonConvert.DeserializeObject(responseString, typeof(RootObject));

                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    dynamic item = serializer.Deserialize<object>(responseString);
                    

                    ViewBag.Summary = responseString;

                    ViewBag.ID = deserializedObj.ID;
                    ViewBag.Name = deserializedObj.Name;
                    ViewBag.Description = deserializedObj.Description;
                    ViewBag.SearchQuery = deserializedObj.SearchQuery;
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.ReturnUrl3 = returnUrl3;
                    ViewBag.Did = did;
                }
                else
                {
                    ViewBag.ID = campainID;
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.ReturnUrl3 = returnUrl3;
                    ViewBag.Summary = null;
                    ViewBag.Did = did;
                }
            }
            return PartialView("_Medium");
        }
        public ActionResult PCard(string cardType, string cNo,string did)
        {
            using (var client = new HttpClient())
            {
                string baseUri = ConfigurationManager.AppSettings.Get("BaseUri");
                string returnUrl = ConfigurationManager.AppSettings.Get("ReturnUrl");
                string returnUrl3 = ConfigurationManager.AppSettings.Get("ReturnUrl3");
                string id = ConfigurationManager.AppSettings.Get("Template");
                string campainID = cNo != "" ? cNo : id;
                string uri = baseUri + "api/summary/?id=" + campainID;

                var response = client.GetAsync(uri).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;
                    dynamic deserializedObj = (RootObject)Newtonsoft.Json.JsonConvert.DeserializeObject(responseString, typeof(RootObject));

                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    dynamic item = serializer.Deserialize<object>(responseString);
                    

                    ViewBag.Summary = responseString;

                    ViewBag.ID = deserializedObj.ID;
                    ViewBag.Name = deserializedObj.Name;
                    ViewBag.Description = deserializedObj.Description;
                    ViewBag.SearchQuery = deserializedObj.SearchQuery;
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.ReturnUrl3 = returnUrl3;
                    ViewBag.Did = did;

                }
                else
                {
                    ViewBag.ID = campainID;
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.ReturnUrl3 = returnUrl3;
                    ViewBag.Summary = null;
                    ViewBag.Did = did;
                }
            }
            return PartialView("_PCard");
        }
        public ActionResult VCard(string cardType, string cNo,string did)
        {
            using (var client = new HttpClient())
            {
                string baseUri = ConfigurationManager.AppSettings.Get("BaseUri");
                string returnUrl = ConfigurationManager.AppSettings.Get("ReturnUrl");
                string returnUrl3 = ConfigurationManager.AppSettings.Get("ReturnUrl3");
                string id = ConfigurationManager.AppSettings.Get("Template");
                string campainID = cNo != "" ? cNo : id;
                string uri = baseUri + "api/summary/?id=" + campainID;

                var response = client.GetAsync(uri).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;
                    dynamic deserializedObj = (RootObject)Newtonsoft.Json.JsonConvert.DeserializeObject(responseString, typeof(RootObject));

                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    dynamic item = serializer.Deserialize<object>(responseString);
                    

                    ViewBag.Summary = responseString;

                    ViewBag.ID = deserializedObj.ID;
                    ViewBag.Name = deserializedObj.Name;
                    ViewBag.Description = deserializedObj.Description;
                    ViewBag.SearchQuery = deserializedObj.SearchQuery;
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.ReturnUrl3 = returnUrl3;
                    ViewBag.Did = did;
                }
                else
                {
                    ViewBag.ID = campainID;
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.ReturnUrl3 = returnUrl3;
                    ViewBag.Summary = null;
                    ViewBag.Did = did;
                }
            }
            return PartialView("_VCard");
        }
        public ActionResult Small(string cardType, string cNo,string did)
        {
            using (var client = new HttpClient())
            {
                string baseUri = ConfigurationManager.AppSettings.Get("BaseUri");
                string returnUrl = ConfigurationManager.AppSettings.Get("ReturnUrl");
                string returnUrl3 = ConfigurationManager.AppSettings.Get("ReturnUrl3");
                string id = ConfigurationManager.AppSettings.Get("Template");
                string campainID = cNo != "" ? cNo : id;
                string uri = baseUri + "api/summary/?id=" + campainID;

                var response = client.GetAsync(uri).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;
                    dynamic deserializedObj = (RootObject)Newtonsoft.Json.JsonConvert.DeserializeObject(responseString, typeof(RootObject));

                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    dynamic item = serializer.Deserialize<object>(responseString);
                    

                    ViewBag.Summary = responseString;

                    ViewBag.ID = deserializedObj.ID;
                    ViewBag.Name = deserializedObj.Name;
                    ViewBag.Description = deserializedObj.Description;
                    ViewBag.SearchQuery = deserializedObj.SearchQuery;
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.ReturnUrl3 = returnUrl3;
                    ViewBag.Did = did;
                }
                else
                {
                    ViewBag.ID = campainID;
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.ReturnUrl3 = returnUrl3;
                    ViewBag.Summary = null;
                    ViewBag.Did = did;
                }
            }
            return PartialView("_Small");
        }
        public ActionResult SmallVertical(string cardType, string cNo,string did)
        {
            using (var client = new HttpClient())
            {
                string baseUri = ConfigurationManager.AppSettings.Get("BaseUri");
                string returnUrl = ConfigurationManager.AppSettings.Get("ReturnUrl");
                string returnUrl3 = ConfigurationManager.AppSettings.Get("ReturnUrl3");
                string id = ConfigurationManager.AppSettings.Get("Template");
                string campainID = cNo != "" ? cNo : id;
                string uri = baseUri + "api/summary/?id=" + campainID;
                
                var response = client.GetAsync(uri).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;
                    dynamic deserializedObj = (RootObject)Newtonsoft.Json.JsonConvert.DeserializeObject(responseString, typeof(RootObject));

                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    dynamic item = serializer.Deserialize<object>(responseString);
                    

                    ViewBag.Summary = responseString;

                    ViewBag.ID = deserializedObj.ID;
                    ViewBag.Name = deserializedObj.Name;
                    ViewBag.Description = deserializedObj.Description;
                    ViewBag.SearchQuery = deserializedObj.SearchQuery;
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.ReturnUrl3 = returnUrl3;
                    ViewBag.Did = did;
                }
                else
                {
                    ViewBag.ID = campainID;
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.ReturnUrl3 = returnUrl3;
                    ViewBag.Summary = null;
                    ViewBag.Did = did;      
                }
            }
            return PartialView("_SmallVertical");
        }
        public ActionResult VCardAuto(string cardType, string cNo,string did)
        {
            using (var client = new HttpClient())
            {
                string baseUri = ConfigurationManager.AppSettings.Get("BaseUri");
                string returnUrl = ConfigurationManager.AppSettings.Get("ReturnUrl");
                string returnUrl3 = ConfigurationManager.AppSettings.Get("ReturnUrl3");
                string id = ConfigurationManager.AppSettings.Get("Template");
                string campainID = cNo != "" ? cNo : id;
                string uri = baseUri + "api/summary/?id=" + cNo!="" ? cNo : id;
                ViewBag.Did = did;
                var response = client.GetAsync(uri).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;
                    dynamic deserializedObj = (RootObject)Newtonsoft.Json.JsonConvert.DeserializeObject(responseString, typeof(RootObject));

                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    dynamic item = serializer.Deserialize<object>(responseString);
                    

                    ViewBag.Summary = responseString;

                    ViewBag.ID = deserializedObj.ID;
                    ViewBag.Name = deserializedObj.Name;
                    ViewBag.Description = deserializedObj.Description;
                    ViewBag.SearchQuery = deserializedObj.SearchQuery;
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.ReturnUrl3 = returnUrl3;

                }
                else
                {
                    ViewBag.ID = campainID;
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.ReturnUrl3 = returnUrl3;
                    ViewBag.Summary = null;
                }
            }
            return PartialView("_VCardAuto");
        }
    }
}