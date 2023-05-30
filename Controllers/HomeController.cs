using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practice1.Model;

namespace Practice1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View(new ListFriend().InitFriend());
        }

        public ActionResult SortAgeDesc()
        {

            return View(new ListFriend().InitFriend().OrderByDescending(m => m.age).ToList());

        }

        public ActionResult SortAgeAsc()
        {
            return View(new ListFriend().InitFriend().OrderBy(m => m.age).ToList());
        }

        public ActionResult SortMale()
        {
            return View(new ListFriend().InitFriend().Where(m => m.sex == "nam").ToList());
        }

        public ActionResult SortFemale()
        {
            return View(new ListFriend().InitFriend().Where(m => m.sex == "nữ").ToList());
        }
    }
}