using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCouch;
using MyCouch.Cloudant;
using System.Threading.Tasks;


namespace BharatMovies.Controllers
{
    public class SearchController : Controller
    {
        public async Task<ActionResult> Index(string q)
        {
            var uri = new MyCouchUriBuilder("https://anupamjaiswal.cloudant.com/")
             .SetBasicCredentials("anupamjaiswal", "social24x7")
             .SetDbName("campaignlink")
             .Build();
            //.SetBasicCredentials("cedsteressivarshwaskyage", "vbmqH8q0PwdKSqaN74yMlqsU")
            // var uri = new MyCouchUriBuilder("https://anupamjaiswal.cloudant.com/")
            //.SetDbName("animaldb")
            //.SetBasicCredentials("nortintastilineafterremp", "XUxnpETtOGgdJ4lnNDQcoG1Q")
            //.Build();

            using (var client = new MyCouchCloudantClient(uri))
            {


                var s = new SearchIndexIdentity("views", "SearchCampaign");


                var si = new MyCouch.Cloudant.Requests.SearchIndexRequest(s);
                si.Expression = q;
                si.Limit = 25;

                si.Counts.Add("default");
                //si.IncludeDocs = true;





                dynamic x = await client.Searches.SearchAsync(si);

                List<string> idList = new List<string>();

                foreach (var data in x.Rows)
                {
                    foreach (var data1 in data.Fields)
                    {
                        idList.Add(data1.Value);
                    }
                }
                var uniqueid = idList.Distinct().ToList();

                ViewBag.Title = q;
                ViewBag.uniqueid = uniqueid;

            }
            return View();
        }
    }
}