using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StockProject.Data;
using StockProject.Models;

namespace StockProject.Controllers
{
    public class StoreController : Controller
    {
        private StockDB _db;

        public StoreController(StockDB db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Stores.ToList());
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Store st) //model binder
        {
            _db.Stores.Add(st);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult edit(int? id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult edit(Store str, int id)
        {
            Store oldStore = _db.Stores.FirstOrDefault(i => i.StoreId == id);
            oldStore.StoreName = str.StoreName;
            oldStore.Address = str.Address;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Store store = _db.Stores.FirstOrDefault(i => i.StoreId == id);
            _db.Stores.Remove(store);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
