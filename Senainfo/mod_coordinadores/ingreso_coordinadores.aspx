<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ingreso_coordinadores.aspx.cs" Inherits="mod_coordinadores_ingreso_coordinadores" Culture="es-CL" UICulture="es" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<%@ Register Assembly="SenameWebTextbox" Namespace="CustomWebControls" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Niños</title>
    <link href="../css/sename_aplica.css" rel="stylesheet" type="text/css" />
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <style type="text/css">
<!--
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
}
-->
</style>
    <link href="../css/sename_aplica.css" rel="stylesheet" type="text/css" />
</head>
<body onload="history.go(+1);">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>

    <cc1:SenameTextBox ID="SenameTextBox1" runat="server" Font-Names="Arial" Font-Size="11px"
                                                                                MaxLength="100" TextMode="MultiLine" Width="650px"></cc1:SenameTextBox>
        <asp:Panel ID="pnl_coordinador" runat="server">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td valign="top" style="height: 1071px">
                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="background-color: #ffffff">
                            <tr>
                                <td valign="top">
                                    <table width="1000" border="0" cellpadding="1" cellspacing="4">
                                        <tr valign="top">
                                            <td align="left">
                                                <asp:Panel ID="Panel2" runat="server" Width="100%">
                                                    <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                                        <tr>
                                                            <td class="titulo_form" colspan="2">
                                                                Busqueda de Niños<br />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="225" class="texto_form">
                                                                Rut Niño</td>
                                                            <td bgcolor="#ffffff" class="linea_inferior">
                                                              

                                                                 <asp:TextBox ID="txt007" runat="server" Font-Size="11px" Width="150px"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="txtRutValidator" runat="server" ControlToValidate="txt007"
                                                                    ErrorMessage="Formato de Rut Inválido" ValidationExpression="^(\d{2}\d{3}\d{3})-([a-zA-Z]{1}$|\d{1}$)" Font-Bold="True"></asp:RegularExpressionValidator>


                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="texto_form">
                                                                Cod. Niño</td>
                                                            <td bgcolor="#ffffff" class="linea_inferior">
                                                               
                                                                <asp:TextBox ID="txt002" runat="server" Font-Size="11px" Width="150px"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt002"
                                                                    ErrorMessage="Formato de Código inválido" ValidationExpression="^(\d{9})" Font-Bold="True"></asp:RegularExpressionValidator>


                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="texto_form">
                                                                Apellido Paterno</td>
                                                            <td bgcolor="#ffffff" class="linea_inferior" style="height: 26px">
                                                                <asp:TextBox ID="txt004" runat="server" Font-Size="11px" Width="450px"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="texto_form">
                                                                Apellido Materno</td>
                                                            <td bgcolor="#ffffff" class="linea_inferior">
                                                                <asp:TextBox ID="txt005" runat="server" Font-Size="11px" Width="450px"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="texto_form">
                                                                Nombres</td>
                                                            <td bgcolor="#ffffff" class="linea_inferior" style="height: 25px">
                                                                <asp:TextBox ID="txt006" runat="server" Font-Size="11px" Width="450px"></asp:TextBox>
                                                                <asp:Label ID="lblSwich" runat="server" Font-Size="1px" ForeColor="White" Width="1px"></asp:Label></td>
                                                        </tr>
                                                    </table>
                                                    <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                                        <tr>
                                                            <td bgcolor="#ffffff" align="center">
                                       
                                                                <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn_buscar" runat="server" Text="Buscar" OnClick="btn_buscar_Click" />



                                                                &nbsp;&nbsp;
                                                    
                                                                <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn_modificar" runat="server" Text="Modificar" OnClick="btn_modificar_Click" />

                                                                &nbsp;&nbsp;
                                                    
                                                                <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn_limpiar" runat="server" Text="Limpiar" OnClick="btn_limpiar_Click" />


                                                                &nbsp; &nbsp;
                                                     
                                                                <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn_volver" runat="server" Text="Volver" OnClick="btn_volver_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                                        <tr>
                                                            <td bgcolor="#ffffff" style="text-align: center; width: 1000px;">
                                                                <asp:Label ID="lbl0013" runat="server" Font-Size="Small" ForeColor="#0253B7" Text="0"
                                                                    Visible="False"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td bgcolor="#ffffff" style="text-align: center; width: 1000px;">
                                                                <asp:Label ID="lbl0014" runat="server" ForeColor="#0253B7" Text="Coincidencias" Visible="False"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td bgcolor="#ffffff" style="text-align: center; width: 1000px;">
                                                                <asp:Label ID="lbl0015" runat="server" ForeColor="#0253B7" Text="Coincidencias" Visible="False"></asp:Label>
                                                                <asp:LinkButton ID="lnk001" runat="server" Font-Size="Small" Visible="False" OnClick="lnk001_Click">INGRESAR NUEVO NIÑO</asp:LinkButton>
                                                                <asp:LinkButton ID="lnk002" runat="server" Font-Size="Small" Visible="False" OnClick="lnk002_Click1">VER RESULTADOS</asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td bgcolor="#ffffff" style="width: 1000px;">
                                                                <asp:GridView ID="grd004" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                                    CellPadding="2" ForeColor="#333333" GridLines="None" OnRowCommand="grd004_RowCommand"
                                                                    Visible="False" Width="100%" OnPageIndexChanging="grd004_PageIndexChanging">
                                                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                                    <Columns>
                                                                        <asp:BoundField DataField="CodNino" HeaderText="CODIGO NI&#209;O">
                                                                            <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                                                            <HeaderStyle Width="40px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="ICodIngreso" HeaderText="COD. INGRESO">
                                                                            <ItemStyle Font-Size="11px" HorizontalAlign="Center" Width="75px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Rut" HeaderText="RUT">
                                                                            <ItemStyle Font-Size="11px" HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="sexo" HeaderText="SEXO">
                                                                            <ItemStyle Font-Size="11px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Nombres" HeaderText="NOMBRES">
                                                                            <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Apellido_paterno" HeaderText="APELLIDO PATERNO">
                                                                            <HeaderStyle Width="60px" />
                                                                            <ItemStyle Font-Size="11px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Apellido_Materno" HeaderText="APELLIDO MATERNO">
                                                                            <HeaderStyle Width="60px" />
                                                                            <ItemStyle Font-Size="11px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="FechaNacimiento" DataFormatString="{0:d}" HeaderText="FECHA DE NACIMIENTO"
                                                                            HtmlEncode="False">
                                                                            <ItemStyle Font-Size="11px" HorizontalAlign="Left" Height="11px" />
                                                                            <HeaderStyle Width="80px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="FechaDerivacion" HeaderText="FECHA DE INGRESO" DataFormatString="{0:d}"
                                                                            Visible="False">
                                                                            <ItemStyle Font-Size="11px" HorizontalAlign="Left" Height="11px" />
                                                                            <HeaderStyle Width="80px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="codregion" HeaderText="REGION">
                                                                            <ItemStyle Font-Size="11px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="ruc">
                                                                            <ControlStyle Font-Size="1px" />
                                                                            <ItemStyle Font-Size="1px" ForeColor="White" Width="1px" />
                                                                            <HeaderStyle Font-Size="1px" Width="1px" />
                                                                        </asp:BoundField>
                                                                        <asp:ButtonField CommandName="ruc" DataTextField="ruc" HeaderText="RUC">
                                                                            <ControlStyle Font-Underline="True" ForeColor="Red" />
                                                                            <ItemStyle Font-Underline="True" ForeColor="Red" Font-Size="11px" />
                                                                        </asp:ButtonField>
                                                                        <asp:BoundField DataField="rit" HeaderText="RIT">
                                                                            <ItemStyle Font-Size="11px" Height="11px" />
                                                                        </asp:BoundField>
                                                                        <asp:ButtonField CommandName="ver" Text="Ver">
                                                                            <ItemStyle Font-Size="11px" ForeColor="Red" Width="30px" />
                                                                        </asp:ButtonField>
                                                                        <asp:ButtonField CommandName="historico" Text="Historial">
                                                                            <ItemStyle Font-Size="11px" ForeColor="Red" />
                                                                        </asp:ButtonField>
                                                                        <asp:ButtonField CommandName="eliminar" Text="Eliminar" Visible="False">
                                                                            <ItemStyle Font-Size="11px" ForeColor="Red" />
                                                                        </asp:ButtonField>
                                                                    </Columns>
                                                                    <RowStyle BackColor="#EFF3FB" Font-Names="Arial" Font-Size="11px" />
                                                                    <EditRowStyle BackColor="#2461BF" />
                                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="10px"
                                                                        ForeColor="White" HorizontalAlign="Left" />
                                                                    <AlternatingRowStyle BackColor="White" Font-Names="Arial" Font-Size="11px" />
                                                                </asp:GridView>
                                                                <asp:LinkButton ID="btnproy" runat="server" OnClick="btnproy_Click"></asp:LinkButton></td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:Label ID="lblbmsg" runat="server" Font-Size="Medium" ForeColor="#0253B7" Text="Coincidencias"
                                        Visible="False"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="pnl001" runat="server" Width="100%" Visible="false">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="1" valign="top" class="linea_inferior" style="height: 244px">
                                                </td>
                                                <td style="height: 244px">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr valign="top">
                                                            <td class="titulo_form" style="width: 1002px;">
                                                                Datos del Niño</td>
                                                        </tr>
                                                        <tr valign="top" align="left">
                                                            <td valign="top" style="width: 1002px;">
                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td width="1" rowspan="1" valign="top" class="linea_inferior">
                                                                        </td>
                                                                        <td style="font-weight: normal; color: #000066">
                                                                            Fecha de Nacimiento:
                                                                            <asp:Label ID="lbl003" runat="server" Font-Size="11px" ForeColor="#0253B7"></asp:Label><br />
                                                                            Código del Niño :
                                                                            <asp:Label ID="lbl004" runat="server" Font-Size="11px" ForeColor="#0253B7"></asp:Label><br />
                                                                            <asp:Label ID="lbl006" runat="server" Visible="False">Código de Ingreso : </asp:Label>
                                                                            <asp:Label ID="lbl005" runat="server" ForeColor="#0253B7" Visible="False"></asp:Label><br />
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>










                                 
                                 


                                                         
                                    <Ajax:TabContainer runat="server" ID="Tabs" Height="250px"  ActiveTabIndex="0" Width="100%" AutoPostBack="true" Font-Italic="false" Visible="false" BorderStyle="Solid" BackColor="#0056D7">

                                        <Ajax:TabPanel ID="t1" runat="server" HeaderText="1 - Ordenes del tribunal">
                                            <ContentTemplate>
                                                <asp:UpdatePanel ID="Updatepanel1" runat="server">
                                                    <ContentTemplate>
                                                        <table width="100%" border="0" cellspacing="1" cellpadding="1">
                                                        <tr>
                                                            <td bgcolor="#ffffff">
                                                                <table border="0" cellpadding="1" cellspacing="1" width="WIDTH: 1000px">
                                                                    <tr>
                                                                        <td colspan="4" bgcolor="#ffffff">
                                                                            <asp:GridView ID="grd001" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                                ForeColor="#333333" Width="100%" OnRowCommand="grd001_RowCommand">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="CodTribunal" Visible="False">
                                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="11px"></ItemStyle>
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="Descripcion" HeaderText="Tribunal">
                                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="11px"></ItemStyle>
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="Fecha" HeaderText="Fecha Orden" DataFormatString="{0:d}">
                                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="11px"></ItemStyle>
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="sentenciaejecutoriada" HeaderText="Sentencia Ejec.">
                                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="11px"></ItemStyle>
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="RUC" HeaderText="RUC">
                                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="11px"></ItemStyle>
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="RIT" HeaderText="RIT">
                                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="11px"></ItemStyle>
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="codigo" HeaderText="codigo" Visible="False">
                                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                                    </asp:BoundField>
                                                                                    <asp:ButtonField Text="Quitar">
                                                                                        <ItemStyle HorizontalAlign="Center" Font-Size="11px"></ItemStyle>
                                                                                    </asp:ButtonField>
                                                                                </Columns>
                                                                                <RowStyle BackColor="White" BorderColor="SteelBlue" />
                                                                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="10px"
                                                                                    ForeColor="White" HorizontalAlign="Left" />
                                                                            </asp:GridView>
                                                                            <asp:Label ID="lbl_mensajeOT" runat="server" CssClass="texto_rojo_peque" Visible="False"
                                                                                Width="100%"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="texto_form" width="225" style="height: 26px">
                                                                            Region</td>
                                                                        <td bgcolor="#ffffff" style="height: 26px">
                                                                            <asp:DropDownList ID="ddown014" runat="server" AutoPostBack="True" Width="300px"
                                                                                OnSelectedIndexChanged="ddown014_SelectedIndexChanged" Font-Size="11px">
                                                                            </asp:DropDownList></td>
                                                                        <td class="texto_form" style="width: 200px; height: 26px;">
                                                                            Tipo de Tribunal</td>
                                                                        <td bgcolor="#ffffff" style="width: 301px; height: 26px;">
                                                                            <asp:DropDownList ID="ddown015" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown015_SelectedIndexChanged"
                                                                                Width="300px" Font-Size="11px">
                                                                            </asp:DropDownList></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="texto_form" width="200" style="height: 22px">
                                                                            Tribunal</td>
                                                                        <td bgcolor="#ffffff" style="height: 22px">
                                                                            <span>
                                                                                <asp:DropDownList ID="ddown016" runat="server" Width="300px" Font-Size="11px">
                                                                                </asp:DropDownList>
                                                                            </span>
                                                                        </td>
                                                                        <td class="texto_form">
                                                                            Sentencia Ejecutoriada</td>
                                                                        <td bgcolor="#ffffff">
                                                                            <asp:RadioButtonList ID="rdo001" runat="server" ForeColor="Black" RepeatDirection="Horizontal">
                                                                                <asp:ListItem Value="1">Si</asp:ListItem>
                                                                                <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                                                                                <asp:ListItem Value="2">Sin Informaci&#243;n</asp:ListItem>
                                                                            </asp:RadioButtonList></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="texto_form">
                                                                            RUC</td>
                                                                        <td bgcolor="#ffffff">
                                                   
                                                                            <asp:TextBox ID="txt006F2" runat="server" Font-Size="11px" Width="250px"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="txtRucValidator" runat="server" ControlToValidate="txt006F2"
                                                                    ErrorMessage="Formato de Rut Inválido" ValidationExpression="^(\d{7}|\d{8}|\d{9})([a-zA-Z]{1}$|\d{1}$)" Font-Bold="True"></asp:RegularExpressionValidator>



                                                                        </td>
                                                                        <td class="texto_form" style="width: 200px">
                                                                            RIT</td>
                                                                        <td bgcolor="#ffffff">
                                                                   
                                                                            <asp:TextBox ID="txt007F2" runat="server" Width="250px" />

                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="texto_form">
                                                                            Fecha</td>
                                                                        <td bgcolor="#ffffff">
                                  
                                                                            <asp:TextBox ID="ddown017" runat="server" Text="Seleccione Fecha" Font-Size="11px" TextMode="SingleLine" ReadOnly="false"></asp:TextBox>
                                                                            <Ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender1" Enabled="true" runat="server" ViewStateMode="Enabled" TargetControlID="ddown017" Format="dd-MM-yyyy" ValidateRequestMode="Enabled"></Ajax:CalendarExtender>


                                                                           
                                                                        </td>
                                                                        <td style="width: 200px" align="right" colspan="2" bgcolor="#ffffff">
                                                                            <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn001" runat="server" Text="Agregar Orden Tribunal" OnClick="btn001_Click"
                                                                                Font-Size="11px" /></td>
                                                                    </tr>
                                                                </table>
                                                                <asp:Label ID="lbl_mensajefecha" runat="server" CssClass="texto_rojo_peque" Width="100%"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td bgcolor="#ffffff">
                                                                <br />
                                                                &nbsp;
                                
                                                                <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnnext003" runat="server" Text="Siguiente >>" OnClick="btnnext" />



                                                                <asp:TextBox ID="txtfoco" runat="server" BorderStyle="None" Font-Size="1px" Height="1px"
                                                                    ReadOnly="True" Width="1px"></asp:TextBox></td>
                                                        </tr>
                                                    </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </ContentTemplate>
                                        </Ajax:TabPanel>

                                        <Ajax:TabPanel ID="t2" runat="server" HeaderText="2 - Delito">
                                            <ContentTemplate>
                                                <asp:UpdatePanel ID="Updatepanel2" runat="server">
                                                    <ContentTemplate>
                                                        <table width="100%" border="0" cellspacing="1" cellpadding="1">
                                                        <tr>
                                                            <td bgcolor="#ffffff">
                                                                <asp:GridView ID="grd002" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                    ForeColor="#333333" Width="100%" OnRowCommand="grd002_RowCommand">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="CodTipoCausalIngreso" Visible="False">
                                                                            <ItemStyle HorizontalAlign="Left" Font-Size="11px"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="CodCausalIngreso" HeaderText="CodCausalIngreso" Visible="False">
                                                                            <ItemStyle HorizontalAlign="Left" Font-Size="11px"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="DescripcionTipo" HeaderText="Tipo Causal de Ingreso">
                                                                            <ItemStyle HorizontalAlign="Left" Font-Size="11px"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Descripcion" HeaderText="Causal de Ingreso">
                                                                            <ItemStyle HorizontalAlign="Left" Font-Size="11px"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="coddelito" HeaderText="Codigo Delito" />
                                                                        <asp:BoundField DataField="codigo">
                                                                            <ControlStyle Width="1px" />
                                                                            <ItemStyle BackColor="White" Font-Size="1px" ForeColor="White" Width="1px" />
                                                                            <HeaderStyle HorizontalAlign="Justify" VerticalAlign="Bottom" Width="1px" />
                                                                            <FooterStyle Width="1px" />
                                                                        </asp:BoundField>
                                                                        <asp:ButtonField Text="Quitar" CommandName="QUITAR">
                                                                            <ItemStyle HorizontalAlign="Center" Font-Size="11px"></ItemStyle>
                                                                        </asp:ButtonField>
                                                                    </Columns>
                                                                    <RowStyle BackColor="White" BorderColor="SteelBlue" />
                                                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="10px"
                                                                        ForeColor="White" HorizontalAlign="Left" />
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td bgcolor="#ffffff" style="height: 18px">
                                                                <asp:Label ID="lbl_causales" runat="server" Text="Label" Width="100%" CssClass="texto_rojo_peque"
                                                                    Visible="False"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td bgcolor="#ffffff">
                                                                <table width="100%" border="0" cellspacing="1" cellpadding="1">
                                                                    <tr>
                                                                        <td class="texto_form" style="width: 229px">
                                                                            <asp:Label ID="lbl_otc" runat="server" Text="Orden de Tribunal"></asp:Label></td>
                                                                        <td bgcolor="#ffffff">
                                                                            <asp:DropDownList ID="ddown_otc" runat="server" AppendDataBoundItems="True" Width="750px"
                                                                                Font-Size="11px">
                                                                            </asp:DropDownList></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="texto_form" style="width: 229px">
                                                                            Tipo Delito</td>
                                                                        <td bgcolor="#ffffff">
                                                                            <asp:DropDownList ID="ddown018" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                                                                Width="750px" OnSelectedIndexChanged="ddown018_SelectedIndexChanged" Font-Size="11px">
                                                                                <asp:ListItem Value="0">Seleccionar </asp:ListItem>
                                                                            </asp:DropDownList></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="texto_form" style="width: 229px; height: 26px;">
                                                                            Delito</td>
                                                                        <td bgcolor="#ffffff" style="height: 26px">
                                                                            <asp:DropDownList ID="ddown019" runat="server" Width="750px" Font-Size="11px" OnSelectedIndexChanged="ddown019_SelectedIndexChanged1"
                                                                                AutoPostBack="True">
                                                                                <asp:ListItem Value="0">Seleccionar </asp:ListItem>
                                                                            </asp:DropDownList></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="texto_form" style="width: 229px">
                                                                            C&oacute;digo Delito</td>
                                                                        <td bgcolor="#ffffff">
                                                                           
                                                                            <asp:TextBox ID="TextBox2" runat="server" Enabled="false" />



                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" bgcolor="#ffffff">
                                                                <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn002" runat="server" Text="Agregar Delito" Font-Size="11px" OnClick="btn002_Click" /></td>
                                                        </tr>
                                                        <tr>
                                                            <td bgcolor="#ffffff">
                                                                <br />
                                                                &nbsp;
                    
                                                                <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnback003" runat="server" Text="<< Atras" OnClick="btnback" />

                                                                <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnnext004" runat="server" Text="Siguiente >>" OnClick="btnnext" />

                                                                <asp:TextBox ID="txtfoco2" runat="server" BorderStyle="None" Font-Size="1px" Height="1px"
                                                                    ReadOnly="True" Width="1px"></asp:TextBox></td>
                                                        </tr>
                                                    </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </ContentTemplate>
                                        </Ajax:TabPanel>

                                        <Ajax:TabPanel ID="t3" runat="server" HeaderText="3 - Resolución Tribunal">
                                            <ContentTemplate>
                                                <asp:UpdatePanel ID="Updatepanel3" runat="server">
                                                    <ContentTemplate>
                                                        <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                                        <tr valign="top">
                                                            <td class="texto_form" style="width: 227px; height: 14px;" colspan="2">
                                                            </td>
                                                        </tr>
                                                        <tr valign="top">
                                                            <td bgcolor="#ffffff" style="height: 16px" colspan="2">
                                                                <asp:GridView ID="grd001_Resolucion" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                    ForeColor="#333333" Width="100%" OnRowCommand="grd001_RowCommand">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="OrdenTribunal" HeaderText="Orden de Tribunal">
                                                                            <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="ResolucionTribunal" HeaderText="Resoluci&#243;n Tribunal">
                                                                            <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Proyecto" HeaderText="Proyecto">
                                                                            <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="FechaDerivacion" HeaderText="Fecha de Derivaci&#243;n"
                                                                            DataFormatString="{0:d}">
                                                                            <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                                                        </asp:BoundField>
                                                                    </Columns>
                                                                    <RowStyle BackColor="White" BorderColor="SteelBlue" />
                                                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="10px"
                                                                        ForeColor="White" HorizontalAlign="Left" />
                                                                </asp:GridView>
                                                        </tr>
                                                        <tr valign="top">
                                                            <td class="texto_form" style="width: 227px">
                                                                Orden Tribunal</td>
                                                            <td bgcolor="#ffffff">
                                                                &nbsp;<asp:DropDownList ID="ddown03_ot" runat="server" AppendDataBoundItems="True"
                                                                    Width="750px" Font-Size="11px">
                                                                </asp:DropDownList></td>
                                                        </tr>
                                                        <tr valign="top">
                                                            <td class="texto_form" style="width: 227px">
                                                                Resolucion Tribunal&nbsp;</td>
                                                            <td bgcolor="#ffffff">
                                                                &nbsp;<asp:DropDownList ID="ddown03_rt" runat="server" AppendDataBoundItems="True"
                                                                    Width="750px" Font-Size="11px" AutoPostBack="True" OnSelectedIndexChanged="ddown03_rt_SelectedIndexChanged">
                                                                    <asp:ListItem Value="0">Seleccionar </asp:ListItem>
                                                                </asp:DropDownList></td>
                                                        </tr>
                                                       
                                                        <tr valign="top">
                                                            <td class="texto_form" style="width: 227px">
                                                                Proyecto</td>
                                                            <td bgcolor="#ffffff">
                                                                &nbsp;<asp:DropDownList ID="ddown03_Proy" runat="server" AppendDataBoundItems="True"
                                                                    Width="750px" Font-Size="11px" OnSelectedIndexChanged="ddown03_Proy_SelectedIndexChanged">
                                                                    <asp:ListItem Value="0">Seleccionar </asp:ListItem>
                                                                </asp:DropDownList></td>
                                                        </tr>
                                                        <tr valign="top">
                                                            <td class="texto_form" style="width: 227px">
                                                                Fecha Derivación
                                                            </td>
                                                            <td bgcolor="#ffffff">
                                 
                                                                 <asp:TextBox ID="ddown001" runat="server" Text="Seleccione Fecha" Font-Size="11px" TextMode="SingleLine" ReadOnly="false"></asp:TextBox>
                                                                 <Ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender4" Enabled="true" runat="server" ViewStateMode="Enabled" TargetControlID="ddown001" Format="dd-MM-yyyy" ValidateRequestMode="Enabled"></Ajax:CalendarExtender>


                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" bgcolor="#ffffff" colspan="2">
                                                                <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn003" runat="server" Text="Agregar Resolución" Font-Size="11px"
                                                                    OnClick="btn003_Click" /></td>
                                                        </tr>
                                                        <tr valign="top">
                                                            <td bgcolor="#ffffff" colspan="2" align="left" style="height: 31px">
               
                                                                <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnback002" runat="server" Text="<< Atras" OnClick="btnback" />


                                                                <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnnext001" runat="server" Text="Siguiente >>" OnClick="btnnext" />

                                                            </td>
                                                        </tr>
                                                    </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </ContentTemplate>
                                        </Ajax:TabPanel>

                                        <Ajax:TabPanel ID="t4" runat="server" HeaderText="4 - Plazos Medida e Investigación">
                                            <ContentTemplate>
                                                <asp:UpdatePanel ID="Updatepanel4" runat="server">
                                                    <ContentTemplate>
                                                        <table width="100%" border="0" cellspacing="1" cellpadding="1">
                                                        <tr>
                                                            <td class="titulo_form">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td bgcolor="#ffffff">
                                                                &nbsp;<asp:GridView ID="grd004_lrpaMedInv" runat="server" AutoGenerateColumns="False"
                                                                    OnRowCommand="grd001LRPA_RowCommand" CellPadding="4" ForeColor="#333333" UseAccessibleHeader="False"
                                                                    Visible="False" Font-Size="800px">
                                                                    <Columns>
                                                                        <asp:BoundField HeaderText="Cod. Orden Tribunal" DataField="IcodOrdenTribunal" Visible="False">
                                                                            <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField HeaderText="F.  Inicio" DataField="FechaInicio" DataFormatString="{0:d}">
                                                                            <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="FechaTermino" HeaderText="F. Termino" DataFormatString="{0:d}">
                                                                            <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="DuracionDia" HeaderText="Plazo Medida">
                                                                            <HeaderStyle Font-Names="11px" />
                                                                            <ItemStyle Font-Size="11px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="PlazoInvestigacion" HeaderText="Plazo de Investigacion">
                                                                            <ItemStyle Font-Size="11px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="FechaPlazoInvestigacion" DataFormatString="{0:d}" HeaderText="F. Plazo de Investigacion">
                                                                            <ItemStyle Font-Size="11px" />
                                                                        </asp:BoundField>
                                                                        <asp:ButtonField Text="Quitar" />
                                                                    </Columns>
                                                                    <RowStyle BackColor="White" BorderColor="SteelBlue" />
                                                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="10px"
                                                                        ForeColor="White" HorizontalAlign="Left" />
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td bgcolor="#ffffff" align="center">
                                                                <table width="100%" border="0" cellspacing="1" cellpadding="1">
                                                                    <tr>
                                                                        <td class="texto_form" align="left" style="width: 227px">
                                                                            <asp:Label ID="lbl_otm" runat="server" Text="Orden de Tribunal"></asp:Label></td>
                                                                        <td bgcolor="#ffffff" align="left">
                                                                            <asp:DropDownList ID="ddown4_otm" runat="server" AppendDataBoundItems="True" Width="700px"
                                                                                Font-Size="11px">
                                                                            </asp:DropDownList></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="texto_form" align="left" style="width: 227px">
                                                                            Fecha Inicio</td>
                                                                        <td align="left">
                           
                                                                            <asp:TextBox ID="wdcMedInv" runat="server" Text="Seleccione Fecha" Font-Size="11px" TextMode="SingleLine" ReadOnly="false"></asp:TextBox>
                                                                            <Ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender5" Enabled="true" runat="server" ViewStateMode="Enabled" TargetControlID="wdcMedInv" Format="dd-MM-yyyy" ValidateRequestMode="Enabled"></Ajax:CalendarExtender>



                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="texto_form" align="left" style="width: 227px">
                                                                            Plazo Medida</td>
                                                                        <td>
                                                                            &nbsp;<table width="100%" style="height: 100%;" border="0" cellspacing="0" cellpadding="0">
                                                                                <tr>
                                                                                    <td align="left" width="150">
                                                                                        
                                                                                        <asp:TextBox ID="txtLrpa_PlazMed" runat="server" Width="50px"></asp:TextBox>
                                                                                        <Ajax:MaskedEditExtender ID="MaskedEditExtender9"  TargetControlID="txtLrpa_PlazMed" Mask="999" MaskType="Number" Enabled="true" MessageValidatorTip="true" DisplayMoney="None" runat="server"></Ajax:MaskedEditExtender>

                                                                                        &nbsp;Dias</td>
                                                                                    <td class="texto_form" align="left" width="100">
                                                                                        Plazo Investigación</td>
                                                                                    <td align="left">
                                                                                    
                                                                                        <asp:TextBox ID="txtLrpa_PlazInv" runat="server" Width="50px"></asp:TextBox>
                                                                                        <Ajax:MaskedEditExtender ID="MaskedEditExtender1"  TargetControlID="txtLrpa_PlazInv" Mask="999" MaskType="Number" Enabled="true" MessageValidatorTip="true" DisplayMoney="None" runat="server"></Ajax:MaskedEditExtender>

                                                                                        &nbsp; &nbsp;Días &nbsp;
                                                                                        <asp:LinkButton ID="lnkLrpa_calculaPlazo" runat="server" OnClick="lnkLrpa_calculaPlazofunc">CALCULAR FECHA</asp:LinkButton>
                                                                                        &nbsp;&nbsp; &nbsp;
                                                                                        <asp:Label ID="lblmsg_plazo" runat="server" CssClass="texto_rojo_peque"></asp:Label></td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="texto_form" align="left" style="width: 227px">
                                                                            Fecha Plazo medida</td>
                                                                        <td align="left">
                                                                            &nbsp;<table width="100%" style="height: 100%;" border="0" cellspacing="0" cellpadding="0">
                                                                                <tr>
                                                                                    <td align="left" width="150">
                                                                                        <asp:TextBox ID="TxtLrpa_FechPlazMed" runat="server" Enabled="False" Width="100px"></asp:TextBox></td>
                                                                                    <td class="texto_form" align="left" width="100">
                                                                                        Fecha&nbsp; Plazo Investigación</td>
                                                                                    <td align="left">
                                                                                        <asp:TextBox ID="TxtLrpa_FechPlazInv" runat="server" Enabled="False" Width="100px"></asp:TextBox></td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="texto_form" align="left" style="width: 227px">
                                                                            <asp:Label ID="lblAmpliaInvestigacion" runat="server" Text="Amplia Investigación"></asp:Label></td>
                                                                        <td bgcolor="#ffffff" align="left">
                                                                        
                                                                            <asp:TextBox ID="txtAmplDias" runat="server"></asp:TextBox>
                                                                            <Ajax:MaskedEditExtender ID="TextBox1MaskedEditExtender1" runat="server" Enabled="true" Mask="9999"  MaskType="Number" TargetControlID="txtAmplDias"></Ajax:MaskedEditExtender>

                                                                            &nbsp;
                                                                            <asp:Label ID="lblEtDias" runat="server" Text="Días"></asp:Label>&nbsp; &nbsp; &nbsp;
                                                                            &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                                                            <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn_AmpliaPLazo" runat="server" Text="Amplia Plazo Investigación"
                                                                                OnClick="btn_AmpliaPLazo_Click" Font-Size="11px" Width="140px" />&nbsp;<asp:Label
                                                                                    ID="lblAmpl" runat="server" CssClass="texto_rojo_peque" Visible="False"></asp:Label></td>
                                                                    </tr>
                                                                </table>
                                                                <asp:GridView ID="grdLrpa_Actuaplazo" runat="server" AutoGenerateColumns="False"
                                                                    OnRowCommand="grd001LRPA_RowCommand" CellPadding="4" ForeColor="#333333" Visible="False">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="FechaActualizacion" HeaderText="Fecha Actualizaci&#243;n"
                                                                            DataFormatString="{0:d}" />
                                                                        <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                                                                        <asp:BoundField DataField="dias" HeaderText="D&#237;as" />
                                                                    </Columns>
                                                                    <RowStyle BackColor="White" BorderColor="SteelBlue" />
                                                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="10px"
                                                                        ForeColor="White" HorizontalAlign="Left" />
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Panel ID="pnl1LRPA" runat="server" Width="100%">
                                                                    <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                                                        <tr>
                                                                            <td align="center" bgcolor="#ffffff">
                                                                                <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnAgregarMedSanc" runat="server" Text="Agregar Medida" OnClick="btnAgregarMedSanc_Click"
                                                                                    Font-Size="11px" Height="22px" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" bgcolor="#ffffff">

                                                                                <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="Button1" runat="server" Text="<< Atras" OnClick="btnback" />

                                                                                <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="Button2" runat="server" Text="Siguiente >>" OnClick="btnnext" />

                                                                                &nbsp;<asp:TextBox ID="txtfoco3" runat="server" BorderStyle="None" Font-Size="1px"
                                                                                    Height="1px" ReadOnly="True" Width="1px"></asp:TextBox></td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:Panel>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </ContentTemplate>
                                        </Ajax:TabPanel>

                                        <Ajax:TabPanel ID="t5" runat="server" HeaderText="4 - Sanción">
                                            <ContentTemplate>
                                                <asp:UpdatePanel ID="Updatepanel5" runat="server">
                                                    <ContentTemplate>
                                                        <div>
                                                        <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                                            <tr>
                                                                <td class="titulo_form" style="height: 20px">
                                                                    <br />
                                                                    <asp:Label ID="lbl_aviso_graba" runat="server" CssClass="texto_rojo_peque"></asp:Label></td>
                                                            </tr>
                                                        </table>
                                                        <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                                            <tr>
                                                                <td style="background-color: #ffffff">
                                                                    <asp:Panel ID="Panel3" runat="server" Width="100%">
                                                                        <table width="100%">
                                                                            <tr>
                                                                                <td bgcolor="#ffffff" colspan="5" style="background-color: #ffffff;">
                                                                                    <asp:GridView ID="grdseleccionLRPA" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                                        ForeColor="#333333" OnRowCommand="grdseleccionLRPA_RowCommand" Width="100%">
                                                                                        <Columns>
                                                                                            <asp:BoundField DataField="ICodOrdenTribunal" HeaderText="C&#243;digo" />
                                                                                            <asp:BoundField DataField="FechaInicio" HeaderText="Fecha Inicio" DataFormatString="{0:d}">
                                                                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField DataField="FechaTermino" HeaderText="Fecha T&#233;rmino" DataFormatString="{0:d}">
                                                                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                                                                            </asp:BoundField>
                                                                                            <asp:ButtonField CommandName="ver" Text="Quitar">
                                                                                                <ItemStyle Font-Size="11px" ForeColor="Red" />
                                                                                            </asp:ButtonField>
                                                                                        </Columns>
                                                                                        <RowStyle BackColor="White" BorderColor="SteelBlue" />
                                                                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="10px"
                                                                                            ForeColor="White" HorizontalAlign="Left" />
                                                                                    </asp:GridView>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="background-color: #ffffff;">
                                                                                    &nbsp;</td>
                                                                            </tr>
                                                                            
                                                                        </table>
                                                                    </asp:Panel>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <asp:Panel ID="pnldatos" runat="server" Width="100%">
                                                            <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                                                <tr>
                                                                    <td style="background-color: #ffffff;">
                                                                        <table border="0" cellpadding="0" cellspacing="1" width="100%">
                                                                            <tr>
                                                                                <td class="texto_form" width="225" style="height: 19px">
                                                                                    <asp:Label ID="Label1" runat="server" Text="Orden de Tribunal"></asp:Label></td>
                                                                                <td style="background-color: #ffffff; height: 19px;">
                                                                                    <asp:DropDownList ID="ddown_otm" runat="server" AppendDataBoundItems="True" Font-Size="11px"
                                                                                        Width="100%">
                                                                                    </asp:DropDownList></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="texto_form" width="225">
                                                                                    Fecha Inicio</td>
                                                                                <td>
                                                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                        <tr>
                                                                                            <td style="background-color: #ffffff">
                                                                                                
                                                                                                 <asp:TextBox ID="ddown001LRPA" runat="server" Text="Seleccione Fecha" Font-Size="11px" TextMode="SingleLine" ReadOnly="false"></asp:TextBox>
                                                                                                 <Ajax:CalendarExtender FirstDayOfWeek="Monday" ID="ddown001LRPACalendarExtender1" Enabled="true" runat="server" ViewStateMode="Enabled" TargetControlID="ddown001LRPA" Format="dd-MM-yyyy" ValidateRequestMode="Enabled"></Ajax:CalendarExtender>


                                                                                                <asp:Label ID="lblfechaini1LRPA" runat="server" CssClass="texto_rojo_peque"></asp:Label>
                                                                                            </td>
                                                                                            <td style="background-color: #ffffff">
                                                                                                Horas trabajo comunidad:
                                                                                              
                                                                                                <asp:TextBox ID="txt0010LRPA" runat="server" Width="50px"></asp:TextBox>
                                                                                    <Ajax:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txt0010LRPA" Enabled="true" EnableViewState="true" MaskType="Number" Mask="9999999"></Ajax:MaskedEditExtender>

                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="texto_form">
                                                                                    Duración dictaminada por Tribunal &nbsp;&nbsp;</td>
                                                                                <td style="background-color: #ffffff">
                                                                                  
                                                                                    <asp:TextBox ID="txt001LRPA" runat="server" Width="50px"></asp:TextBox>
                                                                                    <Ajax:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txt001LRPA" Enabled="true" EnableViewState="true" MaskType="Number" Mask="999"></Ajax:MaskedEditExtender>

                                                                                    &nbsp; Años&nbsp;
                                                                                 
                                                                                     <asp:TextBox ID="txt002LRPA" runat="server" Width="50px"></asp:TextBox>
                                                                                    <Ajax:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txt002LRPA" Enabled="true" EnableViewState="true" MaskType="Number" Mask="999"></Ajax:MaskedEditExtender>

                                                                                    &nbsp; Meses &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                                                                
                                                                                     <asp:TextBox ID="txt007LRPA" runat="server" Width="50px"></asp:TextBox>
                                                                                    <Ajax:MaskedEditExtender ID="MaskedEditExtender10" runat="server" TargetControlID="txt007LRPA" Enabled="true" EnableViewState="true" MaskType="Number" Mask="99"></Ajax:MaskedEditExtender>



                                                                                    &nbsp; &nbsp;Días &nbsp; &nbsp; &nbsp;
                                                                                  
                                                                                     <asp:TextBox ID="txt009LRPA" runat="server" Width="50px"></asp:TextBox>
                                                                                    <Ajax:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txt009LRPA" Enabled="true" EnableViewState="true" MaskType="Number" Mask="9999999"></Ajax:MaskedEditExtender>

                                                                                    &nbsp; Abono &nbsp; &nbsp;&nbsp; &nbsp;<asp:LinkButton ID="LinkButton1" runat="server"
                                                                                        OnClick="lnk001coor_Click">CALCULAR FECHA</asp:LinkButton>
                                                                                    &nbsp; &nbsp;
                                                                                    <asp:Label ID="lbl_avisoDuracionLRPA" runat="server" CssClass="texto_rojo_peque"></asp:Label></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="texto_form">
                                                                                    Fecha Termino</td>
                                                                                <td style="background-color: #ffffff">
                                                                                    <asp:TextBox ID="txt003LRPA" runat="server" Enabled="False"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="texto_form">
                                                                                    Sanción Mixta</td>
                                                                                <td style="background-color: #ffffff">
                                                                                    <asp:CheckBox ID="Chk002LRPAMixta" runat="server" AutoPostBack="True" OnCheckedChanged="Chk002LRPAMixta_CheckedChanged" />
                                                                                    <asp:Label ID="LblfechaLRPA" runat="server" CssClass="texto_rojo_peque"></asp:Label></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="background-color: #ffffff;">
                                                                        <asp:Panel ID="pnlLRPAmixta" runat="server" Height="50px" Visible="False" Width="100%">
                                                                            <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                                                                <tr>
                                                                                    <td class="texto_form" width="225">
                                                                                        Fecha Inicio Mixta</td>
                                                                                    <td style="background-color: #ffffff">
    
                                                                                         <asp:TextBox ID="ddown009LRPA" runat="server" Text="Seleccione Fecha" Font-Size="11px" TextMode="SingleLine" ReadOnly="false"></asp:TextBox>
                                                                                         <Ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender2" Enabled="true" runat="server" ViewStateMode="Enabled" TargetControlID="ddown009LRPA" Format="dd-MM-yyyy" ValidateRequestMode="Enabled"></Ajax:CalendarExtender>



                                                                                        <asp:Label ID="lblfechaini2LRPA" runat="server" CssClass="texto_rojo_peque"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="texto_form">
                                                                                        Duración dictaminada por Tribunal</td>
                                                                                    <td style="background-color: #ffffff">
                                                                                   <asp:TextBox ID="TextBox1" runat="server" Width="50px"></asp:TextBox>
                                                                                    <Ajax:MaskedEditExtender ID="MaskedEditExtender6" runat="server" TargetControlID="TextBox1" Enabled="true" EnableViewState="true" MaskType="Number" Mask="999"></Ajax:MaskedEditExtender>

                                                                                        &nbsp; Años&nbsp;
                                                                                        
                                                                                          <asp:TextBox ID="txt004LRPA" runat="server" Width="50px"></asp:TextBox>
                                                                                    <Ajax:MaskedEditExtender ID="MaskedEditExtender7" runat="server" TargetControlID="txt004LRPA" Enabled="true" EnableViewState="true" MaskType="Number" Mask="99" ></Ajax:MaskedEditExtender>

                                                                                        &nbsp;&nbsp; Meses &nbsp;&nbsp; &nbsp;
                                                                                      
                                                                                          <asp:TextBox ID="txt008LRPA" runat="server" Width="50px"></asp:TextBox>
                                                                                    <Ajax:MaskedEditExtender ID="MaskedEditExtender8" runat="server" TargetControlID="txt008LRPA" DisplayMoney="None" Enabled="true" EnableViewState="true" MaskType="Number" Mask="99" ></Ajax:MaskedEditExtender>


                                                                                        &nbsp; &nbsp;Días &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                                                        &nbsp; &nbsp; &nbsp;
                                                                                        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="lnk002_Click">CALCULAR FECHA</asp:LinkButton>&nbsp;
                                                                                        <asp:Label ID="lbl_avisoDuracion2LRPA" runat="server" CssClass="texto_rojo_peque"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="texto_form">
                                                                                        Fecha Termino Mixta</td>
                                                                                    <td style="background-color: #ffffff">
                                                                                        <asp:TextBox ID="txt006LRPA" runat="server" Enabled="False"></asp:TextBox></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="texto_form">
                                                                                        Modelo Sanción Mixta</td>
                                                                                    <td style="background-color: #ffffff">
                                                                                        <asp:DropDownList ID="ddown011LRPA" runat="server" AppendDataBoundItems="True" Font-Size="11px"
                                                                                            OnSelectedIndexChanged="ddown004LRPA_SelectedIndexChanged" Width="250px" AutoPostBack="True">
                                                                                            <asp:ListItem Value="-1"> Seleccionar</asp:ListItem>
                                                                                        </asp:DropDownList></td>
                                                                                </tr>
                                                                            </table>
                                                                        </asp:Panel>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="background-color: #ffffff;">
                                                                        <asp:LinkButton ID="lnk_limpiaFechas" runat="server" OnClick="lnk_limpiaFechas_Click">RESETEAR FECHAS</asp:LinkButton></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="background-color: #ffffff;">
                                                                        <table border="0" cellpadding="0" cellspacing="1" width="100%">
                                                                            <tr>
                                                                                <td class="texto_form" width="225">
                                                                                    Región</td>
                                                                                <td bgcolor="#ffffff" colspan="3" style="background-color: #ffffff">
                                                                                    <asp:DropDownList ID="ddown003LRPA" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                                                                        Font-Size="11px" OnSelectedIndexChanged="ddown004LRPA_SelectedIndexChanged" Width="445px">
                                                                                        <asp:ListItem Value="0"> Seleccionar</asp:ListItem>
                                                                                    </asp:DropDownList></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="texto_form">
                                                                                    Tipo Tribunal</td>
                                                                                <td bgcolor="#ffffff" style="background-color: #ffffff">
                                                                                    <asp:DropDownList ID="ddown004LRPA" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                                                                        Font-Size="11px" OnSelectedIndexChanged="ddown004LRPA_SelectedIndexChanged" Width="250px">
                                                                                        <asp:ListItem Value="0"> Seleccionar</asp:ListItem>
                                                                                    </asp:DropDownList></td>
                                                                                <td bgcolor="#ffffff" class="texto_form" style="width: 102px">
                                                                                    Tribunal
                                                                                </td>
                                                                                <td bgcolor="#ffffff" style="background-color: #ffffff">
                                                                                    <asp:DropDownList ID="ddown005LRPA" runat="server" AppendDataBoundItems="True" Font-Size="11px"
                                                                                        Width="251px" OnSelectedIndexChanged="ddown005LRPA_SelectedIndexChanged">
                                                                                        <asp:ListItem Value="0"> Seleccionar</asp:ListItem>
                                                                                    </asp:DropDownList></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="texto_form">
                                                                                    Sanción Accesoria (Sí)</td>
                                                                                <td bgcolor="#ffffff" style="background-color: #ffffff;">
                                                                                    <asp:CheckBox ID="chk001LRPA" runat="server" AutoPostBack="True" OnCheckedChanged="chk001LRPA_CheckedChanged" /></td>
                                                                                <td bgcolor="#ffffff" style="background-color: #ffffff;">
                                                                                    &nbsp;</td>
                                                                                <td bgcolor="#ffffff" style="background-color: #ffffff;">
                                                                                    &nbsp;</td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="background-color: #ffffff;">
                                                                        <table border="0" bordercolor="#ffffff" cellpadding="0" cellspacing="1" width="100%">
                                                                            <tr>
                                                                                <td class="texto_form" width="225" style="height: 24px">
                                                                                    Tipo(s) de sanción accesoria</td>
                                                                                <td align="left" bgcolor="#ffffff" style="height: 24px; background-color: #ffffff">
                                                                                    <asp:DropDownList ID="ddown006LRPA" runat="server" AppendDataBoundItems="True" Font-Size="11px"
                                                                                        Visible="False" Width="600px">
                                                                                        <asp:ListItem Value="0"> Seleccionar</asp:ListItem>
                                                                                    </asp:DropDownList></td>
                                                                            </tr>
                                                                        </table>
                                                                        <asp:Panel ID="Panel1" runat="server" Width="100%">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td style="background-color: #ffffff;">
                         
                                                                                        <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnAgregarTsancionLRPA" runat="server" Text="Agregar Tipo Sanción" OnClick="btnAgregarTsancionLRPA_Click" />

                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="background-color: #ffffff;">
                                                                                        <asp:Label ID="lbl_avisoLRPA" runat="server" CssClass="texto_rojo_peque" Visible="False"
                                                                                            Width="100%"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="background-color: #ffffff;">
                                                                                        <asp:GridView ID="grd001LRPA" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                                            ForeColor="#333333" Width="100%">
                                                                                            <Columns>
                                                                                                <asp:BoundField DataField="descripcion" HeaderText="CodSancion" HtmlEncode="False">
                                                                                                    <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="CodSancion" HeaderText="Descripcion">
                                                                                                    <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="CodTipoSancionAccesoria" HeaderText="CodTipoSanci&#243;n">
                                                                                                    <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                                                                                </asp:BoundField>
                                                                                            </Columns>
                                                                                            <RowStyle BackColor="White" BorderColor="SteelBlue" />
                                                                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="10px"
                                                                                                ForeColor="White" HorizontalAlign="Left" />
                                                                                        </asp:GridView>
                                                                                        <asp:LinkButton ID="lnb001" runat="server" OnClick="lnb001_Click" Width="1px"></asp:LinkButton></td>
                                                                                </tr>
                                                                            </table>
                                                                        </asp:Panel>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="text-align: right">
                                                                        <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="Button3" runat="server" Text="Agregar Sanción" Font-Size="11px" OnClick="btnnextcoor" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td bgcolor="#ffffff" style="background-color: #ffffff;">
                                                                        <asp:Panel ID="pnlTermino" runat="server" Width="100%">
                                                                            <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                                                                <tr>
                                                                                    <td bgcolor="#ffffff" style="background-color: #ffffff;">
                                                                                        <asp:Label ID="lbl_aviso2LRPA" runat="server" CssClass="texto_rojo_peque" Visible="False"
                                                                                            Width="100%"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="background-color: #ffffff;">
                                                                                        <asp:Panel ID="pnlTermino2" runat="server">
                                                                                            <table border="0" cellpadding="0" cellspacing="1" width="100%" id="TABLE1">
                                                                                                <tr>
                                                                                                    <td class="texto_form" width="225">
                                                                                                        Fecha de Termino Sanción</td>
                                                                                                    <td bgcolor="#ffffff" style="background-color: #ffffff;">
                                                                                                      
                                                                                         <asp:TextBox ID="ddown007LRPA" runat="server" Text="Seleccione Fecha" Font-Size="11px" TextMode="SingleLine" ReadOnly="false"></asp:TextBox>
                                                                                         <Ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender3" Enabled="true" runat="server" ViewStateMode="Enabled" TargetControlID="ddown007LRPA" Format="dd-MM-yyyy" ValidateRequestMode="Enabled"></Ajax:CalendarExtender>


                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="texto_form" width="225">
                                                                                                        Situación del Termino de la Sanción</td>
                                                                                                    <td bgcolor="#ffffff" style="background-color: #ffffff;">
                                                                                                        <asp:DropDownList ID="ddown008LRPA" runat="server" AppendDataBoundItems="True" Font-Size="11px"
                                                                                                            Width="644px">
                                                                                                            <asp:ListItem Value="0"> Seleccionar</asp:ListItem>
                                                                                                        </asp:DropDownList></td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </asp:Panel>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left" bgcolor="#ffffff" style="background-color: #ffffff;">
                                                                                        
                                                                                        <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="Button4" runat="server" Text="<< Atras" OnClick="btnback" />

               
                                                                                        <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="Button5" runat="server" Text="Siguiente >>"  OnClick="btnnext"/>

                                                                                        <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn_GuardarLRPA" runat="server" Text="Guardar" OnClick="btnnextcoor" />

                                                                                        &nbsp;&nbsp; &nbsp;
                                                                                        <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnAtras" runat="server" Text="Cancelar" OnClick="btnAtras_Click" />

                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </asp:Panel>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </ContentTemplate>
                                        </Ajax:TabPanel>

                                        <Ajax:TabPanel ID="t6" runat="server" HeaderText="5 - Audiencia">
                                            <ContentTemplate>
                                                <asp:UpdatePanel ID="Updatepanel6" runat="server">
                                                    <ContentTemplate>
                                                        <table width="100%" border="0" cellspacing="1" cellpadding="1">
                                                        <tr>
                                                            <td bgcolor="#ffffff">
                                                                <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <asp:GridView ID="grd001Audiencia" runat="server" AutoGenerateColumns="False" Width="100%"
                                                                                OnRowCommand="grd001Audiencia_RowCommand" CellPadding="4" ForeColor="#333333">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="codot">
                                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="1px" ForeColor="White" Width="1px"></ItemStyle>
                                                                                        <HeaderStyle Width="1px" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="codtipoaudiencia" HeaderText="CodTipoAudiencia" Visible="False">
                                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="11px"></ItemStyle>
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="tipoaudiencia" HeaderText="Tipo de Audiencia">
                                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="11px"></ItemStyle>
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="resolucion" HeaderText="Resoluci&#243;n" />
                                                                                    <asp:BoundField DataField="fecha" DataFormatString="{0:d}" HeaderText="Fecha" />
                                                                                    <asp:ButtonField Text="Quitar">
                                                                                        <ItemStyle HorizontalAlign="Center" Font-Size="11px"></ItemStyle>
                                                                                    </asp:ButtonField>
                                                                                </Columns>
                                                                                <RowStyle BackColor="White" BorderColor="SteelBlue" />
                                                                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="10px"
                                                                                    ForeColor="White" HorizontalAlign="Left" />
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="texto_form" width="225">
                                                                            Orden de Tribunal</td>
                                                                        <td bgcolor="#ffffff">
                                                                            <asp:DropDownList ID="ddown_ota" runat="server" AppendDataBoundItems="True" Width="400px"
                                                                                Font-Size="11px">
                                                                            </asp:DropDownList></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="texto_form" width="225">
                                                                            Fecha</td>
                                                                        <td bgcolor="#ffffff">
                                                                     
                                                                            <asp:TextBox ID="ddown001Audiencia" runat="server" Text="Seleccione Fecha" Font-Size="11px" TextMode="SingleLine" ReadOnly="false"></asp:TextBox>
                                                                            <Ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender6" Enabled="true" runat="server" ViewStateMode="Enabled" TargetControlID="ddown001Audiencia" Format="dd-MM-yyyy" ValidateRequestMode="Enabled"></Ajax:CalendarExtender>


                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="texto_form" width="225">
                                                                            Tipo de Audiencia</td>
                                                                        <td bgcolor="#ffffff">
                                                                            <asp:DropDownList ID="ddown021" runat="server" AppendDataBoundItems="True" Width="250px"
                                                                                Font-Size="11px">
                                                                                <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                                                            </asp:DropDownList></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="texto_form">
                                                                            Observaciones</td>
                                                                        <td colspan="1">
                                                                            <cc1:SenameTextBox ID="SenameTextBox2" runat="server" Font-Names="Arial" Font-Size="11px"
                                                                                MaxLength="100" TextMode="MultiLine" Width="650px"></cc1:SenameTextBox></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td bgcolor="#ffffff">
                                                                        </td>
                                                                        <td bgcolor="#ffffff" align="right">
                                                                            <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn001AgregarAudiencia" runat="server" Text="Agregar Audiencia" OnClick="btn001AgregarAudiencia_Click"
                                                                                Font-Size="11px" /></td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td bgcolor="#ffffff" style="height: 31px">
                                                                
                                                                <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnback004" runat="server" Text="<< Atras" OnClick="btnback" />

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td bgcolor="#ffffff" align="center">
                                                                <br />
                                                              
                                                                <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnsaveingreso" runat="server" Text="Realizar Ingreso" OnClick="btnsaveingreso_Click1" />

                                                                &nbsp;&nbsp;
                                                                
                                                               
                                                                <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnactualizaingreso" runat="server" Text="Actualizar Datos" Visible="false" OnClick="btnactualizaingreso_Click" />

                                                                &nbsp;&nbsp;
                                                              
                                                                <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnvolverAudiencia" runat="server" Text="Volver"  OnClick="btnvolverAudiencia_Click"/>

                                                                <asp:TextBox ID="txtfoco4" runat="server" BorderStyle="None" Font-Size="1px" Height="1px"
                                                                    ReadOnly="True" Width="1px"></asp:TextBox></td>
                                                        </tr>
                                                    </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </ContentTemplate>
                                        </Ajax:TabPanel>

                                        <Ajax:TabPanel ID="t7" runat="server" HeaderText="6 - Cierre Causa">
                                            <ContentTemplate>
                                                <asp:UpdatePanel ID="Updatepanel7" runat="server">
                                                    <ContentTemplate>
                                                        <table width="100%" border="0" cellspacing="1" cellpadding="1">
                                                        <tr>
                                                            <td bgcolor="#ffffff">
                                                                <asp:GridView ID="grd001CierreCausa" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                                    CellPadding="2" ForeColor="#333333" GridLines="None" Visible="False" Width="100%">
                                                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                                    <Columns>
                                                                        <asp:BoundField DataField="ICodIE" HeaderText="COD. INGRESO">
                                                                            <ItemStyle Font-Size="11px" HorizontalAlign="Center" Width="75px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="codnino" HeaderText="CODIGO NI&#209;O">
                                                                            <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                                                            <HeaderStyle Width="40px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="NombreCompleto" HeaderText="NOMBRE COMPLETO">
                                                                            <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="codproyecto" HeaderText="COD. PROYECTO" />
                                                                        <asp:BoundField DataField="nombre" HeaderText="NOMBRE" />
                                                                        <asp:BoundField DataField="fechaingreso" HeaderText="FECHA DE INGRESO" DataFormatString="{0:d}"
                                                                            Visible="False">
                                                                            <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                                                            <HeaderStyle Width="80px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="fechaegreso" DataFormatString="{0:d}" HeaderText="FECHA EGRESO"
                                                                            HtmlEncode="False">
                                                                            <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                                                            <HeaderStyle Width="80px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="EgresaPor" HeaderText="EGRESA POR">
                                                                            <ItemStyle Font-Size="11px" HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="FechaOrden" HeaderText="FECHA ORDEN" DataFormatString="{0:d}" />
                                                                        <asp:BoundField DataField="Ruc" HeaderText="RUC" />
                                                                        <asp:BoundField DataField="Rit" HeaderText="RIT" />
                                                                    </Columns>
                                                                    <RowStyle BackColor="#EFF3FB" Font-Names="Arial" Font-Size="11px" />
                                                                    <EditRowStyle BackColor="#2461BF" />
                                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="10px"
                                                                        ForeColor="White" HorizontalAlign="Left" />
                                                                    <AlternatingRowStyle BackColor="White" Font-Names="Arial" Font-Size="11px" />
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" bgcolor="#ffffff">
                                                            
                                                                <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="wib001ExpXls" runat="server" Text="Exportar a Excel" OnClick="wib001ExpXls_Click" />

                                                            </td>
                                                        </tr>
                                                    </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </ContentTemplate>
                                        </Ajax:TabPanel>

                                    </Ajax:TabContainer>





                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:GridView ID="grd003" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            CellPadding="2" ForeColor="#333333" GridLines="None" OnPageIndexChanging="grd003_PageIndexChanging"
            OnRowCommand="grd003_RowCommand" Visible="False" Width="1000px">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:BoundField DataField="CodNino" HeaderText="COD. NI&#209;O">
                    <ItemStyle Font-Size="11px" HorizontalAlign="Left" Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="Rut" HeaderText="RUT">
                    <ItemStyle Font-Size="11px" HorizontalAlign="Right" Width="75px" />
                </asp:BoundField>
                <asp:BoundField DataField="Sexo" HeaderText="SEXO" Visible="False">
                    <ItemStyle Font-Size="11px" HorizontalAlign="Center" Width="30px" />
                </asp:BoundField>
                <asp:BoundField DataField="Nombres" HeaderText="NOMBRES">
                    <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Apellido_paterno" HeaderText="APELLIDO PATERNO">
                    <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Apellido_Materno" HeaderText="APELLIDO MATERNO">
                    <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="FechaNacimiento" DataFormatString="{0:d}" HeaderText="FECHA DE NACIMIENTO"
                    HtmlEncode="False">
                    <ItemStyle Font-Size="11px" HorizontalAlign="Left" Width="80px" />
                </asp:BoundField>
                <asp:ButtonField CommandName="ingresar" Text="Ingresar">
                    <ItemStyle Font-Size="11px" ForeColor="Red" />
                </asp:ButtonField>
                <asp:ButtonField CommandName="Historial" Text="Ver Historial">
                    <ItemStyle Font-Size="11px" ForeColor="Red" />
                </asp:ButtonField>
            </Columns>
            <RowStyle BackColor="#EFF3FB" Font-Names="Arial" Font-Size="11px" />
            <EditRowStyle BackColor="#2461BF" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="10px"
                ForeColor="White" HorizontalAlign="Left" />
            <AlternatingRowStyle BackColor="White" Font-Names="Arial" Font-Size="11px" />
        </asp:GridView>
        <asp:Panel ID="pnlAvisoElimina" runat="server" Width="1000px" Visible="False">
            <table width="400" height="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tbody>
                    <tr>
                        <td height="1" valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="1">
                                        <img src="../images/log_top1.jpg" width="71" height="29" /></td>
                                    <td background="../images/log_top3.jpg">
                                        <img src="../images/log_top3.jpg" width="77" height="29" /></td>
                                    <td width="1">
                                        <img src="../images/log_top22.jpg" width="116" height="29" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="38" valign="top" background="../images/log_fondologo.jpg" class="fdoizq">
                                        <img src="../images/log_fondologo.jpg" width="38" height="123" /></td>
                                    <td>
                                        <div align="center">
                                            <!--Aplicación-->
                                            <table border="0" align="center" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="4">
                                                            <tr>
                                                                <td align="center" class="titulo2" style="height: 13px">
                                                                    ¿Esta seguro que desea eliminar el ingreso del niño
                                                                    <asp:Label ID="lbl_nino" runat="server"></asp:Label>
                                                                    código del niño
                                                                    <asp:Label ID="lbl_CodNino" runat="server"></asp:Label>?</td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" class="titulo2">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" class="titulo2">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" class="titulo2">
                                                                  
                                                                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn_Acepta" runat="server" Text="Aceptar" OnClick="btn_Acepta_Click" />


                                                                    &nbsp;&nbsp;
                                                               
                                                                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />

                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <!--Fín Aplicación-->
                                        </div>
                                    </td>
                                    <td width="1" valign="top" background="../images/log_fdorayader.jpg">
                                        <span class="fdoizq">
                                            <img src="../images/log_fdorayader.jpg" width="13" height="5" alt="" /></span></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#f7f7fb" style="height: 13px">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="1">
                                        <img src="../images/log_inf_1.jpg" width="69" height="13" alt="" /></td>
                                    <td background="../images/log_inf_2.jpg">
                                        <img src="../images/log_inf_2.jpg" width="70" height="13" alt="" /></td>
                                    <td width="1">
                                        <img src="../images/log_inf_3.jpg" width="88" height="13" alt="" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
        </asp:Panel>
    </form>
</body>
</html>
