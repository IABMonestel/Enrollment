<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="frmDetalleMateria.aspx.cs" Inherits="InterfazWeb.frmDetalleMateria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">

        <%if (Session["_mensaje"] != null)
            { %>
        <div class="alert alert-warning alert-dismissible fade show mt-3" role="alert">
            <%=Session["_mensaje"]%>
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
        <% 
                Session["_mensaje"] = null;
            } if (Session["_mensajeB"] != null)
            {%>

        <div class="alert alert-success alert-dismissible fade show mt-3" role="alert">
            <%=Session["_mensajeB"]%>
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
        <% Session["_mensajeB"] = null;} %>


        <div class="card-header text-center">
            <h1>Detalle de Materia</h1>
        </div>
        <div class="card mt-3" style="width: 100%;">
            <div class="card-body">
                <h5 class="card-title">
                    <asp:Literal ID="ltltitulo" runat="server"></asp:Literal>    
                </h5>
                <h6 class="card-subtitle mb-2 text-muted">
                    <asp:Literal ID="ltlSubtitulo" runat="server"></asp:Literal>
                </h6>
                <p class="card-text"><asp:Literal ID="ltlNombre" runat="server"></asp:Literal></p>
                <p class="card-text"><asp:Literal ID="ltlCodigo" runat="server"></asp:Literal></p>
                <p class="card-text"><asp:Literal ID="ltlCarrera" runat="server"></asp:Literal></p>
                <p class="card-text"><asp:Literal ID="ltlRequisito" runat="server"></asp:Literal></p>
                <p class="card-text"><asp:Literal ID="ltlProfesor" runat="server"></asp:Literal></p>
                <p class="card-text"><asp:Literal ID="ltlAula" runat="server"></asp:Literal></p>
                <p class="card-text"><asp:Literal ID="ltlGrupo" runat="server"></asp:Literal></p>
                <p class="card-text"><asp:Literal ID="ltlCupo" runat="server"></asp:Literal></p>
                <p class="card-text"><asp:Literal ID="ltlCosto" runat="server"></asp:Literal></p>
                <p class="card-text"><asp:Literal ID="ltlPeriodo" runat="server"></asp:Literal></p>
                <p class="card-text"><asp:Literal ID="ltlAnio" runat="server"></asp:Literal></p>
                <h6 class="card-text"><asp:Literal ID="ltlHorario" runat="server"></asp:Literal></h6>
                
                <div class="row mt-3">

                <asp:GridView ID="GrdLista" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No existen registros" ForeColor="#333333" GridLines="None" Width="100%" PagerSettings-PageButtonCount="4">
                    <alternatingrowstyle backcolor="White" />
                    <columns>                      

                        <asp:BoundField DataField="Dia" HeaderText="Dia" />
                        <asp:BoundField DataField="StartTime" HeaderText="Hora Inicio" />
                        <asp:BoundField DataField="EndTime" HeaderText="Hora Fin" />
                    </columns>
                    <editrowstyle backcolor="#2461BF" />
                    <footerstyle backcolor="#507CD1" font-bold="True" forecolor="White" />
                    <headerstyle backcolor="#507CD1" font-bold="True" forecolor="White" />

                    <pagersettings pagebuttoncount="4"></pagersettings>

                    <pagerstyle backcolor="#2461BF" forecolor="White" horizontalalign="Center" />
                    <rowstyle backcolor="#EFF3FB" />
                    <selectedrowstyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
                    <sortedascendingcellstyle backcolor="#F5F7FB" />
                    <sortedascendingheaderstyle backcolor="#6D95E1" />
                    <sorteddescendingcellstyle backcolor="#E9EBEF" />
                    <sorteddescendingheaderstyle backcolor="#4870BE" />
                </asp:GridView>
            
            </div>

                
                <asp:LinkButton ID="btnAtras" runat="server" CssClass="btn btn-secondary mt-3" OnClick="btnAtras_Click">Atrás</asp:LinkButton>
            </div>
        </div>
    </div>

</asp:Content>
