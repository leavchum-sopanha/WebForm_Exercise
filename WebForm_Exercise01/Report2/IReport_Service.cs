using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebForm_Exercise01.Report2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IReport_Service" in both code and config file together.
    [ServiceContract]
    public interface IReport_Service
    {
        [OperationContract]
        string DateRange(int id, string orderDate, string customerName, string productName, int totalPayment, string startDate, string endDate);
    }
}
