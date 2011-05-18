<%@ Page Title="Benvindo!" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="recuperarPassword.aspx.cs" Inherits="Face.recuperarPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .style1
        {
            color: #666;
            font-size: 12px;
            font-weight: bold;
            text-align: center;
        }
        .style2
        {
            text-align: center;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="pgErroLogin" align="center">
        <tr>
            <td>
                <h2 style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #a1afcb">
                    Recuperar Password</h2>
            </td>
        </tr>
        <tr align="center">
            <td>
            <div class="yellowError" style="width: 90%" align="left">
                Preenche o campo E-mail:<br /><br /> Escreva no campo email o endereço que foi 
                utilizado para o registo no LOLbook,<br />
                será enviada a password para a sua conta de email.<a href="#">Pedir uma nova.</a>
                </div>
            </td>
        </tr>
        <tr style="padding: 20px; height: 50px; vertical-align: middle">
            <td class="style1" align="right">
                E-mail:<asp:TextBox ID="txtEnviaEmail" runat="server" 
                    CssClass="BoxForm"></asp:TextBox>
            </td>
        </tr>
        <tr style="padding: 20px; height: 50px; vertical-align: middle">
            <td class="style1" align="right">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;
            <asp:Button CssClass="botaoLoginErro" ID="btnRecuperarPass" runat="server" 
                    Text="Enviar Email" onclick="btnRecuperarPass_Click" />
                
            </td>
        </tr>
        <tr style="height: 30px; text-align: center;">
            <td>
                <asp:Label ID="lblEmailInvalido" class="redError" style="width: 90%;" 
                    runat="server" 
                    Text="O e-mail intoduzido não corresponde a nenhum utilizador do LOLbook!" 
                    Visible="False"></asp:Label>            
                <br />
                <asp:Label ID="lblErro" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
