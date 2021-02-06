using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    /* public class EfProductDal : IProductDal
     {
         List<Product> _products;//global değişken olduğu için _ kull.
         //veri varmış gibi yaptık
         public EfProductDal()//ctor tab tab
         {
             //constracter//oracle,sqlserve, postgres.,mongodbden geliyomuş gibi yaptık
             _products = new List<Product> {
                 new Product{ProductId=1, CategoryId=1,ProductName="Bardak",UnitPrice=15, UnitsInStock=15},
                 new Product{ProductId=2, CategoryId=1,ProductName="Kamera",UnitPrice=500, UnitsInStock=3},
                 new Product{ProductId=3, CategoryId=2,ProductName="Telefon",UnitPrice=1500, UnitsInStock=2},
                 new Product{ProductId=4, CategoryId=2,ProductName="Klavye",UnitPrice=150, UnitsInStock=65},
                 new Product{ProductId=5, CategoryId=2,ProductName="Fare",UnitPrice=85, UnitsInStock=1}
             };
         }
         public void Add(Product product)
         {
             _products.Add(product);// List<Product> _products; burası db gibi oldu
         }

         public void Delete(Product product)
         {
             //LINQ- language ıntegrated query
             // _products.Remove(product); çalışmaz// 5 tane ref var. hangi ref olduğunu bilmiyo

             //--------------------------------------------
             //Product productToDelete=null;
             /*foreach (var p in _products)
             {
                 if (product.ProductId==p.ProductId)
                 {
                     productToDelete = p;
                 }
             }
             _products.Remove(productToDelete);*/
    //---------------------------------------------

    /*  Product productToDelete;//linq bilmeden//program hata vermesin diye null vwedik
      productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);//LINQ. p=Lambda ve takmaisim
                                                                                         //foreachi bu kodla yaptık// her p için o an dolaştığımın ıdsi ref ettiğime baktı

  }

  public Product Get(Expression<Func<Product, bool>> filter)
  {
      throw new NotImplementedException();
  }

  public List<Product> GetAll()
  {
      return _products;
  }

  public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
  {
      throw new NotImplementedException();
  }

  public void Update(Product product)
  {
      //gönderdiğim ürün ıdsine sahip olan listeki ürünü bul
      Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
      productToUpdate.ProductName = product.ProductName;
      productToUpdate.CategoryId = product.CategoryId;
      productToUpdate.UnitPrice = product.UnitPrice;
      productToUpdate.UnitsInStock = product.UnitsInStock;//entityframe work yapacak bunu ilerde

  }



  List<Product> IProductDal.GetAllByCategory(int categoryId)
  {
      return _products.Where(p => p.CategoryId == categoryId).ToList();
  }
}*/
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            //Oracle,Sql Server, Postgres , MongoDb
            _products = new List<Product> {
                new Product{ProductId=1, CategoryId=1, ProductName="Bardak", UnitPrice=15, UnitsInStock=15},
                new Product{ProductId=2, CategoryId=1, ProductName="Kamera", UnitPrice=500, UnitsInStock=3},
                new Product{ProductId=3, CategoryId=2, ProductName="Telefon", UnitPrice=1500, UnitsInStock=2},
                new Product{ProductId=4, CategoryId=2, ProductName="Klavye", UnitPrice=150, UnitsInStock=65},
                new Product{ProductId=5, CategoryId=2, ProductName="Fare", UnitPrice=85, UnitsInStock=1}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ - Language Integrated Query
            //Lambda
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
