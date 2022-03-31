<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="uyeGiris.aspx.cs" Inherits="GSL1.uyeGiris" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/formStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="formtitle">
    <h4>Üye Girişş</h4>
</div>
    <div class="girisform form">
        <div class="row" style="text-align:center">
            <img src="Images/295128.png"  style="width:120px;"/>
        </div>
       <asp:panel ID="pnl_basarisiz" runat="server" CssClass="basarisizpanel" Visible="false">
            <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
        </asp:panel>
        <div class="row">
            <asp:TextBox ID="tb_mail" runat="server" CssClass="textbox"  placeholder="Mailinizi Girinn"></asp:TextBox>
        </div>
        <div class="row">
            <asp:TextBox ID="tb_sifre" runat="server" CssClass="textbox" placeholder="Şifrenizi Girinn"></asp:TextBox>
        </div>
        <div class="row" style="text-align:center">
            <asp:LinkButton ID="lbtn_giris" runat="server" Text="Giriş Yap" OnClick="lbtn_giris_Click" CssClass="formbutton"></asp:LinkButton>
        </div>
    </div>
</asp:Content>
