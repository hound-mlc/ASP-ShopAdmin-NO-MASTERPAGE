<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminData.ascx.cs" Inherits="RusticCoolmod.AdminData" %>

<asp:HyperLink ID="HyperLink1" runat="server" class="mr-sm-2" style="color:white">Bienvenido, <%= this.usuario %> </asp:HyperLink>
<asp:Button ID="Button1" runat="server" class="btn btn-secondary my-2 my-sm-0" Text="Cerrar sesión" OnClick="Button1_Click" CausesValidation="false"/>