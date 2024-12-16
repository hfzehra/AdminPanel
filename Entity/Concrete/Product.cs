using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Product  : Entity<int>
    {
        public string Name { get; set; }
        public string Decription { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }

    }
}
