<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPaneli/YoneticiPanel.Master" AutoEventWireup="true" CodeBehind="MakaleListele.aspx.cs" Inherits="GezginKusBlogWebApp.YoneticiPaneli.MakaleListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
        <h1 class="h2">Makale İşlemleri </h1>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header">
                    <h3 class="card-title">Makale Listesi</h3>
                </div>
                <asp:ListView ID="lv_makaleler" runat="server">
                    <LayoutTemplate>
                        <table class="table table-bordered table-striped">
                            <thead>
                                <tr>
                                    <th>Resim</th>
                                    <th>ID</th>
                                    <th>Başlık</th>
                                    <th>Kategori</th>
                                    <th>Yazar</th>
                                    <th>Ekleme Tarihi</th>
                                    <th>Beğeni</th>
                                    <th>Görüntüleme</th>
                                    <th>Durum</th>
                                    <th>Seçenekler</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                            </tbody>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <img src='../assets/MakaleResimleri/<%# Eval("KapakResim") %>' class="img-thumbnail"style="height:40px;" /></td>
                            <td><%# Eval("ID") %></td>
                            <td><%# Eval("Baslik") %></td>
                            <td><%# Eval("Kategori") %></td>
                            <td><%# Eval("Yazar") %></td>
                            <td><%# Eval("EklemeTarihiStr") %></td>
                            <td><%# Eval("BegeniSayi") %></td>
                            <td><%# Eval("GoruntulemeSayi") %></td>
                            <td><%# Eval("Durum") %></td>
                            <td>
                                <a href='MakaleGuncelle.aspx?MakaleID=<%# Eval("ID") %>' class="btn btn-sm btn-primary"><i class="fa fa-edit"></i></a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
                <div class="card-footer">
                    <asp:Label ID="lbl_sayi" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
