<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="frmDetalleFactura.aspx.cs" Inherits="InterfazWeb.frmDetalleFactura" %>
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

        <div class="card-header text-center">
            <h1>Detalle de Factura</h1>
        </div>
        <div class="card mt-3" style="width: 100%;">
            <div class="card-body">
                <h5 class="card-title">
                    <asp:Literal ID="ltltitulo" runat="server"></asp:Literal>    
                </h5>
                
                </div>
            <div class="row">
                <div class="col-3">
                    <asp:Label ID="lblFactura" runat="server" Text="Factura #:"></asp:Label>
                    <asp:Label ID="lblNumFact" runat="server" Text="n-f-a-c"></asp:Label>
                </div>

                <div class="col-3">
                    <asp:Label ID="lblPeriod" runat="server" Text="Periodo:"></asp:Label>
                    <asp:Label ID="lblNPeriod" runat="server" Text="periodo"></asp:Label>
                </div>

                <div class="col-3">
                    <asp:Label ID="lblFecha" runat="server" Text="Fecha:"></asp:Label>
                    <asp:Label ID="lblNFecha" runat="server" Text="fe-ch-a"></asp:Label>
                </div>

                <div class="col-3">
                    <asp:Label ID="lblAnio" runat="server" Text="Anio:"></asp:Label>
                    <asp:Label ID="lblNAnio" runat="server" Text="a-ni-o"></asp:Label>
                </div>
            </div>


            <div class="row">
                <div class="col-3">
                    <asp:Label ID="lblCarne" runat="server" Text="Carné:"></asp:Label>
                    <asp:Label ID="lblNCarne" runat="server" Text="carné"></asp:Label>
                </div>

                <div class="col-8">
                    <asp:Label ID="lblEstudiante" runat="server" Text="Estudiante:"></asp:Label>
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="col-3">
                    <asp:Label ID="lblTipoPago" runat="server" Text="Tipo de Pago:"></asp:Label>
                    <asp:Label ID="lblNTipoPago" runat="server" Text="t-d-p"></asp:Label>
                </div>

                <div class="col-3">
                    <asp:Label ID="lblComprobante" runat="server" Text="Comprobante:"></asp:Label>
                    <asp:Label ID="lblNComprobante" runat="server" Text="c-m-p"></asp:Label>
                </div>
            </div>

        </div>

        <%-- gridview detalles matricula --%>

            <asp:GridView ID="GrdDetalles" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No existen registros" ForeColor="#333333" GridLines="None" Width="100%" PagerSettings-PageButtonCount="4" class="mt-3">
                    <alternatingrowstyle backcolor="White" />
                    <columns>                       

                        <asp:BoundField DataField="MatterCode" HeaderText="Code" Visible="false" />
                        <asp:BoundField DataField="Matter" HeaderText="Materia" />
                        <asp:BoundField DataField="Requirement" HeaderText="Requisito" />
                        <asp:BoundField DataField="Discount" HeaderText="Descuento" />
                        <asp:BoundField DataField="CostMatter" HeaderText="Costo"/>
                        
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
        <hr />

        <div class="row">

                <div class="text-end">
                    <asp:Label ID="lblMaterias" runat="server" Text="Costo Materias:" class="form-label text-end"></asp:Label>

                    <asp:Label ID="lblMateMonto" runat="server" Text="monto" class="form-label text-end"></asp:Label>
                </div>
            </div>

            <div class="row">

                <div class="text-end">
                    <asp:Label ID="lblMatricula" runat="server" Text="Matrícula:" class="form-label text-end"></asp:Label>

                    <asp:Label ID="lblMatriMonto" runat="server" Text="monto" class="form-label text-end"></asp:Label>
                </div>
            </div>

            <div class="row">

                <div class="text-end">
                <asp:Label ID="lblSubtotal" runat="server" Text="Subtotal:" class="form-label text-end"></asp:Label>
               
                <asp:Label ID="lblSubMonto" runat="server" Text="monto" class="form-label text-end"></asp:Label>
                </div>
               
            </div>
            <div class="row">

                <div class="text-end">
                <asp:Label ID="lblDescuento" runat="server" Text="Descuento:" class="form-label text-end"></asp:Label>
                
                <asp:Label ID="lblDesMonto" runat="server" Text="monto" class="form-label text-end"></asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="text-end">
                <asp:Label ID="lblImpuesto" runat="server" Text="Impuesto:" class="form-label text-end"></asp:Label>
                
                <asp:Label ID="lblImpMonto" runat="server" Text="monto" class="form-label text-end"></asp:Label>
            </div></div>

            <div class="row">
                <div class="text-end">
                    <asp:Label ID="lblTotal" runat="server" Text="Total:" class="form-label text-end"></asp:Label>

                    <asp:Label ID="lblTotMonto" runat="server" Text="monto" class="form-label text-end"></asp:Label>
                </div>
            </div>

        
        <hr />
    </div>

</asp:Content>
