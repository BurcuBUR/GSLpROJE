<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Yonetici.Master" AutoEventWireup="true" CodeBehind="OkulGuncelle.aspx.cs" Inherits="GSL1.Yonetici.OkulGuncelle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/formDesign.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="title">
        <h4>Okul Güncelle</h4>
    </div>
    <div class="formcontent">
        <asp:Panel ID="pnl_basarili" runat="server" CssClass="basarili" Visible="false">
            <label>Güncelleme İşlemi Başarılı!</label>
        </asp:Panel>
        <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisiz" Visible="false">
            <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
        </asp:Panel>
        <div class="row">
            <label>Okul No</label><br />
            <asp:TextBox ID="tb_ID" runat="server" CssClass="forminput"></asp:TextBox>
        </div>
        <div class="row">
            <label>Okul Adı</label><br />
            <asp:TextBox ID="tb_ad" runat="server" CssClass="forminput"></asp:TextBox>
        </div>
        <div class="row">
            <label>Şehir</label><br />
            <asp:TextBox ID="tb_sehir" runat="server" CssClass="forminput"></asp:TextBox>
        </div>
        <div class="row">
            <asp:LinkButton ID="lbtn_update" runat="server" OnClick="lbtn_update_Click" CssClass="button">Güncelle</asp:LinkButton> 
        </div>
    </div>
</div>
</asp:Content>
