<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminAddFabr.aspx.cs" Inherits="RusticCoolmod.AdminAddFabr" %>
<%@ Register TagPrefix="Mi" TagName="UserInfo" Src="~/AdminData.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8"/>
    <link rel="stylesheet" href="CSS/boostrap_lux.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <title>AÑADIR FABRICANTE - RUSTIC HARDWARE</title>
</head>
<body style="background-image:url('Assets/fabrwall.jpg'); background-attachment: fixed; background-size: cover;">
    <form id="form1" runat="server">
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
        <a class="navbar-brand" href="AdminIndex.aspx">Rustic Hardware</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarColor02" aria-controls="navbarColor02" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>

        <div class="collapse navbar-collapse" id="navbarColor02">
            <ul class="navbar-nav mr-auto">
                <li class="nav-item">
                    <a class="nav-link" href="AdminAddProducto.aspx">Insertar producto</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="AdminEditProd.aspx">Editar producto</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="AdminDelProd.aspx">Eliminar producto</a>
                </li>
                <li class="nav-item active">
                    <a class="nav-link" href="#">Insertar fabricante</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="AdminEditFabr.aspx">Editar fabricante</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="AdminDelFabr.aspx">Eliminar fabricante</a>
                </li>
            </ul>
            <div class="my-2 my-lg-0">
                <Mi:UserInfo runat="server"></Mi:UserInfo>
            </div>
        </div>
    </nav>
    
        <div>
            <div class="card border-primary mb-3" style="width: 70%; margin:0 auto; margin-top:2%">
        <div class="card-header" style="background-color:black; color:white">INSERTAR FABRICANTE</div>
        <div class="card-body text-center" style="background-color:lightgray">
                <h4>Introduzca el nombre del fabricante:</h4>
                <br />
                <asp:TextBox ID="TextBox2" Width="20%" style="display:block; margin : 0 auto; font-size:16px" Height="40px" runat="server" placeholder="Nombre..."></asp:TextBox>
                <asp:RequiredFieldValidator class="text-danger" runat="server" ErrorMessage="El nombre es obligatorio." ControlToValidate="TextBox2" Display="Dynamic"></asp:RequiredFieldValidator>    
                <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="TextBox2" ErrorMessage="Ya existe un fabricante con ese nombre." ForeColor="Red" Display="Dynamic" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>    
                <br />
                <br />
                <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Insertar" Width="20%" OnClick="Button1_Click"/>
                <br />
                <br />
                <asp:Panel ID="Panel1" runat="server" style="width:25%; margin:0 auto" Visible="false">
                    <div class="alert alert-dismissible alert-success">
                        <button type="button" class="close" data-dismiss="alert">&times;</button>
                        Fabricante añadido correctamente a la base de datos.
                    </div>
                </asp:Panel>
                <br />
        </div>
        </div>
        </div>
    </form>
</body>
</html>
