using EasyParty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyParty.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Create()
        {
            string needs = "";
            string eventType = "";
            string place = "";
            string date = "";
            int numberInvites = 0;
            string description = "";
            Party party = new Party(needs, eventType, place, date, numberInvites, description);
            return View();
        }
    }
}