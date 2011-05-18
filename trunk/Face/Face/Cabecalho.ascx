<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Cabecalho.ascx.cs" Inherits="Face.Cabecalho" %>
<table style="width:100%;">
    <tr>
        <td>
            Escolha a opcao:<asp:ImageButton ID="ImageButton1" runat="server" 
                onclick="ImageButton1_Click" />
            Mensagem&nbsp;&nbsp;
            <asp:ImageButton ID="ImageButton2" runat="server" onclick="ImageButton2_Click" 
                Width="16px" />
            Foto&nbsp;&nbsp;
            <asp:ImageButton ID="ImageButton3" runat="server" onclick="ImageButton3_Click" 
                style="width: 14px" />
            Imagem&nbsp;
            <asp:ImageButton ID="ImageButton4" runat="server" 
                onclick="ImageButton4_Click" />
            Url</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                </asp:View>
                <asp:View ID="View2" runat="server">
                    2<table style="width:100%;">
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                                <asp:Button ID="Button1" runat="server" Text="Button" />
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View3" runat="server">
                    3
                </asp:View>
                <asp:View ID="View4" runat="server">
                    4
                </asp:View>
            </asp:MultiView>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
<p>
&nbsp;</p>

