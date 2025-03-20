<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInput.aspx.cs" Inherits="WebForm_Exercise01.UserInput.UserInput" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>User Input</title>

    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="UserInput.css" rel="stylesheet" />
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.2.0/css/all.min.css" />

</head>

<%--Body--%>
<body>

    <div class="row" >

        <div class="title-1">
            <i class="fa-solid fa-pen-to-square" style="color:#FBB03A "></i>
            <p class="p" style="margin: 0 2% 0 2%; color: #FBB03A ; background-color: bisque; border-radius: 15px;">Input Information</p>
            <i class="fa-solid fa-pen-to-square" style="color:#FBB03A "></i>
        </div>
        
        <div class="container-box" id="msg">

            <%--Header--%>
            <div class="header">
                <img src="info-1.png""/>
            </div>

            <div class="right-container"> 
                 <%--Form--%>
                <div class="form">
                    <label class="label-control">Name<%-- <span>(Text only)</span>--%> :</label>
                    <input class="form-control" type="text" id="txtName" name="name" required/>
                </div>

                <div class="form">
                    <label class="label-control">Sex<%-- <span>(Choose option below)</span>--%> :</label>

                    <select class="form-control" name="Sex" id="txtSex" required>
                        <option value="">None</option>
                        <option value="Male">Male</option>
                        <option value="Female">Female</option>
                    </select>
                    <%--<input class="form-control" type="text" id="txtSex"/>--%>
                </div>

                <div class="form">
                    <label class="label-control">Date of Birth :</label>
                    <input class="form-control" type="date" id="txtDOB" required/>
                </div>

                <div class="form">
                    <label class="label-control">Phone Number <span>(+855xx-xxx-xxx)</span> :</label>
                    <input class="form-control" type="tel" id="txtPhone" <%--pattern="[+0-9]{12,}"--%> <%--title="Number only!"--%> value="+855" <%--maxlength="14"--%> required/>
                </div>

                <div class="form-btn">
                    <button id="btnClear" class="btn btn-danger" type="button">Clear</button>
                    <button id="btnSubmit" class="btn btn-success" type="button" disabled>Submit</button>
                </div>
            </div>
           
        </div>
    </div>
    
    <div class="report">
        <div class="title-2">
            <i class="fa-solid fa-circle-info" style="color: black"></i>
            <p class="p" style="margin: 0 2% 0 2%; color: black; background-color: white; border-radius: 15px" >Information Report</p>
            <i class="fa-solid fa-circle-info" style="color: black "></i>
        </div>
    
        <center>
            <form id="form1" runat="server">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="700px" style="background-color: lightgrey; display: flex; justify-content: center; align-items: center; vertical-align: middle;"  Height="1450px" Font-Overline="False" ZoomMode="FullPage"></rsweb:ReportViewer>
            </form>
        </center>
    </div>


    <script type="text/javascript" src="../Scripts/jquery-3.4.1.min.js"></script>
    <script type="text/javascript" src="UserInput.js"></script> 
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js"></script>  

    <script src="../Scripts/modernizr-2.8.3.js"></script>
</body>
</html> 

