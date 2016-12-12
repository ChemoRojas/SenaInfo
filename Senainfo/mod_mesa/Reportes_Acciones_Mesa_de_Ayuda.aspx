<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reportes_Acciones_Mesa_de_Ayuda.aspx.cs" Inherits="mod_mesa_Reportes_Acciones_Mesa_de_Ayuda" %>



<html lang="es">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico"> 
    <title>Mesa de Ayuda - Senainfo :: SERVICIO NACIONAL DE MENORES </title>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <script src="../js/jquery-ui.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">

    <link href="../css/theme.css" rel="stylesheet">
   <script src="../js/jquery.Rut.js"></script>
   <script src="../js/jquery-2.1.4.js"></script>
   <script src="../js/jquery-2.1.4.min.js"></script>
   <script src="../js/jquery-ui.js"></script>
   <script src="../js/senainfoTools.js"></script>
   <script src="../js/ie-emulation-modes-warning.js"></script>
   <script src="../Script/jquery.mousewheel-3.0.4.pack.js"></script>
   <link rel="stylesheet" type="text/css" href="../css/jquery.maxlength.css">
   <script src="../js/jquery.plugin.js"></script>
   <script src="../js/jquery.maxlength.js"></script>
      <script src="../js/jquery.Rut.js"></script>
  
    </head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="container theme-showcase" role="main">
                    <ol class="breadcrumb">
                        <li><a href="../index.aspx">Inicio</a></li>
                        <li class="active">Mesa de Ayuda</li>
                        <li class="active">Reportes Acciones Mesa de Ayuda</li>
                    </ol>
                    <div class="well">
                        <h4 class="subtitulo-form">Reportes Acciones Mesa de Ayuda</h4>
                        <hr />
                        <div class="row">
                            <div class="col-md-9">
                                <table class="table table-bordered table-condensed">
                                    <tr>
                                        <th class="titulo-tabla col-md-1" scope="row">Busqueda</th>
                                        <td>
                                            <asp:DropDownList ID="ddl_criterioBusqueda" runat="server">
                                                <asp:ListItem Value="0">Rut</asp:ListItem>
                                                <asp:ListItem Value="1">Nombre</asp:ListItem>
                                                <asp:ListItem Value="2">Usuario</asp:ListItem>
                                                <asp:ListItem Value="3">Codigo Proyecto</asp:ListItem>
                                                <asp:ListItem Value="4">Fecha</asp:ListItem>
                                            </asp:DropDownList> 
                                            <asp:TextBox ID="txt_search" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                   <tr>
                                       <td>
                                           <asp:GridView ID="grd_reportes" runat="server"  CssClass="table table-bordered table-hover" AutoGenerateColumns="False">

                                           </asp:GridView>
                                       </td>
                                   </tr>
                                        
                                </table>
                            </div>
                        </div>
                    </div>


                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    
    </div>
    </form>
</body>
</html>
