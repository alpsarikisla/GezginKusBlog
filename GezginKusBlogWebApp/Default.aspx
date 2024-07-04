<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GezginKusBlogWebApp.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="rp_makaleler" runat="server">
        <ItemTemplate>
            <article class="blog-post">
                <img src='assets/MakaleResimleri/<%# Eval("KapakResim") %>' class="img-thumbnail" />
                <h2 class="display-5 link-body-emphasis mb-1"><%# Eval("Baslik") %></h2>
                <p class="blog-post-meta">
                    Tarih: <%# Eval("EklemeTarihiStr") %> | 
                    Yazar: <a href="#"> <%# Eval("Yazar") %></a> | 
                    Kategori: <a href="#"> <%# Eval("Kategori") %></a>
                </p>
                <div>
                    <%# Eval("Ozet") %>
                </div>
                <a href='MakaleDetay.aspx?makaleID=<%# Eval("ID") %>'>Yazının Devamı...</a>
            </article>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
