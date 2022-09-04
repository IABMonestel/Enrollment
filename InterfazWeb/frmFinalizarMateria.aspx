<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="frmFinalizarMateria.aspx.cs" Inherits="InterfazWeb.frmCerrarMateria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script src="https://code.jquery.com/jquery-3.6.0.min.js" integrity="sha256-/xUj+3OJU5yExlq6GSYGSHk7tPXikynS7ogEvDej/m4=" crossorigin="anonymous"></script>
    <script src="js/funciones.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="card-header text-center">
            <h1>Finalizar Curso</h1>
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
                    
                </asp:Label>
                <div class="input-group">
                    <asp:TextBox ID="txtidMateria" runat="server" Visible="False"></asp:TextBox>
                    <asp:TextBox ID="txtMateria" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                    <input type="button" id="btnBuscarMateria" value="Buscar Materia" class="btn btn-outline-primary" data-bs-toggle="modal" data-bs-target="#materiaAbieModal" />
                </div>
            </div>

            <div class="col-3">
                <asp:Label ID="lblCode" runat="server" Text="Código:">
                    
                </asp:Label>
                <asp:TextBox ID="txtCodigo" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="row mt-3">
                <div class="col-2">
                    <asp:Label ID="lblGrupo" runat="server" Text="Grupo:" CssClass="form-label">

                    </asp:Label>
                    <asp:TextBox ID="txtGrupo" runat="server" CssClass="form-control" TextMode="Number" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="col-2">
                    <asp:Label ID="lblCupo" runat="server" Text="Cupo:" CssClass="form-label">

                    </asp:Label>
                    <asp:TextBox ID="txtCupo" runat="server" CssClass="form-control" TextMode="Number" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="col-2">
                    <asp:Label ID="lblCost" runat="server" Text="Costo:" CssClass="form-label">

                    </asp:Label>
                    <asp:TextBox ID="txtCost" runat="server" CssClass="form-control" TextMode="Number" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="col-2">
                    <asp:Label ID="lblPeriod" runat="server" Text="Periodo:" CssClass="form-label"></asp:Label>
                    

                    <asp:TextBox ID="txtPeriod" runat="server" TextMode="Number" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-2">
                    <asp:Label ID="lblAnio" runat="server" Text="Año:" CssClass="form-label"></asp:Label>
                    
                    <asp:TextBox ID="txtAnio" runat="server" TextMode="Number" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <asp:ValidationSummary ID="vsResumen" runat="server" ValidationGroup="1" class="mt-3" Font-Italic="True" ForeColor="#CC0000"/>

            <div class="row mt-3">

                <asp:GridView ID="GrdLista" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4"  ShowFooter="true" EmptyDataText="No existen registros" ForeColor="#333333" GridLines="None" Width="100%" PagerSettings-PageButtonCount="4"
                    OnRowEditing="GrdLista_RowEditing" OnRowCancelingEdit="GrdLista_RowCancelingEdit" OnRowUpdating="GrdLista_RowUpdating">
                    <alternatingrowstyle backcolor="White" />
                    <columns>

                        <asp:BoundField DataField="License" HeaderText="Carné" readonly="true"/>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" readonly="true" />
                        
                        <asp:BoundField DataField="BillNumber" HeaderText="BillNumber" Visible="false"/>
                       
                        <asp:TemplateField HeaderText="Nota">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("FinalNote") %>' runat="server" />

                            </ItemTemplate>

                            <EditItemTemplate>
                                <asp:TextBox ID="txtNota" runat="server" Text='<%# Eval("FinalNote") %>' CssClass="form-control" MaxLength="3"></asp:TextBox>
                            </EditItemTemplate>
                           
                        </asp:TemplateField>

                        <asp:TemplateField >                       

                            <EditItemTemplate>
                                <asp:TextBox ID="txtBillNumber" runat="server" Text='<%# Eval("BillNumber") %>' CssClass="form-control" Visible="false"></asp:TextBox>
                            </EditItemTemplate>
                           
                        </asp:TemplateField>

                        <asp:BoundField DataField="DetailStatus" HeaderText="Estado" readonly="true"/>

                        <asp:TemplateField>
                            <Itemtemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="img/pencil.ico"
                                    CommandName="Edit" ToolTip="Edit" Width="20px"/>
                            </Itemtemplate>

                            <EditItemtemplate>
                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="img/save.ico"
                                    CommandName="Update" ToolTip="Update" Width="20px"/>
                                <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="img/cancel.ico"
                                    CommandName="Cancel" ToolTip="Cancel" Width="20px"/>
                            </EditItemtemplate>

                        </asp:TemplateField>

                        
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
