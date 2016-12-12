<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ninos_HistoricoDiagnosticoCapacitacion.aspx.cs" Inherits="mod_ninos_ninos_HistoricoDiagnosticoCapacitacion" %>

<html lang="es">
<head id="Head1" runat="server">
    <title>Histórico Diagnóstico Capacitación</title>
    <link rel="stylesheet" href="../css/jquery.fancybox-1.3.4.css" type="text/css" media="screen" />
    <!-- Bootstrap core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet"/>
    <!-- Bootstrap theme -->
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet"/>
    <!-- Custom styles for this template -->
    <link href="../css/theme.css" rel="stylesheet"/> 
    <script src="../js/ie-emulation-modes-warning.js"></script>


    <script src="../js/jquery-1.10.2.js"></script>
    <script src="../js/jquery-ui.js"></script>
</head>

<body class="body-form">
    <form id="form1" runat="server">
        <div class="container">
          <h4 class="text-center"><asp:Label CssClass="subtitulo-form" ID="lblmsg" runat="server" Visible="false" Text="No se encontraron registros."></asp:Label></h4>

            <table >
                <tr>
                    <td>
                        <asp:GridView ID="grdcapacitacion" CssClass="table table table-bordered table-hover" runat="server" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
                           <HeaderStyle CssClass="titulo-tabla" />
                            <Columns>
                                <asp:BoundField DataField="institucion" HeaderText="Institucion" />
                                <asp:BoundField DataField="codproyecto" HeaderText="Cod. Proyecto" />
                                <asp:BoundField DataField="proyecto" HeaderText="Proyecto" />
                                <asp:BoundField DataField="area" HeaderText="Area Capacitación" />
                                <asp:BoundField DataField="tipo" HeaderText="Tipo Capacitación" />
                                <asp:BoundField DataField="estado" HeaderText="Estado Capacitación" />
                                <asp:BoundField DataField="organismo" HeaderText="Organismo Capacitación" />
                                <asp:BoundField DataField="inicio" HeaderText="Fecha Inicio" />
                                <asp:BoundField DataField="termino" HeaderText="Fecha Término" />
                            </Columns>
                        </asp:GridView>
                        </td>
                    </tr>      <tr><td>
                        <asp:LinkButton ID="btn_exelCapacitacion" runat="server" CssClass="btn btn-success btn-sm fixed-width-button pull-right" OnClick="btn_exelCapacitacion_Click" >
              <span class="glyphicon glyphicon-floppy-save"></span>&nbsp;Exportar
          </asp:LinkButton>
                                   </td></tr>          
                </table>
        </div>
    </form>
</body>
</html>