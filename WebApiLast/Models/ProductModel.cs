using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiLast.Entity;

namespace WebApiLast.Models
{
    public class ProductModel
    {
        public ProductModel(ProductStaff productStaff)
        {
            id = productStaff.id;
            shortAddress = productStaff.shortAddress;
            numberPhone = productStaff.numberPhone;
            emailAddres = productStaff.emailAddres;
            imageLink = productStaff.imageLink;
        }

        public int id { get; set; }
        public string shortAddress { get; set; }
        public string numberPhone { get; set; }
        public string emailAddres { get; set; }
        public byte[] imageLink { get; set; }
    }
}