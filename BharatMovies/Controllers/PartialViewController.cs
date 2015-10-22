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
        public ActionResult Masonry(object item)
        {
            ViewBag.Item = item;
            return PartialView("_masonry");
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
        public ActionResult CardPanel(string cardType, string cNo,string style)
        {
            using (var client = new HttpClient())
            {
                string baseUri = ConfigurationManager.AppSettings.Get("BaseUri");
              
                string id = ConfigurationManager.AppSettings.Get("Template");
                string campainID = cNo != "" ? cNo : id;
                string uri = baseUri + "api/summary/?id=" + campainID;

                var response = client.GetAsync(uri).Result;
                ViewBag.Did = campainID + "-CardPanel-" + System.Guid.NewGuid().ToString();
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
                  
                    //ViewBag.Did = did;
                    ViewBag.Style = style;
                }
                else
                {
                    ViewBag.ID = campainID;
                  
                    //ViewBag.Did = did;
                    ViewBag.Style = style;
                }
            }
            return PartialView("_CardPanel");
        }
        public ActionResult ImgGallary(string cardType, string cNo,string style)
        {
            using (var client = new HttpClient())
            {
                string baseUri = ConfigurationManager.AppSettings.Get("BaseUri");
                
                string id = ConfigurationManager.AppSettings.Get("Template");
                string campainID = cNo != "" ? cNo : id;
                string uri = baseUri + "api/summary/?id=" + campainID;
                var response = client.GetAsync(uri).Result;
                ViewBag.Did = campainID + "-ImgGallery-" + System.Guid.NewGuid().ToString();
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
                
                   // ViewBag.Did = did;
                    ViewBag.Style = style;
                }
                else
                {
                    ViewBag.ID = campainID;
                    
                    //ViewBag.Did = did;
                    ViewBag.Style = style;
                }
            }
            return PartialView("_ImgGallary");
        }
        public ActionResult Large(string cardType, string cNo, string style)
        {
            using (var client = new HttpClient())
            {
                string baseUri = ConfigurationManager.AppSettings.Get("BaseUri");
                
                string id = ConfigurationManager.AppSettings.Get("Template");
                string campainID = cNo != "" ? cNo : id;
                string uri = baseUri + "api/summary/?id=" + campainID;
                
                var response = client.GetAsync(uri).Result;
                ViewBag.Did = campainID + "-Large-" + System.Guid.NewGuid().ToString();
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
                   
                    //ViewBag.Did = did;
                    ViewBag.Style = style;
                }
                else
                {
                    ViewBag.ID = campainID;
                   
                    //ViewBag.Did = did;
                    ViewBag.Style = style;
                }
            }
            return PartialView("_Large");
        }
        public ActionResult Medium(string cardType, string cNo, string style)
        {
            using (var client = new HttpClient())
            {
                string baseUri = ConfigurationManager.AppSettings.Get("BaseUri");
                
                string id = ConfigurationManager.AppSettings.Get("Template");
                string campainID = cNo != "" ? cNo : id;
                string uri = baseUri + "api/summary/?id=" + campainID;
                
                var response = client.GetAsync(uri).Result;
                ViewBag.Did = campainID + "-Medium-" + System.Guid.NewGuid().ToString();
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
                   
                    //ViewBag.Did = did;
                    ViewBag.Style = style;
                }
                else
                {
                    ViewBag.ID = campainID;
                 
                    //ViewBag.Did = did;
                    ViewBag.Style = style;
                }
            }
            return PartialView("_Medium");
        }
        public ActionResult PCard(string cardType, string cNo,string style)
        {
            using (var client = new HttpClient())
            {
                string baseUri = ConfigurationManager.AppSettings.Get("BaseUri");
                
                string id = ConfigurationManager.AppSettings.Get("Template");
                string campainID = cNo != "" ? cNo : id;
                string uri = baseUri + "api/summary/?id=" + campainID;

                var response = client.GetAsync(uri).Result;
                ViewBag.Did = campainID + "-PCard-" + System.Guid.NewGuid().ToString();
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
                   
                    //ViewBag.Did = did;
                    ViewBag.Style = style;
                   
                }
                else
                {
                    ViewBag.ID = campainID;
                   
                    //ViewBag.Did = did;
                    ViewBag.Style = style;
                }
            }
            return PartialView("_PCard");
        }
        public ActionResult PCardStory(string cardType, string cNo, string style,string Storyid)
        {
            using (var client = new HttpClient())
            {
                string baseUri = ConfigurationManager.AppSettings.Get("BaseUri");
                
                string id = ConfigurationManager.AppSettings.Get("Template");
                string campainID = cNo != "" ? cNo : id;
                string uri = baseUri + "api/summary/story/?id=" + campainID+"&storyid="+Storyid;

                var response = client.GetAsync(uri).Result;
                ViewBag.Did = campainID + "-PCard-" + System.Guid.NewGuid().ToString();
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
                   
                    ViewBag.storyID = Storyid;
                    ViewBag.Style = style;

                }
                else
                {
                    ViewBag.ID = campainID;
                  
                    ViewBag.storyID = Storyid;
                    ViewBag.Style = style;
                }
            }
            return PartialView("_StoryPCard");
        }
        public ActionResult VCard(string cardType, string cNo,string style)
        {
            using (var client = new HttpClient())
            {
                string baseUri = ConfigurationManager.AppSettings.Get("BaseUri");
              
                string id = ConfigurationManager.AppSettings.Get("Template");
                string campainID = cNo != "" ? cNo : id;
                string uri = baseUri + "api/summary/?id=" + campainID;

                var response = client.GetAsync(uri).Result;
                ViewBag.Did = campainID + "-VCard-" + System.Guid.NewGuid().ToString();
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
                    
                    //ViewBag.Did = did;
                    ViewBag.Style = style;
                }
                else
                {
                    ViewBag.ID = campainID;
                 
                    ViewBag.Summary = null;
                    //ViewBag.Did = did;
                    ViewBag.Style = style;
                }
            }
            return PartialView("_VCard");
        }
        public ActionResult Small(string cardType, string cNo, string style)
        {
            using (var client = new HttpClient())
            {
                string baseUri = ConfigurationManager.AppSettings.Get("BaseUri");
              
                string id = ConfigurationManager.AppSettings.Get("Template");
                string campainID = cNo != "" ? cNo : id;
                string uri = baseUri + "api/summary/?id=" + campainID;

                var response = client.GetAsync(uri).Result;
                ViewBag.Did = campainID + "-Small-" + System.Guid.NewGuid().ToString();
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
                    
                    ViewBag.Style = style;
                }
                else
                {
                    ViewBag.ID = campainID;
                    
                    ViewBag.Style = style;
                }
            }
            return PartialView("_Small");
        }
        public ActionResult SmallVertical(string cardType, string cNo, string style)
        {
            using (var client = new HttpClient())
            {
                string baseUri = ConfigurationManager.AppSettings.Get("BaseUri");
            
                string id = ConfigurationManager.AppSettings.Get("Template");
                string campainID = cNo != "" ? cNo : id;
                string uri = baseUri + "api/summary/?id=" + campainID;
                
                var response = client.GetAsync(uri).Result;
                ViewBag.Did = campainID + "-SmallVertical-" + System.Guid.NewGuid().ToString();
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
                    ViewBag.Description += deserializedObj.Description;
                    ViewBag.SearchQuery = deserializedObj.SearchQuery;
                   
                    //ViewBag.Did = did;
                    ViewBag.Style = style;
                }
                else
                {
                    ViewBag.ID = campainID;
                   
                    ViewBag.Summary = null;
                    //ViewBag.Did = did;
                    ViewBag.Style = style;
                }
            }
            return PartialView("_SmallVertical");
        }
        public ActionResult VCardAuto(string cardType, string cNo, string style)
        {
            using (var client = new HttpClient())
            {
                string baseUri = ConfigurationManager.AppSettings.Get("BaseUri");
              
                string id = ConfigurationManager.AppSettings.Get("Template");
                string campainID = cNo != "" ? cNo : id;
                string uri = baseUri + "api/summary/?id=" + cNo!="" ? cNo : id;
                ViewBag.Did = campainID + "-VCardAuto-" + System.Guid.NewGuid().ToString();
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
                    ViewBag.Description += deserializedObj.Description;
                    ViewBag.SearchQuery = deserializedObj.SearchQuery;
                   
                    ViewBag.Style = style;
                }
                else
                {
                    ViewBag.ID = campainID;
                
                    ViewBag.Summary = null;
                    ViewBag.Style = style;
                }
            }
            return PartialView("_VCardAuto");
        }

        public ActionResult StoryCard(string cardType, string cNo, string style, string StoryId, Boolean Isslider)
        {
            using (var client = new HttpClient())
            {
                string baseUri = ConfigurationManager.AppSettings.Get("BaseUri");
           
                string id = ConfigurationManager.AppSettings.Get("Template");
                string campainID = cNo != "" ? cNo : id;
                string uri = baseUri + "api/summary/story/?id=" + campainID + "&storyid=" + StoryId;
                ViewBag.Isslider = Isslider;
                ViewBag.Did = campainID + "-" + cardType +"-" + System.Guid.NewGuid().ToString();
                var response = client.GetAsync(uri).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;
                    dynamic deserializedObj = (RootObject)Newtonsoft.Json.JsonConvert.DeserializeObject(responseString, typeof(RootObject));

                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    dynamic item = serializer.Deserialize<object>(responseString);


                    ViewBag.Summary = responseString;

                    ViewBag.ID = campainID;
                    ViewBag.Name = deserializedObj.Name;
                   
                    ViewBag.storyID = StoryId;
                    ViewBag.Style = style;
                }
                else
                {
                    ViewBag.ID = campainID;
                    
                    ViewBag.Summary = null;
                    ViewBag.storyID = StoryId;
                    ViewBag.Style = style;
                }
            }
            if (cardType == "PCARD")
                return PartialView("_StoryPCard");
            else if (cardType == "VCARD")
                return PartialView("_StoryVCardAuto");
            else if (cardType == "CARDPANEL")
                return PartialView("_StoryCardPanel");
            else if (cardType == "SMALL")
                return PartialView("_StorySmall");
            else
                return PartialView();
        }

    }
}