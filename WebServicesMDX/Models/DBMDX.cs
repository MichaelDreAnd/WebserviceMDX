using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AnalysisServices.AdomdClient;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;

namespace WebServicesMDX.Models
{
    public class DBMDX
    {
        string season;
        AdomdConnection adomdConnection = new AdomdConnection("Data Source=localhost; catalog=AnalysisServicesTutorial;");

        public IEnumerable<Product> getProductSaleCountYear(int year)
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
        public string checkSeason(int month)
        {
            if (month == 12 || month == 1 || month == 2)
            {
                season = "Winter";
            }
            if (month == 3 || month == 4 || month == 5)
            {
                season = "Spring";
            }
            if (month == 6 || month == 7 || month == 8)
            {
                season = "Summer";
            }
            if (month == 9 || month == 10 || month == 11)
            {
                season = "Fall";
            }
            return season;
        }
        public IEnumerable<Product> getProductSaleCountYearMonth(int year, int month)
        {
            List<Product> productList = new List<Product>();
            string season = checkSeason(month);
            try
            {
                string commandtext = "SELECT {[Measures].[Sale Count]} ON Columns, non empty{[Product].[Product Name].children} " +
                    "ON rows From[Fclub DW] where {[Date].[Hierarchy].[Month Number Of Year].&["+ month +"]&["+ year + "]&[" + season + "]}";

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

        public IEnumerable<Product> getProductSaleCountYearMonthDay(int year, int month, int day)
        {
            List<Product> productList = new List<Product>();
            string season = checkSeason(month);
            try
            {
                string commandtext = "SELECT {[Measures].[Sale Count]} ON Columns, non empty{[Product].[Product Name].children} " +
                    "ON rows From[Fclub DW] where {[Date].[Hierarchy].[Day Number Of Month].&[" + day + "]&[" + year + "]&[" + season + "]&[" + month + "]}";

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
        public IEnumerable<Product> getProductCategoriesSaleCountYear(int year)
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
        public IEnumerable<Product> getProductCategoriesSaleCountYearMonth(int year, int month)
        {
            List<Product> productList = new List<Product>();
            string season = checkSeason(month);
            try
            {
                string commandtext = "SELECT {[Measures].[Sale Count]} ON Columns, " +
                    "non empty{[Product].[Main Category].children * [Product].[Sub Category].children * [Product].[Sub Sub Category].children} " +
                    "ON rows From [Fclub DW] where {[Date].[Hierarchy].[Month Number Of Year].&[" + month + "]&[" + year + "]&[" + season + "]}";

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
        //public IEnumerable<Product> getProductCategoriesSaleCountYearMonthDay(int year, int month, int day)
        //{
        //    List<Product> productList = new List<Product>();
        //    string season = checkSeason(month);
        //    try
        //    {
        //        string commandtext = "SELECT {[Measures].[Sale Count]} ON Columns, " +
        //            "non empty{[Product].[Main Category].children * [Product].[Sub Category].children * [Product].[Sub Sub Category].children} " +
        //            "ON rows From [Fclub DW] where {[Date].[Hierarchy].[Day Number Of Month].&[" + day + "]&[" + year + "]&[" + season + "]&[" + month + "]}";

        //        adomdConnection.Open();
        //        AdomdCommand cmd = new AdomdCommand(commandtext, adomdConnection);
                
        //        AdomdDataReader dr = cmd.ExecuteReader();

        //        while (dr.Read())
        //        {
        //            Product product = new Product(dr.GetValue(0) + ": " + dr.GetValue(1) + ": " + dr.GetValue(2) +  ": " + dr[3].ToString());
        //            productList.Add(product);
        //        }
        //    }

        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Errormessage: " + e.Message);
        //        return null;
        //    }
        //    return productList;
        //}

        public IEnumerable<Category> getProductCategoriesSaleCountYearMonthDay(int year, int month, int day)
        {
            List<Category> categoryList = new List<Category>();
            StringBuilder result = new StringBuilder();

            string season = checkSeason(month);
            try
            {
                string commandtext = "SELECT {[Measures].[Sale Count]} ON Columns, " +
                    "non empty{[Product].[Main Category].children * [Product].[Sub Category].children * [Product].[Sub Sub Category].children} " +
                    "ON rows From [Fclub DW] where {[Date].[Hierarchy].[Day Number Of Month].&[" + day + "]&[" + year + "]&[" + season + "]&[" + month + "]}";

                adomdConnection.Open();
                AdomdCommand cmd = new AdomdCommand(commandtext, adomdConnection);

                CellSet cs = cmd.ExecuteCellSet();

                TupleCollection tupleCollection = cs.Axes[0].Set.Tuples;

                TupleCollection tuplesOnRow = cs.Axes[1].Set.Tuples;

                int row = 0;
                foreach (var obj in tuplesOnRow)
                {
                    for (int members = 0; members < tuplesOnRow[row].Members.Count; members++)
                    {
                        result.Append(tuplesOnRow[row].Members[members].Caption + ": ");

                    }
                    for (int col = 0; col < tupleCollection.Count; col++)
                    {
                        result.Append(cs.Cells[col, row].FormattedValue);
                        if (col < tupleCollection.Count - 1)
                        {
                            result.Append(": ");
                        }
                    }
                    row++;

                    Category cat = new Category(result.ToString());
                    categoryList.Add(cat);
                    result.Clear();

                }
            
            }

            catch (Exception e)
            {
                Console.WriteLine("Errormessage: " + e.Message);
                return null;
            }
            return categoryList;
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
                    Product product = new Product(dr.GetValue(0) + ": " + dr.GetValue(1) + ": " + dr.GetValue(2) + ": " + dr.GetValue(3));
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

    public class Category
    {
        public string CategoryName { get; set; }

        public Category(string categoryName)
        {
            CategoryName = categoryName;
        }
    }
}