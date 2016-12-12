<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ninos_relacionados.aspx.cs" Inherits="mod_ninos_ninos_relacionados2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="SenameWebTextbox" Namespace="CustomWebControls" TagPrefix="swtb" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Página sin título</title>
    <link href="../css/sename_aplica.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../css/jquery.fancybox-1.3.4.css" type="text/css" media="screen" />
    <script type="text/javascript" src="../Script/jquery.min.js"></script>
    <script type="text/javascript" src="../Script/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="../Script/jquery-1.4.3.min.js"></script>
    <script type="text/javascript" src="../Script/jquery.fancybox-1.3.4.js"></script>

    <script language="javascript" type="text/javascript">
        function TABLE1_onclick() {

        }

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
            <ContentTemplate>
                <div>
                    <table border="0" cellpadding="1" cellspacing="1" width="100%">
                        <tr>
                            <td class="titulo_form" colspan="2">NIÑOS RELACIONADOS</td>
                        </tr>
                        <tr>
                            <td class="texto_form" width="225">Institución
                            </td>
                            <td bgcolor="#ffffff" class="linea_inferior">
                                <asp:DropDownList ID="ddown001" runat="server" AutoPostBack="True" Font-Size="11px"
                                    OnSelectedIndexChanged="ddown001_SelectedIndexChanged" Width="700px">
                                    <asp:ListItem Value="0"> Seleccionar</asp:ListItem>
                                </asp:DropDownList>
                                <a id="A1" runat="server" class="ifancybox" href="../mod_instituciones/bsc_institucion.aspx?param001=Plan de Intervencion&dir=../mod_ninos/ninos_relacionados.aspx">
                                    <asp:ImageButton ID="imb001" runat="server" ImageUrl="~/images/lupa.jpg" OnClick="ImageButton1_Click" /></a></td>
                        </tr>
                        <tr>
                            <td class="texto_form">Proyecto
                            </td>
                            <td bgcolor="#ffffff" class="linea_inferior">
                                <asp:DropDownList ID="ddown002" runat="server" AutoPostBack="True" Font-Size="11px"
                                    OnSelectedIndexChanged="ddown002_SelectedIndexChanged" Width="700px">
                                    <asp:ListItem Selected="True" Value="0">Seleccionar</asp:ListItem>
                                </asp:DropDownList>
                                <a id="A2" runat="server" class="ifancybox" href="../mod_instituciones/bsc_institucion.aspx?param001=Busca Proyectos&dir=../mod_ninos/ninos_relacionados.aspx">
                                    <asp:ImageButton ID="imb002" runat="server" ImageUrl="~/images/lupa.jpg" OnClick="ImageButton2_Click" /></a>&nbsp;
                  <asp:LinkButton
                      ID="lnk002" runat="server" OnClick="lnk002_Click" Visible="False">Ver</asp:LinkButton>

                            </td>

                        </tr>
                        <tr>
                            <td class="texto_form" style="height: 26px">Apellido Paterno</td>
                            <td bgcolor="#ffffff" class="linea_inferior" style="height: 26px">

                                <asp:TextBox ID="txt001" runat="server" Font-Size="11px" Width="150px" />

                                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Font-Size="11px">Filtrar</asp:LinkButton></td>
                        </tr>
                        <tr>
                            <td class="titulo_form" colspan="2" style="height: 20px">
                                <asp:Label ID="lbl001" runat="server" Text="Niños Vigentes en Proyecto "></asp:Label></td>
                        </tr>
                        <tr>
                            <td bgcolor="#ffffff" colspan="2">
                                <asp:GridView ID="grd001" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    CellPadding="2" ForeColor="#333333" GridLines="None" OnPageIndexChanging="grd001_PageIndexChanging"
                                    Visible="False" Width="100%" OnRowCommand="grd001_RowCommand" OnSelectedIndexChanged="grd001_SelectedIndexChanged">
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="CodNino" HeaderText="CODIGO NI&#209;O">
                                            <ItemStyle Font-Size="11px" HorizontalAlign="Left" Width="60px" />
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
                                        <asp:BoundField DataField="FechaNacimiento" DataFormatString="{0:d}" HeaderText="FECHA DE NACIMIENTO"
                                            HtmlEncode="False">
                                            <ItemStyle Font-Size="11px" HorizontalAlign="Left" Width="80px" />
                                        </asp:BoundField>
                                        <asp:ButtonField CommandName="Agregar" Text="Agregar">
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
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#ffffff" colspan="2">
                                <asp:GridView ID="grd002" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    CellPadding="2" ForeColor="#333333" GridLines="None" Visible="False" Width="100%"
                                    OnRowCommand="grd002_RowCommand" OnSelectedIndexChanged="grd002_SelectedIndexChanged">
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="CodNino" HeaderText="CODIGO NI&#209;O">
                                            <ItemStyle Font-Size="11px" HorizontalAlign="Left" Width="60px" />
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
                                        <asp:BoundField DataField="FechaNacimiento" DataFormatString="{0:d}" HeaderText="FECHA DE NACIMIENTO"
                                            HtmlEncode="False">
                                            <ItemStyle Font-Size="11px" HorizontalAlign="Left" Width="80px" />
                                        </asp:BoundField>
                                        <asp:ButtonField CommandName="Ver" Text="Ver ">
                                            <ItemStyle Font-Names="Arial" Font-Size="11px" ForeColor="Red" />
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
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:GridView ID="grd005" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    CellPadding="2" ForeColor="#333333" GridLines="None" Visible="False" Width="100%"
                                    OnRowCommand="grd005_RowCommand">
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="CodNino" HeaderText="CODIGO NI&#209;O">
                                            <ItemStyle Font-Size="11px" HorizontalAlign="Left" Width="60px" />
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
                                        <asp:BoundField DataField="Observacion" HeaderText="OBSERVACION">
                                            <ItemStyle Font-Size="11px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="TipoRelacion" HeaderText="TIPO RELACION">
                                            <ItemStyle Font-Size="11px" HorizontalAlign="Left" Width="80px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Descripcion" HeaderText="DESCRIPCION">
                                            <ItemStyle Font-Size="11px" HorizontalAlign="Left" Width="80px" />
                                        </asp:BoundField>
                                        <asp:ButtonField CommandName="Modificar" Text="Modificar">
                                            <ItemStyle Font-Names="Arial" Font-Size="11px" ForeColor="Red" />
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
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 17px"></td>
                        </tr>
                        <tr>
                            <td bgcolor="#ffffff" colspan="2" style="text-align: center">
                                <asp:Panel ID="pnl001" runat="server" Visible="False" Width="100%">
                                    <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                        <tr>
                                            <td colspan="2" class="titulo_form">Buscar Niño a Relacionar</td>
                                        </tr>
                                        <tr>
                                            <td class="texto_form" width="225">Rut Niño</td>
                                            <td bgcolor="#ffffff" class="linea_inferior" align="left">

                                                <asp:TextBox ID="txt007" runat="server"  Width="150px" />
                                                <%--<ajax:MaskedEditExtender ID="MaskedEditExtender215" runat="server" TargetControlID="txt007" MaskType="None" InputDirection="RightToLeft" ErrorTooltipEnabled="True" Mask="$$$$$$$$$$$$$$$" />--%>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="txt007" runat="server" ErrorMessage="Rut Inv&aacute;lido" Font-Bold="True" ForeColor="Red" ValidationExpression="^(\d{2}\d{3}\d{3})-([a-zA-Z]{1}$|\d{1}$)"></asp:RegularExpressionValidator>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="texto_form">Cod. Niño</td>
                                            <td bgcolor="#ffffff" class="linea_inferior" align="left">

                                                <asp:TextBox ID="txt002" runat="server" Width="150px" />
                                                <%--<ajax:MaskedEditExtender ID="MaskedEditExtender217" runat="server" TargetControlID="txt002" MaskType="None" InputDirection="RightToLeft" ErrorTooltipEnabled="True" Mask="999999999" />--%>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txt002" runat="server" ErrorMessage="C&oacute;digo Inv&aacute;lido" Font-Bold="True" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="texto_form">Apellido Paterno</td>
                                            <td bgcolor="#ffffff" class="linea_inferior" align="left">
                                                <asp:TextBox ID="txt004" runat="server" Font-Size="11px" Width="350px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td class="texto_form">Apellido Materno</td>
                                            <td bgcolor="#ffffff" class="linea_inferior" align="left">
                                                <asp:TextBox ID="txt005" runat="server" Font-Size="11px" Width="350px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td class="texto_form">Nombres</td>
                                            <td bgcolor="#ffffff" class="linea_inferior" align="left">
                                                <asp:TextBox ID="txt006" runat="server" Font-Size="11px" Width="350px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td class="texto_form">Sexo</td>
                                            <td bgcolor="#ffffff" class="linea_inferior">
                                                <asp:RadioButtonList ID="rdolist001" runat="server" RepeatDirection="Horizontal" Font-Size="11px">
                                                    <asp:ListItem Value="F">Femenino</asp:ListItem>
                                                    <asp:ListItem Value="M">Masculino</asp:ListItem>
                                                </asp:RadioButtonList></td>
                                        </tr>

                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnl002" runat="server" Visible="False" Width="100%">
                                    <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                        <tr>
                                            <td bgcolor="#ffffff" style="text-align: center">

                                                <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="WebImageButton1" runat="server" Text="Buscar" OnClick="WebImageButton1_Click" />



                                                <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="WebImageButton3" runat="server" Text="Ir a Búsqueda" OnClick="WebImageButton3_Click" Visible="False" />


                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnl003" runat="server" Visible="False" Width="100%">
                                    <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                        <tr>
                                            <td bgcolor="#ffffff" style="text-align: center">
                                                <asp:Label ID="lbl0013" runat="server" Font-Size="XX-Large" ForeColor="#0253B7" Text="0"
                                                    Visible="False"></asp:Label><br />
                                                <asp:Label ID="lbl0014" runat="server" Font-Size="X-Small" ForeColor="#0253B7" Text="Coincidencias"
                                                    Visible="False"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#ffffff" style="text-align: center">
                                                <asp:LinkButton ID="lbl0015" runat="server" Visible="False" OnClick="lbl0015_Click" Font-Size="11px">Ver Resultados</asp:LinkButton></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl006" runat="server" CssClass="texto_rojo_peque" Visible="False"></asp:Label></td>
                                        </tr>

                                        <tr>
                                            <td bgcolor="#ffffff" style="text-align: center">
                                                <asp:GridView ID="grd003" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                    CellPadding="2" ForeColor="#333333" GridLines="None" OnPageIndexChanging="grd003_PageIndexChanging"
                                                    Visible="False" Width="100%" OnRowCommand="grd003_RowCommand">
                                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                    <Columns>
                                                        <asp:BoundField DataField="CodNino" HeaderText="CODIGO NI&#209;O">
                                                            <ItemStyle Font-Size="11px" HorizontalAlign="Left" Width="60px" />
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
                                                        <asp:BoundField DataField="FechaNacimiento" DataFormatString="{0:d}" HeaderText="FECHA DE NACIMIENTO"
                                                            HtmlEncode="False">
                                                            <ItemStyle Font-Size="11px" HorizontalAlign="Left" Width="80px" />
                                                        </asp:BoundField>
                                                        <asp:ButtonField CommandName="Agregar" Text="Agregar">
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
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnl004" runat="server" Visible="False" Width="100%">
                                    <table border="0" cellpadding="1" cellspacing="1" width="100%" id="TABLE1" onclick="return TABLE1_onclick()">
                                        <tr>
                                            <td class="titulo_form" colspan="2">Niño Relacionado<br />
                                                <asp:Label ID="lbl003" runat="server" CssClass="texto_rojo_peque"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:GridView ID="grd004" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                    CellPadding="2" ForeColor="#333333" GridLines="None" Visible="False" Width="100%">
                                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                    <Columns>
                                                        <asp:BoundField DataField="CodNino" HeaderText="CODIGO NI&#209;O">
                                                            <ItemStyle Font-Size="11px" HorizontalAlign="Left" Width="60px" />
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
                                                        <asp:BoundField DataField="FechaNacimiento" DataFormatString="{0:d}" HeaderText="FECHA DE NACIMIENTO"
                                                            HtmlEncode="False">
                                                            <ItemStyle Font-Size="11px" HorizontalAlign="Left" Width="80px" />
                                                        </asp:BoundField>
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
                                            <td class="texto_form" width="225" style="height: 23px">Tipo Relaci&oacute;n
                                            </td>
                                            <td class="linea_inferior" style="height: 23px">
                                                <asp:DropDownList ID="ddown005" runat="server" Font-Names="Arial" Font-Size="11px"
                                                    Width="350px">
                                                </asp:DropDownList>
                                                <asp:Label ID="lbl004" runat="server" Visible="False"></asp:Label>
                                                <asp:Label ID="lbl007" runat="server" CssClass="texto_rojo_peque" Visible="False"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="texto_form">Descripci&oacute;n</td>
                                            <td class="linea_inferior">
                                                <swtb:SenameTextBox ID="txt008" runat="server" Font-Names="Arial" Font-Size="11px"
                                                    MaxLength="100" TextMode="MultiLine" Width="640px"></swtb:SenameTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: center; height: 27px;">

                                                <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn_actualizar" runat="server" OnClick="btn_actualizar_Click" Text="Actualizar" Visible="False" />



                                                <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn_guardar" runat="server" OnClick="btn_guardar_Click" Text="Guardar" />


                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center">
                                <br />

                                <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn_volver" runat="server" OnClick="btn_volver_Click" Text="Volver" />


                                &nbsp;&nbsp; &nbsp;
                        <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="WebImageButton4" runat="server" OnClick="WebImageButton4_Click" Text="Limpiar" />


                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
