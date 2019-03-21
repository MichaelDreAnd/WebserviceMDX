using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServicesMDX.Models;

namespace WebServicesMDX.Controllers
{
    public class CategoryController : ApiController
    {
        public IEnumerable<Category> Get(int year)
        {
            DBMDX d = new DBMDX();
            List<Category> categoryList = new List<Category>();
            categoryList = (List<Category>)d.getProductCategoriesSaleCountYear(year);

            return categoryList;
        }
        public IEnumerable<Category> Get(int year, int month)
        {
            DBMDX d = new DBMDX();
            List<Category> categoryList = new List<Category>();
            categoryList = (List<Category>)d.getProductCategoriesSaleCountYearMonth(year, month);

            return categoryList;
        }
        public IEnumerable<Category> Get(int year, int month, int day)
        {
            DBMDX d = new DBMDX();
            List<Category> categoryList = new List<Category>();
            categoryList = (List<Category>)d.getProductCategoriesSaleCountYearMonthDay(year, month, day);

            return categoryList;
        }

        public IEnumerable<Product> Get()
        {
            DBMDX d = new DBMDX();
            List<Product> productList = new List<Product>();
            productList = (List<Product>)d.getProductCategories();

            return productList;
        }
    }
}
