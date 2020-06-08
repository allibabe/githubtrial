using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.core.Models
{
  public class ProductCategory :BaseEntity
    {
        //public string Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Category { get; set; }

        //public ProductCategory()
        //{
        //    this.Id = Guid.NewGuid().ToString();
        //}

    }

}
