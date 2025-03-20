using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm_Exercise01.Report2
{
    public partial class DateRange : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sd = Request.QueryString["startDate"]?.ToString();

                //Set Processing Mode of Report as Local
                ReportViewer1.ProcessingMode = ProcessingMode.Local;

                //Set Path of the Local Report
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("Report1.rdlc");                

                //Database connection
                if(sd != "")
                {
                    //Creating object of DataSet1 and filling the DataSet using SQLDataAdapter
                    DataSet1 ds1 = new DataSet1();

                    SqlConnection connect = new SqlConnection("Data Source = MSI; Initial Catalog = Report; Integrated Security = True");
                    connect.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("select * from OrderList", connect);
                    adapter.Fill(ds1, "DataTable1");

                    connect.Close();

                    //Providing DataSource for Report
                    ReportDataSource rds = new ReportDataSource("DataSet1", ds1.Tables[0]);
                    ReportViewer1.LocalReport.DataSources.Clear();

                    //Add ReportDataSource
                    ReportViewer1.LocalReport.DataSources.Add(rds);
                }
                else
                {
                    //Creating object of DataSet1 and filling the DataSet using SQLDataAdapter
                    DataSet1 _ds1 = new DataSet1();

                    SqlConnection _connect = new SqlConnection("Data Source = MSI; Initial Catalog = Report; Integrated Security = True");
                    _connect.Open();

                    SqlDataAdapter _adapter = new SqlDataAdapter("select * from OrderList where OrderDate between '" + "2023-01-15" + "' and '" + "2023-03-13" + "'", _connect);
                    _adapter.Fill(_ds1, "DataTable1");

                    _connect.Close();

                    //Providing DataSource for Report
                    ReportDataSource _rds = new ReportDataSource("DataSet1", _ds1.Tables[0]);
                    ReportViewer1.LocalReport.DataSources.Clear();

                    //Add ReportDataSource
                    ReportViewer1.LocalReport.DataSources.Add(_rds);
                }
            }

            //if(IsPostBack)
            //{
            //    string sd = Request.QueryString["obj.startDate"]?.ToString();
            //    //string ed = Request.QueryString["obj.startDate"]?.ToString();

            //    //Set Processing Mode of Report as Local
            //    ReportViewer1.ProcessingMode = ProcessingMode.Local;

            //    //Set Path of the Local Report
            //    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Report1.rdlc");

            //    //Creating object of DataSet1 and filling the DataSet using SQLDataAdapter
            //    DataSet1 _ds1 = new DataSet1();

            //    //Database connection
            //    SqlConnection _connect = new SqlConnection("Data Source = MSI; Initial Catalog = Report; Integrated Security = True");
            //    _connect.Open();

            //    SqlDataAdapter adapter = new SqlDataAdapter("select * from OrderList where OrderDate between '" + sd + "' and '" + sd + "'", _connect);
            //    adapter.Fill(_ds1, "DataTable1");

            //    _connect.Close();

            //    //Providing DataSource for Report
            //    ReportDataSource _rds = new ReportDataSource("DataSet1", _ds1.Tables[0]);
            //    ReportViewer1.LocalReport.DataSources.Clear();

            //    //Add ReportDataSource
            //    ReportViewer1.LocalReport.DataSources.Add(_rds);
            //}
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}