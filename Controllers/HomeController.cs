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
            var listFriend = Friends.friends;
            return View(listFriend);
        }

        public ActionResult SortAgeDesc()
        {
            var listFriend = Friends.friends;
            return View(listFriend.OrderByDescending(m => m.age).ToList());

        }

        public ActionResult SortAgeAsc()
        {
            var listFriend = Friends.friends;
            return View(listFriend.OrderBy(m => m.age).ToList());
        }

        public ActionResult SortMale()
        {
            var listFriend = Friends.friends;
            return View(listFriend.Where(m => m.sex == "Nam").ToList());
        }

        public ActionResult SortFemale()
        {
            var listFriend = Friends.friends;
            return View(listFriend.Where(m => m.sex == "Nữ").ToList());
        }

        public ActionResult SaveFriend(string name, int age, string major, string sex) 
        {
            Friends.friends.Add(new ListFriend()
            {
                name = name,
                age = age,
                major = major,
                sex = sex
            });
            return RedirectToAction("Index");
        }

        public ActionResult AddFriend()
        {
            
            return View();
        }

        public ActionResult AddFriends()
        {
            return View(new ListFriend());
        }

        [HttpPost]
        public ActionResult AddFriends(ListFriend model)
        {
            if(ModelState.IsValid == true)
            {
                Friends.friends.Add(model);
                return RedirectToAction("Index");

            } else
            {
                ModelState.AddModelError("", "Bạn chưa nhập đủ dữ liệu");
                return View(model);
            }
        }
    }
}