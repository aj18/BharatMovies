using System;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;
using System.IO;
using System.Collections.Generic;

namespace BharatMovies.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //[OutputCache(Duration = 3600, VaryByParam = "none")]
        public ActionResult Index()
        {
            using (var client = new HttpClient())
            {
                string baseUri = ConfigurationManager.AppSettings.Get("BaseUri");
                string returnUrl = ConfigurationManager.AppSettings.Get("ReturnUrl");
                string returnUrl3 = ConfigurationManager.AppSettings.Get("ReturnUrl3");
                string id = ConfigurationManager.AppSettings.Get("Template");

                string uri = baseUri + "api/summary/template/?id=" + id;

                var response = client.GetAsync(uri).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;
                    dynamic deserializedObj = (RootObject)Newtonsoft.Json.JsonConvert.DeserializeObject(responseString, typeof(RootObject));

                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    dynamic item = serializer.Deserialize<object>(responseString);
                    string test = item["_id"];

                    ViewBag.data = responseString;

                    ViewBag.ID = deserializedObj.ID;
                    ViewBag.Name = deserializedObj.Name;
                    ViewBag.Description = deserializedObj.Description;
                    ViewBag.SearchQuery = deserializedObj.SearchQuery;
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.ReturnUrl3 = returnUrl3;

                }
            }
            
            return View();
        }

        ////[OutputCache(Duration = 3600, VaryByParam = "id")]
        public ActionResult News(string id)
        {
            using (var client = new HttpClient())
            {
                string baseUri = ConfigurationManager.AppSettings.Get("BaseUri");
                string returnUrl = ConfigurationManager.AppSettings.Get("ReturnUrl");
                string returnUrl2 = ConfigurationManager.AppSettings.Get("ReturnUrl2");
                string returnUrl3 = ConfigurationManager.AppSettings.Get("ReturnUrl3");

                string uri = baseUri + "api/summary/?id=" + id;

                var response = client.GetAsync(uri).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;
                    dynamic deserializedObj = (RootObject)Newtonsoft.Json.JsonConvert.DeserializeObject(responseString, typeof(RootObject));

                    ViewBag.Summary = responseString;

                    ViewBag.ID = deserializedObj.ID;
                    ViewBag.Name = deserializedObj.Name;
                    ViewBag.StoryId = deserializedObj.StoryId;
                    ViewBag.Name = deserializedObj.Name;
                    ViewBag.Stories = deserializedObj.Stories;
                    ViewBag.Description = deserializedObj.Description;
                    ViewBag.SearchQuery = deserializedObj.SearchQuery;
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.ReturnUrl2 = returnUrl2;
                    ViewBag.ReturnUrl3 = returnUrl3;

                }
            }
           


            
            return View();
        }


        //[OutputCache(Duration = 3600, VaryByParam = "id")]
        public ActionResult Story(string id , string storyid)
        {
            using (var client = new HttpClient())
            {
                string baseUri = ConfigurationManager.AppSettings.Get("BaseUri");
                string returnUrl = ConfigurationManager.AppSettings.Get("ReturnUrl");
                string returnUrl2 = ConfigurationManager.AppSettings.Get("ReturnUrl2");
                string returnUrl3 = ConfigurationManager.AppSettings.Get("ReturnUrl3");

                string uri = baseUri + "api/summary/?id=" + id;

                var response = client.GetAsync(uri).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;
                    dynamic deserializedObj = (RootObject)Newtonsoft.Json.JsonConvert.DeserializeObject(responseString, typeof(RootObject));

                    ViewBag.Summary = responseString;

                    ViewBag.ID = deserializedObj.ID;
                    ViewBag.StoryId = storyid;
                    ViewBag.Name = deserializedObj.Name;
                    ViewBag.Stories = deserializedObj.Stories;

                    ViewBag.Description = deserializedObj.Description;
                    ViewBag.SearchQuery = deserializedObj.SearchQuery;
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.ReturnUrl2 = returnUrl2;
                    ViewBag.ReturnUrl3 = returnUrl3;

                }
            }




            return View();
        }

        public ActionResult Comments(string id, string q, string type)
        {
            string baseUri = ConfigurationManager.AppSettings.Get("BaseUri");
            string returnUrl = ConfigurationManager.AppSettings.Get("ReturnUrl");
            string returnUrl2 = ConfigurationManager.AppSettings.Get("ReturnUrl2");
            string returnUrl3 = ConfigurationManager.AppSettings.Get("ReturnUrl3");
         


            using (var client = new HttpClient())
            {


                string uri = baseUri + "api/summary/?id=" + id;

                var response = client.GetAsync(uri).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;
                    dynamic deserializedObj = (RootObject)Newtonsoft.Json.JsonConvert.DeserializeObject(responseString, typeof(RootObject));

                    ViewBag.Summary = responseString;


                    ViewBag.Name = deserializedObj.Name;
                    ViewBag.Description = deserializedObj.Description;
                    ViewBag.SearchQuery = deserializedObj.SearchQuery;


                }
            }
            ViewBag.ID = id;
            ViewBag.q = q;
            ViewBag.type = type;
            ViewBag.ReturnUrl = returnUrl;
            ViewBag.ReturnUrl2 = returnUrl2;
            ViewBag.ReturnUrl3 = returnUrl3;
            return View();
        }


        public ActionResult Advertise()
        {
           
            return View();
        }
        public ActionResult Contact()
        {

            return View();
        }
        public ActionResult Privacy()
        {

            return View();
        }
        public ActionResult CopyWrite()
        {

            return View();
        }
        //public ActionResult Story()
        //{

        //    return View("Story");
        //}
    }

    public class RootObject
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool ShowDefaultPicture { get; set; }
        public string SearchQuery { get; set; }
        public int VideosCount { get; set; }
        public int PhotosCount { get; set; }
        public string PictureUrl { get; set; }

        public string Photo { get; set; }
        public object Video { get; set; }
        public int Total { get; set; }

        public string StoryId { get; set; }
        public string StoryTitle { get; set; }
        public IList<object> Stories { get; set; }



        public object Comments { get; set; }

        public string Decision { get; set; }
        public string DecisionImage { get; set; }
        public object ReturnUrl { get; set; }
        public object ContainerID { get; set; }
    }
}