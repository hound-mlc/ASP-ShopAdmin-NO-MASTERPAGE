<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminIndex.aspx.cs" Inherits="RusticCoolmod.AdminIndex" %>
<%@ Register TagPrefix="Mi" TagName="UserInfo" Src="~/AdminData.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8"/>
    <link rel="stylesheet" href="CSS/boostrap_lux.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <title>ADMINISTRADOR - RUSTIC HARDWARE</title>
</head>
<body>
    <form runat="server">
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
        <a class="navbar-brand" href="#">Rustic Hardware</a>
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
                <li class="nav-item">
                    <a class="nav-link" href="AdminAddFabr.aspx">Insertar fabricante</a>
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
        <div class="jumbotron">
            <h1 class="display-3">Hola, <%= this.usuario %></h1>
            <p class="lead">Bienvenido al panel de administración de Rustic Hardware, recuerde que cualquier cambio que realice se verá reflejado para el cliente.</p>
            <hr class="my-4"/>
            <p>Puede consultar el listado de productos y fabricantes cuando lo desee.</p>
            <p class="lead">
                <a class="btn btn-primary btn-lg" target="blank" href="AdminTables.aspx" role="button">Ver ahora</a>
            </p>
        </div>
        </form>
</body>
</html>
