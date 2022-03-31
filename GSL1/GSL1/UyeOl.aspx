<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UyeOl.aspx.cs" Inherits="GSL1.UyeOl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <link href="css/formStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div >
          <div class="formtitle">
              <h2>Öğrenci Kayıt</h2>
          </div>
          <div >
               <asp:Panel ID="pnl_basarili" runat="server" CssClass="basarilipanel" Visible="false">
                <label>Kayıt İşlemi Başarılı, HOŞGELDİNİZ</label>
            </asp:Panel>
             <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizpanel" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
              <div>
                  <label>İsim</label><br />
                  <asp:TextBox ID="tb_ad" runat="server" CssClass="textbox"></asp:TextBox>
              </div>
              <div>
                  <label>Soyisim</label><br />
                  <asp:TextBox ID="tb_soyad" runat="server" CssClass="textbox"></asp:TextBox>
              </div>
              <div>
                  <label>Kullanıcı Adı</label><br />
                  <asp:TextBox ID="tb_nick" runat="server" CssClass="textbox"></asp:TextBox>
              </div>
              <div>
                  <label>Okul</label><br />
                  <asp:DropDownList ID="ddl_okullar" runat="server" CssClass="forminput" DataTextField="isim" DataValueField="ID"></asp:DropDownList>
              </div>
              <div>
                  <label>Bölüm</label><br />
                  <asp:DropDownList ID="ddl_bolumler" runat="server" CssClass="forminput" DataTextField="isim" DataValueField="ID"></asp:DropDownList>
              </div>
                <div>
                    <label>Mail</label><br />
                    <asp:TextBox ID="tb_mail" runat="server" CssClass="textbox" ></asp:TextBox>
                </div>
                <div>
                    <label>Şifre</label><br />
                    <asp:TextBox ID="tb_sifre" runat="server" TextMode="Password" CssClass="textbox"></asp:TextBox>
                </div>
                <div>
                    <asp:Button ID="btn_kayit" runat="server" Text="Kayıt Ol" CssClass="formbutton" OnClick="btn_kayit_Click"/>
                </div>
              </div>
         </div>
</asp:Content>
