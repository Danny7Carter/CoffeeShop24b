﻿using System.Web;
using System.Web.Mvc;

namespace GC_CoffeeLab24b
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}