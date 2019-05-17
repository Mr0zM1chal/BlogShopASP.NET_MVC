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

        public static string ProductPicturesAddres( this UrlHelper helper, string categoryName )
        {
            var ProductPicturesFolder = AppConfig.PicturesCategory;
            var addres = Path.Combine(ProductPicturesFolder, categoryName);
            var addresRelative = helper.Content(addres);

                return addresRelative;
        }

        public static string IconProductFileName(this UrlHelper helper, string productFileName)
        {
            var ProductPicturesFolder = AppConfig.PicturesProducts;
            var addres = Path.Combine(ProductPicturesFolder, productFileName);
            var addresRelative = helper.Content(addres);

            return addresRelative;
        }
    }
}