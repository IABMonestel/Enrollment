<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="InterfazWeb.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="card-header text-center">
            <h1>Sistema de Matrícula</h1>
        </div>
        <p class="mt-5 border-bottom">
            Bienvenido al sistema de matrícula de Contoso Education.
        </p>
        <p class="mt-5 border-bottom">
            Este sistema ofrece la posibilidad de habilitar materias para ser matriculadas, matricular a los 
            estudiantes, consultar las matrículas facturadas y establecer una nota final a los estudiantes.
        </p>
        <br /><br /><br />
    </div>
    <div class="position-relative">
        <div class="position-absolute top-200 start-50 translate-middle border border-3">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/img/img-edu.jpg" Width="200px" />

        </div>
    </div>
    <br /> <br />
    <div class="container">
        <p class="mt-5 border-bottom" width="100px">
            Además provee la oportunidad de dar mantenimiento a los registros de materias y aulas de la institución.
        </p>
    </div>
</asp:Content>
