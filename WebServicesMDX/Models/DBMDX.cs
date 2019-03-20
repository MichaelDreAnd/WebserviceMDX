using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AnalysisServices.AdomdClient;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace WebServicesMDX.Models
{
    public class DBMDX
    {
        AdomdConnection adomdConnection = new AdomdConnection("Data Source=localhost; catalog=AnalysisServicesTutorial;");

        public IEnumerable<Product> getProductSaleCount(int year, int month, int day)
        {
            List<Product> productList = new List<Product>();

            try
            {
                string commandtext = "SELECT {[Measures].[Sale Count]} ON Columns, non empty{[Product].[Product Name].children} " +
                    "ON rows From[Fclub DW] where {[Date].[Year].&[" + year + "]}";

                adomdConnection.Open();
                AdomdCommand cmd = new AdomdCommand(commandtext, adomdConnection);
                AdomdDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Product product = new Product(dr.GetValue(0) + ": " + dr[1].ToString());
                    productList.Add(product);
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Errormessage: " + e.Message);
                return null;
            }
            return productList;
        }
        public IEnumerable<Product> getProductSaleCountMembers()
        {
            List<Product> productList = new List<Product>();

            try
            {
                string commandtext = "SELECT {[Measures].[Sale Count]} ON Columns, " +
                    "non empty{[Member].[Member ID].children} ON rows From[Fclub DW]";

                adomdConnection.Open();
                AdomdCommand cmd = new AdomdCommand(commandtext, adomdConnection);
                AdomdDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Product product = new Product(dr.GetValue(0) + ": " + dr[1].ToString());
                    productList.Add(product);
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Errormessage: " + e.Message);
                return null;
            }
            return productList;
        }
        public IEnumerable<Product> getProductCategoriesSaleCount(int year,int month,int day)
        {
            List<Product> productList = new List<Product>();

            try
            {
                string commandtext = "SELECT {[Measures].[Sale Count]} ON Columns, " +
                    "non empty{[Product].[Main Category].children * [Product].[Sub Category].children * [Product].[Sub Sub Category].children} " +
                    "ON rows From [Fclub DW] where {[Date].[Year].&[" + year + "]}";

                adomdConnection.Open();
                AdomdCommand cmd = new AdomdCommand(commandtext, adomdConnection);
                AdomdDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Product product = new Product(dr.GetValue(0) + ": " + dr[1].ToString());
                    productList.Add(product);
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Errormessage: " + e.Message);
                return null;
            }
            return productList;
        }
        public IEnumerable<Product> getProductCategories()
        {
            List<Product> productList = new List<Product>();

            try
            {
                string commandtext = "SELECT {} ON 0, {[Product].[Product Name].[Product Name] *[Product].[Main Category].children*[Product].[Sub Category].children*[Product].[Sub Sub Category].children} " +
                    "on 1 From [Fclub DW]";

                adomdConnection.Open();
                AdomdCommand cmd = new AdomdCommand(commandtext, adomdConnection);
                AdomdDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Product product = new Product(dr.GetValue(0) + ": " + dr[1].ToString());
                    productList.Add(product);
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Errormessage: " + e.Message);
                return null;
            }
            return productList;
        }
    }

    public class Product
    {
        public string ProductName { get; set; }

        public Product(string productName)
        {
            ProductName = productName;
        }
    }
}