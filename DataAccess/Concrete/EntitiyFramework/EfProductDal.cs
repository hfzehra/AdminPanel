using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntitiyFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, AdminPanelContext>, IProductDal
    {
        public List<ProductListDTO> GetProductsWithCategory()
        {
            using (var context = new AdminPanelContext())
            {
                return context.Products
                    .Include(p => p.Category) // İlgili kategoriyi dahil ediyoruz
                    .Select(p => new ProductListDTO
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price,
                        CategoryName = p.Category.Name
                    })
                    .ToList();
            }
        }
    }
}
