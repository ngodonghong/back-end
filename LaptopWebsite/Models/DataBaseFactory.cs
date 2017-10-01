using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaptopWebsite.Models
{
    public static class DataBaseFactory
    {
        public static LaptopDbContext context;
        public static void Initialize()
        {
            DataBaseFactory.context = new LaptopDbContext();
            DataBaseFactory.context.Database.CreateIfNotExists();
            DataBaseFactory.context.Database.Initialize(false);
        }
    }
}