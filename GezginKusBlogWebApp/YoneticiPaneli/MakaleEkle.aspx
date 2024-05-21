<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPaneli/YoneticiPanel.Master" AutoEventWireup="true" CodeBehind="MakaleEkle.aspx.cs" Inherits="GezginKusBlogWebApp.YoneticiPaneli.MakaleEkle" %>

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
                    <h3 class="card-title">Makale Ekle</h3>
                </div>
                <div class="card-body">
                    <asp:Panel ID="pnl_basarili" runat="server" CssClass="alert alert-success" Visible="false">
                        Makale Ekleme <strong> Başarılı </strong>
                    </asp:Panel>
                    <asp:Panel ID="pnl_basaririz" runat="server" CssClass="alert alert-danger" Visible="false">
                        <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
                    </asp:Panel>
                    <div class="row">
                        <div class="col-md-5">
                            <div class="mb-3">
                                <label class="form-label">Kategori Seçiniz</label>
                                <asp:DropDownList ID="ddl_kategoriler" runat="server" CssClass="form-select"></asp:DropDownList>
                            </div>
                            <div class="mb-3">
                                <label class="form-label">Makale Başlığı</label>
                                <asp:TextBox ID="tb_baslik" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <label class="form-label">Makale Kapak Resmi</label>
                                <asp:FileUpload ID="fu_resim" runat="server" CssClass="form-control" />
                            </div>
                            <div class="mb-3">
                                <asp:CheckBox ID="cb_durum" runat="server" />
                                <label for="ContentPlaceHolder1_cb_durum">Aktif Makale<small>(İşaterlenirse Makale Yayınlanır)</small></label>
                            </div>
                        </div>
                        <div class="col-md-7">
                            <div class="mb-3">
                                <label class="form-label">Makale Özeti</label>
                                <asp:TextBox ID="tb_ozet" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <label class="form-label">Makale İçerik</label>
                                <asp:TextBox ID="tb_icerik" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card-footer">
                    <asp:LinkButton ID="lbtn_makaleEkle" runat="server" CssClass="btn btn-primary" OnClick="lbtn_makaleEkle_Click">Makale Ekle</asp:LinkButton>
                    <a href="MakaleListele.aspx" class="btn btn-link">Makaleler Listesine Git</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
