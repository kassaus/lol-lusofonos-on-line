<%@ Page Title="Bem vindo ao registo!" Language="C#" MasterPageFile="~/Site3.Master"
    AutoEventWireup="true" CodeBehind="registo.aspx.cs" Inherits="Face.registo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            margin: 0px;
            text-align: right;
            color: #051b47;
            font-size: 12px;
            width: 228px;
        }
        .style2
        {
            width: 228px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table align="center" style="margin-top: 20px">
<tr style="border-top-style: solid; border-top-width: thin; border-top-color: #ededed">
<td>
<asp:Image ID="imagRegisto" runat="server" ImageUrl="~/images/registo.png" ImageAlign="Middle" />    
    </td>
    <td>
    <span class="letraCinzento"><strong>Regista-te no FaceBook</strong></span><br /> e vive momentos de loucura<strong> liga-te a amigos, partilha fotos e cria o teu próprio perfil</strong>
    </td>
    </tr>
    </table>
    <table class="pgRegisto" align="center" style="margin-top:10px">
        <tr>
            <td class="style1">
                <asp:Label CssClass="letraCinzento" ID="lblNome" runat="server" Text="Nome:"></asp:Label>
            </td>
            <td>
                <asp:TextBox CssClass="BoxForm" ID="txtNome" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNome" runat="server" ControlToValidate="txtNome"
                    ErrorMessage="Campo obrigatório" ForeColor="Red" ValidationGroup="grupo1">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label CssClass="letraCinzento" ID="lblApelido" runat="server" Text="Apelido:"></asp:Label>
            </td>
            <td>
                <asp:TextBox CssClass="BoxForm" ID="TxtApelido" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rftApelido" runat="server" ControlToValidate="txtApelido"
                    ErrorMessage="Campo obrigatório" ForeColor="Red" ValidationGroup="grupo1">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label CssClass="letraCinzento" ID="drlSexo" runat="server" Text="Sexo:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList CssClass="BoxForm" ID="ddSexo" runat="server" Width="105">
                    <asp:ListItem>Masculino</asp:ListItem>
                    <asp:ListItem>Feminino</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label CssClass="letraCinzento" ID="lblpais" runat="server" Text="País:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList CssClass="BoxForm" ID="ddPais" runat="server" Width="105px" AutoPostBack="True"
                    DataSourceID="pais" DataTextField="pais" DataValueField="IdPais">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label CssClass="letraCinzento" ID="Label1" runat="server" Text="Cidade:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList CssClass="BoxForm" ID="ddCidade" runat="server" Width="203px" DataSourceID="cidade"
                    DataTextField="cidade" DataValueField="idCidade">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label CssClass="letraCinzento" ID="lblDataNascimento" runat="server" Text="Data Nascimento:"></asp:Label>
            </td>
            <td>
                <asp:TextBox CssClass="BoxForm" ID="txtDataNascimento" runat="server"></asp:TextBox>
                <asp:CalendarExtender ID="txtDataNascimento_CalendarExtender" runat="server" TargetControlID="txtDataNascimento" Format= "dd / MM /yyyy">
                </asp:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label CssClass="letraCinzento" ID="lblEmail" runat="server" Text="E-Mail:"></asp:Label>
            </td>
            <td>
                <asp:TextBox CssClass="BoxForm" ID="TxtEmail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rftEmail" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="Campo obrigatório" ForeColor="Red" ValidationGroup="grupo1">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="Email Inválido" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ValidationGroup="grupo1">*</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label CssClass="letraCinzento" ID="lblPass" runat="server" Text="Password:"></asp:Label>
            </td>
            <td>
                <asp:TextBox CssClass="BoxForm" ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvpass1" runat="server" ControlToValidate="txtPass"
                    ErrorMessage="Têm de preencher a Password" ForeColor="Red" ValidationGroup="grupo1">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label CssClass="letraCinzento" ID="lblPassConf" runat="server" Text="Confirme Password:"></asp:Label>
            </td>
            <td>
                <asp:TextBox CssClass="BoxForm" ID="txtPassConf" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvpass2" runat="server" ControlToValidate="txtPassConf"
                    ErrorMessage="Têm que confirmar a Password" ForeColor="Red" ValidationGroup="grupo1">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label CssClass="letraCinzento" ID="lblFoto" runat="server" Text="Foto:"></asp:Label>
            </td>
            <td>
               <asp:FileUpload ID="fupImagem" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;
            </td>
            <td height="50" valign="middle">
                <p>
                    <asp:Button class="botaoRegisto" ID="btnRegisto" runat="server" ValidationGroup="grupo1"
                        Text="Regista-te" PostBackUrl="#" onclick="btnRegisto_Click1" /></p>
            </td>
        </tr>
    </table>
    <table align="center">
        <tr>
            <td align="right">
                <br />
                
                <asp:Label ID="lblUserValidado" runat="server" CssClass="yellowError" 
                    Text="Label" Visible="False"></asp:Label>
                
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="yellowError"
                    ForeColor="Red" ValidationGroup="grupo1" />
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:RegularExpressionValidator ID="revPass" runat="server" ControlToValidate="txtPass"
                    CssClass="yellowError" ErrorMessage="Deve conter uma letra minuscula uma letra maiuscula e um número"
                    ValidationExpression="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{4,20}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPass"
                    ControlToValidate="txtPassConf" CssClass="yellowError" ErrorMessage="Password diferentes!"
                    ForeColor="Red"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
                <asp:SqlDataSource ID="pais" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                    SelectCommand="SELECT * FROM [pais]"></asp:SqlDataSource>
                <asp:SqlDataSource ID="cidade" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                    SelectCommand="SELECT * FROM [cidade] WHERE ([idPais] = @idPais)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddPais" Name="idPais" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
