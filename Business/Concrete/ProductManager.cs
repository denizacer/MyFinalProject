﻿using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

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
            if (product.ProductName.Length<2) {

                //magic string
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            
            _productDal.Add(product);
       

            return new SuccessResult((Messages.ProductAdded));
            //b.lambadan ekledim.iki cons. çalıştı
        }

        public IDataResult<List<Product>> GetAll()
        {
            //İş kodları
            //Yetkisi var mı?
            if (DateTime.Now.Hour == 1)
            {
               return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);//bakım zamanı
           
            ////ampülden generatefielt
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
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }








        /*  IResult IProductService.Add(Product product)
          {
              throw new NotImplementedException();
          }*/
    }
}
