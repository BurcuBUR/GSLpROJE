<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Yonetici.Master" AutoEventWireup="true" CodeBehind="ProjeGuncelle.aspx.cs" Inherits="GSL1.Yonetici.ProjeGuncelle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/formDesign.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <div class="title">
        <h4>Proje Güncelle</h4>
    </div>
    <div class="formcontent">
        <asp:Panel ID="pnl_basarili" runat="server" CssClass="basarili" Visible="false">
            <label>Güncelleme İşlemi Başarılı!</label>
        </asp:Panel>
        <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisiz" Visible="false">
            <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
        </asp:Panel>
            <div class="row">
            <label>Proje Başlık</label><br />
            <asp:TextBox ID="tb_baslik" runat="server" CssClass="forminput"></asp:TextBox>
        </div>
        <div class="row">
            <label>Şehirler</label>
            <asp:DropDownList ID="ddl_sehirler" runat="server" CssClass="forminput" DataTextField="AD"  DataValueField="ID"></asp:DropDownList>
        </div>
        <div class="row">
            <label>Okul</label><br />
            <asp:DropDownList ID="ddl_okullar" runat="server" CssClass="forminput" DataTextField="isim" DataValueField="ID"></asp:DropDownList>
        </div>
        <div class="row">
            <label>Kategori</label><br />
            <asp:DropDownList ID="ddl_kategoriler" runat="server" CssClass="forminput" DataTextField="Isim" DataValueField="ID"></asp:DropDownList>
        </div>
        <div class="row">
            <label>Kapak Resim</label><br /><br />
            <asp:Image ID="img_resim" runat="server" Width="500" /><br />
            Seçiniz : <asp:FileUpload ID="fu_resim" runat="server" />
        </div>
        <div class="row">
            <label>Özet</label><br />
            <asp:TextBox ID="tb_ozet" runat="server" CssClass="forminput" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div class="row">
            <label>Başlangıç Tarihi:</label>
            <asp:TextBox ID="tb_baslangic" runat="server" CssClass="forminput"></asp:TextBox>
        </div>
        <div class="row">
            <label>Bitiş Tarihi:</label>
            <asp:TextBox ID="tb_bitis" runat="server" CssClass="forminput"></asp:TextBox>
        </div>
        <div class="row">
            <label>Katılım Şartları</label><br />
            <asp:TextBox ID="tb_sartlar" runat="server" CssClass="forminput" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div class="row">
            <label>İçerik</label><br />
            <asp:TextBox ID="tb_icerik" runat="server" CssClass="forminput" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div class="row">
            <label>Katılımcılar</label><br />
            <asp:TextBox ID="tb_katilimci" runat="server" CssClass="forminput" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div class="row">
            <label>İletişim:</label>
            <asp:TextBox ID="tb_iletisim" runat="server" CssClass="forminput" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div class="row">
            <label>Yayınla</label><br />
            <asp:CheckBox ID="cb_yayinla" runat="server" />
        </div>
        <div class="row" style="clear:both">
            <asp:LinkButton ID="lbtn_update" runat="server" OnClick="lbtn_update_Click" CssClass="button">Güncelle</asp:LinkButton> 
        </div>
    </div>
</div>
</asp:Content>
