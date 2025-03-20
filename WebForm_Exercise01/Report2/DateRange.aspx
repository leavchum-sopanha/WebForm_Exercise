<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DateRange.aspx.cs" Inherits="WebForm_Exercise01.Report2.DateRange" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> OrderList - Report </title>
    
    <script type="text/javascript" src="../Scripts/jquery-3.4.1.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../Content/bootstrap.css"/>
    <link href="../Content/bootstrap-theme.css" rel="stylesheet" />
    <link href="DateRange.css" rel="stylesheet" />
</head>
<body id="1">t
    <form class="container-box" id="form1" runat="server">
        
        <div class="container-header">

            <div class="header-left">
                <p>From</p>
                <input type="date" id="startDate"/>
            </div>

            <div class="header-right">
                <p>To</p>
                <input type="date" id="endDate"/>
            </div>
            <button id="btnSearch" class="btn" type="button">Search</button>
            <%--<asp:Button ID="btnSearch" runat="server" class="btn" type="button" Text="Search" />--%>
                
        </div>
            
        <div class="container-report" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="698px" Height="980px" BackColor="" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HighlightBackgroundColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" SecondaryButtonBackgroundColor="#0066FF" ToolbarDividerColor="#003300" ToolbarForegroundColor="Blue" ToolbarForegroundDisabledColor="#CCCCCC" ToolbarHoverBackgroundColor="#CCFFFF"></rsweb:ReportViewer>
        </div>

    </form>

    <script type="text/javascript" src="DateRange.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js"></script>  
    <script src="../Scripts/modernizr-2.8.3.js"></script>
</body>
</html>