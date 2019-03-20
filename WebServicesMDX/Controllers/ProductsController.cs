using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServicesMDX.Models;

namespace WebServicesMDX.Controllers
{
    public class ProductsController : ApiController
    {
        public IEnumerable<Product> Get(int year,int month, int day)
        {
            

            DBMDX d = new DBMDX();
            List<Product> productList = new List<Product>();
            productList = (List<Product>)d.getProductSaleCountYearMonthDay(year,month, day);

            return productList;
        }
    }
}
