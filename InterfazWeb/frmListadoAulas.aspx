<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="frmListadoAulas.aspx.cs" Inherits="InterfazWeb.frmListadoAulas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="card-header text-center">
            <h1>Listado de Aulas</h1>
        </div>
        <%if (Session["_mensaje"] != null)
            { %>
               <div class="alert alert-warning alert-dismissible fade show mt-3" role="alert">
                   <%=Session["_mensaje"]%>
                    <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
               </div> 
        <% 
                Session["_mensaje"] = null;
            } 
            if (Session["_mensajeB"] != null)
            {%>
                <div class="alert alert-success alert-dismissible fade show mt-3" role="alert">
                   <%=Session["_mensajeB"]%>
                    <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
               </div> 
        <% 
                Session["_mensajeB"] = null;
            }%>

        <div class="row mt-3">
            <div class="col-auto">
                <asp:Label ID="lblAula" 
                           runat="server" 
                           Text="Tipo de Aula:"
                           CssClass="col-form-label"></asp:Label>
            </div>
            <div class="col-auto">
                <asp:TextBox ID="txtTipo" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-auto">
                <asp:Button ID="btnBuscar" 
                    runat="server" 
                    Text="Buscar" 
                    CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
            </div>
            <div class="col-auto">
                <asp:Button ID="btnAgregar" 
                    runat="server" 
                    Text="Nueva Aula" 
                    CssClass="btn btn-secondary" OnClick="btnAgregar_Click" />
            </div>
        </div><!-- cierra div row-->
       
        <br />
    
        <asp:GridView ID="grdLista" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se registran materias" ForeColor="#333333" GridLines="None" Width="100%" OnPageIndexChanging="GrdLista_PageIndexChanging">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkModificar" runat="server" CommandArgument='<%# Eval("Codigo").ToString() %>' OnCommand="lnkModificar_Command">Modificar</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEliminar" runat="server" CommandArgument='<%# Eval("Codigo").ToString() %>' OnCommand="lnkEliminar_Command">Eliminar</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Codigo" HeaderText="Código" />
                <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                <asp:BoundField DataField="Numero" HeaderText="Número" />
                <asp:BoundField DataField="Capacidad" HeaderText="Capacidad" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>

    </div>

</asp:Content>
