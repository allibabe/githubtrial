using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyShop.core.Models;

namespace MyShop.DataAccess.InMemory
{
    public class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Products> products;
        
        public ProductRepository()
        {
            products = cache["products"] as List<Products>;
            if (products == null)
            {
                products = new List<Products>();
            }

        }

        public void Commit() {
            cache["products"] = products;
        }

        public void Insert(Products p) {
            products.Add(p);
            Commit();
        
        }

        public void Update(Products p) {

            Products productToUpdate = products.Find(x => x.Id == p.Id);

            if (productToUpdate != null)
            {
                productToUpdate = p;

                products.RemoveAll(x => x.Id == productToUpdate.Id);
                products.Add(productToUpdate);
                Commit();
                
            }
            else {
                throw new Exception("Product not Found");
            }
        
        }


        public Products find(string Id) {

            Products product = products.Find(x => x.Id == Id);

            if (product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("Product not Found");
            }

        }

        public IQueryable<Products> Collection() {
            return products.AsQueryable();
        }

        public void Delete(string Id) {
            Products productToDelete = products.Find(x => x.Id == Id);

            if (productToDelete != null)
            {
                products.Remove(productToDelete);
                Commit();
            }
            else
            {
                throw new Exception("Product not Found");
            }


        }


        public IQueryable<Products> CollectionDesc()
        {
            return products.AsQueryable().OrderBy(x=> x.Price);
        }


    }
}
