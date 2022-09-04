<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="frmMaterias.aspx.cs" Inherits="InterfazWeb.frmMaterias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="card-header text-center">
            <h1>Mantenimiento de materias</h1>
        </div>
        <%if (Session["_mensaje"] != null)
            { %>
               <div class="alert alert-warning alert-dismissible fade show mt-3" role="alert">
                   <%=Session["_mensaje"]%>
                    <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
               </div> 
        <% 
                //Session["_mensaje"] = null;
            } %>
        <br />

        <div class="mb-3">
            <asp:Label ID="lblCode" runat="server" Text="Código:" 
                CssClass="form-label">
                <asp:RequiredFieldValidator ID="rfvTxtCode" runat="server" ErrorMessage="El código es obligatorio"
                    ControlToValidate="txtCode"
                    Text="*"
                    ValidationGroup="1" Font-Italic="True" ForeColor="#FF5050"></asp:RequiredFieldValidator>

            </asp:Label>
            <asp:TextBox ID="txtCode" runat="server" MaxLength="6"
                CssClass="form-control"></asp:TextBox>
        </div>
        <div class="mb-3">
            <asp:Label ID="lblNombre" runat="server" Text="Nombre:" 
                CssClass="form-label">
                <asp:RequiredFieldValidator ID="rfvtxtnombre" runat="server" ErrorMessage="El nombre es obligatorio"
                    ControlToValidate="txtnombre"
                    Text="*"
                    ValidationGroup="1" Font-Italic="True" ForeColor="#FF5050"></asp:RequiredFieldValidator>
            </asp:Label>
            <asp:TextBox ID="txtNombre" AutoCompleteType="Disabled" runat="server"
                CssClass="form-control" MaxLength="99"></asp:TextBox>
        </div>
        <div class="mb-3">
            <asp:Label ID="lblCredits" runat="server" Text="Créditos:" 
                CssClass="form-label">
                <asp:RequiredFieldValidator ID="rfvtxtCredits" runat="server" ErrorMessage="Los créditos son obligatorios"
                    ControlToValidate="txtCredits"
                    Text="*"
                    ValidationGroup="1" Font-Italic="True" ForeColor="#FF5050"></asp:RequiredFieldValidator>

            </asp:Label>
            <asp:TextBox ID="txtCredits" AutoCompleteType="Disabled" runat="server"
                CssClass="form-control" TextMode="Number" MaxLength="2"></asp:TextBox>
        </div>
        <!--<div class="mb-3">
            <asp:Label ID="lbldireccion" runat="server" Text="Dirección" 
                CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtdireccion" AutoCompleteType="Disabled" runat="server"
                CssClass="form-control" MaxLength="80"></asp:TextBox>
        </div>-->
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" ValidationGroup="1" OnClick="btnGuardar_Click"/>
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCancelar_Click"/>
        <br />
        <asp:ValidationSummary ID="vsResumen" runat="server" CssClass="mt-3" 
            ValidationGroup="1" Font-Italic="True" ForeColor="#FF5050" />

    </div>

</asp:Content>
