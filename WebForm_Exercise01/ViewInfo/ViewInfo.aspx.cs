using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForm_Exercise01.Report;

namespace WebForm_Exercise01.ViewInfo
{
    public partial class ViewInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if(!IsPostBack)
            //{
            //    ReportViewer1.ProcessingMode = ProcessingMode.Local;
            //    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report1.rdlc");

            //    DataSet1 ds1 = new DataSet1();

            //    SqlConnection connect = new SqlConnection("Data Source = MSI; Initial Catalog = panhaBase; Integrated Security = True");
            //    connect.Open();

            //    SqlDataAdapter adapter = new SqlDataAdapter("select * from PersonalInfo", connect);
            //    adapter.Fill(ds1, "DataTable1");

            //    connect.Close();

            //    ReportDataSource rds = new ReportDataSource("DataSet1", ds1.Tables[0]);
            //    ReportViewer1.LocalReport.DataSources.Clear();

            //    ReportViewer1.LocalReport.DataSources.Add(rds);

            //}
        }
    }
}