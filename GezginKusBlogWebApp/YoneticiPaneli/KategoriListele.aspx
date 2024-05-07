<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPaneli/YoneticiPanel.Master" AutoEventWireup="true" CodeBehind="KategoriListele.aspx.cs" Inherits="GezginKusBlogWebApp.YoneticiPaneli.KategoriListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
        <h1 class="h2">Kategori İşlemleri </h1>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header">
                    <h3 class="card-title">Kategori Listesi</h3>
                </div>
                <asp:ListView ID="lv_Kategoriler" runat="server" OnItemCommand="lv_Kategoriler_ItemCommand">
                    <LayoutTemplate>
                        <table class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>Isim</th>
                                    <th>Açıklama</th>
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
                            <td><%# Eval("ID") %></td>
                            <td><%# Eval("Isim") %></td>
                            <td><%# Eval("Aciklama") %></td>
                            <td><%# Eval("Durum") %></td>
                            <td>
                                <asp:LinkButton ID="lbtn_durumdegistir" runat="server" CssClass="btn btn-success btn-sm" CommandArgument='<%# Eval("ID") %>' CommandName="durumdegistir"><i class="fa fa-recycle"></i></asp:LinkButton>

                                <a href="KategoriDuzenle.aspx" class="btn btn-sm btn-primary"><i class="fa fa-edit"></i></a>

                                <asp:LinkButton ID="lbtn_sil" runat="server" CssClass="btn btn-danger btn-sm" CommandArgument='<%# Eval("ID") %>' CommandName="sil"><i class="fa fa-trash" ></i></asp:LinkButton>
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
