<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewInfo.aspx.cs" Inherits="WebForm_Exercise01.ViewInfo.ViewInfo" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%--<%@ Page Title="ViewInfo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewInfo.aspx.cs" Inherits="WebForm_Exercise01.ViewInfo.ViewInfo" %>--%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>User Information</title>

    <link rel="stylesheet" type="text/css" href="../Content/bootstrap.css"/>
    <script type="text/javascript" src="../Scripts/jquery-3.4.1.min.js"></script>
    <link href="../Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap-theme.css" rel="stylesheet" />

    <link href="ViewInfo.css" rel="stylesheet" />
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.2.0/css/all.min.css" />
    <link href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/themes/smoothness/jquery-ui.css" rel="stylesheet" />
</head>

<%--Body--%>
<body>

    <div class="container-box">

        <%-- Left Container --%>
        <div class="search-container">
            <%--Icon--%>
            <div class="header">
                <i class="fa-solid fa-users-viewfinder"> </i>
                <p style="color: #CBA02D; /*color: #31D2F2;*/ font-weight: bold; text-decoration: underline">USER INFORMATION</p>
            </div>
            
            <div class="form-id">
                <label class="label-control" style="color:cornflowerblue;">ID: </label>
                <input id="txtID" class="form-control" style="margin-left: 2%; border: 2px solid #337AB7" name="sid" placeholder="User ID"/>
            </div>
            
            <button id="btnSearch" class="btn btn-primary" type="button">Search</button>
        </div>
        
        <%--Right Container--%>
        <div class="info-container">
            <form id="form">
                <div class="form">
                    <label class="label-control inline">Full Name :</label>
                    <input class="form-control" style="height: 50%; cursor: not-allowed" id="txtName" type="text" name="name" disabled/>
                </div>

                <div class="form">
                    <label class="label-control">Sex :</label>
                    <select class="form-control" style="height: 50%; cursor: not-allowed" id="txtSex" type="text" name="sex" disabled>
                        <option value=""></option>
                        <option value="Male">Male</option>
                        <option value="Female">Female</option>
                    </select>
                </div>

                <div class="form">
                    <label class="label-control">Date of Birth <span style="color: lightgray;"> (mm/dd/yyyy)</span> :</label>
                    <input type="date" class="form-control" style="height: 50%; /*cursor: not-allowed*/" id="txtDOB" name="dob" disabled/>
                </div>

                <div class="form">
                    <label class="label-control">Phone Number <span style="color: lightgray;"> (+855xx-xxx-xxxx)</span> :</label>
                    <input class="form-control" type="tel" value="+855" style="height: 50%; cursor: not-allowed" id="txtPhone"  name="phone" disabled/>
                </div>

                <div class="btn-form" style="margin: 1%">
                    <div class="btnEdit">
                        <button id="btnEdit" class="btn btn-info" type="button" <%--style="background-color: antiquewhite"--%> disabled>Edit</button>
                    </div>
                    <div class="btnUpdate">
                        <button id="btnUpdate" class="btn btn-success" type="button" style="display: none; margin-right:3%" disabled>Update</button>
                        <button id="btnDelete" class="btn btn-danger" type="button" style="display: none; margin-right:3%" >Delete</button>
                        <button id="btnCancel" class="btn btn-warning" type="button" style="display: none;" >Cancel</button>
                    </div>

                </div>
            </form>
        </div>
    </div>
    
       
    <%--Script--%>
    <script type="text/javascript" src="ViewInfo.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js"></script>  
    <script src="../Scripts/modernizr-2.8.3.js"></script>
</body>
</html> 