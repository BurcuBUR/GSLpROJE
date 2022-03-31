<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profil.aspx.cs" Inherits="GSL1.Profil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Profilim</title>
    <link href="css/userLayout.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>           
         <div class="menuBar">
        
             <div class="user" style="float:left;">
                 <div>
                     <img style="width:170px" src="Images/GSL.png" />
                 </div>        
                     <asp:LinkButton ID="lbtn_degistir" runat="server"  OnClick="lbtn_degistir_Click">Kullanıcı Değiştir</asp:LinkButton> | <asp:LinkButton ID="lbtn_cikis" runat="server" OnClick="lbtn_cikis_Click">Çıkış Yap</asp:LinkButton> </label>          
              </div>
             </div>
        
            <div>
                <div class="solMenu">
                    <div class="">
                        <asp:Label ID="lbl_kullanici" runat="server"></asp:Label> 
                    </div>
                    <ul class="menu">
                        <a href="Default.aspx">
                             <li>Anasayfa</li>
                        </a>

                          <a href="Projelerim.aspx">
                            <li>Projelerim</li>
                        </a>

                        <a href="ProjeEkle.aspx">
                            <li>Proje Ekle</li>
                        </a>
                    </ul>
                </div>
   
             </div>        
        </div>
    </form>
</body>
</html>
