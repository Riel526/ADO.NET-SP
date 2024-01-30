using SDSolutionsExam.Data;
using SDSolutionsExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDSolutionsExam.Controllers
{
    public class ItemController : Controller
    {
        public ActionResult Index()
        {
            List<ItemEntity> items = new List<ItemEntity>();

            ItemRepository itemRepository = new ItemRepository();

            items = itemRepository.getAllItems();

            return View(items);
        }

        public ActionResult AddItem()
        {
            ItemRepository itemRepository = new ItemRepository();
            List<int> recycableTypeIds = itemRepository.GetRecycableTypeIds();

            ViewBag.RecycableTypeIds = new SelectList(recycableTypeIds);

            return View();

        }

        public ActionResult AddNewItem(ItemEntity itemDetails)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    ItemRepository db = new ItemRepository();



                    if (db.AddItem(itemDetails))
                    {
                        return RedirectToAction("Index");
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }


        public ActionResult EditItem(int Id)
        {
            ItemEntity items = new ItemEntity();

            ItemRepository itemRepository = new ItemRepository();

            items = itemRepository.getItemById(Id);

            List<int> recycableTypeIds = itemRepository.GetRecycableTypeIds();

            ViewBag.RecycableTypeIds = new SelectList(recycableTypeIds);


            return View(items);

        }

        public ActionResult EditItemDetails(int Id, ItemEntity itemDetails)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    ItemRepository db = new ItemRepository();

                    if (db.EditItemDetails(Id, itemDetails))
                    {
                        return RedirectToAction("Index");
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteItem(int Id)
        {
            ItemEntity items = new ItemEntity();

            ItemRepository itemRepository = new ItemRepository();

            items = itemRepository.getItemById(Id);

            return View(items);
        }

        public ActionResult DeleteItemDetails(int Id, ItemEntity itemDetails)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    ItemRepository db = new ItemRepository();

                    if (db.DeleteItemDetails(Id, itemDetails))
                    {
                        return RedirectToAction("Index");
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
