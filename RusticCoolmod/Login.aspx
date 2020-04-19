<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RusticCoolmod.Login" %>
<%@ Register TagPrefix="Mi" TagName="Loading" Src="~/Loading.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8"/>
    <link rel="stylesheet" href="CSS/boostrap_lux.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <title>LOGIN - RUSTIC HARDWARE</title>
    
</head>
<body>
        <div class="card border-primary mb-3" style="width:450px; margin:0 auto; margin-top:60px" >
        <div class="card-header"><h3 style="padding-top:10px; padding-left:10px">Iniciar sesión</h3></div>
        <div class="card-body" style="margin: 0 auto;">
            <form id="form1" runat="server" class="formulario-pers">
            <div >
                <asp:TextBox class="form-control" placeholder="Usuario..." ID="textBox1" runat="server" Width="250" style="margin: 0 auto;"></asp:TextBox> 
                <asp:RequiredFieldValidator class="text-danger" runat="server" ErrorMessage="No puede dejar ningún campo vacío." ControlToValidate="textBox1" Display="Dynamic"></asp:RequiredFieldValidator> 
                <br />
                <br />
                <asp:TextBox TextMode="Password" class="form-control" placeholder="Contraseña..." ID="textBox2" runat="server" Width="250" style="margin: 0 auto;"></asp:TextBox> 
                <asp:RequiredFieldValidator class="text-danger" runat="server" ErrorMessage="No puede dejar ningún campo vacío." ControlToValidate="textBox2" Display="Dynamic"></asp:RequiredFieldValidator> 
                <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="textBox2" ErrorMessage="La combinación de usuario y contraseña es incorrecta." ForeColor="Red" OnServerValidate="CustomValidator2_ServerValidate"></asp:CustomValidator>
                <br />
                <br />
                <asp:Button type="button" class="btn btn-primary" ID="Button1" runat="server" Text="Iniciar sesión" style="margin-left: 120px" OnClick="Button1_Click"/>
                <br />
                <br />
                <asp:Button type="button" CausesValidation="false" class="btn btn-outline-primary" ID="Button2" runat="server" Text="Entrar como invitado" style="margin-left: 90px" OnClick="Button2_Click" UseSubmitBehavior="False"/>
                <br />
                <br />
                <Mi:Loading id="loading" runat="server" Visible="false"></Mi:Loading>
            </div>
            </form>
       </div>
    </div>
    <br />

    <blockquote class="blockquote text-center">
        <p class="mb-0">Las máquinas me sorprenden con mucha frecuencia.</p>
        <footer class="blockquote-footer"><cite title="Source Title">Alan Turing</cite></footer>
    </blockquote>

</body>
</html>
