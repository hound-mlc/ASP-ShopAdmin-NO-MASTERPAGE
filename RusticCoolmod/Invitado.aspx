<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Invitado.aspx.cs" Inherits="RusticCoolmod.Invitado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8"/>
    <link rel="stylesheet" href="CSS/boostrap_lux.css"/>
    <title>ACCESO DE INVITADO - RUSTIC HARDWARE</title>
</head>
<body style="background-image:url('Assets/wall1.jpg'); background-attachment: fixed;">
    <nav class="navbar navbar-expand-lg navbar-light bg-light" style="align-content:end;">
        <a class="navbar-brand" href="Main.aspx">RUSTIC HARDWARE</a>
        <ul class="navbar-nav mr-auto">
        </ul>
        <span class="d-xl-inline-flex my-2 my-lg-0"><b style="font-size:13px">ACCESO DE INVITADO</b></span>
    </nav>
    <br />
    <br />
    <div>
        <div class="card border-primary mb-3" style="width: 70%; margin:0 auto">
        <div class="card-header">BÚSQUEDA DE PRODUCTOS Y FABRICANTES</div>
        <div class="card-body" >
            <form id="form1" runat="server">
                <h4 style="margin-left: 15%">Introduzca la cadena de búsqueda:</h4>
                <br />
                <asp:TextBox ID="TextBox1" Width="30%" style="display:block; margin : 0 auto; font-size:16px" Height="40px" runat="server" placeholder="Cadena a buscar..."></asp:TextBox>
                <span style="margin-left:15%"><asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="TextBox1" ErrorMessage="Sólo puede introducir números positivos mayores que 0 si buscas por precios." ForeColor="Red" Display="Dynamic" OnServerValidate="CustomValidator2_ServerValidate"></asp:CustomValidator></span>
                <br />
                <br />
                <h4 style="margin-left: 15%">Elija la tabla donde sea buscar:</h4>
                <br />
                <asp:DropDownList ID="DropDownList1" class="nav-link dropdown-toggle" Width="20%" style="margin: 0 auto" data-toggle="dropdown" role="button" AutoPostBack="True" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                <br />
                <br />
                <h4 style="margin-left: 15%">Elija el campo por el que quiere realizar la búsqueda:</h4>
                <br />
                <asp:DropDownList ID="DropDownList2" class="nav-link dropdown-toggle" Width="20%" style="margin: 0 auto" data-toggle="dropdown" role="button" runat="server"></asp:DropDownList>
                <br />
                <br />
                <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Buscar" Width="20%" style="margin-left: 40%" OnClick="Button1_Click"/>
                <br />
                <br />
                <asp:Panel ID="Panel1" runat="server" style="width:25%; margin:0 auto" Visible="false">
                    <div class="alert alert-dismissible alert-danger">
                        No se han encontrado resultados para sus criterios de búsqueda.
                    </div>
                </asp:Panel>
                <br />
                <br />
                <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="Black" RowStyle-CssClass="table-default" AlternatingRowStyle-CssClass="table-active" style="margin: 0 auto; width:60%;" ></asp:GridView>
            </form>
        </div>
        </div>
    </div>
    
</body>
</html>