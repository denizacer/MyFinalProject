using Business.Abstract;

using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;//tabloyu ilgilendirdiği için direk service olarak koyduk
        
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;//producte categoryi böyle enjekte ettik
            
        }
        [ValidationAspect(typeof(ProductValidator))]//ProductValidator validatortype
        public IResult Add(Product product)
        {
            //eğer mevcut kategori sayısı 15 i geçtyse sisteme yeni ürün eklenemez
           IResult result= BusinessRules.Run(CheckIfProductNameExists(product.ProductName), 
                CheckIfProductCountCategoryCategory(product.CategoryId),
                CheckIfCategoryLimitExceded());
            
            if (result!=null)//kurala uymayan bi şart oluştuysa error geldi
            {
                return result;
            }
                                 
            _productDal.Add(product);

            return new SuccessResult((Messages.ProductAdded));
              
            
        }

        public IDataResult<List<Product>> GetAll()
        {
            //İş kodları
            
            if (DateTime.Now.Hour == 1)
            {
               return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);//bakım zamanı
           
            //ampülden generatefielt
            }


            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);

            //ampülden generatefielt
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
            //gelen kategoriyi filitrele benimkine göre
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p=>p.ProductId==productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            //şu fiyat aralığında olanları getir
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 1)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Uptade(Product product)
        {
            throw new NotImplementedException();

        }

        private IResult CheckIfProductCountCategoryCategory(int categoryId)//Product product olur 
        {
            //bir kategıride en fazla 10 ürün olabilir.
            //select coubr(*) from products where categoryId=1 bunu çalıştırıyor
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);//genarate field yaptım
            }

            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(string productName)//Product product olur 
        {
            //aynı isimde ürün eklenemez
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);//genarate field yaptım
            }

            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);//genarate field yaptım
            }
            return new SuccessResult();
        }



    }
}
