<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Yonetici.Master" AutoEventWireup="true" CodeBehind="OkulListele.aspx.cs" Inherits="GSL1.Yonetici.OkulListele" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/formDesign.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="title">
      <h4>Okullar</h4>
    </div>
    <div class=" formcontent contentable">
        <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisiz" Visible="false">
            <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
        </asp:Panel>
        <asp:ListView ID="lvi_okullar" runat="server" OnItemCommand="lvi_okullar_ItemCommand">
            <LayoutTemplate>
                <table class="liste" cellspacing="0" cellpadding="0">
                    <tr>
                    
                        <th>ID</th>
                        <th>İsim</th>
                        <th>BölümID</th>                  
                        <th>ŞehirID</th>
                    
                    </tr>
                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("ID") %></td>
                    <td><%# Eval("isim") %></td>
                    <td><%# Eval("BolumID") %></td>
                    <td><%# Eval("SehirID") %></td>
                    <td>
                        <a href='OkulGuncelle.aspx?oid=<%# Eval ("ID") %>' class="button update">Güncelle</a>
                        <asp:LinkButton ID="lbtn_sil" runat="server" CommandName="sil" CommandArgument='<%# Eval ("ID") %>' CssClass="button delete">Sil</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>

</div>
</asp:Content>
