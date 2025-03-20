using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebForm_Exercise01.Report2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Report_Service" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Report_Service.svc or Report_Service.svc.cs at the Solution Explorer and start debugging.
    public class Report_Service : IReport_Service
    {
        SqlConnection connect = new SqlConnection("Data Source = MSI; Initial Catalog = Report; Integrated Security = True");
        public string DateRange(int id, string orderDate, string customerName, string productName, int totalPayment, string startDate, string endDate)
        {
            try
            {
                connect.Open(); /*FORMAT(DOB, 'mm/dd/yyyy') = DEFAULT*/
                SqlCommand cmd = new SqlCommand(
                    "SELECT [ID], FORMAT(OrderDate, 'dd/MMM/yyyy'), [CustomerName], [ProductName], [TotalPayment] " +
                    "FROM OrderList " +
                    "WHERE OrderDate between '" + startDate + "' AND '" + endDate+ "'",
                    connect);

                connect.Close();
                return "1";
            }
            catch (Exception)
            {
                return "Error";
            }
            
        }
    }
}