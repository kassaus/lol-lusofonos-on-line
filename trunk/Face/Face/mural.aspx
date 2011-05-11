<%@ Page Title="" Language="C#" MasterPageFile="~/LayoutFace.master" AutoEventWireup="true"
    CodeBehind="mural.aspx.cs" Inherits="Face.mensagens" %>

<asp:Content ID="Content1" ContentPlaceHolderID="corpo" runat="server">
    <div class="corpoInterior">
        <table style="width: 100%;">
            <tr>
                <td>
                    <asp:Label ID="lblNome" runat="server" CssClass="letraAzulGrande"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPerfil" runat="server" CssClass="letraCinzentoPeq" Text="Label"></asp:Label>
                </td>
            </tr>
           
            <tr>
                <td>
                    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                        <asp:View ID="View1" runat="server">
                            <table style="width: 100%">
                                <tr>
                                    <td align="left" bgcolor="#3B5998">
                                    <span class="letraBrancoMedia">Partilhar:&nbsp;</span>
                                        <img align="middle" src="images/estado.png" alt="estado" height="20" />
                                        <asp:LinkButton ID="btnEstado" runat="server" OnClick="btnEstado_Click">Estado</asp:LinkButton>&nbsp;&nbsp;
                                        <img align="middle" src="images/fotos.png" alt="fotos" height="20" />
                                        <asp:LinkButton ID="btnFotos" runat="server" OnClick="btnFotos_Click">Fotos</asp:LinkButton>&nbsp;&nbsp;
                                        <img align="middle" src="images/videos.png" alt="videos" height="20" />
                                        <asp:LinkButton ID="btnVideos" runat="server" OnClick="btnVideos_Click">Videos</asp:LinkButton>
                                        </td>
                                </tr>
                            </table>
                        </asp:View>
                    </asp:MultiView>
                </td>
            </tr>
           
            <tr>
                <td>
                    <asp:MultiView ID="MultiView2" runat="server">
                        <asp:View ID="View2" runat="server">
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtMensagens" runat="server" Columns="80" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 0px">
                                        <asp:DropDownList ID="ddCategoriaMensagem" runat="server" 
                                            DataSourceID="SqlDataSource1" DataTextField="categoria" 
                                            DataValueField="idCategoria">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                                            SelectCommand="SELECT * FROM [Categorias]"></asp:SqlDataSource>
                                        <span style="margin-left: 100px"> <asp:Button ID="btnPartilhar" runat="server" CssClass="botaoRegisto" 
                                            onclick="btnPartilhar_Click" Text="Partilhar" />
                                            </span>

                                        <asp:Label ID="lblErroPartilhar" runat="server" CssClass="yellowError" 
                                            Text="Label" Visible="False"></asp:Label>

                                    </td>
                                </tr>
                            </table>
                            <br />
                        </asp:View>
                        <asp:View ID="View3" runat="server">
                            Fotos
                        </asp:View>
                        <asp:View ID="View4" runat="server">
                            Vídeos
                        </asp:View>
                    </asp:MultiView><br /><br />
                    <asp:MultiView ID="MultiView3" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View5" runat="server">
                        <asp:Table ID="Table1" runat="server">
                        </asp:Table>
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
           
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
           
        </table>
    </div>
</asp:Content>
