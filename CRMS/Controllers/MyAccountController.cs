using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CRMS.Models;
using CRMS.ServiceReference1;

namespace CRMS.Controllers
{
    public class MyAccountController : Controller
    {
        //
        // GET: /MyAccount/
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login l, string ReturnUrl = "")
        {
            string strUsername = l.Username;
            string strPassword = l.Password;

            ADAuthenticatorSoapClient userStatus = new ADAuthenticatorSoapClient();
            string strStatus = userStatus.getUserStatus(strUsername, strPassword);


            if (strStatus.Substring(0, 2) == "00")
            {
                FormsAuthentication.SetAuthCookie(strUsername, l.RememberMe);
                if (Url.IsLocalUrl(ReturnUrl))
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ViewBag.Error = "Invalid Username and password";
            }
            return View();
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "MyAccount");
        }
        
    }
}