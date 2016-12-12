<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bsc_PII.aspx.cs" Inherits="mod_ninos_bsc_PII" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Buscador Instituciones</title>
    <link href="../css/sename_aplica.css" rel="stylesheet" type="text/css" />

     <link rel="stylesheet" href="../css/jquery.fancybox-1.3.4.css" type="text/css" media="screen" />

    <script type="text/javascript" src="../Script/jquery.min.js"></script>    
    <script type="text/javascript" src="../Script/jquery.mousewheel-3.0.4.pack.js"></script>
    <script src="../Script/jquery-1.4.3.min.js" type="text/javascript"></script>
    <script src="../Script/jquery.fancybox-1.3.4.js" type="text/javascript"></script>

     <script language="javascript" type="text/javascript">

         $(document).ready(function () {
             $(".ifancybox").fancybox({
                 'width': '75%',
                 'height': '75%',
                 'autoScale': false,
                 'transitionIn': 'none',
                 'transitionOut': 'none',
                 'type': 'iframe'
             });
         });

         function CerrarFancybox() {
             parent.$.fancybox.close();
         }

         function AbrirURLFancybox(url, cod) {
             if (cod != 0)
                 parent.location.replace(url);
             else
                 alert('Sin Grupo');
         }

    </script>

    <style type="text/css">
        .auto-style1 {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 10px;
            color: #ffffff;
            font-weight: bolder;
            background-color: #066CB7;
            padding-left: 2px;
            height: 22px;
        }

        .auto-style2 {
            height: 22px;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel6" runat="server">    
            <Triggers>
                <asp:PostBackTrigger ControlID="imb002" />
                <asp:PostBackTrigger ControlID="lbl0015" />
                <asp:PostBackTrigger ControlID="grd001" />
            </Triggers>
            <ContentTemplate>  

            <table width="100%" border="0" cellpadding="1" cellspacing="1">
                <tr>
                    <td class="titulo_form" height="25px">&nbsp;Buscador Plan Intervención</td>
                </tr>

                <tr>
                    <td>
                        <asp:Panel ID="pnl001" runat="server">
                            <table width="100%" border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td width="200" class="texto_form">Cod. Plan Intervencion</td>
                                    <td bgcolor="#ffffff">
                                        <asp:TextBox ID="txt001" runat="server" Width="150px" Font-Size="11px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="texto_form">Cod. Niño</td>
                                    <td bgcolor="#ffffff">
                                        <asp:TextBox ID="txt002" runat="server" Width="150px" Font-Size="11px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="texto_form">Apellido Paterno</td>
                                    <td bgcolor="#ffffff">
                                        <asp:TextBox ID="txt004" runat="server" Width="150px" Font-Size="11px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="texto_form">Apellido Materno</td>
                                    <td bgcolor="#ffffff">
                                        <asp:TextBox ID="txt005" runat="server" Width="150px" Font-Size="11px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">Nombres</td>
                                    <td bgcolor="#ffffff" class="auto-style2">
                                        <asp:TextBox ID="txt006" runat="server" Width="150px" Font-Size="11px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="texto_form">Run</td>
                                    <td bgcolor="#ffffff">
                                        <asp:TextBox ID="txt007" runat="server" Width="150px" Font-Size="11px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="texto_form">Institución</td>
                                    <td bgcolor="#ffffff">(<asp:Label ID="lbl001" runat="server" Font-Size="11px"></asp:Label>) &nbsp;<asp:Label ID="lbl002" runat="server" Font-Size="11px"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="texto_form">Proyecto</td>
                                    <td align="left" bgcolor="#ffffff">
                                        <asp:Label ID="lbl003" runat="server" Visible="False" Font-Size="11px"></asp:Label><asp:Label ID="lbl004" runat="server" Font-Size="11px"></asp:Label></td>
                                </tr>

                                <tr>
                                    <td class="texto_form">Grupo </td>
                                    <td bgcolor="#ffffff">
                                        <asp:LinkButton ID="lnk001" runat="server" ForeColor="Navy"
                                            OnClick="lnk001_Click">Ver>></asp:LinkButton>

                                        <asp:DropDownList ID="ddown001" runat="server" Width="350px" Font-Size="11px" Visible="False">
                                        </asp:DropDownList>

                                    </td>
                                </tr>
                                <tr>
                                    <td class="texto_form">Técnico
                                    </td>
                                    <td bgcolor="#ffffff">
                                        <asp:LinkButton ID="lnk002" runat="server" ForeColor="Navy"
                                            OnClick="lnk002_Click">Ver>></asp:LinkButton>

                                        <asp:DropDownList ID="ddown002" runat="server" Width="350px" Font-Size="11px" Visible="False">
                                        </asp:DropDownList>

                                    </td>
                                </tr>

                            </table>
                        </asp:Panel>

                    </td>
                </tr>

                <tr>
                    <td align="center">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="center" style="height: 29px">
                                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="imb001" runat="server" Text="Buscar" OnClick="imb001_Click" CausesValidation="False" />
                                    &nbsp;
                                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="imb002" runat="server" Text="Limpiar" OnClick="imb002_Click" CausesValidation="False" />
                                    &nbsp;
                                    <a id="myLink" title="Click to do something" href="#" onclick="CerrarFancybox();return false;"><asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="Button1" runat="server" Text="Cerrar" CausesValidation="False" /></a>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lbl0013" runat="server" Font-Size="XX-Large" ForeColor="#0253B7" Text="0" Visible="False"></asp:Label><br />
                                    <asp:Label ID="lbl0014" runat="server" Font-Size="Small" ForeColor="#0253B7" Text="Coincidencias" Visible="False"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:LinkButton ID="lbl0015" runat="server" OnClick="lbl0015_Click" Visible="False">Ver Resultados</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>

                                    <asp:GridView ID="grd001" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        CellPadding="2" ForeColor="#333333" GridLines="None" Width="100%" OnPageIndexChanging="grd001_PageIndexChanging" Font-Names="Arial" Font-Size="11px">
                                        <Columns>
                                            <asp:BoundField DataField="CodPlanIntervencion" HeaderText="Cod. Plan Intev.">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Descripcion" HeaderText="Estado Interv." Visible="False">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CodProyecto" HeaderText="Cod. Proyecto">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NombreProyecto" HeaderText="Nombre Proyecto" Visible="False">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CodNino" HeaderText="Cod. NI&#209;O">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Rut" HeaderText="RUT" Visible="False">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" Width="60px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Apellidos_Nino" HeaderText="Apellidos NI&#209;O">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Nombres" HeaderText="Nombres NI&#209;O">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FechaIngreso" HeaderText="Fecha Ingreso">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NombreTrabajador" HeaderText="T&#233;cnico" Visible="False">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Apellidos_Tecnico" HeaderText="Apellidos T&#233;cnico" Visible="False">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FechaInicioPII" HeaderText="Fecha Inicio PII">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FechaTerminoRealPII" HeaderText="Fecha T&#233;rmino" Visible="False">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CodGradoCumplimiento" HeaderText="Cod. Grado Cump." Visible="False">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CodGrupo" HeaderText="Cod. Grupo">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NombreGrupo" HeaderText="Grupo">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                             <asp:TemplateField HeaderText="" >
                                                <ItemTemplate>
                                                    <a id="ax1" href="#" onclick="AbrirURLFancybox('<%# string.Concat("pi_gestion.aspx?sw=2&grupo=", Eval("CodGrupo"))%>',<%# Eval("CodGrupo")%>);return false;" >Ver Grupo</a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="" >
                                                <ItemTemplate>
                                                    <a id="ax2" href="#" onclick="AbrirURLFancybox('<%# string.Concat("pi_gestion.aspx?sw=1&planinterv=", Eval("CodPlanIntervencion"),"&grupo=", Eval("CodGrupo"))%>',1);return false;" >Ver Ni&#241;o</a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="10px" ForeColor="White" HorizontalAlign="Left" />
                                        <RowStyle BackColor="#EFF3FB" Font-Names="Arial" Font-Size="11px" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <AlternatingRowStyle BackColor="White" Font-Names="Arial" Font-Size="11px" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    </asp:GridView>

                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td align="center">
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
                </ContentTemplate>
        </asp:UpdatePanel>
             <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel6">
            <ProgressTemplate>
                <div class="UpdateProgress">
                    <img alt="Cargando" height="70" src="../images/Cursors/ajax-loader.gif" width="70" />
                    Cargando...       
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        </div>
    </form>
</body>
</html>
