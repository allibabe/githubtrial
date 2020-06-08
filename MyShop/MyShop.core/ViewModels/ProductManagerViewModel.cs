using MyShop.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.core.ViewModels
{
    public class ProductManagerViewModel
    {
        public Products product { get; set; }
        public IEnumerable<ProductCategory> category { get; set; }

    }
}
