<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="frmConsultarMatricula.aspx.cs" Inherits="InterfazWeb.frmConsultarMatricula" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="https://code.jquery.com/jquery-3.6.0.min.js" integrity="sha256-/xUj+3OJU5yExlq6GSYGSHk7tPXikynS7ogEvDej/m4=" crossorigin="anonymous"></script>
    <script src="js/funciones.js"></script>

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
            <h1>Consultar Matrícula</h1>
        </div>
        <div class="card mt-3" style="width: 100%;">
            <div class="card-body">
                <h5 class="card-title">
                    <asp:Literal ID="ltltitulo" runat="server"></asp:Literal>    
                </h5>

                <div class="col-8">
                <asp:Label ID="Label1" runat="server" Text="Estudiante:">
                    <asp:RequiredFieldValidator ID="rfvtxtEstudiante" runat="server"
                        ErrorMessage="Debe seleccionar un estudiante"
                        Text="*"
                        ControlToValidate="txtEstudiante"
                        ValidationGroup="1"
                        ForeColor="#FF3300">
                    </asp:RequiredFieldValidator>
                </asp:Label>
                <div class="input-group">
                    <asp:TextBox ID="txtCarne" runat="server" Visible="False"></asp:TextBox>
                    <asp:TextBox ID="txtFactEstu" runat="server" Visible="False"></asp:TextBox>
                    <asp:TextBox ID="txtEstudiante" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                    <input type="button" id="btnBuscarEstudiante" value="Buscar Estudiante" class="btn btn-outline-primary" data-bs-toggle="modal" data-bs-target="#estudianteModal" />
                </div>
            </div>
                
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

    <%--buscar Estudiante--%>
    <div class="modal fade" id="estudianteModal" tabindex="-1" aria-labelledby="MateriaModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-xl">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="estudianteModallbl">Buscar Estudiante</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="row ">
                        <div class="col">

                            <div class="row mt-3">
                                <div class="col-auto">
                                    <asp:Label ID="Label2" runat="server" Text="Nombre:" class="col-form-label">Nombre</asp:Label>
                                </div>
                                <div class="col-auto">
                                    <asp:TextBox ID="txtNombreS" runat="server" class="form-control"></asp:TextBox>
                                </div>
                                <div class="col-auto">
                                    <asp:Button ID="btnBEstu" runat="server" class="btn btn-primary" Text="Buscar" OnClick="btnBEstu_Click" />
                                </div>
                            </div>
                            <br />

                            <br />
                            <asp:GridView ID="grdEstudiante" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No existen registros" ForeColor="#333333" GridLines="None" Width="100%" PagerSettings-PageButtonCount="4" OnPageIndexChanging="grdEstudiante_PageIndexChanging">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkSeleccionarE" runat="server" CommandArgument='<%# Eval("License").ToString() %>' CommandName="Seleccionar" ToolTip="Seleccionar" OnCommand="lnkSeleccionarE_Command">
                                    Seleccionar

                                            </asp:LinkButton>

                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="License" HeaderText="License" />
                                    <asp:BoundField DataField="Id" HeaderText="Id" />
                                    <asp:BoundField DataField="Name" HeaderText="Nombre" />
                                    <asp:BoundField DataField="FLastName" HeaderText="Primer Apellido" />
                                    <asp:BoundField DataField="SLastName" HeaderText="Segundo Apellido" />
                                    <asp:BoundField DataField="Discount" HeaderText="Descuento" />
                                    <asp:BoundField DataField="State" HeaderText="Estado" />
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />

                                <PagerSettings PageButtonCount="4"></PagerSettings>

                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </div>

                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

