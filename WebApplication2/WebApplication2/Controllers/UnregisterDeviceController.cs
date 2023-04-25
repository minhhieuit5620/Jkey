using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class UnregisterDeviceController : Controller
    {
        // GET: UnregisterDeviceController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UnregisterDeviceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UnregisterDeviceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UnregisterDeviceController/Create
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

        // GET: UnregisterDeviceController/Edit/5
        public ActionResult Unregister(int id)
        {
            return View();
        }

        // POST: UnregisterDeviceController/Edit/5
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

        // GET: UnregisterDeviceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UnregisterDeviceController/Delete/5
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
