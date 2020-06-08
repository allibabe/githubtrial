using MyShop.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{
   public class ProductCategoryRepository
    {

        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productsCategory;

        public ProductCategoryRepository()
        {
            productsCategory = cache["productscategory"] as List<ProductCategory>;
            if (productsCategory == null)
            {
                productsCategory = new List<ProductCategory>();
            }

        }

        public void Commit()
        {
            cache["productscategory"] = productsCategory;
        }

        public void Insert(ProductCategory p)
        {
            productsCategory.Add(p);
            Commit();

        }

        public void Update(ProductCategory p)
        {

            ProductCategory productToUpdate = productsCategory.Find(x => x.Id == p.Id);

            if (productToUpdate != null)
            {
                productToUpdate = p;

                productsCategory.RemoveAll(x => x.Id == productToUpdate.Id);
                productsCategory.Add(productToUpdate);
                Commit();

            }
            else
            {
                throw new Exception("Product not Found");
            }

        }


        public ProductCategory find(string Id)
        {

            ProductCategory product = productsCategory.Find(x => x.Id == Id);

            if (product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("Product not Found");
            }

        }

        public IQueryable<ProductCategory> Collection()
        {
            return productsCategory.AsQueryable();
        }

        public void Delete(string Id)
        {
            ProductCategory productToDelete = productsCategory.Find(x => x.Id == Id);

            if (productToDelete != null)
            {
                productsCategory.Remove(productToDelete);
                Commit();
            }
            else
            {
                throw new Exception("Product not Found");
            }


        }




    }
}
