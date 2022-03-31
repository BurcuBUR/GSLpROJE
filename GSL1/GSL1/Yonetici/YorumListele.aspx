<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Yonetici.Master" AutoEventWireup="true" CodeBehind="YorumListele.aspx.cs" Inherits="GSL1.Yonetici.YorumListele" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/formDesign.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <div class="title">
      <h4>Yorumlar</h4>
    </div>
    <div class=" formcontent contentable">
        <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisiz" Visible="false">
            <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
        </asp:Panel>
        <asp:ListView ID="lvi_yorumlar" runat="server"  OnItemCommand="lvi_yorumlar_ItemCommand">
            <LayoutTemplate>
                <table class="liste" cellspacing="0" cellpadding="0">
                    <tr>
                    
                        <th>ID</th>
                        <th>Öğrenci İsim</th>
                        <th>Proje İsim</th>                  
                        <th>Yorum:</th>
                        <th>Durum</th>
                    </tr>
                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("ID") %></td>
                    <td><%# Eval("Ogrenci") %></td>
                    <td><%# Eval("Proje") %></td>
                    <td><%# Eval("YorumTarih") %></td>
                    <td><%# Eval("OnayDurum") %></td>
                    <td>
                        <asp:LinkButton ID="lbtn_durumdegistir" runat="server" CommandName="durum" CommandArgument='<%# Eval("ID")%>' CssClass="button durum">Durum Değiştir</asp:LinkButton>
                        <asp:LinkButton ID="lbtn_sil" runat="server" CommandName="sil" CommandArgument='<%# Eval ("ID") %>' CssClass="button delete">Sil</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>

</div>
</asp:Content>
