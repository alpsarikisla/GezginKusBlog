<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPaneli/YoneticiPanel.Master" AutoEventWireup="true" CodeBehind="KategoriGuncelle.aspx.cs" Inherits="GezginKusBlogWebApp.YoneticiPaneli.KategoriGuncelle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-check-input input{
            margin-top:-5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
        <h1 class="h2">Kategori İşlemleri </h1>
    </div>
    <div class="row">
        <div class="col-12">
            <div class="card">
                <div class="card-header">
                    <h3 class="card-title">Kategori Düzenle</h3>
                </div>
                <div class="card-body">
                    <asp:Panel ID="pnl_basarili" runat="server" CssClass="alert alert-success" Visible="false">
                        Kategori Düzenleme <strong>Başarılı</strong>
                    </asp:Panel>
                    <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="alert alert-danger" Visible="false">
                        <asp:Label ID="lbl_basarisiz" runat="server"></asp:Label>
                    </asp:Panel>
                    <div class="mb-3">
                        <label class="form-label">Kategori Adı</label>
                        <asp:TextBox ID="tb_isim" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Açıklama</label>
                        <asp:TextBox ID="tb_aciklama" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <asp:CheckBox ID="cb_durum" runat="server"/>
                        <label for="ContentPlaceHolder1_cb_durum">Aktif Kategori<small>(İşaterlenirse Kategori Yayınlanır)</small></label>
                    </div>
                </div>
                <div class="card-footer">
                   
                    <asp:LinkButton ID="lbtn_guncelle" runat="server" CssClass="btn btn-primary" OnClick="lbtn_guncelle_Click">Kategori Düzenle</asp:LinkButton>
                    <a href="KategoriListele.aspx" class="btn-link m-2">Kategoriler Listesine Dön</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

