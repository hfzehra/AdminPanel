using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult();
        }

        public IResult Delete(Product product)
        {
            var deletedProduct = _productDal.Get(b => b.Id == product.Id);
            _productDal.Delete(deletedProduct);
            return new SuccessResult();
        }

        public IDataResult<List<Product>> GetAll()
        {
            var result = _productDal.GetAll();
            return new SuccessDataResult<List<Product>>(result, "Tüm ürünler listelendi.");

        }

        public IDataResult<Product> GetByIdProduct(int id)
        {
            var result = _productDal.Get(p => p.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<Product>("Belirtilen ID'ye sahip ürün bulunamadı.");
            }
            return new SuccessDataResult<Product>(result, "Ürün başarıyla getirildi.");

        }

        public IResult Update(Product product)
        {
            var existingProduct = _productDal.Get(p => p.Id == product.Id);
            if (existingProduct == null)
            {
                return new ErrorResult("Güncellenecek ürün bulunamadı.");
            }
            _productDal.Update(product);
            return new SuccessResult("Ürün başarıyla güncellendi.");
        }
    }
}
