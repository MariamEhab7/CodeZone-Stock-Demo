using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StockProject.Data;
using StockProject.Models;

namespace StockProject.Controllers
{
    public class ItemController : Controller
    {
        #region Dependancy injection
        private StockDB _db;

        public ItemController(StockDB db)
        {
            _db = db;
        }
        #endregion

        public IActionResult Index()
        {
            //Eager loading
            return View(_db.Items.Include(a=>a.Store).ToList());
        }

        #region Add
        public IActionResult Add()
        {
            ViewBag.store = new SelectList(_db.Stores.ToList(), "StoreId", "StoreName");
            return View();
        }

        [HttpPost]
        public IActionResult Add(Item itm) //model binder
        {
            _db.Items.Add(itm);
            _db.SaveChanges();                        
            ViewBag.store = new SelectList(_db.Stores.ToList(), "StoreId", "StoreName");

            return RedirectToAction("Index");
        }
        #endregion

        #region Edit
        [HttpGet]
        public IActionResult edit(int? id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult edit(Item itm, int id)
        {
            Item NewItem = _db.Items.FirstOrDefault(i => i.Id == id);
            NewItem.ItemName = itm.ItemName;
            NewItem.Quantity = itm.Quantity;
            NewItem.Price = itm.Price;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Item itm = _db.Items.FirstOrDefault(i => i.Id == id);
            _db.Items.Remove(itm);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

    }
}
