using Hammock;
using Hammock.Authentication.OAuth;
using Hammock.Web;
using LinkedIn_RD.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkedIn_RD.Controllers
{
    public class LinkedInController : Controller
    {
        //
        // GET: /LinkedIn/
       public ActionResult index()
        {
            return AuthenticateToLinkedIn();
        }
 
        static string token_secret = "";
        public ActionResult AuthenticateToLinkedIn()
        {
            var credentials = new OAuthCredentials
            {
                CallbackUrl = "http://localhost:51899/LinkedIn/callback",
                ConsumerKey = ConfigurationManager.AppSettings["ConsumerKey"],
                ConsumerSecret = ConfigurationManager.AppSettings["ConsumerSecret"],
                Verifier = "123456",
                Type = OAuthType.RequestToken
            };
 
            var client = new RestClient { Authority = "https://api.linkedin.com/uas/oauth", Credentials = credentials };
            var request = new RestRequest { Path = "requestToken" };
            RestResponse response = client.Request(request);
 
            token = response.Content.Split('&').Where(s =>s.StartsWith("oauth_token=")).Single().Split('=')[1];
            token_secret = response.Content.Split('&').Where(s=>s.StartsWith("oauth_token_secret=")).Single().Split('=')[1];
            Response.Redirect("https://api.linkedin.com/uas/oauth/authorize?oauth_token=" + token);
            return null;
        }
 
        string token = "";
        string verifier = "";
        public ActionResult Callback()
        {
            token = Request["oauth_token"];
            verifier = Request["oauth_verifier"];
            var credentials = new OAuthCredentials
            {
                ConsumerKey = ConfigurationManager.AppSettings["ConsumerKey"],
                ConsumerSecret = ConfigurationManager.AppSettings["ConsumerSecret"],
                Token = token,
                TokenSecret = token_secret,
                Verifier = verifier,
                Type = OAuthType.AccessToken,
                ParameterHandling = OAuthParameterHandling.HttpAuthorizationHeader,
                SignatureMethod = OAuthSignatureMethod.HmacSha1,
                Version = "1.0"
            };
 
            var client = new RestClient { Authority = "https://api.linkedin.com/uas/oauth", Credentials = credentials, Method = WebMethod.Post };
            var request = new RestRequest { Path = "accessToken" };
            RestResponse response = client.Request(request);
            string content = response.Content;
 
 
            string accessToken = response.Content.Split('&').Where(s =>s.StartsWith("oauth_token=")).Single().Split('=')[1];
            //string accessToken=response.Content.Split('&amp')
            string accessTokenSecret = response.Content.Split('&').Where(s => s.StartsWith("oauth_token_secret=")).Single().Split('=')[1];
             
            var company = new LinkedInService(accessToken, accessTokenSecret).GetCompany(96);            
             
            // Some commented call to API
            //company = new LinkedInService(accessToken, accessTokenSecret).GetCompanyByUniversalName("linkedin");
           //  var companies = new LinkedInService(accessToken, accessTokenSecret).GetCompaniesByEmailDomain("apple.com");            
           // var companies1 = new LinkedInService(accessToken, accessTokenSecret).GetCompaniesByEmailDomain("linkedin.com");           
           // var companies2= new LinkedInService(accessToken, accessTokenSecret).GetCompaniesByIdAnduniversalName("162479", "linkedin");
            //var peoples = new LinkedInService(accessToken, accessTokenSecret).GetPersonById("f7cp5sKscd");
            var people = new LinkedInService(accessToken, accessTokenSecret).GetCurrentUser();
 
            string url = Url.Encode("http://bd.linkedin.com/pub/rakibul-islam/37/522/653");
            //var peoples = new LinkedInService(accessToken, accessTokenSecret).GetPeoPleByPublicProfileUrl(url);
            //var peopleSearchresult = new LinkedInService(accessToken, accessTokenSecret).SearchPeopleByKeyWord("Princes");
             
            //var peopleSearchresult = new LinkedInService(accessToken, accessTokenSecret).GetPeopleByFirstName("Venkat");
            //String companyName = company.Name;
            string Person = people.FirstName;
            //return Content(Person);  
            return View(people);
        }
	}
}