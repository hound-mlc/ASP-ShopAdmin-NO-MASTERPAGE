<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminTables.aspx.cs" Inherits="RusticCoolmod.AdminTables" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css"/>
    <link rel="stylesheet" href="/resources/demos/style.css"/>
    <link rel="stylesheet" href="CSS/boostrap_lux.css"/>
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script>
        $(function () {
            $("#accordion").accordion();
        });
    </script>
    <title>TABLAS</title>
</head>
<body style="background-image:url('Assets/wallcircuit.jpg'); background-attachment: fixed;">
    <form id="form1" runat="server">
        <div id="accordion" style="margin:0 auto; width:50%; margin-top:1%">
          <h3>Productos</h3>
          <div>
            <p>
                <asp:GridView CssClass="table table-hover" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="Black" RowStyle-CssClass="table-default" AlternatingRowStyle-CssClass="table-active" ID="GridView1" runat="server"></asp:GridView>
            </p>
          </div>
          <h3>Fabricantes</h3>
          <div>
            <p>
                <asp:GridView CssClass="table table-hover" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="Black" RowStyle-CssClass="table-default" AlternatingRowStyle-CssClass="table-active" ID="GridView2" runat="server"></asp:GridView>
            </p>
          </div>
        </div>
    </form>
</body>
</html>
