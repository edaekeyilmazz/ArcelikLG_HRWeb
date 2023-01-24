using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArcelikLgHRWeb
{
    public static class UIHelper
    {
        public static string UserInformationSession { get { return "UserInfo"; } }
        public static UserInformation UserInfo
        {
            get { return HttpContext.Current.Session["UserInfo"] != null ? (UserInformation)HttpContext.Current.Session["UserInfo"] : null; }
            set
            {
                HttpContext.Current.Session["UserInfo"] = value;
            }
        }
    }
}