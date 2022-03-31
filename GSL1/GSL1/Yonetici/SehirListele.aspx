<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Yonetici.Master" AutoEventWireup="true" CodeBehind="SehirListele.aspx.cs" Inherits="GSL1.Yonetici.SehirListele" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/formDesign.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <div class="title">
      <h4>İl/İlçe</h4>
    </div>
    <div class=" formcontent contentable">
        <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisiz" Visible="false">
            <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
        </asp:Panel>
        <asp:ListView ID="lvi_sehirler" runat="server" OnItemCommand="lvi_sehirler_ItemCommand">
            <LayoutTemplate>
                <table class="liste" cellspacing="0" cellpadding="0">
                    <tr>                   
                        <th>ID</th>
                        <th>İsim</th>
                    </tr>
                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("ID") %></td>
                    <td><%# Eval("AD") %></td>
                    <td>
                        <a href='SehirGuncelle.aspx?sid=<%# Eval ("ID") %>' class="button update">Güncelle</a>
                        <asp:LinkButton ID="lbtn_sil" runat="server" CommandName="sil" CommandArgument='<%# Eval ("ID") %>' CssClass="button delete">Sil</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</div>
</asp:Content>
