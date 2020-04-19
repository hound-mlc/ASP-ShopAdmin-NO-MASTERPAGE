<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="RusticCoolmod.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8"/>
    <link rel="stylesheet" href="CSS/boostrap_lux.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="Scripts/carrusel.js"></script>
    <title>RUSTIC HARDWARE</title>
    <style>
        body{
            opacity: 0;
            transition: opacity 4s;
            overflow: hidden;
        }

        #footer {
            position: fixed;
            bottom: 0;
            width: 100%;
            background-color: black;
            height:80px
        }
    </style>
</head>
<body onload="document.body.style.opacity='1'">
    <nav class="navbar navbar-expand-lg navbar-dark bg-primary" style="text-align: center">
        <a class="navbar-center" href="#" style="color:white; font-size:30px; margin:0 auto">RUSTIC HARDWARE</a>
        <form class="form-inline my-2 my-lg-0" runat="server">
            <asp:Button type="button" class="btn btn-warning my-2 my-sm-0" ID="Button1" runat="server" Text="Iniciar sesión" OnClick="Button1_Click"/>
        </form>
    </nav>
    <div class="slider" style="height:900px">
        <div>
            <img id="pic" src="Assets/Carrusel/ryzen.jpg" style="opacity: 0.5; background-color:black"/>
        </div>
    </div>
    
    <div id="footer">
        <blockquote class="blockquote text-center">
            <footer class="blockquote-footer" style="margin-top:20px;font-size:19px">Manuel López Camarena - 2020</footer>
        </blockquote>
    </div>

    
</body>
</html>
