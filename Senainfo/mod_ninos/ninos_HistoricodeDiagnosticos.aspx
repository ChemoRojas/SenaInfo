<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ninos_HistoricodeDiagnosticos.aspx.cs" Inherits="mod_ninos_ninos_HistoricodeDiagnosticos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Historico de Niños(as) y/o Jovenes</title>
   
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../css/theme.css" rel="stylesheet" /> 
</head>
<body class="body-form">
    <form id="form1" runat="server">
    <div>
        <h4 class="text-center"><asp:Label CssClass="subtitulo-form" ID="lblmsg" runat="server" Visible="false" Text="No se encontraron registros."></asp:Label></h4>

        <asp:GridView CssClass="table table table-bordered table-hover caja-tabla" ID="grd001" runat="server" AutoGenerateColumns="False" >
            <Columns>
                <asp:BoundField DataField="codigo" HeaderText="C&#243;digo">
                </asp:BoundField>
                <asp:BoundField DataField="FechaIngreso" HeaderText="Fecha Ingreso">
                </asp:BoundField>
                <asp:BoundField DataField="Causal_Ingreso_1" HeaderText="Causal Ingreso1">
                </asp:BoundField>
                <asp:BoundField DataField="Causal_Ingreso_2" HeaderText="Causal Ingreso2" >
                </asp:BoundField>
                <asp:BoundField DataField="Causal_Ingreso_3" HeaderText="Causal Ingreso3" >
                </asp:BoundField>
                <asp:BoundField DataField="rut" HeaderText="RUT" >
                </asp:BoundField>
                <asp:BoundField DataField="paterno" HeaderText="Apellido Paterno">
                </asp:BoundField>
                <asp:BoundField DataField="materno" HeaderText="Apellido Materno">
                </asp:BoundField>
                <asp:BoundField DataField="Nombres" HeaderText="Nombres">
                </asp:BoundField>
                <asp:BoundField DataField="codproyecto" HeaderText="C&#243;digo  Proyecto" >
                </asp:BoundField>
                <asp:BoundField DataField="proyecto" HeaderText="Proyecto" >
                </asp:BoundField>
                <asp:BoundField DataField="codinst" HeaderText="Cod. Instit.">
                </asp:BoundField>
                <asp:BoundField DataField="Nombreints" HeaderText="Instituci&#243;n" >
                </asp:BoundField>
                <asp:BoundField DataField="Modelo" HeaderText="Modelo" >
                </asp:BoundField>
                <asp:BoundField DataField="FechaEgreso" HeaderText="Fecha Egreso" >
                </asp:BoundField>
                <asp:BoundField DataField="Causal_Egreso" HeaderText="Causal Egreso" >
                </asp:BoundField>
                <asp:BoundField DataField="Con_Quien_Egresa" HeaderText="Con Quien Egresa" >
                </asp:BoundField>
            </Columns>
            <HeaderStyle CssClass="titulo-tabla" />
            <PagerStyle CssClass="titulo-tabla" ForeColor="White"/>                        
        </asp:GridView>
        <asp:LinkButton  ID="Webimagebutton2"  CssClass="btn btn-success btn-sm fixed-width-button pull-right" runat="server" OnClick="wibtnprint_Click" >
              <span class="glyphicon glyphicon-floppy-save"></span>&nbsp;Exportar
          </asp:LinkButton>
      </div>
    </form>
</body>
</html>
