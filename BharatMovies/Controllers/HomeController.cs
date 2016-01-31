using System;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;
using System.IO;
using System.Collections.Generic;
using BharatMovies.Models;
using System.Web;
using System.Net;
using System.Net.Mail;


namespace BharatMovies.Controllers
{
    
    public class HomeController : Controller
    {
        string responseString = "";
        // GET: Preview
        //[OutputCache(Duration = 3600, VaryByParam = "none")]
        public ActionResult Preview(string id)
        {
            using (var client = new HttpClient())
            {
                string baseUri = ConfigurationManager.AppSettings.Get("BaseUri");
                string returnUrl = ConfigurationManager.AppSettings.Get("ReturnUrl");
                string returnUrl3 = ConfigurationManager.AppSettings.Get("ReturnUrl3");
              

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
                   
                    ViewBag.Name = deserializedObj.Name;
                    ViewBag.SearchQuery = deserializedObj.SearchQuery;

                    ViewBag.Title = deserializedObj.Title;
                    ViewBag.Description = deserializedObj.Description;
                    ViewBag.Keyword = deserializedObj.Keyword;


                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.ReturnUrl3 = returnUrl3;

                }
            }
            
            return View("Index");
        }

        // GET: Home
        //[OutputCache(Duration = 3600, VaryByParam = "none")]
        public ActionResult Index()
        {
            string returnUrl = ConfigurationManager.AppSettings.Get("ReturnUrl");
            string returnUrl3 = ConfigurationManager.AppSettings.Get("ReturnUrl3");
            if (Session["bolly_default"] == null)
            {
                responseString = Common.GetTempateData();
                Session["bolly_default"] = responseString;
            }
            else
            {
                responseString = (string)Session["bolly_default"];
            }

            dynamic deserializedObj = (RootObject)Newtonsoft.Json.JsonConvert.DeserializeObject(responseString, typeof(RootObject));
            
            ViewBag.data = responseString;
            ViewBag.ID = deserializedObj.ID;
            ViewBag.Name = deserializedObj.Name;
            ViewBag.Title = deserializedObj.Title;
            ViewBag.Description = deserializedObj.Description;
            ViewBag.Keyword = deserializedObj.Keyword;
            ViewBag.SearchQuery = deserializedObj.SearchQuery;
            ViewBag.ReturnUrl = returnUrl;
            ViewBag.ReturnUrl3 = returnUrl3;
            return View();
        }

        //[OutputCache(Duration = 3600, VaryByParam = "id")]
        public ActionResult News(string id)
        {
            if (Session["bolly_default"] == null)
            {
                responseString = Common.GetTempateData();
                Session["bolly_default"] = responseString;
            }
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
                    ViewBag.Title = deserializedObj.Description;


                    if (deserializedObj.Photos != null)
                    {
                        foreach (var item in deserializedObj.Photos)
                        {
                            ViewBag.Description += item.Description + " ";
                        }
                    }
                    if (deserializedObj.Tags != null)
                    {
                        foreach (var item in deserializedObj.Tags)
                        {
                            ViewBag.Keyword += item.key + " ";
                        }
                    }

                }
            }
           


            
            return View();
        }


        //[OutputCache(Duration = 3600, VaryByParam = "id")]
        public ActionResult Story(string id , string storyid)
        {
            if (Session["bolly_default"] == null)
            {
                responseString = Common.GetTempateData();
                Session["bolly_default"] = responseString;
            }
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

                    ViewBag.Title = deserializedObj.Description;
                   
                    
                    if (deserializedObj.Photos != null)
                    {
                        foreach (var item in deserializedObj.Photos)
                        {
                            ViewBag.Description += item.Description +" ";
                        }
                    }
                    if (deserializedObj.Tags != null)
                    {
                        foreach (var item in deserializedObj.Tags)
                        {
                            ViewBag.Keyword += item.key + " ";
                        }
                    }
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
                    ViewBag.Stories = deserializedObj.Stories;

                    ViewBag.Title = deserializedObj.Description;


                    if (deserializedObj.Photos != null)
                    {
                        foreach (var item in deserializedObj.Photos)
                        {
                            ViewBag.Description += item.Description + " ";
                        }
                    }
                    if (deserializedObj.Tags != null)
                    {
                        foreach (var item in deserializedObj.Tags)
                        {
                            ViewBag.Keyword += item.key + " ";
                        }
                    }
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
        [HttpPost]
        public ActionResult Contact(Common objModelMail, HttpPostedFileBase fileUploader)
        {
            if (ModelState.IsValid)
            {
                string from = ConfigurationManager.AppSettings.Get("GEmail"); //any valid GMail ID  
                using (MailMessage mail = new MailMessage(from, ConfigurationManager.AppSettings.Get("MailTo")))
                {
                    var password = ConfigurationManager.AppSettings.Get("GmailPassword");
                    //password = BharatMovies.Models.MyMailModel.Decrypt(password);
                    mail.Subject = "Support - Bharat Movies";
                    mail.Body = "Email : " + objModelMail.Email + " Message : " + objModelMail.Body;
                    mail.IsBodyHtml = false;
                    mail.Subject = objModelMail.Subject;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    NetworkCredential networkCredential = new NetworkCredential(from, password);
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = networkCredential;
                    smtp.Port = 587;
                    try {
                        smtp.Send(mail);
                        ViewBag.Message = "Sent";
                    } catch(Exception e)
                    {
                        ViewBag.Message = e.Message;
                    }
                    //return View("Contact", objModelMail);
                    return View();
                }
                //string pGmailEmail = ConfigurationManager.AppSettings.Get("MailTo");
                //string pGmailPassword = BharatMovies.Models.MyMailModel.Decrypt(ConfigurationManager.AppSettings.Get("GmailPassword"));
                //string pSubject = "Support - Bharat Movies";
                //string pBody = "Email : " + objModelMail + " Message : " + objModelMail.Body; ; //Body
                //MailFormat pFormat = MailFormat.Text; //Text Message

                //MailMessage myMail = new MailMessage();

                //myMail.From = pGmailEmail;
                //myMail.To = pGmailEmail;
                //myMail.Subject = pSubject;
                //myMail.BodyFormat = pFormat;
                //myMail.Body = pBody;

                //SmtpMail.SmtpServer = "smtp.gmail.com:465";
                //SmtpMail.Send(myMail);
                //ViewBag.Message = "Sent";
                //return View("Contact", objModelMail);
            }
            else
            {
                return View();
            }
        }
        public ActionResult Privacy()
        {

            return View();
        }
        public ActionResult CopyWrite()
        {

            return View();
        }
        public ActionResult Test()
        {

            return View();
        }
    }

    public class RootObject
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Keyword { get; set; }
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
        public IList<object> Tags { get; set; }
        public IList<object> Photos { get; set; }



        public object Comments { get; set; }

        public string Decision { get; set; }
        public string DecisionImage { get; set; }
        public object ReturnUrl { get; set; }
        public object ContainerID { get; set; }
    }
}