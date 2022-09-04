<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="frmHabilitarMatricula.aspx.cs" Inherits="InterfazWeb.frmHabilitarMatricula" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
        <div class="card-header">
            <h1>Habilitar Matrícula</h1>            
        </div>
        <br />
        <!--Mensaje de Error-->
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
        <% 
                Session["_mensajeB"] = null;
            }%>
        
        <!--Validation summary-->
        <asp:ValidationSummary ID="vsResumen" runat="server" CssClass="mt-3" 
            ValidationGroup="1" Font-Italic="True" ForeColor="#FF5050" />

        <div class="row mt-5">
            <div class="mt-10">
            <asp:Label ID="lblHabilitarMatricula" runat="server" Text="Habilitar Matrícula:"></asp:Label>
            &nbsp
            <asp:CheckBox ID="chkHabilitarMatricula" runat="server"/>
            </div>

            <div class="mt-4">
            <asp:Label ID="lblYear" runat="server" Text="Año:"></asp:Label>
                &nbsp
            <asp:RadioButton ID="rbtnAnioActual" runat="server" Text="temp" OnCheckedChanged="rbtnAnioActual_CheckedChanged" GroupName="RadioGroup1"/><!--Set text from server site-->
                &nbsp
            <asp:RadioButton ID="rbtnSigAnio" runat="server" Text="temp" OnCheckedChanged="rbtnSigAnio_CheckedChanged" GroupName="RadioGroup1"/>
            </div>

            <div class="row mt-4">
            <div class="col"></div>
            <div class="col text-end">
            <asp:Label ID="lblPeriod" runat="server" Text="Periodo:">
                <asp:RequiredFieldValidator runat="server" 
                    ErrorMessage="El periodo es obligatorio"
                    ID="rfvtxtPeriod"
                    ControlToValidate="txtPeriod"
                    Text="*"
                    ValidationGroup="1" Font-Italic="True" ForeColor="#FF5050"
                    ></asp:RequiredFieldValidator>

            </asp:Label>
            </div>
            <div class="col text-start">
            <asp:TextBox ID="txtPeriod" runat="server" MaxLength="1" TextMode="Number" class="form-control"></asp:TextBox>
            </div>
            <div class="col"></div>

            </div>

            <div class="row mt-4">
            <div class="col"></div>
            <div class="col text-end">
            <asp:Label ID="lblMontoMatricula" runat="server" Text="Monto Matrícula:">
                <asp:RequiredFieldValidator runat="server" 
                    ErrorMessage="El monto es obligatorio"
                    ID="rfvtxtMontoMatricula"
                    ControlToValidate="txtMontoMatricula"
                    Text="*"
                    ValidationGroup="1" Font-Italic="True" ForeColor="#FF5050"
                    ></asp:RequiredFieldValidator>

            </asp:Label>
            </div>
            <div class="col text-start">
            <asp:TextBox ID="txtMontoMatricula" runat="server" MaxLength="6" TextMode="Number" class="form-control"></asp:TextBox>
            </div>
            <div class="col"></div>
            </div>

            <div class="row mt-4">
            <div class="col"></div>
            <div class="col text-end">
            <asp:Label ID="lblIVA" runat="server" Text="IVA:">
                <asp:RequiredFieldValidator runat="server" 
                    ErrorMessage="El impuesto es obligatorio"
                    ID="rfvtxtImpuesto"
                    ControlToValidate="txtIVA"
                    Text="*"
                    ValidationGroup="1" Font-Italic="True" ForeColor="#FF5050"
                    ></asp:RequiredFieldValidator>

            </asp:Label>
            </div>
            <div class="col text-start">
                <asp:TextBox ID="txtIVA" runat="server" TextMode="Number" MaxLength="3" class="form-control"></asp:TextBox>
            </div>
            <div class="col"></div>
            </div>

            <div class="mt-4">
                <asp:Button ID="btnUpdate" runat="server" Text="Actualizar" class="btn btn-primary" OnClick="btnUpdate_Click"/>
            </div>
        </div>
    </div>
    
</asp:Content>
