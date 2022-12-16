using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Univ_WebSite_Api_Net_Use.Models;

namespace Univ_WebSite_Api_Net_Use.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            string uri = "https://localhost:44309/api/Person/";
            //string actionName = "Get";


            HttpClient httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri(uri);

            HttpResponseMessage r =  httpClient.GetAsync("Get").Result;


            string x =  r.Content.ReadAsStringAsync().Result;


           List<Person> personList =  JsonConvert.DeserializeObject<List<Person>>(x);

            return View(personList);
        }


        public ActionResult PersonDetail(int personID)
        {

            Person person = GetPerson( personID);




            return View(person);
        }

        private Person GetPerson(int personID)
        {
            Person person = new Person();


            string uri = "https://localhost:44309/api/Person/";

            HttpClient httpclient = new HttpClient();

            httpclient.BaseAddress = new Uri(uri);

            string tail = "GetByID?personID=" + personID.ToString();

            HttpResponseMessage r = httpclient.GetAsync(tail).Result;

            string x = r.Content.ReadAsStringAsync().Result;

            person = JsonConvert.DeserializeObject<Person>(x);

            return person;
        }


        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Person person)
        {
            string uri = "https://localhost:44309/api/Person/";

            HttpClient httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri(uri);

            //var content = new FormUrlEncodedContent(person);

            HttpResponseMessage r = httpClient.PostAsJsonAsync<Person>("Post", person).Result;

            string x = r.Content.ReadAsStringAsync().Result;

            return View();
        }


        public ActionResult Update()
        {
            Person person = GetPerson(10);

            return View(person);
        }


        [HttpPost]
        public ActionResult Update(Person person)
        {
            string uri = "https://localhost:44309/api/Person/";

            HttpClient httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri(uri);

            HttpResponseMessage r =   httpClient.PutAsJsonAsync<Person>("Put", person).Result;

            string x =  r.Content.ReadAsStringAsync().Result;





            return RedirectToAction("Index");
        }

        
    }
}