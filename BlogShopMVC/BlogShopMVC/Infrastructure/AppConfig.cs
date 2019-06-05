using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace BlogShopMVC.Infrastructure
{
    public class AppConfig
    {
        private static string _picturesProducts = ConfigurationManager.AppSettings["PicturesProducts"];

        public static string PicturesProducts
        {
            get
            {
                return _picturesProducts;
            } 
        }
        //private static string _picturesCategory = ConfigurationManager.AppSettings["PicturesCategory"];

        //public static string PicturesCategory
        //{
        //    get
        //    {
        //        return _picturesCategory;
        //    }
        //}

    }
}