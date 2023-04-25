using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Middleware;
using WebApplication2.Models;
using X.PagedList;

namespace WebApplication2.Controllers
{
    public class SystemConfigController : BaseController
    {
        // GET: SystemConfigController
        [AuthenticationMiddleware(actionId: "List", pageId: "6")]
        [HttpGet]
        public ActionResult Index(
           [FromQuery] string? value ,// dữ liệu cần tìm kiếm        
           [FromQuery] string? name ,// dữ liệu cần tìm kiếm        
           [FromQuery] string? type ,// dữ liệu cần tìm kiếm          
           [FromQuery] int pageIndex = 1)
        {

            var lst = db.SystemConfigs.Where(x => x.Value.Contains(value ?? "") && x.Name.Contains(name ?? "") && x.Type.Contains(type ?? "")).OrderByDescending(y => y.DateCreated).ToList();

            int pageSize = 15;

            return View(lst.ToPagedList(pageIndex, pageSize));
        }

        [AuthenticationMiddleware(actionId: "Detail", pageId: "9")]
        // GET: SystemConfigController/Details/5
        public ActionResult Details(Guid id)
        {
            if (id == Guid.Empty)
            {
                return RedirectToAction(nameof(Index));

            }
            else
            {
                var system = db.SystemConfigs.Where(x => x.Id == id).FirstOrDefault();



                return View(system);
            }
        }

        [AuthenticationMiddleware(actionId: "Create", pageId: "7")]
        // GET: SystemConfigController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SystemConfigController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind] SystemConfig systemConfig)
        {
            try
            {
                if (systemConfig == null)
                {
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    SystemConfig system = new SystemConfig()
                    {
                        Id=Guid.NewGuid(),
                        Name = systemConfig.Name,
                        Type = systemConfig.Type,
                        Value = systemConfig.Value,
                        Active = systemConfig.Active,
                        Description = systemConfig.Description,
                        UserCreated = Guid.NewGuid(),
                        DateCreated = DateTime.Now
                    };
                    db.Add(system);
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));

                }
            }
            catch
            {
                return View();
            }
        }
        [AuthenticationMiddleware(actionId: "Edit", pageId: "8")]
        // GET: SystemConfigController/Edit/5
        public ActionResult Edit(Guid id)
        {

            if (id == Guid.Empty)
            {
                return RedirectToAction(nameof(Index));

            }
            else
            {
                var system = db.SystemConfigs.Where(x => x.Id == id).FirstOrDefault();
                return View(system);
            }
        }

        // POST: SystemConfigController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, [Bind] SystemConfig systemConfig )
        {
            try
            {
                if (id == Guid.Empty )
                {

                }else if(systemConfig == null)
                {
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                   var systemConfigOld = db.SystemConfigs.Where(x => x.Id == id).FirstOrDefault();

                    if(systemConfigOld == null)
                    {
                        return RedirectToAction(nameof(Index));

                    }
                    else
                    {
                        systemConfigOld.Active = systemConfig.Active;
                        systemConfigOld.Name = systemConfig.Name;
                        systemConfigOld.Value = systemConfig.Value;
                        systemConfigOld.Type = systemConfig.Type;
                        systemConfigOld.Description = systemConfig.Description;
                        systemConfigOld.DateModified = DateTime.Now;
                        systemConfigOld.UserModified = Guid.NewGuid();

                        db.SaveChanges();
                        return RedirectToAction(nameof(Index));
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [AuthenticationMiddleware(actionId: "Delete", pageId: "10")]
        // GET: SystemConfigController/Delete/5
        public ActionResult Delete(Guid id)
        {
            try
            {
                if (id != Guid.Empty)
                {
                    SystemConfig Deleteitem = db.SystemConfigs.Where(c => c.Id == id).FirstOrDefault();
                    if (Deleteitem == null)
                    {
                        return NotFound();
                    }
                    db.SystemConfigs.Remove(Deleteitem);
                    db.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
