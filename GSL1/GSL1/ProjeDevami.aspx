<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProjeDevami.aspx.cs" Inherits="GSL1.ProjeDevami" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/main.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="proje">
        <div class="baslik">
            <h2><asp:Literal  ID="ltrl_baslik" runat="server"></asp:Literal></h2>
        </div>
        <div class="image"> 
            <asp:Image  ID="img_resim" runat="server" />
        </div>
    <div class="subcontent">
        Şehir :<asp:Literal ID="ltrl_sehir" runat="server"></asp:Literal>
        | Okul: <asp:Literal ID="ltrl_okul" runat="server"></asp:Literal>
        | Bolum: <asp:Literal ID="ltrl_bolum" runat="server"></asp:Literal>
        | Kategori: <asp:Literal ID="ltrl_kategori" runat="server"></asp:Literal>      
        | Hazırlayan Öğrenci: <asp:Literal ID="ltrl_ogrenci" runat="server">l</asp:Literal>
    </div>
    <div class="content">
        <asp:Literal ID="ltrl_icerik" runat="server"></asp:Literal>
    </div>
    <div class="subcontent">
        Katılım Şartları: <asp:Literal ID="ltrl_sart" runat="server"></asp:Literal>
        | Katılımcılar: <asp:Literal ID="ltrl_katılımcı" runat="server"></asp:Literal>
        | İletişim: <asp:Literal ID="ltrl_iletisim" runat="server"></asp:Literal>
    </div>
        </div>

    <div style="min-height: 400px;">
        <div class="yorum" style="margin-top:50px;">
            <div class="yorumbaslik"><h2>Yorumlar</h2></div>
            <asp:Panel ID="pnl_girisVar" runat="server" Visible="false">
                <br /><br />
                <h3>Yorumunuzu Yazınız</h3>
                <asp:TextBox ID="tb_yorum" TextMode="MultiLine" runat="server" CssClass="yorumkutu"></asp:TextBox>
                <br /><br /><br />
                <asp:LinkButton ID="lbtn_yorumYap" runat="server" Text="Yorum Yap" OnClick="lbtn_yorumYap_Click" CssClass="yorumyapbutton"></asp:LinkButton>
            </asp:Panel>
            <asp:Panel ID="pnl_girisyok" runat="server" style="margin:20px 0;">
                <h2>Yorum yapabilmek için lütfen <a href="uyeGiris.aspx">giriş yapınız </a></h2>
            </asp:Panel>
            <asp:Repeater ID="rp_yorumlar" runat="server">
                <ItemTemplate>
                    <div class="yorumitem">
                        <label><%# Eval("Uye") %></label> | <label><%# Eval("YorumTarih") %></label>
                        <br />
                        <p><%# Eval("Icerik") %></p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
       </div>
    </div>
</asp:Content>
