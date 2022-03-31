<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GSL1.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/main.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView ID="lv_projeler" runat="server">
        <LayoutTemplate>
            <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="proje">
                <div class="baslik">
                    <h2><%# Eval("Baslik") %></h2>
                </div>
                <div class="image">
                    <img src='Images/<%# Eval("KapakResim") %>' />
                </div>
                <div class="subcontent">
                    Okul: <%# Eval("Okul") %> -- Bölüm: <%# Eval("Bolum") %>-- Kategori: <%# Eval("Kategori") %> -- Öğrenci: <%# Eval("Ogrenci") %>
                </div>
                <div class="summary">
                    <%# Eval("Ozet") %>
                </div>
                <div class="bilgi">
                 Eklenme Tarihi:<%# Eval("EklemeTarihi") %>
                </div>
                <div class="button">
                    <a href="ProjeDevami.aspx?pid=<%# Eval("ID") %>">Proje için..</a>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>    
</asp:Content>

