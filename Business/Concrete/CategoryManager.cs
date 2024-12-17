using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntitiyFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult();
        }

        public IResult Delete(Category category)
        {
            var deleteCategory = _categoryDal.Get(c => c.Id == category.Id);
            _categoryDal.Delete(deleteCategory);
            return new SuccessResult();
        }

        public IDataResult<List<Category>> GetAll()
        {
            var result = _categoryDal.GetAll();
            return new SuccessDataResult<List<Category>>(result, "Tüm ürünler listelendi.");

        }

        public IDataResult<Category> GetByIdCategory(int id)
        {
            var result = _categoryDal.Get(p => p.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<Category>("Belirtilen ID'ye sahip ürün bulunamadı.");
            }
            return new SuccessDataResult<Category>(result, "Ürün başarıyla getirildi.");

        }

        public IResult Update(Category category)
        {
            var existingProduct = _categoryDal.Get(p => p.Id == category.Id);
            if (existingProduct == null)
            {
                return new ErrorResult("Güncellenecek ürün bulunamadı.");
            }
            _categoryDal.Update(category);
            return new SuccessResult("Ürün başarıyla güncellendi.");

        }
    }
}
