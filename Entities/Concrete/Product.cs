using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        //public-> bu klasa diğer katmanlarda ulaşbilsin diye
        //internal->sadece entities erişebilir.
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; }//ürün stok
        public decimal UnitPrice { get; set; }

    }
}
