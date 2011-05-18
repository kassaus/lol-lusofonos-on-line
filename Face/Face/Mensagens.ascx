<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Mensagens.ascx.cs" Inherits="Face.Mensagens" %>
<table style="width:100%;">
    <tr>
        <td>
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <asp:Image ID="Image1" runat="server" />
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                </asp:View>
                <asp:View ID="View2" runat="server">
                </asp:View>
                <asp:View ID="View3" runat="server">
                </asp:View>
                <asp:View ID="View4" runat="server">
                </asp:View>
            </asp:MultiView>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>
</table>

