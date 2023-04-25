using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using WebApplication2.Models.DTO;

namespace WebApplication2.Controllers
{
    public class RoleManagement : BaseController
    {
        // GET: RoleManagement
        public ActionResult Index()
        {

            var list = db.UserRoles.Include(ur => ur.User).Include(ur => ur.Role).ToList();           
            return View(list);
        }

        // GET: RoleManagement/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RoleManagement/Create
        public ActionResult Create()
        {
            var pageList = db.Pages.Where(x => x.BackPageId == null&& (x.PermissionRequire==false||x.PermissionRequire==null));
            ViewBag.PageList = pageList;
            return View();
        }

        // POST: RoleManagement/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind] Role role,string[] ListPage, string[] Listname)
        {
            try
            {
                if (role == null)
                {
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    Guid id = Guid.NewGuid();
                    Role newRole = new Role()
                    {
                        Id = id,
                        RoleName = role.RoleName,
                        RoleDesciption = role.RoleDesciption,                       
                        Active = role.Active,                        
                        UserCreated = Guid.NewGuid(),
                        DateCreated = DateTime.Now
                    };
                    db.Add(newRole);
                    db.SaveChanges();
                    for (int i = 0; i < Listname.Length;)
                    {
                        Page page=db.Pages.Where(x => x.Name == Listname[i]).FirstOrDefault();
                        var list = db.Pages.Where(c => c.BackPageId == page.Id);

                        for (int j = 0; j < ListPage.Length; j++)
                        {

                        }
                    }


                    return RedirectToAction(nameof(Index));

                }


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RoleManagement/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RoleManagement/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RoleManagement/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RoleManagement/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
