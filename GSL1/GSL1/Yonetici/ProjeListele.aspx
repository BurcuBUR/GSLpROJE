<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Yonetici.Master" AutoEventWireup="true" CodeBehind="ProjeListele.aspx.cs" Inherits="GSL1.Yonetici.ProjeListele" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/formDesign.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <div class="title">
      <h4>Projeler</h4>
    </div>
    <div class=" formcontent contentable">
        <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisiz" Visible="false">
            <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
        </asp:Panel>
        <asp:ListView ID="lvi_projeler" runat="server"  OnItemCommand="lvi_projeler_ItemCommand">
            <LayoutTemplate>
                <table class="liste" cellspacing="0" cellpadding="0">
                    <tr>
                    
                        <th>Resim</th>
                        <th>ID</th>
                        <th>Şehir</th>
                        <th>Bölüm</th>    
                        <th>Okul</th>
                        <th>Kategori</th>
                        <th>Yazar</th>
                        <th>Başlık</th>
                        <th>Başlangıç Tarihi</th>
                        <th>Bitiş Tarihi</th>
                        <th>Katılımcılar</th>
                        <th>İletişiim</th>
                        <th>Görüntülenme Sayısı</th>
                        <th>Durum</th>
                    
                    </tr>
                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><img src='../ProjeResimleri/<%# Eval("KapakResim") %>' width="100"/></td>
                    <td><%# Eval("ID") %></td>
                    <td><%# Eval("Sehir") %></td>
                    <td><%# Eval("Bolum") %></td>
                    <td><%# Eval("Okul") %></td>
                    <td><%# Eval("Kategori") %></td>
                    <td><%# Eval("Yazar") %></td>
                    <td><%# Eval("Baslik") %></td>
                    <td><%# Eval("BaTarih") %></td>
                    <td><%# Eval("BiTarih") %></td>
                    <td><%# Eval("Katılımcılar") %></td>
                    <td><%# Eval("iletişim") %></td>
                    <td><%# Eval("GoruntulenmeSayısı") %></td>
                    <td><%# Eval("Durum") %></td>
                    <td>
                        <asp:LinkButton ID="lbtn_durumdegistir" runat="server" CommandName="durum" CommandArgument='<%# Eval("ID") %>' CssClass="button durum">Durum Değiştir</asp:LinkButton>
                        <a href='ProjeGuncelle.aspx?pid=<%# Eval ("ID") %>' class="button update">Güncelle</a>
                        <asp:LinkButton ID="lbtn_sil" runat="server" CommandName="sil" CommandArgument='<%# Eval ("ID") %>' CssClass="button delete">Sil</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>

</div>
</asp:Content>
