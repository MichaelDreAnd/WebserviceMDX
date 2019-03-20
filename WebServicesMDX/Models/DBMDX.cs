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
        static string json;
        AdomdConnection adomdConnection = new AdomdConnection("Data Source=localhost; catalog=AnalysisServicesTutorial;");
        /*public IEnumerable<string> GetAllProducts()
        {
            string commandtext = "SELECT {[Measures].[Sale Count]} ON Columns,non empty{[Product].[Product Name].members}ON rows From[Fclub DW]where { [Date].[Year].&[2002]}";

            adomdConnection.Open();

            AdomdCommand cmd = new AdomdCommand(commandtext, adomdConnection);


            AdomdDataReader dr = cmd.ExecuteReader();

            List<string> stringlist = new List<string>();

            while (dr.Read())
            {
                stringlist.Add(dr[1].ToString()); // virker edit query

            }
            return stringlist;

        }*/
        public IEnumerable<Product> getProductCountMDX()
        {
            List<Product> productList = new List<Product>();

            try
            {
                AdomdConnection adomdConnection = new AdomdConnection("Data Source=localhost; catalog=AnalysisServicesTutorial;");
                string commandtext = "SELECT {[Measures].[Sale Count]} ON Columns, non empty{[Product].[Product Name].members} " +
                    "ON rows From[Fclub DW] where {[Date].[Year].&[2003]}";

                adomdConnection.Open();
                AdomdCommand cmd = new AdomdCommand(commandtext, adomdConnection);
                AdomdDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Product product = new Product(dr.GetValue(0) + ": " + dr[1].ToString());
                    productList.Add(product);
                }

                DataContractJsonSerializer serializeJSON = new DataContractJsonSerializer(typeof(Product));
                MemoryStream streamObj = new MemoryStream();
                StreamReader streamReader = new StreamReader(streamObj);

                for (int i = 0; i < productList.Count; i++)
                {
                    serializeJSON.WriteObject(streamObj, productList[i]);
                    streamObj.Position = 0;
                    json = streamReader.ReadToEnd();
                }

                Console.WriteLine(json);
                streamReader.Close();
                streamObj.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine("Errormessage: " + e.Message);
                return null;
            }
            return productList;
        }

    }
    [DataContract]
    public class Product
    {
        [DataMember(Name = "Product Name")]
        public string ProductCount { get; set; }

        public Product(string productCount)
        {
            ProductCount = productCount;
        }
    }

}
