using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StockProject.Data;
using StockProject.Models;
using System.Linq;
using System.Text;

namespace StockProject.Controllers
{
    public class StoreController : Controller
    {
        #region Dependancy Injection
        private StockDB _db;

        public StoreController(StockDB db)
        {
            _db = db;
        }
        #endregion
        public IActionResult Index()
        {
            return View(_db.Stores.ToList());
        }

        #region Add
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
        #endregion

        #region Edit
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
        #endregion

        #region Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Store store = _db.Stores.FirstOrDefault(i => i.StoreId == id);
            _db.Stores.Remove(store);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

        public IActionResult Purchase(int? id)
        {
            var itemsOfStore = _db.Items.Where(i => i.StoreId == id).ToList();
            ViewBag.itemm = new SelectList(itemsOfStore, "Id", "ItemName");

            return View();

            if (id == null)
            {
                return BadRequest();
            }

            if (itemsOfStore == null)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult getItem(int? Id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult getItem(Item str, int id)
        {
            var itemSelected = _db.Items.Include(i => i.Store).FirstOrDefault(t => t.Id == id);
            var oldQ = itemSelected.Quantity;
            var newQ = str.Quantity;

            var result = oldQ + newQ;
            itemSelected.Quantity = result;
            ViewBag.res = result;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
