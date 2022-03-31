<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProjeEkle.aspx.cs" Inherits="GSL1.ProjeEkle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/formStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Container">
        <div class="title">
            <h3>Proje Ekle Ekle</h3>
        </div>
        <div class="formcontent">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="basarilipanel" Visible="false">
                <label>Proje Ekleme İşlemi Başarılı!</label>
            </asp:Panel>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizpanel" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <div style="width:650px; float:left">  
                <div class="row">
                    <div class="row">
                    <label>Şehir</label>
                    <asp:DropDownList ID="ddl_sehirler" runat="server" CssClass="forminput" DataTextField="AD" DataValueField="ID"></asp:DropDownList>
                </div>
                    <label>Okul</label>
                    <asp:DropDownList ID="ddl_okullar" runat="server" CssClass="forminput" DataTextField="isim" DataValueField="ID"></asp:DropDownList>
                </div>
                    <div class="row">
                        <label>Bölüm</label>
                        <asp:DropDownList ID="ddl_bolumler" runat="server" CssClass="forminput" DataTextField="isim" DataValueField="ID"></asp:DropDownList>
                    </div>       
                 <div class="row">
                    <label>Kategori</label><br />
                    <asp:DropDownList ID="ddl_kategoriler" runat="server" CssClass="forminput" DataTextField="Isim" DataValueField="ID"></asp:DropDownList>
                </div>
                <div class="row">
                    <label>Proje Başlık</label><br />
                    <asp:TextBox ID="tb_baslik" runat="server" CssClass="forminput"></asp:TextBox>
                </div>
                <div class="row">
                    <label>Şartlar</label>
                    <asp:TextBox ID="tb_sartlar" runat="server" CssClass="forminput"></asp:TextBox>
                </div>
                <div class="row">
                    <label>Katılımcılar</label>
                    <asp:TextBox ID="tb_katiimcilar" runat="server" CssClass="forminput"></asp:TextBox>
                </div>
                <div class="row">
                    <asp:TextBox ID="tb_bat" runat="server" CssClass="forminput" placeholder="Başlangıç Tarihi" ></asp:TextBox>
                </div>
                <div class="row">
                    <asp:TextBox ID="tb_bit" runat="server" CssClass="forminput" placeholder="Bitiş Tarihi"></asp:TextBox>
                </div>
                <div class="row">
                    <label>İletişim İçin:</label>
                    <asp:TextBox ID="tb_iletisim" runat="server" CssClass="forminput"></asp:TextBox>
                </div>
                <div class="row">
                    <label>Kapak Resim</label><br /><br />
                    Seçç : <asp:FileUpload ID="fu_resim" runat="server" />
                </div>
                <div class="row">
                    <label>Projeyi Yayınla</label> 
                    <asp:CheckBox ID="cb_yayinla" runat="server"/>
                </div>
            </div>
            <div style="width:650px; float:left">
                <div class="row">
                    <label>Özet</label><br />
                    <asp:TextBox ID="tb_ozet" runat="server" CssClass="formInput" TextMode="MultiLine"></asp:TextBox>
                </div>
                <div class="row">
                    <label>İçerik</label><br />
                    <asp:TextBox ID="tb_icerik" runat="server" CssClass="formInput" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <div class="row" style="clear:both">
                <asp:LinkButton ID="lbtn_ekle" runat="server"  OnClick="lbtn_ekle_Click" CssClass="formButton">Makale Ekle</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
