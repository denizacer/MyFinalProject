using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using Core.Entites;
//using Entities.Abstract; sildim


namespace Core.DataAccess//değiştirdim
{
    //generic constraint kısıtlıyacaz where T:class
    //class: referan tip olabilir
    // IEntity: IEntity olabilir veya IEntity implemente eden bir nesne olabilir
    //new():newlenebilir olabilmeli
    public interface IEntityRepository<T> where T:class, IEntity,new()
    {
        //<T> category yada product gelebilir ikisde olabilir bunu yazınca
        //db yapacağın şeylerle ilgili class
        //data acceses sağ tık add reference+ entities+ok//ref verdik product için
        List<T> GetAll(Expression<Func<T, bool>> filter = null);//filitreleme yapıyor.null demek filitre vermemiişda olabilir bütündatayı getircek
        T Get(Expression<Func<T, bool>> filter);//sadece category ıdye göre listeledik bu başka bişide olabilir
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        /*List<T> GetAllByCategory(int categoryId);//List<T> GetAll(Expression<Func<T, bool>> filter = null);//filitreleme yapıyor.null demek filitre vermemiişda olabilir bütündatayı getircek
        T Get(Expression<Func<T, bool>> filter)
        burayı yazığımız için buna gerek kalmadı
        //kartegoriye göre listeledik.getalla şart girdik bu iptal olacak*/
    }
}
