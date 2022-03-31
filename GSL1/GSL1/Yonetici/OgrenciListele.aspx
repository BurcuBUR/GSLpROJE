﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Yonetici.Master" AutoEventWireup="true" CodeBehind="OgrenciListele.aspx.cs" Inherits="GSL1.Yonetici.OgrenciListele" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/formDesign.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <div class="title">
      <h4>Öğrenciler</h4>
    </div>
    <div class=" formcontent contentable">
        <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisiz" Visible="false">
            <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
        </asp:Panel>
        <asp:ListView ID="lvi_ogrenciler" runat="server" OnItemCommand="lvi_ogrenciler_ItemCommand">
            <LayoutTemplate>
                <table class="liste" cellspacing="0" cellpadding="0">
                    <tr>
                    
                        <th>ID</th>
                        <th>KategoriID</th>
                        <th>BölümID</th>                  
                        <th>OkulID</th>
                        <th>İsim</th>
                        <th>Soyisim</th>
                        <th>Nick</th>
                        <th>Üyelik Tarihi</th>
                        <th>Durum</th>
                    </tr>
                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("ID") %></td>
                    <td><%# Eval("KategoriID") %></td>
                    <td><%# Eval("BolumID") %></td>
                    <td><%# Eval("OkulID") %></td>
                    <td><%# Eval("ad") %></td>
                    <td><%# Eval("soyad") %></td>
                    <td><%# Eval("nickname") %></td>
                    <td><%# Eval("uyelikTarihi") %></td>
                    <td><%# Eval("Durum") %></td>
                    <td>
                        <asp:LinkButton ID="lbtn_durumdegistir" runat="server" CommandName="durum" CommandArgument='<%# Eval("ID") %>' CssClass="button status">Durum Değiştir</asp:LinkButton>
                        
                        <asp:LinkButton ID="lbtn_sil" runat="server" CommandName="sil" CommandArgument='<%# Eval ("ID") %>' CssClass="button delete">Sil</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>

</div>
</asp:Content>
