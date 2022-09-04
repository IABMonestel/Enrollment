<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="frmMatricular.aspx.cs" Inherits="InterfazWeb.frmMatricular" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <script src="https://code.jquery.com/jquery-3.6.0.min.js" integrity="sha256-/xUj+3OJU5yExlq6GSYGSHk7tPXikynS7ogEvDej/m4=" crossorigin="anonymous"></script>
    <script src="js/funciones.js"></script>

    <style>
        .right {
            position: relative;
            right: -700px;
            width: 300px;
            border: 3px solid #0094ff;
            padding: 10px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="card-header text-center">
            <h1>Matrícula</h1>
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

            <div class="col-8">
                <asp:Label ID="lblEstudiante" runat="server" Text="Estudiante:">
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

            <div class="col-6">
                <asp:Label ID="lblFecha" runat="server" Text="Fecha:"></asp:Label>
                <asp:TextBox ID="txtFecha" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>

            </div>

            <div class="col-2">
                    <asp:Label ID="lblPeriodo" runat="server" Text="Periodo:"></asp:Label>
                    <asp:TextBox ID="txtPeriodo" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
                </div>

                <div class="col-2">
                    <asp:Label ID="lblAnio" runat="server" Text="Año:"></asp:Label>
                    <asp:TextBox ID="txtAnio" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
                </div>


            <div class="col-6">
                <asp:Label ID="lblMateria" runat="server" Text="Materia:">
                    <asp:RequiredFieldValidator ID="rfvMateria" runat="server"
                        ErrorMessage="Debe seleccionar una materia"
                        Text="*"
                        ControlToValidate="txtMateria"
                        ValidationGroup="1"
                        ForeColor="#FF3300">
                    </asp:RequiredFieldValidator>
                </asp:Label>
                <div class="input-group">
                    <asp:TextBox ID="txtIdMateria" runat="server" Visible="False"></asp:TextBox>
                    <asp:TextBox ID="txtMateria" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                    <input type="button" id="btnBuscarMateriaAbi" value="Buscar Materia" class="btn btn-outline-primary" data-bs-toggle="modal" data-bs-target="#materiaModal" />
                </div>
            </div>

            <div class="col-6">
                <asp:Label ID="lblCodigo" runat="server" Text="Código:"></asp:Label>
                <asp:TextBox ID="txtCodigo" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>

            </div>

            <div class="col-6">
                <asp:Label ID="lblCarrera" runat="server" Text="Carrera:"></asp:Label>
                <asp:TextBox ID="txtCarrera" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>

            </div>

            <div class="row mt-3">
                <div class="col-2">
                    <asp:Label ID="lblGrupo" runat="server" Text="Grupo:"></asp:Label>
                    <asp:TextBox ID="txtGrupo" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
                </div>

                <div class="col-2">
                    <asp:Label ID="lblCupo" runat="server" Text="Cupo:"></asp:Label>
                    <asp:TextBox ID="txtCupo" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
                </div>

                <div class="col-3 mt-4">
                    <asp:Button ID="btnMatricular" runat="server" Text="Matricular" ValidationGroup="1" class="btn btn-primary" OnClick="btnMatricular_Click"/>   
                </div>
            </div>
            <asp:ValidationSummary ID="vsResumen" runat="server" ValidationGroup="1" class="mt-3" Font-Italic="True" ForeColor="#CC0000" />
            <asp:ValidationSummary ID="vsResume" runat="server" ValidationGroup="2" class="mt-3" Font-Italic="True" ForeColor="#CC0000" />

            <%-- gridview detalles matricula --%>

            <asp:GridView ID="GrdDetalles" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No existen registros" ForeColor="#333333" GridLines="None" Width="100%" PagerSettings-PageButtonCount="4" class="mt-3">
                    <alternatingrowstyle backcolor="White" />
                    <columns>
                        <asp:TemplateField>
                            <itemtemplate>
                                <asp:LinkButton ID="lnkEliminarD" runat="server" CommandArgument='<%# Eval("MatterCode").ToString() %>' CommandName="Eliminar" ToolTip="Eliminar" OnCommand="lnkEliminarD_Command">
                                    Eliminar

                                </asp:LinkButton>

                            </itemtemplate>
                        </asp:TemplateField>

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
        </div>

        <div class="row mt-3">

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

            <div class="row right">
                <div >
                <asp:DropDownList ID="cboTipoPago" runat="server" class="form-select" Width="200px">
                    <asp:ListItem Selected="True" Value="Efectivo">Efectivo</asp:ListItem>
                    <asp:ListItem Value="Otro">Otro</asp:ListItem>
                    <asp:ListItem Value="Sinpe">Sinpe</asp:ListItem>
                    <asp:ListItem Value="Tarjeta">Tarjeta</asp:ListItem>
                    <asp:ListItem Value="Transferencia">Transferencia</asp:ListItem>
                </asp:DropDownList>
                    <asp:Label ID="lblComprobante" runat="server" Text="Comprobante #:">
                        <asp:RequiredFieldValidator ID="rfvComprobante" runat="server"
                        ErrorMessage="Ingrese el número de comprobante"
                        Text="*"
                        ControlToValidate="txtComprobante"
                        ValidationGroup="2"
                        ForeColor="#FF3300">
                    </asp:RequiredFieldValidator>

                    </asp:Label>
                    <asp:TextBox ID="txtComprobante" runat="server" TextMode="Number" CssClass="form-control" ValidationGroup="2" MaxLength="15"></asp:TextBox>
                    </div>
                <div>
                    

                </div>
            </div>

        </div>

        <div class="row mt-3">

            <div class="col-3">
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="btn btn-primary" OnClick="btnCancelar_Click" />
            </div>

            <div class="col-3">
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" class="btn btn-primary" OnClick="btnLimpiar_Click" />
            </div>

            <div class="col-3">
                <asp:Button ID="btnFacturar" runat="server" Text="Facturar" class="btn btn-primary" OnClick="btnFacturar_Click" ValidationGroup="2" />
            </div>

        </div>

        <div><p><br/><br/></p></div>
        <div><p><br/><br/></p></div>
    </div>

    <%--buscar materia abierta--%>
            <div class="modal fade" id="materiaModal" tabindex="-1" aria-labelledby="MateriaModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-xl">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="MateriaAModalLabel">Buscar Materia</h5>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body">
                            <div class="row ">
                                <div class="col">

                                    <div class="row mt-3">
                                        <div class="col-auto">
                                            <asp:Label ID="Label1" runat="server" Text="Nombre:" class="col-form-label">Nombre</asp:Label>
                                        </div>
                                        <div class="col-auto">
                                            <asp:TextBox ID="txtNMatAbi" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-auto">
                                            <asp:Button ID="btnBMatA" runat="server" class="btn btn-primary" Text="Buscar" OnClick="btnBMatA_Click" />
                                        </div>
                                    </div>
                                    <br />

                                    <br />
                                    <asp:GridView ID="GrdMaterias" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No existen registros" ForeColor="#333333" GridLines="None" Width="100%" PagerSettings-PageButtonCount="4">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkSeleccionar" runat="server" CommandArgument='<%# Eval("OpenSubjectsCode").ToString() %>' CommandName="Seleccionar" ToolTip="Seleccionar" OnCommand="lnkSeleccionar_Command">
                                    Seleccionar

                                                    </asp:LinkButton>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="Name" HeaderText="Materia" />
                                            <asp:BoundField DataField="Code" HeaderText="Codigo" />
                                            <asp:BoundField DataField="CareerName" HeaderText="Carrera" />
                                            <asp:BoundField DataField="Group" HeaderText="Grupo" />
                                            <asp:BoundField DataField="Quota" HeaderText="Cupo" />
                                            <asp:BoundField DataField="Period" HeaderText="Periodo" />
                                            <asp:BoundField DataField="Year" HeaderText="Año" />
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
                                    <asp:Label ID="lblNombre" runat="server" Text="Nombre:" class="col-form-label">Nombre</asp:Label>
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