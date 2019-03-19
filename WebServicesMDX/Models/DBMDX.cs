using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AnalysisServices.AdomdClient;


namespace WebServicesMDX.Models
{
    public class DBMDX
    {
        AdomdConnection adomdConnection = new AdomdConnection("Data Source=localhost; catalog=AnalysisServicesTutorial;");
        public IEnumerable<string> testingMDX()
        {
            

            string commandtext = "SELECT {[Measures].[Sale Count]} ON COLUMNS, {[Date].[Year].&[2003]} ON ROWS FROM[Fclub DW]";

            adomdConnection.Open();

            AdomdCommand cmd = new AdomdCommand(commandtext, adomdConnection);

            AdomdDataReader dr = cmd.ExecuteReader();

            List<string> stringlist = new List<string>();

            while (dr.Read())
            {
                stringlist.Add(dr[1].ToString());

            }
            return stringlist;


        }

        public IEnumerable<string> GetAllProducts()
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

        }


    }

}
