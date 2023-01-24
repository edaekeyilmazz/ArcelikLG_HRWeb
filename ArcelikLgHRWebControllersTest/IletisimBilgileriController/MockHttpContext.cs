using ArcelikLgHRWeb;
using DAL.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;
using System.Web.SessionState;


namespace ArcelikLgHRWebControllersTest.IletisimBilgileriController
{
   public class MockHttpContext
    {
        public static string UserInformationSession { get { return "UserInfo"; } }
        public static UserInformation UserInfo
        {
            get { return HttpContext.Current.Session["UserInfo"] != null ? (UserInformation)HttpContext.Current.Session["UserInfo"] : null; }
            set
            {
                HttpContext.Current.Session["UserInfo"] = 1;
            }
        }

        public static HttpContextBase FakeHttpContext()
        {
            var context = new Mock<HttpContextBase>();
            var request = new Mock<HttpRequestBase>();
            var response = new Mock<HttpResponseBase>();
            var session = new MockHttpSession();
            var server = new Mock<HttpServerUtilityBase>();
            //var requestContext = new Mock<RequestContext>();

            context.Setup(ctx => ctx.Request).Returns(request.Object);
            context.Setup(ctx => ctx.Response).Returns(response.Object);
            context.Setup(ctx => ctx.Session).Returns(session);
            context.Setup(ctx => ctx.Server).Returns(server.Object);

            return context.Object;
        }
        public static HttpContext HttpContextCurrent()
        {
            var httpRequest = new HttpRequest("", "http://mySomething/", "");
            var stringWriter = new StringWriter();
            var httpResponce = new HttpResponse(stringWriter);
            var httpContext = new HttpContext(httpRequest, httpResponce);

            var sessionContainer = new HttpSessionStateContainer("id", new SessionStateItemCollection(),
                                                                 new HttpStaticObjectsCollection(), 10, true,
                                                                 HttpCookieMode.AutoDetect,
                                                                 SessionStateMode.InProc, false);

            httpContext.Items["AspSession"] = typeof(HttpSessionState).GetConstructor(
                                                     BindingFlags.NonPublic | BindingFlags.Instance,
                                                     null, CallingConventions.Standard,
                                                     new[] { typeof(HttpSessionStateContainer) },
                                                     null)
                                                .Invoke(new object[] { sessionContainer });
            httpContext.Session["UserInfo"] = IletisimControllerTest.UserInfo;

            return httpContext;
        }
    }


   public class MockHttpSession : HttpSessionStateBase
   {
       Dictionary<string, object> m_SessionStorage = new Dictionary<string, object>();

       public override object this[string name]
       {
           get { return m_SessionStorage[name]; }
           set { m_SessionStorage[name] = value; }
       }
   }

}


