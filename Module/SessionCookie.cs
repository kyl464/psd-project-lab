using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace PSDProject.Module
{
    public class SessionCookie
    {
        public static HttpCookie createCookie(string id, string userName, string userRole)
        {
            HttpCookie cookie = new HttpCookie("session");
            cookie.Values["userID"] = id;
            cookie.Values["userName"] = userName;
            cookie.Values["userRole"] = userRole;
            return cookie;
        }

        public static void createSession(HttpSessionState sessionState, string id, string userName, string userRole)
        {
            sessionState["userID"] = id;
            sessionState["userName"] = userName;
            sessionState["userRole"] = userRole;
        }

        public static void createSession(HttpSessionState sessionState, HttpCookie cookie)
        {
            createSession(sessionState, cookie["userID"], cookie["userName"], cookie["userRole"]);
        }
    }
}
