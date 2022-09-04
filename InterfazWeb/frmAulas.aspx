<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="frmAulas.aspx.cs" Inherits="InterfazWeb.frmAulas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="card-header text-center">
            <h1>Mantenimiento de Aulas</h1>
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

            </asp:Label>
            <asp:TextBox ID="txtCode" runat="server" MaxLength="6"
                CssClass="form-control"></asp:TextBox>
        </div>
        <div class="mb-3">
            <asp:Label ID="lblTipo" runat="server" Text="Tipo:" 
                CssClass="form-label">
            </asp:Label>

            <asp:DropDownList ID="cboTipo" runat="server" class="form-select" >
                <asp:ListItem Selected="True" Value="Laboratorio" class="dropdown-item">Laboratorio</asp:ListItem>
                <asp:ListItem Value="Salón" class="dropdown-item">Salón</asp:ListItem>
                <asp:ListItem Value="Taller" class="dropdown-item">Taller</asp:ListItem>

            </asp:DropDownList>
        </div>
        <div class="mb-3">
            <asp:Label ID="lblNumero" runat="server" Text="Número:" 
                CssClass="form-label">
                <asp:RequiredFieldValidator ID="rfvtxtNumero" runat="server" ErrorMessage="El número de aula es obligatorio"
                    ControlToValidate="txtNumero"
                    Text="*"
                    ValidationGroup="1" Font-Italic="True" ForeColor="#FF5050"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rvNumero" runat="server" ErrorMessage="Ingrese un valor mayor a 0" ControlToValidate="txtNumero" MaximumValue="1000000" MinimumValue="1" ValidationGroup="1" Type="Integer" Text="*" Display="Dynamic"></asp:RangeValidator>
            </asp:Label>
            <asp:TextBox ID="txtNumero" AutoCompleteType="Disabled" runat="server"
                CssClass="form-control" TextMode="Number" MaxLength="2"></asp:TextBox>
        </div>
        <div class="mb-3">
            <asp:Label ID="lblCapacidad" runat="server" Text="Capacidad:" 
                CssClass="form-label">
                <asp:RequiredFieldValidator ID="rfvCapacidad" runat="server" ErrorMessage="La capacidad es obligatoria"
                    ControlToValidate="txtCapacidad"
                    Text="*"
                    ValidationGroup="1" Font-Italic="True" ForeColor="#FF5050"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rvCapacidad" runat="server" ErrorMessage="Capacidad debe ser un valor entre 10 y 40" Text="*" MinimumValue="10" MaximumValue="40" Type="Integer" ValidationGroup="1" ControlToValidate="txtCapacidad"></asp:RangeValidator>
            </asp:Label>
            <asp:TextBox ID="txtCapacidad" AutoCompleteType="Disabled" runat="server"
                CssClass="form-control" TextMode="Number" MaxLength="2"></asp:TextBox>
        </div>
        
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" ValidationGroup="1" OnClick="btnGuardar_Click"/>
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCancelar_Click"/>
        <br />
        <asp:ValidationSummary ID="vsResumen" runat="server" CssClass="mt-3" 
            ValidationGroup="1" Font-Italic="True" ForeColor="#FF5050" />

    </div>

</asp:Content>
