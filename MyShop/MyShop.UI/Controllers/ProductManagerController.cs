using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShop.core.Contracts;
using MyShop.core.Models;
using MyShop.core.ViewModels;
using MyShop.DataAccess.InMemory;

namespace MyShop.UI.Controllers
{
    public class ProductManagerController : Controller
    {


        IRepository<Products>  contex;
        IRepository<ProductCategory> productCategories;
        public ProductManagerController(IRepository<Products> contex, IRepository<ProductCategory> productCategories)
        {
            this.contex = contex;
            this.productCategories = productCategories;

        }



        // GET: ProductManager
        public ActionResult Index()
        {
            List<Products> products = contex.Collection().ToList();
            return View(products);
        }


        // GET: ProductManager/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        //// GET: ProductManager/DetailsList
        //public ActionResult DetailsList()

        //{
        //   List<Products> Item =  contex.CollectionDesc().ToList();

        //    return View(Item);
        //}





        // GET: ProductManager/Create
        public ActionResult Create()
        {
            ProductManagerViewModel viewModel = new ProductManagerViewModel();
            viewModel.product = new Products();
            viewModel.category = productCategories.Collection();

            return View(viewModel);
        }

        // POST: ProductManager/Create
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase filer, ProductManagerViewModel collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {

                    return View(collection);
                }
                else {
                    if (filer != null)
                    {
                        collection.product.Image = collection.product.Id + Path.GetExtension(filer.FileName);

                        filer.SaveAs(Server.MapPath("/Content/ProductImages/") + collection.product.Image);
                    }
                    else {
                        collection.product.Image = "meeow";
                    }
                    contex.Insert(collection.product);
                    return RedirectToAction("Index");

                }

               
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductManager/Edit/5
        public ActionResult Edit(string id)

        {
            Products item = contex.find(id);
            if (item == null) {

                return HttpNotFound();
            }
            else {

                ProductManagerViewModel viewModel = new ProductManagerViewModel();
                viewModel.product = item;
                viewModel.category = productCategories.Collection();

                return View(viewModel);
            }
            
        }

        // POST: ProductManager/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, ProductManagerViewModel collection ,HttpPostedFileBase filer)
        {
            try
            {
                // TODO: Add update logic here

                Products item = contex.find(id);
                if (item == null) {
                    return HttpNotFound();

                }
                else {
                    if (!ModelState.IsValid) {
                        return View(collection);
                    }

                    if (filer != null)
                    {
                        collection.product.Image = collection.product.Id + Path.GetExtension(filer.FileName);

                        filer.SaveAs(Server.MapPath("/Content/ProductImages/") + collection.product.Image);
                    }



                    ProductManagerViewModel viewMOdel = new ProductManagerViewModel();
                    viewMOdel.product = collection.product;
                    viewMOdel.category = productCategories.Collection();


                    contex.Update(collection.product);
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
            Products item = contex.find(id);
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
        public ActionResult Delete(string id, Products collection)
        {
            try
            {
                // TODO: Add delete logic here

                Products item = contex.find(id);
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
