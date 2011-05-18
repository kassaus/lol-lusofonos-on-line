<%@ Page Title="Confirme Login!" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true"
    CodeBehind="loginIncorrecto.aspx.cs" Inherits="Face.loginIncorrecto" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="pgErroLogin" align="center">
        <tr>
            <td colspan="2">
                <h2 style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #a1afcb">
                    Iniciar sessão no Facebook</h2>
            </td>
        </tr>
        <tr align="center">
            <td colspan="2">
            <div class="redError" style="width: 90%">
                <strong>Reescreve a tua palavra-passe</strong><br /><br /> O E-mail ou palavra-passe que introduziste
                está incorrecta. Tenta novamente (certifica-te de que a tecla caps lock está desligada).<br /><br />
                Esqueceste-te da tua palavra-passe? <a href="#">Pedir uma nova.</a>
                </div>
            </td>
        </tr>
        <tr style="padding: 20px; height: 50px; vertical-align: middle">
            <td class="letraCinzento" align="right">
                E-mail:</td>
            <td>
                <asp:TextBox ID="txtEmailErro" runat="server" CssClass="BoxForm"></asp:TextBox>
            </td>
        </tr>
        <tr style="padding: 20px; height: 50px; vertical-align: middle">
            <td class="letraCinzento" align="right">
                Password:</td>
            <td>
               <asp:TextBox ID="TxtPasswordErro" runat="server" CssClass="BoxForm" 
                    TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
            <asp:Button CssClass="botaoLoginErro" ID="btnLogin" runat="server" 
                    Text="Iniciar Sessão" onclick="btnLogin_Click" />
                
            <span class="letraAzulPeq">&nbsp;ou <a href="registo.aspx">regista-te no FaceBook</a></span></td>
        </tr>
        <tr style="height: 30px">
            <td>
                &nbsp;
            </td>
            <td>
                <span class="letraAzulPeq"><a href="recuperarPassword.aspx">Esqueceste-te da palavra passe?</a></span></td>
        </tr>
        <tr style="height: 30px; text-align: center;">
            <td colspan="2">
                <asp:Label ID="lblErro" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
