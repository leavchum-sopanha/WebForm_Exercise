using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForm_Exercise01.Report;

namespace WebForm_Exercise01.UserInput
{
    public partial class UserInput : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Set Processing Mode of Report as Local
                ReportViewer1.ProcessingMode = ProcessingMode.Local;

                //Set path of the Local report
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/s/Report1.rdlc");

                //Creating object of DataSet1 and filling the DataSet using SQLDataAdapter
                DataSet1 ds1 = new DataSet1();

                //Database connection
                SqlConnection connect = new SqlConnection("Data Source = MSI; Initial Catalog = panhaBase; Integrated Security = True");
                connect.Open();

                SqlDataAdapter adapter = new SqlDataAdapter("select * from PersonalInfo", connect);
                adapter.Fill(ds1, "DataTable1");

                connect.Close();

                //Providing DataSource for Report
                ReportDataSource rds = new ReportDataSource("DataSet1", ds1.Tables[0]);
                ReportViewer1.LocalReport.DataSources.Clear();

                //Add ReportDataSource
                ReportViewer1.LocalReport.DataSources.Add(rds);
            }
        }
    }
}