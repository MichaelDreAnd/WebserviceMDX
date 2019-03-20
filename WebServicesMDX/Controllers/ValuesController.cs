using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServicesMDX.Models;

namespace WebServicesMDX.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<Product> Get()
        {
            DBMDX d = new DBMDX();
            List<Product> productList = new List<Product>();
            productList = (List<Product>)d.getProductSaleCountYear(2004);

            return productList;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
