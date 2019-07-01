using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogShopMVC.Infrastructure
{
    public static class UrlHelpers
    {

        //public static string CategoryPicturesAddres( this UrlHelper helper, string categoryName )
        //{
        //    var CategoryPicturesFolder = AppConfig.PicturesCategory;
        //    var addres = Path.Combine(CategoryPicturesFolder, categoryName);
        //    var addresRelative = helper.Content(addres);

        //        return addresRelative;
        //}

        public static string PicturesProducts(this UrlHelper helper, string productFileName)
        {
           var ProductPicturesFolder = AppConfig.PicturesProducts;
           var addres = Path.Combine(ProductPicturesFolder, productFileName);
           var addresRelative = helper.Content(addres);

            return addresRelative;
        }
        public static string ObrazkiSciezka(this UrlHelper helper, string nazwaObrazka)
        {
            
            try
            {
                var ObrazkiFolder = AppConfig.ObrazkiFolderWzgledny;
                var sciezka = Path.Combine(ObrazkiFolder, nazwaObrazka);
                var sciezkaBezwgledna = helper.Content(sciezka);
                return sciezkaBezwgledna;

            }
            catch (ArgumentNullException e)
            {
                e = new ArgumentNullException();
                return "~/Content/PicturesProducts/xyz3.png";
            }
        }

    }
}