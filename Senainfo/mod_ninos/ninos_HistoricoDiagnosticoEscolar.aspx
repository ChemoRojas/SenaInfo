<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ninos_HistoricoDiagnosticoEscolar.aspx.cs" Inherits="mod_ninos_ninos_HistoricoDiagnosticoEscolar" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>



<html lang="es">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="img/favicon.ico">
    <title>Diagnóstico Escolar</title>

    <!-- Bootstrap core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet"/>
    <!-- Bootstrap theme -->
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet"/>
    <!-- Custom styles for this template -->
    <link href="../css/theme.css" rel="stylesheet"/> 



 <%--   <script src="../js/jquery-1.10.2.js"></script>
    <script src="../js/jquery-ui.js"></script>--%>
</head>
<body class="body-form">
    <form id="form1" runat="server">
        <div class="container">             
           <h4 class="text-center"><asp:Label CssClass="subtitulo-form" ID="lblmsg" runat="server" Visible="false" Text="No se encontraron registros."></asp:Label></h4>

             <table >
                <tr>
                    <td>
                      <asp:GridView ID="grdDescolar" CssClass="table table table-bordered table-hover" runat="server" CellPadding="4" GridLines="None" Width="100%" AutoGenerateColumns="False">
                        <HeaderStyle CssClass="titulo-tabla" /> 
                          <Columns>
                            <asp:BoundField AccessibleHeaderText="institucion" DataField="institucion" HeaderText="institución">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField AccessibleHeaderText="codproyecto" DataField="codproyecto" HeaderText="Cod. Proyecto">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField AccessibleHeaderText="proyecto" DataField="proyecto" HeaderText="Proyecto">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField AccessibleHeaderText="escolaridad" DataField="escolaridad" HeaderText="Escolaridad">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField AccessibleHeaderText="ultimo" DataField="ultimo" HeaderText="Año Escolaridad">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField AccessibleHeaderText="fecha" DataField="fecha" HeaderText="Fecha Diagnostico">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField AccessibleHeaderText="asistencia" DataField="asistencia" HeaderText="Asistencia Escolar">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            </Columns>
                      </asp:GridView>
                    </td>
                </tr>     
                 <tr><td>
                     <asp:linkButton ID="btn_exelEscolar" runat="server" OnClick="btn_exelEscolar_Click" CssClass="btn btn-success btn-sm fixed-width-button pull-right" >
               <span class="glyphicon glyphicon-floppy-save"></span>&nbsp;Exportar
           </asp:linkButton>
                     </td></tr>           
            </table>
        </div>
    </form>
        <script src="../js/jquery-1.9.1.js"></script>
        <script src="../js/jquery1.10.2.min.js"></script>
        <script src="../js/bootstrap3.3.4.min.js"></script>
        <script src="../js/ie-emulation-modes-warning.js"></script>
</body>
</html>
