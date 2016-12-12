<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ninos_busqueda.ascx.cs" Inherits="mod_ninos_ninos_busqueda" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%--<link rel="stylesheet" href="../css/jquery.fancybox-1.3.4.css" type="text/css" media="screen" />
    <!-- Bootstrap core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <!-- Bootstrap theme -->
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <!-- Custom styles for this template -->
    <link href="../css/theme.css" rel="stylesheet"> 
   
    <script src="../js/jquery-1.10.2.js"></script>
    <script src="../js/jquery.blockUI.js"></script>   
    <script src="../js/ie-emulation-modes-warning.js"></script>
    <script src="../js/jquery-ui.js"></script> 

    <!-- originales -->
<!-- gfontbrevis agrega senainfotools con herramientas como fijador de headers de tablas -->
    <script src="../js/senainfoTools.js"></script>
    <script src="../js/jquery.floatThead.js"></script>
    <script src="../js/jquery.dataTables.js"></script>
    <script src="../js/dataTables.bootstrap.js"></script>--%>

    <script type="text/javascript" src="../js/jquery.dataTables.js"></script>

    <script  type="text/javascript">

       

    </script>
<style type="text/css">
    /*body {
        margin-left: 0px;
        margin-top: 0px;
        margin-right: 0px;
        margin-bottom: 0px;
    }*/


</style>

<table width="100%" >
    <tr>
        <td valign="top">
            <h4><asp:Label  CssClass="subtitulo-form" ID="lbl003" runat="server" Text="Ni&ntilde;os en la RED" Visible="false"></asp:Label></h4>&nbsp;
        <asp:Label ID="lbl_error_ingreso" runat="server" CssClass="help-block"   Display="Dynamic"></asp:Label></td>
    </tr>
    <tr>
        <td valign="top">
            <!-- inicio gfontbrevis se agrega para fijar header -->
                         <div id="tableHeader1" class="fixed-header"></div>
                         <div id="tableContainer1" class="fixed-header-table-container">
                             <!-- fin -->
            <asp:GridView ID="grd001" CssClass="table table table-bordered table-hover caja-tabla text-center" OnRowDataBound="grd001_RowDataBound" runat="server" AllowPaging="False" Visible="False" AutoGenerateColumns="False" CellPadding="4"  GridLines="None" OnPageIndexChanging="grd001_PageIndexChanging" OnRowCommand="grd001_RowCommand" Width="99%" OnPageIndexChanged="grd001_PageIndexChanged">
                <HeaderStyle CssClass="titulo-tabla" />
                <Columns>
                    <asp:BoundField DataField="CodigoNi&#241;o" HeaderText="Codigo Ni&#241;o">
                        
                    </asp:BoundField>
                    <asp:BoundField DataField="Rut" HeaderText="RUN">
                        
                    </asp:BoundField>
                    <asp:BoundField DataField="sexo" HeaderText="Sexo">
                        
                    </asp:BoundField>
                    <asp:BoundField DataField="Nombres" HeaderText="Nombres">
                        
                    </asp:BoundField>
                    <asp:BoundField DataField="apellidopaterno" HeaderText="Apellido Paterno">
                       
                    </asp:BoundField>
                    <asp:BoundField DataField="apellidomaterno" HeaderText="Apellido Materno">
                        
                    </asp:BoundField>
                    <asp:BoundField DataField="fechadenacimiento" HeaderText="Fecha de Nacimiento" DataFormatString="{0:d}" HtmlEncode="False">
                       
                    </asp:BoundField>
                    <asp:ButtonField  Text="Ver Detalle Vigentes" CommandName="LINK">
                        
                        
                    </asp:ButtonField>
                    <asp:BoundField DataField="CantidadVecesVigenteEnOtrosProyectos" HeaderText="Nro de Vigentes">
                        
                    </asp:BoundField>
                    <asp:ButtonField Text="Ingresar" CommandName="INGRESAR" >
                    </asp:ButtonField>

                    <asp:ButtonField Text="Ingresar Niño Fallecido" CommandName="INGRESAR" >
                       
                    </asp:ButtonField>   

                </Columns>
                <PagerStyle CssClass="pager-tabla" ForeColor="White"/>
            </asp:GridView>
                             </div>

        </td>
    </tr>
    <tr>
        <td height="20" valign="top">&nbsp;</td>
    </tr>
    <tr>
        <td valign="top" style="height: 21px">

<h4> <asp:Label ID="lbl005" runat="server" CssClass="subtitulo-form"  Text="Ni&ntilde;os en PROYECTO" Visible="False"></asp:Label></h4></td>    </tr>
    <tr>
        <td valign="top">
            <!-- inicio gfontbrevis se agrega para fijar header -->
                         <%--<div id="tableHeader2" class="fixed-header"></div>--%>
                         <%--<div id="tableContainer2" class="fixed-header-table-container">--%>
                             <!-- fin -->
            <asp:GridView ID="grd002" CssClass="table table-bordered table-hover" data-name="Ninos_busqueda1_grd002" runat="server" AutoGenerateColumns="False" OnRowCommand="grd002_RowCommand" Width="100%" OnPageIndexChanging="grd002_PageIndexChanging">
                <HeaderStyle CssClass="titulo-tabla" />
                <Columns>
                    <asp:BoundField DataField="CodigoNi&#241;o" HeaderText="Codigo Ni&#241;o">
                       
                    </asp:BoundField>
                    <asp:BoundField DataField="ICodIE" HeaderText="ICodIE"> 
                        
                    </asp:BoundField>
                    <asp:BoundField DataField="Rut" HeaderText="RUN">
                      
                    </asp:BoundField>
                    <asp:BoundField DataField="apellidopaterno" HeaderText="Apellido Paterno">
                        
                    </asp:BoundField>
                    <asp:BoundField DataField="apellidomaterno" HeaderText="Apellido Materno">
                       
                    </asp:BoundField>
                    <asp:BoundField DataField="Nombres" HeaderText="Nombres">
                       
                    </asp:BoundField>
                    <asp:BoundField DataField="sexo" HeaderText="Sexo">
                        
                    </asp:BoundField>
                    <asp:BoundField DataField="fechadenacimiento" HeaderText="Fecha de Nacimiento" DataFormatString="{0:d}" HtmlEncode="False">
                        
                    </asp:BoundField>
                    
                    <asp:BoundField HeaderText="Fecha de Ingreso" DataField="FechaIngreso" DataFormatString="{0:d}" HtmlEncode="False">
                        
                    </asp:BoundField>
                    
                    <asp:ButtonField Text="Seleccionar" CommandName="SELECCIONAR">
                        
                       
                    </asp:ButtonField>
                </Columns>
                <HeaderStyle CssClass="Rut titulo-tabla" />
                <%--<PagerStyle CssClass="pager-tabla" ForeColor="White"/>--%>
                <RowStyle CssClass="text-center" />
            </asp:GridView>
                             <%--</div>--%>
        </td>
        <tr>
            <td valign="top"></td>
        </tr>
    <tr>
        <td style="height: 21px">
            <!-- inicio gfontbrevis se agrega para fijar header -->
                         <%--<div id="tableHeader3" class="fixed-header"></div>--%>
                         <%--<div id="tableContainer3" class="fixed-header-table-container">--%>
                             <!-- fin -->
            <asp:GridView ID="grd003" CssClass="table table table-bordered table-hover caja-tabla" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="grd002_RowCommand" Width="99%" OnPageIndexChanging="grd002_PageIndexChanging">
                <HeaderStyle CssClass="titulo-tabla" />
                <Columns>
                    <asp:BoundField DataField="CodigoNi&#241;o" HeaderText="Codigo Ni&#241;o">
                       
                    </asp:BoundField>
                    <asp:BoundField DataField="ICodIE" HeaderText="ICodIE">
                        
                    </asp:BoundField>
                    <asp:BoundField DataField="Rut" HeaderText="RUN">
                        
                    </asp:BoundField>
                    <asp:BoundField DataField="sexo" HeaderText="Sexo">
                       
                    </asp:BoundField>
                    <asp:BoundField DataField="Nombres" HeaderText="Nombres">
                        
                    </asp:BoundField>
                    <asp:BoundField DataField="apellidopaterno" HeaderText="Apellido Paterno">
                        
                    </asp:BoundField>
                    <asp:BoundField DataField="apellidomaterno" HeaderText="Apellido Materno">
                       
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Fecha de Ingreso" DataField="FechaIngreso" DataFormatString="{0:d}" HtmlEncode="False">
                       
                    </asp:BoundField>
                    <asp:BoundField DataField="fechadenacimiento" HeaderText="Fecha de Nacimiento" DataFormatString="{0:d}" HtmlEncode="False">
                       
                    </asp:BoundField>
                </Columns>
                <PagerStyle CssClass="pager-tabla" ForeColor="White"/>
                
            </asp:GridView>
                             <%--</div>--%>
        </td>
    </tr>

    <tr>
        <td valign="top">
            <h4>  <asp:Label ID="lbl006" CssClass="subtitulo-form" runat="server"   Text="Niños en LISTA DE ESPERA"
                Visible="False"></asp:Label></h4></td>
    </tr>
    <tr>
        <td valign="top">
            <!-- inicio gfontbrevis se agrega para fijar header -->
                         <div id="tableHeader4" class="fixed-header"></div>
                         <div id="tableContainer4" class="fixed-header-table-container">
                             <!-- fin -->
            <asp:GridView ID="grd_listaespera" CssClass="table table table-bordered table-hover caja-tabla" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" GridLines="None" OnRowCommand="grd_listaespera_RowCommand" Width="99%" OnPageIndexChanging="grd_listaespera_PageIndexChanging">
                <HeaderStyle CssClass="titulo-tabla" />
                <Columns>
                    <asp:TemplateField HeaderText="CODIGO NI&#209;O">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CodigoNino") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("CodigoNino") %>'></asp:Label>
                        </ItemTemplate>
                        
                    </asp:TemplateField>
                    <asp:BoundField DataField="Rut" HeaderText="RUN">
                        
                    </asp:BoundField>
                    <asp:BoundField DataField="sexo" HeaderText="Sexo">
                       
                    </asp:BoundField>
                    <asp:BoundField DataField="Nombres" HeaderText="Nombres">
                        
                    </asp:BoundField>
                    <asp:BoundField DataField="apellidopaterno" HeaderText="Apellido Paterno">
                       
                    </asp:BoundField>
                    <asp:BoundField DataField="apellidomaterno" HeaderText="Apellido Materno">
                       
                    </asp:BoundField>
                    <asp:BoundField DataField="fechadenacimiento" HeaderText="Fecha de Nacimiento" DataFormatString="{0:d}" HtmlEncode="False">
                       
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Fecha de Ingreso Lista de Espera" DataField="FechaIngresoLE" DataFormatString="{0:d}" HtmlEncode="False">
                       
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Cod Proyecto" DataField="CodProyecto" />
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Bind("CodigoNino") %>' CausesValidation="false" CommandName='<%# Bind("ICodIngresoLE") %>' Text="Ingresar">
                            </asp:LinkButton>
                        </ItemTemplate>
                      
                        
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            &nbsp;<asp:LinkButton ID="LinkButton33" runat="server" CausesValidation="false" CommandArgument='<%# Bind("CodigoNino") %>' CommandName='<%# Bind("ICodIngresoLE") %>' Text="Modificar"></asp:LinkButton>
                            
                                   <%--CommandName='<%# Bind("ICodIngresoLE") %>' CommandArgument='<%# Bind("CodigoNino") %>'--%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="codingresoLE" Visible="False" DataField="ICodIngresoLE" />

                </Columns>
                <PagerStyle CssClass="pager-tabla" ForeColor="White"/>
                
            </asp:GridView>
            </div>
        </td>

        
    </tr>
</table>

