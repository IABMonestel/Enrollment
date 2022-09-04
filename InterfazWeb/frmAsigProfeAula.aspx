<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="frmAsigProfeAula.aspx.cs" Inherits="InterfazWeb.frmAsigProfeAula" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="https://code.jquery.com/jquery-3.6.0.min.js" integrity="sha256-/xUj+3OJU5yExlq6GSYGSHk7tPXikynS7ogEvDej/m4=" crossorigin="anonymous"></script>
    <script src="js/funciones.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="card-header text-center">
            <h1>Asignar Profesor y Aula</h1>
        </div>
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
        <div class="row mt-3">

            <div class="col-3">
                <asp:Label ID="lblMateria" runat="server" Text="Materia:"></asp:Label>
                <asp:TextBox ID="txtidMateriaA" runat="server" Visible="False"></asp:TextBox>
                 <asp:TextBox ID="txtMateria" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-3">
                <asp:Label ID="lblCodMat" runat="server" Text="Código:"></asp:Label>
                <asp:TextBox ID="txtCodMat" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>                 
            </div>
            <div class="col-3">
                <asp:Label ID="lblCarrera" runat="server" Text="Carrera:"></asp:Label>
                <asp:TextBox ID="txtCarrera" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>                 
            </div>
            <div class="col-3">
                <asp:Label ID="lblCupo" runat="server" Text="Cupo:"></asp:Label>
                <asp:TextBox ID="txtCupo" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>                 
            </div>
        </div>
        <div class="row mt-3">
            <h4>Profesor</h4>
            <div class="col-8">
                <asp:Label ID="lblProfesor" runat="server" Text="Profesor:">

                    <asp:RequiredFieldValidator ID="rfvtxtIdP" runat="server"
                        ErrorMessage="Debe seleccionar un profesor"
                        Text="*"
                        ControlToValidate="txtIdP"
                        ValidationGroup="1"
                        ForeColor="#FF3300">
                    </asp:RequiredFieldValidator>

                </asp:Label>
                <div class="input-group">
                <asp:TextBox ID="txtIdP" runat="server" ReadOnly="true" CssClass="form-control mt-2"></asp:TextBox>
                <input type="button" id="btnBuscarP" value="Buscar Profesor" class="btn btn-outline-primary mt-2" data-bs-toggle="modal" data-bs-target="#profesorModal" />
                </div>
                <div class="input-group">
                <asp:TextBox ID="txtNombreP" runat="server" ReadOnly="true" CssClass="form-control mt-2"></asp:TextBox>
                
                <asp:Button ID="btnAsigP" runat="server" Text="Asignar" class="btn btn-primary mt-2" ValidationGroup="1" OnClick="btnAsigP_Click"/>
                &nbsp&nbsp
                    <div class="col-3">
                        <asp:Button ID="btnEliP" runat="server" Text="Eliminar" class="btn btn-primary mt-2" ValidationGroup="1" OnClick="btnEliP_Click" />
                    </div>

                </div>
           </div>
            
        </div>

        <div class="row mt-3">
            <h4>Aula</h4>
            <div class="col-8">
                <asp:Label ID="lblAula" runat="server" Text="Aula:">

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ErrorMessage="Debe seleccionar un aula"
                        Text="*"
                        ControlToValidate="txtIdA"
                        ValidationGroup="2"
                        ForeColor="#FF3300">
                    </asp:RequiredFieldValidator>

                </asp:Label>


                <div class="input-group">
                    <asp:TextBox ID="txtIdA" runat="server" ReadOnly="true" CssClass="form-control mt-2"></asp:TextBox>
                    <input type="button" id="btnBuscarA" value="Buscar Aula" class="btn btn-outline-primary mt-2" data-bs-toggle="modal" data-bs-target="#aulaModal" />

                </div>

                <div class="input-group">
                    <asp:TextBox ID="txtTipo" runat="server" ReadOnly="true" CssClass="form-control mt-2"></asp:TextBox>
                    <asp:Button ID="btnAsigA" runat="server" Text="Asignar" class="btn btn-primary mt-2" ValidationGroup="2" OnClick="btnAsigA_Click" />
                    &nbsp&nbsp
                    <div class="col-3">
                        <asp:Button ID="btnEliA" runat="server" Text="Eliminar" class="btn btn-primary mt-2" ValidationGroup="2" OnClick="btnEliA_Click" />

                    </div>

                </div>
            </div>
            
        </div>

        <asp:ValidationSummary ID="vsResumen" runat="server" ValidationGroup="1" class="mt-3" Font-Italic="True" ForeColor="#CC0000" />
        <asp:ValidationSummary ID="vsResumen1" runat="server" ValidationGroup="2" class="mt-3" Font-Italic="True" ForeColor="#CC0000" />
    </div>  
    <div class="container">
        <div class="row mt-3">
            <div class="col-3">
                <asp:Button ID="btnAtras" runat="server" Text="Atrás" CssClass="btn btn-primary ml-5" OnClick="btnAtras_Click" />

            </div>

            <div class="col-3">
                <asp:Button ID="btnMenuP" runat="server" Text="Menú Principal" CssClass="btn btn-primary" OnClick="btnMenuP_Click" />

            </div>

            <div class="col-3">
                <asp:Button ID="btnFinalizar" runat="server" Text="Finalizar" CssClass="btn btn-primary" OnClick="btnFinalizar_Click" />

            </div>
        </div>
    </div>

    <%--buscar profesor--%>
    <div class="modal fade" id="profesorModal" tabindex="-1" aria-labelledby="ClienteModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-xl">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="ProfeModalLabel">Buscar Aula</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="row ">
                        <div class="col">

                            <div class="row mt-3">
                                <div class="col-auto">
                                    <asp:Label ID="lblProfe" runat="server" Text="Nombre:" class="col-form-label">Nombre</asp:Label>
                                </div>
                                <div class="col-auto">
                                    <asp:TextBox ID="txtNProfe" runat="server" class="form-control"></asp:TextBox>
                                </div>
                                <div class="col-auto">
                                    <asp:Button ID="btnBProfe" runat="server" class="btn btn-primary" Text="Buscar" OnClick="btnBProfe_Click"  />
                                </div>
                            </div>
                            <br />

                            <br />
                            <asp:GridView ID="grdProfes" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No existen registros" ForeColor="#333333" GridLines="None" Width="100%" PagerSettings-PageButtonCount="4">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkSeleccionarP" runat="server" CommandArgument='<%# Eval("Codigo").ToString() %>' CommandName="Seleccionar" ToolTip="Seleccionar" OnCommand="lnkSeleccionarP_Command">
                                                Seleccionar

                                            </asp:LinkButton>

                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="Codigo" HeaderText="Code" Visible="false " />
                                    <asp:BoundField DataField="Id" HeaderText="Identificacion" />
                                    <asp:BoundField DataField="Name" HeaderText="Nombre" />
                                    <asp:BoundField DataField="FLastName" HeaderText="Primer Apellido" />
                                    <asp:BoundField DataField="SLastName" HeaderText="Segundo Apellido" />

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

    <%--buscar aula--%>
    <div class="modal fade" id="aulaModal" tabindex="-1" aria-labelledby="ClienteModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-xl">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="AulaModalLabel">Buscar Aula</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="row ">
                        <div class="col">

                            <div class="row mt-3">
                                <div class="col-auto">
                                    <asp:Label ID="lblTipo" runat="server" Text="Tipo:" class="col-form-label">Nombre</asp:Label>
                                </div>
                                <div class="col-auto">
                                    <asp:TextBox ID="txtTipoA" runat="server" class="form-control"></asp:TextBox>
                                </div>
                                <div class="col-auto">
                                    <asp:Button ID="btnBAula" runat="server" class="btn btn-primary" Text="Buscar" OnClick="btnBAula_Click"  />
                                </div>
                            </div>
                            <br />

                            <br />
                            <asp:GridView ID="grdAulas" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No existen registros" ForeColor="#333333" GridLines="None"  Width="100%" PagerSettings-PageButtonCount="4">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkSeleccionarAula" runat="server" CommandArgument='<%# Eval("Codigo").ToString() %>' CommandName="Seleccionar" ToolTip="Seleccionar" OnCommand="lnkSeleccionarAula_Command">
                                                Seleccionar

                                            </asp:LinkButton>

                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="Codigo" HeaderText="Código" Visible="false " />
                                    <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                                    <asp:BoundField DataField="Numero" HeaderText="Número" />
                                    <asp:BoundField DataField="Capacidad" HeaderText="Capacidad" />
                                    
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
