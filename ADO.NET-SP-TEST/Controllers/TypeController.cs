using SDSolutionsExam.Data;
using SDSolutionsExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDSolutionsExam.Controllers
{
    public class TypeController : Controller
    {
        public ActionResult Index()
        {
            List <TypeEntity> types = new List <TypeEntity> (); 

            TypeRepository typeRepository = new TypeRepository ();

            types = typeRepository.getAllTypes();

            return View(types);
        }
        public ActionResult AddType()
        {
            return View();
        }

        public ActionResult AddNewType(TypeEntity typeDetails)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    TypeRepository db = new TypeRepository();

                    if (db.AddType(typeDetails))
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

        public ActionResult EditType(int Id)
        {
            TypeEntity types = new TypeEntity();

            TypeRepository typeRepository = new TypeRepository();

            types = typeRepository.getTypeById(Id);

            return View(types);

        }

        public ActionResult EditTypeDetails(int Id, TypeEntity typeDetails)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    TypeRepository db = new TypeRepository();

                    if (db.EditTypeDetails(Id, typeDetails))
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

        public ActionResult DeleteType(int Id)
        {
            TypeEntity types = new TypeEntity();

            TypeRepository typeRepository = new TypeRepository();

            types = typeRepository.getTypeById(Id);

            return View(types);
        }

        public ActionResult DeleteTypeDetails(int Id, TypeEntity typeDetails)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    TypeRepository db = new TypeRepository();

                    if (db.DeleteTypeDetails(Id, typeDetails))
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
