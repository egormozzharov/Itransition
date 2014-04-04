using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.DataBaseClasses;
using MvcApplication2.Models;

namespace MvcApplication2.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            DataManager dataManager = new DataManager();
            IEnumerable<UserInfo> allUserInfo = dataManager.GetUsers();
            
            return View(allUserInfo);
        }

      //  [Authorize]
        [HttpGet]
        public ActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public ActionResult Register(String login, String email, String password)
        {
            DataBaseUser dataBaseUser = new DataBaseUser();
            ActionResult actionResult;
            // check valid
            if (ModelState.IsValid)
            {
                if (dataBaseUser.IsExistsLogin(login) == false)// check if this login already taken
                {

                    if (dataBaseUser.IsExistsEmail(email) == false)// check if this email alredy taken
                    {
                        User newUser = new User();
                        newUser.Login = login;
                        newUser.Email = email;
                        newUser.Password = password;
                        dataBaseUser.AddUser(newUser);
                        dataBaseUser.SaveChanges();
                        actionResult = View("SuccesedRegistartion");
                    }
                    else
                    {
                        ModelState.AddModelError("Email", "Email is already taken!");
                        actionResult = View("Register");
                    }
                }
                else
                {
                    ModelState.AddModelError("Login", "Login is already taken!");
                    actionResult = View("Register");
                }
            }
            else
            {
                actionResult = View("Register");
            }
            return actionResult;
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            DataManager dataManager = new DataManager();
            UserInfo user = dataManager.GetUserById(id);
            ViewData.Model = user;

            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "Female", Value = "Female", Selected = false});

            items.Add(new SelectListItem { Text = "Male", Value = "Male", Selected = false});

            if (user.Gender == "Male")
            {
                SelectListItem item = items.Find(match => match.Value == "Male");
                item.Selected = true;
            }
            else
            {
                SelectListItem item = items.Find(match => match.Value == "Female");
                item.Selected = true;
            }

            ViewBag.MovieType = items;

            return View();
        }

        [HttpPost]
        public ActionResult Edit(UserInfo user)
        {
            DataManager dataManager = new DataManager();

            dataManager.UpdateUser(user);

            return RedirectToAction("Index");
        }


    }
}
