<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="frmAbrirMaterias.aspx.cs" Inherits="InterfazWeb.frmAbrirMaterias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="https://code.jquery.com/jquery-3.6.0.min.js" integrity="sha256-/xUj+3OJU5yExlq6GSYGSHk7tPXikynS7ogEvDej/m4=" crossorigin="anonymous"></script>
    <script src="js/funciones.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="card-header text-center">
            <h1>Abrir Materia</h1>
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

            <div class="col-8">
                <asp:Label ID="lblMateria" runat="server" Text="Materia:">
                    <asp:RequiredFieldValidator ID="rfvtxtMateria" runat="server"
                        ErrorMessage="Debe seleccionar una Materia"
                        Text="*"
                        ControlToValidate="txtMateria"
                        ValidationGroup="1"
                        ForeColor="#FF3300">
                    </asp:RequiredFieldValidator>
                </asp:Label>
                <div class="input-group">
                    <asp:TextBox ID="txtidMateriaC" runat="server" Visible="False"></asp:TextBox>
                    <asp:TextBox ID="txtMateria" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                    <input type="button" id="btnBuscarMateria" value="Buscar Materia" class="btn btn-outline-primary" data-bs-toggle="modal" data-bs-target="#materiaModal" />
                </div>
            </div>
            <div class="row mt-3">
                <div class="col-2">
                    <asp:Label ID="lblGrupo" runat="server" Text="Grupo:" CssClass="form-label">

                    </asp:Label>
                    <asp:TextBox ID="txtGrupo" runat="server" CssClass="form-control" TextMode="Number" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="col-2">
                    <asp:Label ID="lblCupo" runat="server" Text="Cupo:" CssClass="form-label">

                        <asp:RequiredFieldValidator ID="rfvtxtCupo" runat="server" 
                        ErrorMessage="Debe indicar el cupo" 
                        Text="*"
                        ControlToValidate="txtCupo"
                        ValidationGroup="1"
                        ForeColor="#FF3300"></asp:RequiredFieldValidator>

                        <asp:RangeValidator ID="rvCupo" runat="server" ErrorMessage="El cupo debe ser un valor entre 10 y 40" Text="*" Type="Integer" MaximumValue="40" MinimumValue="10" ControlToValidate="txtCupo" ValidationGroup="1"></asp:RangeValidator>

                    </asp:Label>
                    <asp:TextBox ID="txtCupo" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </div>
                <div class="col-2">
                    <asp:Label ID="lblCost" runat="server" Text="Costo:" CssClass="form-label">

                        <asp:RequiredFieldValidator ID="rfvtxtCost" runat="server" 
                        ErrorMessage="Debe indicar el costo" 
                        Text="*"
                        ControlToValidate="txtCost"
                        ValidationGroup="1"
                        ForeColor="#FF3300"></asp:RequiredFieldValidator>

                        <asp:RangeValidator ID="rvCost" runat="server" ErrorMessage="El costo debe ser un valor mayor a 0" Text="*" Type="Integer" MaximumValue="1000000" MinimumValue="1" ValidationGroup="1" ControlToValidate="txtCost"></asp:RangeValidator>

                    </asp:Label>
                    <asp:TextBox ID="txtCost" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </div>
                <div class="col-2">
                    <asp:Label ID="lblPeriod" runat="server" Text="Periodo:" CssClass="form-label"></asp:Label>
                    <asp:DropDownList ID="cboPeriodo" runat="server" class="form-select">
                        <asp:ListItem Selected="True" Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-2">
                    <asp:Label ID="lblAnio" runat="server" Text="Año:" CssClass="form-label"></asp:Label>
                    <asp:RadioButton ID="rbAnioActual" runat="server" Text="Año:" GroupName="RadioGroup1"></asp:RadioButton>
                    <asp:RadioButton ID="rbAnioSig" runat="server" Text="Año:" GroupName="RadioGroup1"></asp:RadioButton>
                </div>
            </div>
            <div class="row mt-3">
                <h4>Horario</h4>
                <div class="col-2">
                    <asp:Label ID="lblDia" runat="server" Text="Día:" CssClass="form-label"></asp:Label>
                    <asp:DropDownList ID="cboDia" runat="server">
                        <asp:ListItem Selected="True" Value="L">Lunes</asp:ListItem>
                        <asp:ListItem Value="K">Martes</asp:ListItem>
                        <asp:ListItem Value="M">Miércoles</asp:ListItem>
                        <asp:ListItem Value="J">Jueves</asp:ListItem>
                        <asp:ListItem Value="V">Viernes</asp:ListItem>
                        <asp:ListItem Value="S">Sábado</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-2">
                    <asp:Label ID="lblHoraE" runat="server" Text="Hora Inicio:" CssClass="form-label">

                        <asp:RequiredFieldValidator ID="rfvtxtHoraE" runat="server" 
                        ErrorMessage="Debe indicar la hora de entrada" 
                        Text="*"
                        ControlToValidate="txtHoraE"
                        ValidationGroup="1"
                        ForeColor="#FF3300"></asp:RequiredFieldValidator>

                        <asp:CompareValidator ID="cvtxtHoraE" runat="server"
                            ErrorMessage="La hora de ingreso debe ser mayor o igual a las 6 am"
                            ControlToValidate="txtHoraE"
                            ControlToCompare="txt6am"
                            Display="Dynamic"
                            ValidationGroup="1"
                            Operator="GreaterThanEqual" Text="*" ValueToCompare="06:00">
                        </asp:CompareValidator>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="RangeValidator" MaximumValue="20:00" ValidationGroup="1" ControlToValidate="txtHoraE" Display="Dynamic" Text="*"></asp:RangeValidator>
                    </asp:Label>
                    <asp:TextBox ID="txt6am" runat="server" CssClass="form-control" TextMode="Time" Visible="False"></asp:TextBox>
                    <asp:TextBox ID="txtHoraE" runat="server" CssClass="form-control" TextMode="Time" MinimumValue="06:00" MaximumValue="19:00" Display="Dynamic"></asp:TextBox>
                    
                </div>
                <div class="col-2">
                    <asp:Label ID="lblHoraS" runat="server" Text="Hora Salida:" CssClass="form-label">

                        <asp:RequiredFieldValidator ID="rfvtxtHoraS" runat="server" 
                        ErrorMessage="Debe indicar la hora de salida" 
                        Text="*"
                        ControlToValidate="txtHoraS"
                        ValidationGroup="1"
                        ForeColor="#FF3300"></asp:RequiredFieldValidator>

                        <asp:CompareValidator ID="cvtxtHoraS" runat="server"
                            ErrorMessage="La hora de salida debe ser mayor a la hora de Inicio"
                            ControlToValidate="txtHoraS"
                            ControlToCompare="txtHoraE"
                            Display="Dynamic"
                            ValidationGroup="1"
                            Operator="GreaterThan" Text="*">
                        </asp:CompareValidator>

                    </asp:Label>
                    <asp:TextBox ID="txtHoraS" runat="server" CssClass="form-control" TextMode="Time"></asp:TextBox>
                </div>
                <div class="col-2">
                    <asp:Button ID="btnAbrir" runat="server" Text="Agregar Horario" CssClass="btn btn-primary"
                        ValidationGroup="1" OnClick="btnAbrir_Click" />
                </div>
                <div class="col-2">
                    
                        
                </div>

            </div>
            <div class="col-6">
                    

                    <asp:ValidationSummary ID="vsResumen" runat="server" ValidationGroup="1" class="mt-3" Font-Italic="True" ForeColor="#CC0000" />
            </div>

            <div class="row mt-3">

                <asp:GridView ID="GrdLista" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No existen registros" ForeColor="#333333" GridLines="None" Width="100%" PagerSettings-PageButtonCount="4"
                    OnPageIndexChanging="GrdLista_PageIndexChanging">
                    <alternatingrowstyle backcolor="White" />
                    <columns>
                        <asp:TemplateField>
                            <itemtemplate>
                                <asp:LinkButton ID="lnkEliminar" runat="server" CommandArgument='<%# Eval("ID").ToString() %>' CommandName="Eliminar" ToolTip="Eliminar" OnCommand="lnkEliminar_Command">
                                    Eliminar

                                </asp:LinkButton>

                            </itemtemplate>
                        </asp:TemplateField>

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
            <div class="row mt-3 position-relative">
                
                <div class="col-3">
                    <asp:Button ID="btnCancelar" runat="server" Text="Eliminar" CssClass="btn btn-primary end-1"
                         OnClick="btnCancelar_Click" />
                </div>

                <div class="col-3">
                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-primary end-1"
                         OnClick="btnLimpiar_Click" />
                </div>

                <div class="col-3">
                    <input type="button" id="btnBuscarMateriaAbi" value="Modificar Materia" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#materiaAbieModal" />

                </div>

                <div class="col-3">
                    <asp:Button ID="btnSig" runat="server" Text="Siguiente" CssClass="btn btn-primary end-0"
                         OnClick="btnSig_Click" />
                </div>

            </div>

        </div>
    </div>

    <%--buscar materia carrera--%>
    <div class="modal fade" id="materiaModal" tabindex="-1" aria-labelledby="ClienteModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-xl">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="MateriaModalLabel">Buscar Materia</h5>
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
                                    <asp:TextBox ID="txtNombreMateria" runat="server" class="form-control"></asp:TextBox>
                                </div>
                                <div class="col-auto">
                                    <asp:Button ID="btnBuscar" runat="server" class="btn btn-primary" Text="Buscar" OnClick="btnBuscar_Click"  />
                                </div>
                            </div>
                            <br />

                            <br />
                            <asp:GridView ID="grdMaterias" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No existen registros" ForeColor="#333333" GridLines="None"  Width="100%" PagerSettings-PageButtonCount="4"
                                OnPageIndexChanging="grdMaterias_PageIndexChanging">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkSeleccionar" runat="server" CommandArgument='<%# Eval("CodeCareerMatter").ToString() %>' CommandName="Seleccionar" ToolTip="Seleccionar" OnCommand="lnkSeleccionar_Command">
                                                Seleccionar

                                            </asp:LinkButton>

                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="CodeCareerMatter" HeaderText="CodeCareerMatter" Visible="false " />
                                    <asp:BoundField DataField="Name" HeaderText="Materia" />
                                    <asp:BoundField DataField="Code" HeaderText="Código" />
                                    <asp:BoundField DataField="Requirement" HeaderText="Requisito" />
                                    <asp:BoundField DataField="CareerName" HeaderText="Carrera" />
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

    <%--buscar materia abierta--%>
    <div class="modal fade" id="materiaAbieModal" tabindex="-1" aria-labelledby="MateriaModalLabel" aria-hidden="true">
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
                                    <asp:Button ID="btnBMatA" runat="server" class="btn btn-primary" Text="Buscar" OnClick="btnBMatA_Click"  />
                                </div>
                            </div>
                            <br />

                            <br />
                            <asp:GridView ID="grdMatAbi" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No existen registros" ForeColor="#333333" GridLines="None"  Width="100%" PagerSettings-PageButtonCount="4">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkSeleccionarMatA" runat="server" CommandArgument='<%# Eval("OpenSubjectsCode").ToString() %>' CommandName="Seleccionar" ToolTip="Seleccionar" OnCommand="lnkSeleccionarMatA_Command">
                                                Seleccionar

                                            </asp:LinkButton>

                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="OpenSubjectsCode" HeaderText="CodeCareerMatter" Visible="false " />
                                    <asp:BoundField DataField="Name" HeaderText="Materia" />
                                    <asp:BoundField DataField="Code" HeaderText="Código" />
                                    <asp:BoundField DataField="Group" HeaderText="Grupo" />
                                    <asp:BoundField DataField="Period" HeaderText="Periodo" />
                                    <asp:BoundField DataField="Year" HeaderText="Año" />
                                    <asp:BoundField DataField="CareerCode" HeaderText="Carrera" />
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
