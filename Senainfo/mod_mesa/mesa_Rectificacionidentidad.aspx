<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="mesa_Rectificacionidentidad.aspx.cs" Inherits="mod_mesa_mesa_Rectificacionidentidad" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="../css/sename_aplica.css" rel="stylesheet" type="text/css" />
</head>
<body onload="history.go(+1);">
    <form name="form1" id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <div>
            <asp:Panel ID="Pnl_Descicion" runat="server" Width="100%">
                <table width="100%" border="0" cellspacing="0" cellpadding="4">
                    <tr>
                        <td class="titulo_form">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="225">SELECCIONAR ACCION:</td>
                                    <td>
                                        <asp:Button CssClass="BtnSenaInfo-02 BtnSenaInfo-02-azul" ID="WebImageButton1" runat="server" OnClick="WebImageButton1_Click" Text="Rectificación de Identidad" />



                                        <asp:Button CssClass="BtnSenaInfo-02 BtnSenaInfo-02-azul" ID="WebImageButton2" runat="server" OnClick="WebImageButton2_Click" Text="Unir Cabecera del Niño(a)" />
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="Panel1" runat="server" Width="100%" Visible="False">
                <table width="100%" border="0" cellspacing="0" cellpadding="4">
                    <tr>
                        <td class="texto_form" style="width: 958px">RECTIFICACION DE IDENTIDAD / ACTUALIZACION DEL NIÑO</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="Panel2" runat="server" Width="100%">
                                <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                    <tr>
                                        <td colspan="2" class="titulo_form">Buscar Niño:
                                            <asp:Label ID="lbl002" runat="server" Text="AL QUE SE DESEA RECTIFICAR O TRASPASAR INGRESOS"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="texto_form" width="225">Rut Niño</td>
                                        <td bgcolor="#ffffff" class="linea_inferior">

                                            <asp:TextBox ID="txt007" runat="server" Width="150px" Font-Size="11px" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt007" Font-Bold="true" ForeColor="Red" ErrorMessage="Rut Requerido"></asp:RequiredFieldValidator><br />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="txt007" runat="server" ErrorMessage="Rut Inv&aacute;lido" Font-Bold="True" ForeColor="Red" ValidationExpression="^(\d{2}\d{3}\d{3})-([a-zA-Z]{1}$|\d{1}$)"></asp:RegularExpressionValidator>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="texto_form">Cod. Niño</td>
                                        <td bgcolor="#ffffff" class="linea_inferior">

                                            <asp:TextBox ID="txt002" runat="server" Width="150px" Font-Size="11px" /><cc1:MaskedEditExtender ID="MaskedEditExtender99" runat="server" TargetControlID="txt002" MaskType="None" InputDirection="RightToLeft" ErrorTooltipEnabled="True" Mask="999999999" />

                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="texto_form">Apellido Paterno</td>
                                        <td bgcolor="#ffffff" class="linea_inferior">
                                            <asp:TextBox ID="txt004" runat="server" Font-Size="11px" Width="450px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td class="texto_form">Apellido Materno</td>
                                        <td bgcolor="#ffffff" class="linea_inferior">
                                            <asp:TextBox ID="txt005" runat="server" Font-Size="11px" Width="450px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td class="texto_form">Nombres</td>
                                        <td bgcolor="#ffffff" class="linea_inferior">
                                            <asp:TextBox ID="txt006" runat="server" Font-Size="11px" Width="450px"></asp:TextBox></td>
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
                                <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                    <tr>
                                        <td bgcolor="#ffffff" style="text-align: center; height: 31px;">

                                            <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="WebImageButton3" runat="server" Text="Buscar" OnClick="WebImageButton3_Click" />


                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                    <tr>
                                        <td bgcolor="#ffffff" style="text-align: center">
                                            <asp:Label ID="lbl0014" runat="server" Font-Size="X-Small" ForeColor="#0253B7" Text="Coincidencias"
                                                Visible="False"></asp:Label>&nbsp;<br />
                                            <asp:LinkButton ID="lnk001" runat="server" Font-Size="X-Small" OnClick="lnk001_Click"
                                                Visible="False">CREAR</asp:LinkButton></td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#ffffff">
                                            <asp:GridView ID="grd003" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                CellPadding="2" ForeColor="#333333" GridLines="None" Visible="False" Width="100%"
                                                OnRowCommand="grd003_RowCommand" OnPageIndexChanging="grd003_PageIndexChanging">
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
                                                    <asp:ButtonField CommandName="Ver" Text="Ver">
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
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="pnl001" runat="server" Width="100%" Visible="False">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="titulo_form" style="height: 20px">Niño Origen: (<asp:Label ID="lbl_codNinoOrigen" runat="server"></asp:Label>)
                            <asp:Label ID="lbl001" runat="server"></asp:Label><br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="grd001" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                CellPadding="2" ForeColor="#333333" GridLines="None" Visible="False" Width="100%"
                                OnRowCommand="grd003_RowCommand" OnPageIndexChanging="grd001_PageIndexChanging">
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chk001" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ICodIE" HeaderText="ICODIE">
                                        <ItemStyle Font-Size="11px" HorizontalAlign="Left" Width="60px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="f_ingreso" HeaderText="FECHA INGRESO" DataFormatString="{0:d}"
                                        HtmlEncode="False">
                                        <ItemStyle Font-Size="11px" HorizontalAlign="Right" Width="75px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="f_egreso" HeaderText="FECHA EGRESO" DataFormatString="{0:d}"
                                        HtmlEncode="False">
                                        <ItemStyle Font-Size="11px" HorizontalAlign="Center" Width="30px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="codproy" HeaderText="COD. PROYECTO">
                                        <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="nombre_p" HeaderText="NOMBRE PROYECTO">
                                        <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="codinst" HeaderText="COD. INSTITUCION">
                                        <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="nombre_i" HeaderText="INSTITUCION">
                                        <ItemStyle Font-Size="11px" HorizontalAlign="Left" Width="80px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="modelo" HeaderText="MOD. INTERVENCION">
                                        <ItemStyle Font-Size="11px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="cq_egresa" HeaderText="CON QUIEN EGRESO">
                                        <ItemStyle Font-Size="11px" />
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
                        <td></td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="pnl002" runat="server" Width="100%" Visible="False">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td height="25" class="titulo_form">Niño Destino:&nbsp; (<asp:Label ID="lblCodNinoDestino" runat="server"></asp:Label>)
                            <asp:Label ID="lbl003" runat="server"></asp:Label><br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="grd002" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                CellPadding="2" ForeColor="#333333" GridLines="None" Visible="False" Width="100%"
                                OnRowCommand="grd003_RowCommand" OnPageIndexChanging="grd002_PageIndexChanging">
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="ICodIE" HeaderText="ICODIE">
                                        <ItemStyle Font-Size="11px" HorizontalAlign="Left" Width="60px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="f_ingreso" HeaderText="FECHA INGRESO" DataFormatString="{0:d}"
                                        HtmlEncode="False">
                                        <ItemStyle Font-Size="11px" HorizontalAlign="Right" Width="75px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="f_egreso" HeaderText="FECHA EGRESO" DataFormatString="{0:d}"
                                        HtmlEncode="False">
                                        <ItemStyle Font-Size="11px" HorizontalAlign="Center" Width="30px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="codproy" HeaderText="COD. PROYECTO">
                                        <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="nombre_p" HeaderText="NOMBRE PROYECTO">
                                        <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="codinst" HeaderText="COD. INSTITUCION">
                                        <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="nombre_i" HeaderText="INSTITUCION">
                                        <ItemStyle Font-Size="11px" HorizontalAlign="Left" Width="80px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="modelo" HeaderText="MOD. INTERVENCION">
                                        <ItemStyle Font-Size="11px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="cq_egresa" HeaderText="CON QUIEN EGRESO">
                                        <ItemStyle Font-Size="11px" />
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
                </table>
            </asp:Panel>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>


                    <asp:Panel ID="pnl005" runat="server" Width="100%" Visible="False">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td height="25" class="titulo_form">Identidad<asp:Label ID="lbl_CodNinoActual" runat="server" Visible="False"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td>
                                                <table width="100%" border="0" cellspacing="1" cellpadding="1">
                                                    <tr>
                                                        <td width="225" class="texto_form" style="width: 225px">Rut</td>
                                                        <td>
                                                            <table width="100%" border="0" cellspacing="1" cellpadding="1">
                                                                <tr>
                                                                    <td>

                                                                        <asp:TextBox ID="txt_rut" runat="server" Width="150px" Font-Names="Arial" Font-Size="11px" AutoPostBack="True" ONVALUECHANGE="txt_rut_ValueChange" /><cc1:MaskedEditExtender ID="MaskedEditExtender102" runat="server" TargetControlID="txt_rut" MaskType="None" InputDirection="RightToLeft" ErrorTooltipEnabled="True" Mask="$$$$$$$$$$$" />

                                                                        <asp:Panel ID="pnl003" runat="server" BorderColor="Red" BorderStyle="Inset" BorderWidth="1px"
                                                                            Height="1px" HorizontalAlign="Center" Visible="False" Width="250px">
                                                                            <asp:Label ID="lbl004" runat="server" Font-Size="11px"></asp:Label>&nbsp;
                                                                        </asp:Panel>
                                                                    </td>
                                                                    <td>
                                                                        <asp:CheckBox ID="chk001" runat="server" Text="Sin Run" AutoPostBack="True" OnCheckedChanged="chk001_CheckedChanged" Font-Size="11px" /></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="texto_form">Nombres</td>
                                                        <td>
                                                            <asp:TextBox ID="txt_Nombre" runat="server" Font-Names="Arial" Font-Size="11px" Width="650px" MaxLength="100"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="texto_form" style="height: 24px">Apellido Paterno
                                                        </td>
                                                        <td style="height: 24px">
                                                            <asp:TextBox ID="txt_apPaterno" runat="server" Font-Names="Arial" Font-Size="11px"
                                                                Width="650px" MaxLength="50"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="texto_form">Apellido Materno
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txt_apMaterno" runat="server" Font-Names="Arial" Font-Size="11px"
                                                                Width="650px" MaxLength="50"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="texto_form">Sexo</td>
                                                        <td>
                                                            <asp:DropDownList ID="ddown_sexo" runat="server" Font-Names="Arial" Font-Size="11px"
                                                                Width="150px">
                                                                <asp:ListItem Value="-1">Seleccionar</asp:ListItem>
                                                                <asp:ListItem Value="M">Masculino</asp:ListItem>
                                                                <asp:ListItem Value="F">Femenino</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="texto_form">Fecha Nacimiento
                                                        </td>
                                                        <td>

                                                            <asp:TextBox ID="cal_Nacim" runat="server" Width="150px" ONVALUECHANGED="cal_Nacim_ValueChanged" Font-Size="11px" />
                                                            <cc1:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende328" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal_Nacim" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Enabled="true" ControlToValidate="cal_Nacim" runat="server" ErrorMessage="Fecha Inválida" Font-Bold="True" ForeColor="Red" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" />


                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="texto_form">Edad Actual
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txt_edadActual" runat="server" Font-Names="Arial" Font-Size="11px"
                                                                Width="50px" ReadOnly="True"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="texto_form">Nacionalidad</td>
                                                        <td>
                                                            <asp:DropDownList ID="ddown_nacionalidad" runat="server" Width="400px" Font-Size="11px">
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="texto_form">Identidad Confirmada del ni&ntilde;o
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="chk_ident" runat="server" Font-Names="Arial" Font-Size="11px" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="texto_form" style="height: 24px">Etnia</td>
                                                        <td style="height: 24px">
                                                            <asp:DropDownList ID="ddown_etnia" runat="server" Width="400px" Font-Size="11px">
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="texto_form">Oficina Inscripci&oacute;n
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txt_Oficina" runat="server" Font-Names="Arial" Font-Size="11px"
                                                                Width="650px" MaxLength="50"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="texto_form">A&ntilde;o Inscripci&oacute;n
                                                        </td>
                                                        <td>

                                                            <asp:TextBox ID="txt_Ano" runat="server" AutoPostBack="True" ONVALUECHANGE="txt_Ano_ValueChange" Width="50px" Font-Size="11px" /><cc1:MaskedEditExtender ID="MaskedEditExtender105" runat="server" TargetControlID="txt_Ano" MaskType="None" InputDirection="RightToLeft" ErrorTooltipEnabled="True" Mask="9999" />

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="texto_form">N&ordm; Inscripci&oacute;n Civil
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txt_NInscrip" runat="server" Font-Names="Arial" Font-Size="11px"
                                                                Width="300px" MaxLength="20"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="texto_form">Alergias Conocidas
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="TextBox1" runat="server" Font-Names="Arial" Font-Size="11px" MaxLength="100"
                                                                TextMode="MultiLine" Width="640px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="texto_form">Inscrito Registro Nac. de Discapacidad
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddown_Registro" runat="server" Font-Size="11px" Width="90px">
                                                                <asp:ListItem Value="-1">Seleccionar</asp:ListItem>
                                                                <asp:ListItem Value="1">SI</asp:ListItem>
                                                                <asp:ListItem Value="0">NO</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="texto_form">Inscrito en Fonasa
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddown_Fonasa" runat="server" Font-Size="11px" Width="90px">
                                                                <asp:ListItem Value="-1">Seleccionar</asp:ListItem>
                                                                <asp:ListItem Value="1">SI</asp:ListItem>
                                                                <asp:ListItem Value="0">NO</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <caption>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</caption>
                        </table>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td align="center">
                        <br />

                        <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn_actualizar" runat="server" Text="Actualizar" Visible="False" OnClick="btn_actualizar_Click" />


                        &nbsp;&nbsp;
                        <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn_guardar" runat="server" Text="Procesar" OnClick="btn_guardar_Click" Visible="False" />


                        &nbsp;
                        
                        <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn_limpiar" runat="server" Text="Limpiar" OnClick="btn_limpiar_Click" Visible="False" CausesValidation="False" />


                        &nbsp;
                        
                        <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn_volver" runat="server" OnClick="btn_volver_Click" Text="Volver" Visible="False" CausesValidation="False" />



                        <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn_volver2" runat="server" OnClick="btn_volver2_Click" Text="Volver" />


                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
