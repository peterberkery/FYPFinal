using FYPFinal.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYPFinal.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        // GET: User
        // functional code changes as per tutorial: https://www.c-sharpcorner.com/UploadFile/asmabegam/Asp-Net-mvc-5-security-and-creating-user-role/
        //check the user's role.
        
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                // depending on role, viewbag.dsiplaymenu is either yes/no
                var user = User.Identity;
                ViewBag.Name = user.Name;

                ViewBag.displayMenu = "No";

                if (isAdminUser())
                {
                    ViewBag.displayMenu = "Yes";
                }
                return View();
            }
            // display message "not logged in" if user is not logged in
            else
            {
                ViewBag.Name = "Not Logged IN";
            }
            return View();
        }

        //to check if user is logged in, this method returns the boolean value to our main mehtod
        // tutorial: https://www.c-sharpcorner.com/UploadFile/asmabegam/Asp-Net-mvc-5-security-and-creating-user-role/
        public Boolean isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}