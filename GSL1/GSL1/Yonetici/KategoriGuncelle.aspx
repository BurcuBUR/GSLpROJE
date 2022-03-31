<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Yonetici.Master" AutoEventWireup="true" CodeBehind="KategoriGuncelle.aspx.cs" Inherits="GSL1.Yonetici.KategoriGuncelle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/formDesign.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <div class="title">
        <h4>Kategorileri Güncelle</h4>
    </div>
    <div class="formcontent">
        <asp:Panel ID="pnl_basarili" runat="server" CssClass="basarili" Visible="false">
            <label>Kategori Güncelleme İşlemi Başarılı!</label>
        </asp:Panel>
        <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisiz" Visible="false">
            <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
        </asp:Panel>
        <div class="row">
            <label>Kategori No</label><br />
            <asp:TextBox ID="tb_ID" runat="server" CssClass="forminput"></asp:TextBox>
        </div>
        <div class="row">
            <label>Bölüm No</label><br />
            <asp:TextBox ID="tb_bolumıd" runat="server" CssClass="forminput"></asp:TextBox>
        </div>
        <div class="row">
            <label>Kategori Adı</label><br />
            <asp:TextBox ID="tb_ad" runat="server" CssClass="forminput"></asp:TextBox>
        </div>
        <div class="row">
            <asp:LinkButton ID="lbtn_update" runat="server" OnClick="lbtn_update_Click" CssClass="button">Güncelle</asp:LinkButton> 
        </div>
    </div>
</div>
</asp:Content>
