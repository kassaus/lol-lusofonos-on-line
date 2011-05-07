<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="entrada.aspx.cs" Inherits="Face.WebForm1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="pgEntrada" style="padding: 0px; margin: 0px;" width="1024">
        <tr>
            <td rowspan="12" valign="top" width="627">
                <h1>
                    Insira a chapa na ranhura<br />
                    e viva momentos de Loucura!</h1>
                <p align="left">
                    <br />
                    <br />
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/redeSocial.png" ImageAlign="Middle" />
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
                </p>
            </td>
            <td colspan="2" valign="top" width="387" style="border-bottom-style: solid; border-bottom-width: thin;
                border-bottom-color: #a1afcb;">
                <h1 style="margin-bottom: 5px">
                    Regista-te</h1>
                <p class="letraAzulMedia" style="margin-top: 0px; margin-bottom: 0px">
                    Anda lá faz-me um Like!</p>
            </td>
        </tr>
        <tr>
            <td class="labelForm">
                <asp:Label ID="lblNome" runat="server" Text="Nome:"></asp:Label>
            </td>
            <td>
                <asp:TextBox CssClass="BoxForm" ID="txtNome" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNome" runat="server" ControlToValidate="txtNome"
                    ErrorMessage="Campo obrigatório" ForeColor="Red" ValidationGroup="grupo1">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="labelForm">
                <asp:Label ID="lblApelido" runat="server" Text="Apelido:"></asp:Label>
            </td>
            <td>
                <asp:TextBox CssClass="BoxForm" ID="TxtApelido" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rftApelido" runat="server" ControlToValidate="txtApelido"
                    ErrorMessage="Campo obrigatório" ForeColor="Red" ValidationGroup="grupo1">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="labelForm">
                <asp:Label ID="drlSexo" runat="server" Text="Sexo:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList CssClass="BoxForm" ID="ddSexo" runat="server" Width="105">
                    <asp:ListItem>Masculino</asp:ListItem>
                    <asp:ListItem>Feminino</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="labelForm">
                <asp:Label ID="lblpais" runat="server" Text="País:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList CssClass="BoxForm" ID="ddPais" runat="server" Width="105px" AutoPostBack="True"
                    DataSourceID="pais" DataTextField="pais" DataValueField="IdPais">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="labelForm">
                <asp:Label ID="Label1" runat="server" Text="Cidade:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList CssClass="BoxForm" ID="ddCidade" runat="server" Width="203px" DataSourceID="cidade"
                    DataTextField="cidade" DataValueField="idCidade">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="labelForm">
                <asp:Label ID="lblDataNascimento" runat="server" Text="Data Nascimento:"></asp:Label>
            </td>
            <td>
                <asp:TextBox CssClass="BoxForm" ID="txtDataNascimento" runat="server"></asp:TextBox>
                <asp:CalendarExtender ID="txtDataNascimento_CalendarExtender" runat="server" TargetControlID="txtDataNascimento">
                </asp:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="labelForm">
                <asp:Label ID="lblEmail" runat="server" Text="E-Mail:"></asp:Label>
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
            <td class="labelForm">
                <asp:Label ID="lblPass" runat="server" Text="Password:"></asp:Label>
            </td>
            <td>
                <asp:TextBox CssClass="BoxForm" ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvpass1" runat="server" ControlToValidate="txtPass"
                    ErrorMessage="Têm de preencher a Password" ForeColor="Red" ValidationGroup="grupo1">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revPass" runat="server"
                    ControlToValidate="txtPass" ErrorMessage="Password deve conter uma letra minuscula uma letra maiuscula e um número"
                    ValidationExpression="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{4,20}$" ForeColor="red" ValidationGroup="grupo1">*</asp:RegularExpressionValidator><br />
            
            </td>
        </tr>
        <tr>
            <td class="labelForm">
                <asp:Label ID="lblPassConf" runat="server" Text="Confirme Password:"></asp:Label>
            </td>
            <td>
                <asp:TextBox CssClass="BoxForm" ID="txtPassConf" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvpass2" runat="server" ControlToValidate="txtPassConf"
                    ErrorMessage="Têm que confirmar a Password" ForeColor="Red" ValidationGroup="grupo1">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="labelForm">
                <asp:Label ID="lblFoto" runat="server" Text="Foto:"></asp:Label>
            </td>
            <td>
                <asp:FileUpload ID="fupImagem" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="border-bottom-width: medium; border-bottom-style: solid;
                border-bottom-color: #a1afcb;" height="50" valign="middle">
                <p>
                    <asp:Button class="botaoRegisto" ID="btnRegisto" runat="server" ValidationGroup="grupo1"
                        Text="Regista-te" PostBackUrl="#" OnClick="btnRegisto_Click" /></p>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="right">
                
                <asp:Label ID="lblUserValidado" runat="server" CssClass="yellowError" 
                    Text="Label" Visible="False"></asp:Label>
                
                </td>
        </tr>
        <tr>
            <td colspan="3" align="right">
                <asp:CompareValidator CssClass="yellowError" ID="error1" runat="server"
                    ControlToCompare="txtPass" ControlToValidate="txtPassConf" ErrorMessage="Password diferentes!"
                    ForeColor="Red"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="right">
                <asp:ValidationSummary CssClass="yellowError" ID="ValidationSummary1" runat="server"
                    ForeColor="Red" ValidationGroup="grupo1" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
            </td>
        </tr>
    </table>
</asp:Content>
