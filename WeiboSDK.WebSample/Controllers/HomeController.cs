using System.Web.Mvc;
using SocialKit.LightRest.OAuth;
using WeiboSDK.Factories;

namespace WeiboSDK.WebSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string weiboType)
        {
            var consumer = ConsumerFactory.GetConsumer(weiboType);
            consumer.Callback = "http://localhost:4055/Home/Callback";

            var requestToken = consumer.GetRequestToken();
            Session["requestToken"] = requestToken;
            var authorizeUri = requestToken.GetNormalizedAuthorizeUri();

            return Redirect(authorizeUri);
        }

        public ActionResult Callback(string oauth_verifier)
        {
            var requestToken = (RequestToken) Session["requestToken"];
            var accessToken = requestToken.ToAccessToken(oauth_verifier);

            return View(accessToken);
        }
    }
}