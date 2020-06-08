using MyShop.core.Contracts;
using MyShop.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.UI.Controllers
{
    public class HomeController : Controller
    {

        IRepository<Products> contex;
        IRepository<ProductCategory> productCategories;
        public HomeController(IRepository<Products> contex, IRepository<ProductCategory> productCategories)
        {
            this.contex = contex;
            this.productCategories = productCategories;

        }

        public ActionResult Index()
        {

            List<Products> products = contex.Collection().ToList();

            return View(products);
        
        }

        public ActionResult Details(string id)
        {

            Products products = contex.find(id);
            if (products == null)
            {

                return HttpNotFound();
            }
            else {
                return View(products);

            }

        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}