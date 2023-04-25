using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class DeviceManagement : Controller
    {
        // GET: DeviceManagement
        public ActionResult Index()
        {
            return View();
        }

        // GET: DeviceManagement/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DeviceManagement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeviceManagement/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: DeviceManagement/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DeviceManagement/Edit/5
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

        // GET: DeviceManagement/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DeviceManagement/Delete/5
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
