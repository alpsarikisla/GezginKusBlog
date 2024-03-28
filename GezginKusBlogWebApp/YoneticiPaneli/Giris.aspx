<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Giris.aspx.cs" Inherits="GezginKusBlogWebApp.YoneticiPaneli.Giris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../assets/bootstrap-5.3.3/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .golge {
            -webkit-box-shadow: 0px 10px 15px -9px rgba(0,0,0,0.75);
            -moz-box-shadow: 0px 10px 15px -9px rgba(0,0,0,0.75);
            box-shadow: 0px 10px 15px -9px rgba(0,0,0,0.75);
        }
    </style>
</head>
<body style="background-color: #F5F5F5">
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row" style="margin-top: 300px">
                <div class="col-md-4"></div>
                <div class="col-md-4">
                    <div class="card golge">
                        <div class="card-body">
                            <div class="row">
                               <asp:panel ID="pnl_mesaj" runat="server" CssClass="col-12" Visible="false">
                                   <div class="alert alert-danger">
                                        <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
                                   </div>
                               </asp:panel>
                                <div class="col-md-5">
                                    <center>
                                        <img src="../assets/SayfaResimleri/slidebanklogin.gif" class="img-fluid" /></center>
                                </div>
                                <div class="col-md-7">
                                    <div class="mt-3">
                                        <asp:TextBox ID="tb_mail" runat="server" CssClass="form-control" placeholder="Mail Adresiniz"></asp:TextBox>
                                    </div>
                                    <div class="mt-3">
                                        <asp:TextBox ID="tb_sifre" runat="server" CssClass="form-control" TextMode="Password" placeholder="Şifreniz"></asp:TextBox>
                                    </div>
                                    <div class="mt-3">
                                        <div class="row">
                                            <div class="col-6 ">
                                                <label class="form-check-label mt-2" for="cb_hatirla">Beni Hatırla</label>
                                                <asp:CheckBox ID="cb_hatirla" runat="server" CssClass="form-check-inline" />
                                            </div>
                                            <div class="col-6">
                                                <a href="#" class="btn btn-link">Şifremi Unuttum</a>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <div class="mt-3 d-grid">
                                        <asp:Button ID="btn_giris" runat="server" Text="Giriş Yap" CssClass="btn btn-primary d-block" OnClick="btn_giris_Click" />
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
                <div class="col-md-4"></div>
            </div>
        </div>
    </form>
    <script src="../assets/bootstrap-5.3.3/js/bootstrap.bundle.js"></script>
</body>
</html>
