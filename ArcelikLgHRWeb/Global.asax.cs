using DAL;
using DAL.Models;
using HRBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ArcelikLgHRWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            DependencyResolver.SetResolver(new ArcelikLGNinjectResolver());
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_Error()
        {
            Exception exception = Server.GetLastError();
            Response.Clear();
            UnitOfWork _uow = new UnitOfWork();
            _uow.LogRepository.Insert(new Log()
            {
                LogType = (byte)LogTypes.Exception,
                Description = exception.ToString(),
                Message = exception.Message,
                Sequence = Guid.NewGuid(),
                UserInformation = UIHelper.UserInfo != null ? UIHelper.UserInfo : null,
                UserID = UIHelper.UserInfo != null ? (long?)UIHelper.UserInfo.UserID : null
            });
            _uow.SaveChanges();
            Server.ClearError();
            if (UIHelper.UserInfo != null)
            {
                var step = _uow.UserInformationRepository.GetNextStep(UIHelper.UserInfo.UserID);
                Response.Redirect(string.Format("~/{0}/{1}", step.ControllerName, step.ActionName), false);
            }
            
            HttpException httpException = exception as HttpException;

            if (httpException != null)
            {
                string action;

                switch (httpException.GetHttpCode())
                {
                    case 404:
                        // page not found
                        action = "HttpError404";
                        break;
                    case 500:
                        // server error
                        action = "HttpError500";
                        break;
                    default:
                        action = "HttpGeneral";
                        break;
                }

                // clear error on server
                Server.ClearError();

                Response.Redirect(String.Format("~/Error/{0}/?message={1}", action, exception.Message));
            }
        }
    }
}
