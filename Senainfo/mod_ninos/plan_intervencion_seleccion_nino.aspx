<%@ Page Language="C#" AutoEventWireup="true" CodeFile="plan_intervencion_seleccion_nino.aspx.cs" Inherits="mod_ninos_Nuevo_Plan_de_Intervención_plan_intervencion_seleccion_nino" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="SenameWebTextbox" Namespace="CustomWebControls" TagPrefix="swtb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../css/sename_aplica.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../css/jquery.fancybox-1.3.4.css" type="text/css" media="screen" />
    <script type="text/javascript" src="../Script/jquery.min.js"></script>
    <script type="text/javascript" src="../Script/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="../Script/jquery-1.4.3.min.js"></script>
    <script type="text/javascript" src="../Script/jquery.fancybox-1.3.4.js"></script>

    <script language="javascript" type="text/javascript">
        function pageLoad() {
            $(".ifancybox").fancybox({
                'width': '75%',
                'height': '75%',
                'autoScale': false,
                'transitionIn': 'none',
                'transitionOut': 'none',
                'type': 'iframe'
            });
        };

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
            </Triggers>
            <ContentTemplate>
                <div>
                    <table border="0" cellpadding="1" cellspacing="1" width="100%">
                        <tbody>
                            <tr>
                                <td class="titulo_form" colspan="2"></td>
                            </tr>
                            <tr>
                                <td class="texto_form" width="225">Institución
                                </td>
                                <td bgcolor="#ffffff" style="width: 674px">
                                    <asp:DropDownList ID="ddown001" runat="server" AutoPostBack="True" Font-Size="11px" Width="600px" OnSelectedIndexChanged="ddown001_SelectedIndexChanged">
                                        <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                    </asp:DropDownList>
                                    <a id="A1" runat="server" class="ifancybox" href="../mod_instituciones/bsc_institucion.aspx?param001=Plan de Intervencion&dir=../mod_ninos/plan_intervencion.aspx">
                                        <asp:ImageButton ID="imb001" runat="server" ImageUrl="~/images/lupa.jpg" OnClick="imb001_Click" /></a></td>
                            </tr>
                            <tr>
                                <td class="texto_form">Proyecto
                                </td>
                                <td bgcolor="#ffffff" style="width: 674px">
                                    <asp:DropDownList ID="ddown002" runat="server" AutoPostBack="True" Font-Size="11px" Width="600px">
                                        <asp:ListItem Value="0"> Seleccionar</asp:ListItem>
                                    </asp:DropDownList>
                                    <a id="A2" runat="server" class="ifancybox" href="../mod_instituciones/bsc_institucion.aspx?param001=Busca Proyectos&dir=../mod_ninos/plan_intervencion.aspx">
                                        <asp:ImageButton ID="imb002" runat="server" ImageUrl="~/images/lupa.jpg" OnClick="imb002_Click" /></a>
                                    <asp:LinkButton ID="lnk002" runat="server" Visible="False">Ver</asp:LinkButton></td>
                            </tr>
                            <tr>
                                <td class="texto_form">Apellido Paterno</td>
                                <td bgcolor="#ffffff" style="width: 667px">

                                    <asp:TextBox ID="txt001" runat="server" Enabled="False" Font-Size="11px" Width="150px" />


                                    <asp:LinkButton ID="LinkButton1" runat="server" Font-Size="11px">Filtrar</asp:LinkButton></td>
                            </tr>
                            <tr>
                                <td class="titulo_form" colspan="2"></td>
                            </tr>
                            <tr>
                                <td class="titulo_form" colspan="2">
                                    <asp:Label ID="lbl001" runat="server" Text="Niños Seleccionados Plan Intervención"
                                        Visible="False"></asp:Label>
                                    <br />
                                    <asp:Label ID="lbl003" runat="server" CssClass="texto_rojo_peque"></asp:Label></td>
                            </tr>
                            <tr>
                                <td bgcolor="#ffffff" colspan="2" style="height: 77px">
                                    <asp:GridView ID="grd002" runat="server" AutoGenerateColumns="False" CellPadding="2"
                                        ForeColor="#333333" GridLines="None" Visible="False"
                                        Width="100%">
                                        <Columns>
                                            <asp:BoundField DataField="CodPlanIntervencion" HeaderText="COD. PLAN INTERVENCION"
                                                Visible="False">
                                                <ItemStyle Font-Size="11px" />
                                                <HeaderStyle Width="25px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CodNino" HeaderText="CODIGO NI&#209;O">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" Width="60px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ICodIE" HeaderText="ICodIE">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Rut" HeaderText="RUT">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Right" Width="75px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Sexo" HeaderText="SEXO">
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
                                            <asp:BoundField DataField="FechaIngreso" DataFormatString="{0:d}" HeaderText="FECHA DE INGRESO"
                                                HtmlEncode="False">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" Width="80px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FechaNacimiento" DataFormatString="{0:d}" HeaderText="FECHA DE NACIMIENTO"
                                                HtmlEncode="False">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" Width="80px" />
                                            </asp:BoundField>
                                            <asp:ButtonField CommandName="Quitar" Text="Quitar">
                                                <ItemStyle Font-Size="11px" ForeColor="Red" HorizontalAlign="Center" />
                                            </asp:ButtonField>
                                        </Columns>
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="10px"
                                            ForeColor="White" HorizontalAlign="Left" />
                                        <RowStyle BackColor="#EFF3FB" Font-Names="Arial" Font-Size="11px" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <AlternatingRowStyle BackColor="White" Font-Names="Arial" Font-Size="11px" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td class="titulo_form" colspan="2">
                                    <table align="right" border="0" cellpadding="1" cellspacing="1" width="100%">
                                        <tr>
                                            <td class="titulo_form">Niños Vigentes en Proyecto</td>
                                            <td style="text-align: right">

                                                <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="WebImageButton8" runat="server" Text="Ver Estados PII" Visible="False" />


                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#ffffff" colspan="2">
                                    <asp:GridView ID="grd001" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        CellPadding="2" ForeColor="#333333" GridLines="None" Visible="False" Width="100%">
                                        <Columns>
                                            <asp:BoundField DataField="CodNino" HeaderText="CODIGO NI&#209;O">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" Width="60px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="pii" HeaderText="PII" Visible="False">
                                                <ItemStyle Font-Size="11px" ForeColor="Red" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ICodIE" HeaderText="ICodIE">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Rut" HeaderText="RUT">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Right" Width="75px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Sexo" HeaderText="SEXO">
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
                                            <asp:BoundField DataField="FechaIngreso" DataFormatString="{0:d}" HeaderText="FECHA DE INGRESO"
                                                HtmlEncode="False">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" Width="80px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FechaNacimiento" DataFormatString="{0:d}" HeaderText="FECHA DE NACIMIENTO"
                                                HtmlEncode="False">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" Width="80px" />
                                            </asp:BoundField>
                                            <asp:ButtonField CommandName="Agregar" Text="Agregar">
                                                <ItemStyle Font-Size="11px" ForeColor="Red" />
                                            </asp:ButtonField>
                                        </Columns>
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="10px"
                                            ForeColor="White" HorizontalAlign="Left" />
                                        <RowStyle BackColor="#EFF3FB" Font-Names="Arial" Font-Size="11px" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <AlternatingRowStyle BackColor="White" Font-Names="Arial" Font-Size="11px" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">

                                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="WebImageButton1" runat="server" Text="Siguiente >>" Visible="False" />


                                </td>
                            </tr>
                        </tbody>
                    </table>

                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                <div class="UpdateProgress">
                    <img alt="Cargando" height="70" src="../images/Cursors/ajax-loader.gif" width="70" />
                    Cargando...       
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </form>
</body>
</html>
