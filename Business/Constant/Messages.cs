using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constant
{
    public static class Messages// sürekli newlenmesin dite static
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime="Sistem bakımda";
        public static string ProductsListed= "Ürünler Listelendi";
        public static string ProductCountOfCategoryError="Bir kayegoride en fazla 10 ürün olabilir";
        public static string ProductNameAlreadyExists="Bu isimde zaten başka bir ürün var";
        internal static string CategoryLimitExceded="Kategori limiti aşıldığı için yeni ürün  eklenemiyor";
    }
}
