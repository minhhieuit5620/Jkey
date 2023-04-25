using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Security.Claims;
using WebApplication2.Middleware;
using WebApplication2.Models;
using WebApplication2.Models.CustomModel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace WebApplication2.Controllers
{
    public class UserController : BaseController
    {
        public IActionResult Login(string requestPath)
        {
            ViewBag.RequestPath = requestPath;

            if (HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value != null)
            {               
                return Redirect("/HOMEINDEX/" + HttpContext.User.Identity.Name);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value == null)
            {
                var user = IsAuthenticated(model.Username, model.Password);
                if (user== null)
                {
                    return View();  
                }
               

                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.Username),
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())                   

                };

                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(
                        scheme: "AuthenticationDemo",
                        principal: principal,
                        properties: new AuthenticationProperties
                        {
                            //IsPersistent = true, // for 'remember me' feature
                            ExpiresUtc = DateTime.UtcNow.AddDays(1)
                        });

             
             //  var pagePermisstion = checkPermission(user.Id);
            }
            //var userid = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //if (userid != null)
            //{

            //    checkAuth(Guid.Parse(userid));
            //}
            //query actionid: add, BackPageId = ID cua trang Listing
            //return RedirectToAction("Index", "Home");
            return Redirect("/HOMEINDEX/" + model.Username);
        }

        //public List<Page> checkPermission(Guid userId)
        //{
        //    var roleUsers = db.UserRoles.Where(x => x.UserId == userId).ToList();

        //    IDictionary<Guid, List<PageRight>> pageRight = new Dictionary<Guid, List<PageRight>>();

        //    for (int i = 0; i < roleUsers.Count; i++)
        //    {
        //        var pageId = db.PageRights.Where(x=>x.RoleId==roleUsers[i].RoleId).ToList();
        //        if (pageId != null && pageId.Count>0)
        //        {
        //            pageRight.Add(roleUsers[i].RoleId, pageId);
        //        }
        //    }

        //    List<Page> page = new List<Page>();
        //    foreach (var entry in pageRight)

        //    {
        //        var check = "";
        //        for (int i = 0; i < entry.Value.Count; i++)
        //        {
        //            check = entry.Value[i].PageId.ToString();
        //            var valuePage = db.Pages.Where(x => x.Id == check).FirstOrDefault();
        //            if (!page.Contains(valuePage)) { 
        //                page.Add(valuePage); 
        //            }
        //            //page.Add(valuePage);
        //        }
        //    }

        //    return page;


        //}

        public async Task<IActionResult> Logout(string requestPath)
        {
            await HttpContext.SignOutAsync(
                    scheme: "AuthenticationDemo");

            return RedirectToAction("Login");
        }

        public IActionResult Access()
        {
            return View();
        }

        private User IsAuthenticated(string username, string password)
        {

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return null;
            }
            else
            {
                var user = db.Users.Where(x => x.UserName == username && x.Password == password).FirstOrDefault();
                if (user != null)
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }
          
           // return (username == "admin" && password == "1");
        }
    }
}