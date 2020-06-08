using MyShop.core.Contracts;
using MyShop.core.Models;
using MyShop.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.UI.Controllers
{
    public class ProductCategoryManagerController : Controller
    {

        IRepository<ProductCategory> contex;
        public ProductCategoryManagerController(IRepository<ProductCategory> contex)
        {
            this.contex = contex;
        }


        // GET: ProductManager
        public ActionResult Index()
        {
            List<ProductCategory> products = contex.Collection().ToList();
            return View(products);
        }


        // GET: ProductManager/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


     


        // GET: ProductManager/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: ProductManager/Create
        [HttpPost]
        public ActionResult Create(ProductCategory collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {

                    return View(collection);
                }
                else
                {
                    contex.Insert(collection);
                    return RedirectToAction("Index");

                }


            }
            catch
            {
                return View();
            }
        }

        // GET: ProductManager/Edit/5
        public  ActionResult Edit(string id)

        {
            ProductCategory item =  contex.find(id);
            if (item == null)
            {

                return HttpNotFound();
            }
            else
            {
                return View(item);
            }

        }

        // POST: ProductManager/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, ProductCategory collection)
        {
            try
            {
                // TODO: Add update logic here

                ProductCategory item = contex.find(id);
                if (item == null)
                {
                    return HttpNotFound();

                }
                else
                {
                    //if (!ModelState.IsValid)
                    //{
                    //    return View(collection);
                    //}

                    contex.Update(collection);
                    return RedirectToAction("Index");
                }


            }
            catch
            {
                return View();
            }



        }

        // GET: ProductManager/Delete/5
        public ActionResult Delete(string id)
        {
            ProductCategory item = contex.find(id);
            if (item == null)
            {

                return HttpNotFound();
            }
            else
            {
                return View(item);
            }


        }

        // POST: ProductManager/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, ProductCategory collection)
        {
            try
            {
                // TODO: Add delete logic here

                ProductCategory item = contex.find(id);
                if (item == null)
                {

                    return HttpNotFound();
                }
                else
                {
                    contex.Delete(collection.Id);
                    return RedirectToAction("Index");
                }

            }
            catch
            {
                return View();
            }


        }
    }
}